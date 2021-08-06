namespace Long_War_Assistant.Code_Base
{
    public class Perk
    {
        public string PerkName { get; set; }
        public string PerkDescription { get; set; }
        public string PerkImage { get; set; }
        public SoldierStats AdditionalStats { get; set; }

        public Perk() { }

        public Perk(string name, string description, string image)
        {
            PerkName = name;
            PerkDescription = description;
            PerkImage = image;
        }

        public Perk(string name, string description, string image, SoldierStats additionalStats) : this(name, description, image)
        {
            AdditionalStats = additionalStats;
        }

        // TODO - make sure to sanitize inputs from name for the icon name
    }
}
