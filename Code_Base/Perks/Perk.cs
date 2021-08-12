using System.Runtime.CompilerServices;

namespace Long_War_Assistant.Code_Base
{
    public class Perk
    {
        private readonly string _sanitizedName;

        public string PerkName { get; set; }
        public string PerkDescription { get; set; }
        
        // TODO - refactor this to an image that can be displayed with the perk.  Multi sized images?
        public string PerkImage 
        {
            get
            {
                string pathString = "pack://application:,,,/Code_Base/Perks/Icons/";

                return pathString + _sanitizedName + ".png";
            }
        }
        public SoldierStats AdditionalStats { get; set; }

        public Perk() { }

        public Perk(string name, string description)
        {
            PerkName = name;
            PerkDescription = description;

            //Remove spaces and any special characters for the name of the image icon in the Perk/Icons folder
            _sanitizedName = name.Replace(" ","").Replace("'","").Replace("-","").Replace("&","");
        }

        public Perk(string name, string description, SoldierStats additionalStats) : this(name, description)
        {
            AdditionalStats = additionalStats;
        }
    }
}