using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterArkadiusz4F.Models
{
    internal class AllCounters
    {
        public ObservableCollection<Counter> Counters { get; set; } = new ObservableCollection<Counter>();

        public AllCounters()
        {
            //Counters.Add(new Counter { Id = 1, Name = "Counter 1", Value = 0 });
            //Counters.Add(new Counter { Id = 2, Name = "Counter 2", Value = 5 });
            //Counters.Add(new Counter { Id = 3, Name = "Counter 3", Value = 10 });
            LoadFromFile();
        }
            private void LoadFromFile()
            {
            
                var filepath = "../../../../../counters.csv";
                string[] readText = File.ReadAllLines(filepath);
                for (int i = 0; i < readText.Length; i++)
                {
                    string line = readText[i];
                    string[] values = line.Split(',');

                    var newCounter = new Counter()
                    {
                        Id = int.Parse(values[0]),
                        Name = values[1],
                        Value = int.Parse(values[2])
                    };
                    Counters.Add(newCounter);
                }
            }

    }
}
