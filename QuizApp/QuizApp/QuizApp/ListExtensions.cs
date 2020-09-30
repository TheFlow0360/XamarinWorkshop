using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizApp
{
    public static class ListExtensions
    {
        public static void Shuffle<T>(this List<T> list)
        {
            var r = new Random();
            var tempList = new List<Tuple<T, int>>();
            foreach (var x in list)
            {
                tempList.Add(new Tuple<T, int>(x, r.Next()));
            }

            tempList.Sort((x, y) => x.Item2.CompareTo(y.Item2));
            list.Clear();
            list.AddRange(tempList.Select(x => x.Item1));
        }
    }
}
