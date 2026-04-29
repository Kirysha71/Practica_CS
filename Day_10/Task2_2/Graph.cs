using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_2
{
    public class Graph
    {
        public string Title { get; set; }
        public List<string> Labels { get; set; }
        public List<double> Values { get; set; }
        public string Type { get; set; }

        public Graph()
        {
            Labels = new List<string>();
            Values = new List<double>();
        }

        public void Display()
        {
            Console.WriteLine($"График: {Title} (Тип: {Type})");
            for (int i = 0; i < Labels.Count; i++)
            {
                Console.WriteLine($"  {Labels[i]}: {Values[i]}");
            }
        }
    }
}
