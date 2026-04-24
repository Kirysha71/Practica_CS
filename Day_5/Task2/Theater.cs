using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Task2
{
    public class Theater
    {
        private readonly Actor[] _actors;
        private readonly Stage _stage;
        private readonly Audience _audience;

        public string Name { get; }

        public Theater(string name, Actor[] actors, int stageCapacity, Audience audience)
        {
            Name = name;
            _actors = actors;
            _stage = new Stage(stageCapacity);
            _audience = audience;
        }

        public void PerformPlay()
        {
            WriteLine($"Театр: {Name}");
            WriteLine($"Сцена: {_stage.Capacity} мест");
            WriteLine($"Зрителей: {_audience.Count}");
            Write("Актёры: ");

            foreach (var actor in _actors)
            {
                Write($"{actor.Name} ");
            }

            WriteLine("\n");
        }
    }
}
