namespace Long_War_Assistant.Code_Base
{
    public class SoldierStats
    {
        private int _mobility;
        private int _hp;
        private int _will;
        private int _defense;
        private int _aim;

        public SoldierStats() 
        {
            // Default to strict screening stats.  These can be adjusted later by the user for rookies
            _aim = 65;
            _hp = 4;
            _mobility = 13;
            _defense = 0;
            _will = 30;
        }

        public SoldierStats(int mobility, int hp, int will, int defense, int aim)
        {
            _mobility = mobility;
            _hp = hp;
            _will = will;
            _defense = defense;
            _aim = aim;
        }

        public void AddAdditionalStats(SoldierStats additionalStats)
        {
            _mobility += additionalStats._mobility;
            _hp += additionalStats._hp;
            _will += additionalStats._will;
            _defense += additionalStats._defense;
            _aim += additionalStats._aim;
        }

        public int Aim { get { return _aim; } }
    }
}
