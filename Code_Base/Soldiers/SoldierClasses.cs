using Long_War_Assistant.Code_Base.Soldiers;

namespace Long_War_Assistant.Code_Base.Soldier
{
    public enum Soldier_Classes
    {
        Scout,
        Sniper,
        Infantry,
        Assault,
        Gunner,
        Rocketeer,
        Medic,
        Engineer
    }

    public enum MEC_Classes
    {
        Jaegar,
        Pathfinder,
        Valkyrie,
        Marauder,
        Goliath,
        Archer,
        Guardian,
        Shogun
    }

    /// <summary>
    /// Extension methods for the Soldier class enum
    /// </summary>
    public static class SoldierClassesExtension
    {
        /// <summary>
        /// Upon leveling up, a soldier gains varied stats based on a combination of class and rank
        /// This method is a one stop shop for getting the appropriate stat increase based off both.
        /// </summary>
        /// <param name="soldierClass">The soldier's current class</param>
        /// <param name="newRank">The rank the soldier is promoting to</param>
        /// <returns></returns>
        public static SoldierStats GetPromotionStats(this Soldier_Classes soldierClass,  EnlistedRanks newRank)
        {
            return newRank switch
            {
                EnlistedRanks.Specialist => PromoteToSpecialist(soldierClass),
                EnlistedRanks.LanceCorporal => PromoteToLanceCorporal(soldierClass),
                EnlistedRanks.Corporal => PromoteToCorporal(soldierClass),
                EnlistedRanks.Sergeant => PromoteToSergeant(soldierClass),
                EnlistedRanks.TechSergeant => PromoteToTechSergeant(soldierClass),
                EnlistedRanks.GunnerySergeant => PromoteToGunnerySergeant(soldierClass),
                EnlistedRanks.MasterSergeant => PromoteToMasterSergeant(soldierClass),
                _ => null,
            };
        }

        #region Promotion Helper Methods
        /// <summary>
        /// Generates the stats upon leveling up a soldier from PFC to SPEC
        /// </summary>
        private static SoldierStats PromoteToSpecialist(this Soldier_Classes soldierClass)
        {
            int _willIncrease = 5;
            int _hpIncrease = 0;
            int _aimIncrease;

            switch (soldierClass)
            {
                case Soldier_Classes.Scout:
                case Soldier_Classes.Sniper:
                    _aimIncrease = 4;
                    break;

                case Soldier_Classes.Infantry:
                    _aimIncrease = 3;
                    break;

                case Soldier_Classes.Assault:
                case Soldier_Classes.Gunner:
                case Soldier_Classes.Rocketeer:
                case Soldier_Classes.Engineer:
                    _hpIncrease = 1;
                    _aimIncrease = 3;
                    break;

                case Soldier_Classes.Medic:
                    _hpIncrease = 1;
                    _aimIncrease = 3;
                    _willIncrease = 6;
                    break;

                default:
                    _hpIncrease = -99;
                    _willIncrease = -99;
                    _aimIncrease = -99;
                    break;
            }

            return new SoldierStats(0, _hpIncrease, _willIncrease, 0, _aimIncrease);
        }

        /// <summary>
        /// Generates the stats upon leveling up a soldier from SPEC to LCPL
        /// </summary>
        public static SoldierStats PromoteToLanceCorporal(this Soldier_Classes soldierClass)
        {
            int _willIncrease = 5;
            int _hpIncrease = 0;
            int _aimIncrease;

            switch (soldierClass)
            {
                case Soldier_Classes.Scout:
                case Soldier_Classes.Infantry:
                case Soldier_Classes.Rocketeer:
                    _aimIncrease = 3;
                    break;
                case Soldier_Classes.Sniper:
                    _aimIncrease = 4;
                    break;
                case Soldier_Classes.Assault:
                case Soldier_Classes.Gunner:
                case Soldier_Classes.Engineer:
                    _aimIncrease = 2;
                    break;
                case Soldier_Classes.Medic:
                    _aimIncrease = 2;
                    _willIncrease = 6;
                    break;
                default:
                    _hpIncrease = -99;
                    _willIncrease = -99;
                    _aimIncrease = -99;
                    break;
            }

            return new SoldierStats(0, _hpIncrease, _willIncrease, 0, _aimIncrease);
        }

        /// <summary>
        /// Generates the stats upon leveling up a soldier from LCP to CPL
        /// </summary>
        private static SoldierStats PromoteToCorporal(this Soldier_Classes soldierClass)
        {
            int _willIncrease = 3;
            int _hpIncrease = 1;
            int _aimIncrease;

            switch (soldierClass)
            {
                case Soldier_Classes.Scout:
                case Soldier_Classes.Sniper:
                    _aimIncrease = 4;
                    break;
                case Soldier_Classes.Infantry:
                case Soldier_Classes.Rocketeer:
                    _hpIncrease = 0;
                    _aimIncrease = 3;
                    break;
                case Soldier_Classes.Assault:
                case Soldier_Classes.Gunner:
                case Soldier_Classes.Engineer:
                    _aimIncrease = 3;
                    break;
                case Soldier_Classes.Medic:
                    _aimIncrease = 3;
                    _hpIncrease = 0;
                    _willIncrease = 4;
                    break;
                default:
                    _hpIncrease = -99;
                    _willIncrease = -99;
                    _aimIncrease = -99;
                    break;
            }

            return new SoldierStats(0, _hpIncrease, _willIncrease, 0, _aimIncrease);
        }

        /// <summary>
        /// Generates the stats upon leveling up a soldier from CPL to SGT
        /// </summary>
        private static SoldierStats PromoteToSergeant(this Soldier_Classes soldierClass)
        {
            int _hpIncrease = 0;
            int _willIncrease = 3;
            int _aimIncrease;

            switch (soldierClass)
            {
                case Soldier_Classes.Scout:
                    _aimIncrease = 3;
                    break;
                case Soldier_Classes.Sniper:
                    _aimIncrease = 4;
                    _willIncrease = 2;
                    break;
                case Soldier_Classes.Assault:
                case Soldier_Classes.Gunner:
                case Soldier_Classes.Engineer:
                    _aimIncrease = 2;
                    break;
                case Soldier_Classes.Infantry:
                case Soldier_Classes.Rocketeer:
                    _hpIncrease = 1;
                    _aimIncrease = 3;
                    break;
                case Soldier_Classes.Medic:
                    _hpIncrease = 1;
                    _aimIncrease = 2;
                    break;
                default:
                    _hpIncrease = -99;
                    _willIncrease = -99;
                    _aimIncrease = -99;
                    break;
            }

            return new SoldierStats(0, _hpIncrease, _willIncrease, 0, _aimIncrease);
        }

        /// <summary>
        /// Generates the stats upon leveling up a soldier from SGT to TSGT
        /// </summary>
        private static SoldierStats PromoteToTechSergeant(this Soldier_Classes soldierClass)
        {
            int _hpIncrease = 0;
            int _willIncrease = 3;
            int _aimIncrease;

            switch (soldierClass)
            {
                case Soldier_Classes.Scout:
                    _aimIncrease = 4;
                    break;
                case Soldier_Classes.Sniper:
                    _aimIncrease = 4;
                    _willIncrease = 2;
                    break;
                case Soldier_Classes.Infantry:
                case Soldier_Classes.Rocketeer:
                case Soldier_Classes.Medic:
                    _aimIncrease = 3;
                    break;
                case Soldier_Classes.Assault:
                case Soldier_Classes.Gunner:
                case Soldier_Classes.Engineer:
                    _hpIncrease = 1;
                    _aimIncrease = 3;
                    break;
                default:
                    _hpIncrease = -99;
                    _willIncrease = -99;
                    _aimIncrease = -99;
                    break;
            }

            return new SoldierStats(0, _hpIncrease, _willIncrease, 0, _aimIncrease);
        }

        /// <summary>
        /// Generates the stats upon leveling up a soldier from TSGT to GSGT
        /// </summary>
        private static SoldierStats PromoteToGunnerySergeant(this Soldier_Classes soldierClass)
        {
            int _hpIncrease = 0;
            int _willIncrease = 3;
            int _aimIncrease;

            switch (soldierClass)
            {
                case Soldier_Classes.Scout:
                case Soldier_Classes.Infantry:
                case Soldier_Classes.Rocketeer:
                    _aimIncrease = 3;
                    break;
                case Soldier_Classes.Sniper:
                    _aimIncrease = 4;
                    _willIncrease = 2;
                    break;
                case Soldier_Classes.Assault:
                case Soldier_Classes.Gunner:
                case Soldier_Classes.Medic:
                case Soldier_Classes.Engineer:
                    _aimIncrease = 2;
                    break;
                default:
                    _hpIncrease = -99;
                    _willIncrease = -99;
                    _aimIncrease = -99;
                    break;
            }

            return new SoldierStats(0, _hpIncrease, _willIncrease, 0, _aimIncrease);
        }

        /// <summary>
        /// Generates the stats upon leveling up a soldier from GSGT to MSGT
        /// </summary>
        private static SoldierStats PromoteToMasterSergeant(this Soldier_Classes soldierClass)
        {
            //All promotions to MSgt come with a health increase
            int _hpIncrease = 1;

            int _willIncrease = 3;
            int _aimIncrease;

            switch (soldierClass)
            {
                case Soldier_Classes.Scout:
                case Soldier_Classes.Sniper:
                    _aimIncrease = 4;
                    _willIncrease = 2;
                    break;
                case Soldier_Classes.Infantry:
                case Soldier_Classes.Assault:
                case Soldier_Classes.Gunner:
                case Soldier_Classes.Rocketeer:
                case Soldier_Classes.Medic:
                case Soldier_Classes.Engineer:
                    _aimIncrease = 3;
                    break;
                default:
                    _hpIncrease = -99;
                    _willIncrease = -99;
                    _aimIncrease = -99;
                    break;
            }

            return new SoldierStats(0, _hpIncrease, _willIncrease, 0, _aimIncrease);
        }
        #endregion
    }
}