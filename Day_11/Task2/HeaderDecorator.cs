namespace Task2
{
    class HeaderDecorator : DocumentDecorator
    {
        public HeaderDecorator(IDocument document) : base(document) { }
        public override string GetFormattedText() => _document.GetFormattedText();
    }
}
