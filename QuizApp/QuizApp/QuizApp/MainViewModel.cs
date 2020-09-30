using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuizApp
{
    class MainViewModel : INotifyPropertyChanged
    {
        private List<Tuple<string, bool>> Questions { get; }

        private const int NOQUESTION = -1;

        private const int DISPLAYRESULTTIME = 1500;

        private int CurrentQuestionIndex { get; set; } = NOQUESTION;

        public bool AllowInteraction => CurrentQuestionIndex != NOQUESTION && QuestionDisplay == QuestionDisplayType.Unanswered;

        public String CurrentQuestion => CurrentQuestionIndex != NOQUESTION ? Questions[CurrentQuestionIndex].Item1 : "";

        private QuestionDisplayType _questionDisplay;
        public QuestionDisplayType QuestionDisplay 
        { 
            get => _questionDisplay; 
            private set
            {
                _questionDisplay = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(AllowInteraction));
            }
        }

        public ICommand AnswerTrueCommand { get; }

        public ICommand AnswerFalseCommand { get; }

        public ICommand SkipCommand { get; }

        public ICommand OpenStatisticsCommand { get; }

        #region Statistics Properties

        private int _totalQuestionsSeen;
        public int TotalQuestionsSeen
        {
            get => _totalQuestionsSeen;
            private set
            {
                _totalQuestionsSeen = value;
                NotifyPropertyChanged();
            }
        }

        private int _questionsSkipped;
        public int QuestionsSkipped
        {
            get => _questionsSkipped;
            private set
            {
                _questionsSkipped = value;
                NotifyPropertyChanged();
            }
        }

        private int _correctAnswers;
        public int CorrectAnswers
        {
            get => _correctAnswers;
            private set
            {
                _correctAnswers = value;
                NotifyPropertyChanged();
            }
        }

        private int _incorrectAnswers;
        public int IncorrectAnswers
        {
            get => _incorrectAnswers;
            private set
            {
                _incorrectAnswers = value;
                NotifyPropertyChanged();
            }
        }

        #endregion Statistics Properties

        private Action OpenStatisticsAction { get; }

        public MainViewModel(Action openStatisticsAction)
        {
            OpenStatisticsAction = openStatisticsAction ?? throw new ArgumentNullException(nameof(openStatisticsAction));
            Questions = new List<Tuple<string, bool>>();
            AnswerTrueCommand = new Command(async () => await Answer(true));
            AnswerFalseCommand = new Command(async () => await Answer(false));
            SkipCommand = new Command(Skip);
            OpenStatisticsCommand = new Command(OpenStatisticsAction);
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            // TODO read from file
            Questions.Add(new Tuple<string, bool>("1 + 1 = 10", true));
            Questions.Add(new Tuple<string, bool>("Is 42 the answer to everything?", true));
            Questions.Add(new Tuple<string, bool>("this statement is false", false));
            if (Questions.Count > 0)
            {
                CurrentQuestionIndex = 0;
            }

            QuestionChanged();
        }

        private async Task Answer(bool answer)
        {
            if (!AllowInteraction)
            {
                return;
            }

            var expected = Questions[CurrentQuestionIndex].Item2;

            if (answer == expected)
            {
                CorrectAnswers++;
                QuestionDisplay = QuestionDisplayType.Correct;
            } 
            else
            {
                IncorrectAnswers++;
                QuestionDisplay = QuestionDisplayType.Incorrect;
            }

            await Task.Delay(DISPLAYRESULTTIME);

            QuestionDisplay = QuestionDisplayType.Unanswered;
            NextQuestion();    
        }

        private void Skip()
        {
            if (!AllowInteraction)
            {
                return;
            }

            QuestionsSkipped++;
            NextQuestion();
        }

        private void NextQuestion()
        {
            if (!AllowInteraction)
            {
                return;
            }

            TotalQuestionsSeen++;
            CurrentQuestionIndex++;
            if (CurrentQuestionIndex >= Questions.Count)
            {
                // TODO later maybe end the game here or show statistics
                CurrentQuestionIndex = 0;
            }

            QuestionChanged();
        }

        private void QuestionChanged()
        {
            NotifyPropertyChanged(nameof(CurrentQuestionIndex));
            NotifyPropertyChanged(nameof(CurrentQuestion));
            NotifyPropertyChanged(nameof(AllowInteraction));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
