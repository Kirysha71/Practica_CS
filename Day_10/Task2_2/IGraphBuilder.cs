using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_2
{
    public interface IGraphBuilder
    {
        void CreateNewGraph();
        void SetTitle(string title);
        void AddDataPoint(string label, double value);
        void SetGraphType();
        Graph GetResult();
    }
}
