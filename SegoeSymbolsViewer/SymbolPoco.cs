namespace SegoeSymbolsViewer
{
    public struct SymbolPoco
    {
        public SymbolPoco(int i)
        {
            this.Symbol = char.ConvertFromUtf32(i);
            this.XamlText = "&#x" + i.ToString("X") + ";";
            this.HexText = "\\u" + i.ToString("X");
        }

        public string Symbol { get; set; } 
        public string XamlText { get; set; } 
        public string HexText { get; set; } 
    }
}