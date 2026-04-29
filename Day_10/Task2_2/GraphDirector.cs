using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_2
{
    public class GraphDirector
    {
        public void BuildSalesGraph(IGraphBuilder builder)
        {
            builder.CreateNewGraph();
            builder.SetTitle("Продажи по месяцам");
            builder.AddDataPoint("Январь", 100);
            builder.AddDataPoint("Февраль", 150);
            builder.AddDataPoint("Март", 200);
            builder.SetGraphType();
        }
    }
}
