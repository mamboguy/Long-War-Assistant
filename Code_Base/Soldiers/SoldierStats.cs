namespace Long_War_Assistant.Code_Base
{
    public class SoldierStats
    {
        private int _mobility;
        private int _hp;
        private int _will;
        private int _defense;
        private int _aim;
        private double _dr;

        public SoldierStats() 
        {
            // Default to strict screening stats.  These can be adjusted later by the user for rookies
            _aim = 65;
            _hp = 4;
            _mobility = 13;
            _defense = 0;
            _will = 30;
            _dr = 0;
        }

        public SoldierStats(int mobility, int hp, int will, int defense, int aim)
        {
            _mobility = mobility;
            _hp = hp;
            _will = will;
            _defense = defense;
            _aim = aim;
            _dr = 0;
        }

        public void AddAdditionalStats(SoldierStats additionalStats)
        {
            _mobility += additionalStats._mobility;
            _hp += additionalStats._hp;
            _will += additionalStats._will;
            _defense += additionalStats._defense;
            _aim += additionalStats._aim;
            _dr += additionalStats._dr;
        }

        public int Aim { get { return _aim; } }
        public int Will { get { return _will; } }
        public int Mobility { get { return _mobility; } }
        public int HP { get { return _hp; } }
        public int Defense { get { return _defense; } }
        public double DamageReduction { get { return _dr; } }
    }
}
