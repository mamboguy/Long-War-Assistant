namespace Long_War_Assistant.Code_Base
{
    public class SoldierStats
    {
        private int _mobility;
        private int _hp;
        private int _will;
        private int _defense;
        private int _aim;

        public SoldierStats() { }

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
    }
}
