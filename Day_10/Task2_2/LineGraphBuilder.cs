using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_2
{
    public class LineGraphBuilder : IGraphBuilder
    {
        private Graph _graph;

        public void CreateNewGraph()
        {
            _graph = new Graph();
        }

        public void SetTitle(string title)
        {
            _graph.Title = title;
        }

        public void AddDataPoint(string label, double value)
        {
            _graph.Labels.Add(label);
            _graph.Values.Add(value);
        }

        public void SetGraphType()
        {
            _graph.Type = "Линейный";
        }

        public Graph GetResult()
        {
            return _graph;
        }
    }
}

