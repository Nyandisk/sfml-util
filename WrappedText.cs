public class WrappedText : Text
{
    public string Base { get; set; }
    public int Limit { get; set; }
    public WrappedText(string baseText, Font font, int limit, uint cSize) : base(baseText, font) {
        Base = baseText;
        Limit = limit;
        CharacterSize = cSize;
        Recalculate();
    }
    public void Recalculate()
    {
        DisplayedString = string.Empty;
        uint cPos = 0;
        foreach (char c in Base)
        {
            DisplayedString += c;
            if ((FindCharacterPos(cPos) - Position).X > Limit)
            {
                int lastSpace = DisplayedString.LastIndexOf(' ');
                DisplayedString = lastSpace >= 0 ? string.Concat(DisplayedString.AsSpan(0, lastSpace), "\n", DisplayedString.AsSpan(lastSpace + 1)) : DisplayedString + '\n';
            }
            cPos++;
        }
    }
}
