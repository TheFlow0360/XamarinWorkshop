using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp
{
    [Table("Statistics")]
    class StatisticsData
    {
        [PrimaryKey, NotNull]
        public string Name { get; set; }

        public int Value { get; set; }

        public StatisticsData()
        {
            // for SQLite
        }

        public StatisticsData(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
