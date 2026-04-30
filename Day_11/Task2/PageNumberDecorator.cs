namespace Task2
{
    class PageNumberDecorator : DocumentDecorator
    {
        public PageNumberDecorator(IDocument document) : base(document) { }
        public override string GetFormattedText() => _document.GetFormattedText();
    }
}
