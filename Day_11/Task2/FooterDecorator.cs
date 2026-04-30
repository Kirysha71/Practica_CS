namespace Task2
{
    class FooterDecorator : DocumentDecorator
    {
        public FooterDecorator(IDocument document) : base(document) { }
        public override string GetFormattedText() => _document.GetFormattedText();
    }
}
