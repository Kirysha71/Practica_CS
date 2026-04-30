namespace Task2
{
    abstract class DocumentDecorator : IDocument
    {
        protected IDocument _document;
        public DocumentDecorator(IDocument document) => _document = document;
        public virtual string GetFormattedText() => _document.GetFormattedText();
    }
}
