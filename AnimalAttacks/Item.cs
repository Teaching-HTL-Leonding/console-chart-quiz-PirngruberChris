namespace AnimalAttacks
{
    class Item
    {
        private string _group;
        private int _attacks;
        private int _percent;

        public Item(string group, int attacks, int percent)
        {
            Group = group;
            Attacks = attacks;
            Percent = percent;
        }

        public string Group { get; set; }

        public int Attacks { get; set; }

        public int Percent { get; set; }
    }
}