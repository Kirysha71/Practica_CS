namespace Task2_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var director = new GraphDirector();

            var lineBuilder = new LineGraphBuilder();
            director.BuildSalesGraph(lineBuilder);
            Graph lineGraph = lineBuilder.GetResult();
            lineGraph.Display();

            Console.WriteLine();

            var barBuilder = new BarGraphBuilder();
            barBuilder.CreateNewGraph();
            barBuilder.SetTitle("Распределение бюджета");
            barBuilder.AddDataPoint("Маркетинг", 30);
            barBuilder.AddDataPoint("Разработка", 50);
            barBuilder.AddDataPoint("Поддержка", 20);
            barBuilder.SetGraphType();
            Graph barGraph = barBuilder.GetResult();
            barGraph.Display();

            var pieBuilder = new PieChartBuilder();
            pieBuilder.CreateNewGraph();
            pieBuilder.SetTitle("Доли рынка");
            pieBuilder.AddDataPoint("Компания A", 40);
            pieBuilder.AddDataPoint("Компания B", 35);
            pieBuilder.AddDataPoint("Компания C", 25);
            pieBuilder.SetGraphType();
            Graph pieGraph = pieBuilder.GetResult();
        }
    }
}
