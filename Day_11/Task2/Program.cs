namespace Task2
{

    class Program
    {
        static void Main()
        {
            IDocument doc = new PlainDocument();

            doc = new HeaderDecorator(doc);
            doc = new FooterDecorator(doc);
            doc = new PageNumberDecorator(doc);

            Console.WriteLine(doc.GetFormattedText());
        }
    }
}
