namespace GenesysRoller
{
    public class LookupTable
    {
        public string[] Boost { get; } = {"","","X","XA","AA","A"};

        public string[] Setback { get; } = { "", "", "F", "F", "T", "T" };

        public string[] Ability { get; } = { "", "X", "X", "XX", "A", "A", "XA", "AA" };

        public string[] Difficulty { get; } = { "", "F", "FF", "T", "T", "T", "TT", "FT" };

        public string[] Proficiency { get; } = { "", "X", "X", "XX", "XX", "A", "XA", "XA", "XA", "AA", "AA", "TP" };

        public string[] Challenge { get; } = { "", "F", "F", "FF", "FF", "T", "T", "FT", "FT", "TT", "TT", "DR" };
    }
}