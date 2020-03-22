namespace GlossoryTrainer
{
    public class Lexicon
    {
        public LexiconEntry[] LexiconEntries { get; set; }
    }

    public class LexiconEntry
    {
        public string[] Language1 { get; set; }

        public string[] Language2 { get; set; }
    }
}