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

    public static class MECClassesExtension
    {
        public static SoldierStats GetPromotionStats(this MEC_Classes mecClass, EnlistedRanks newRank)
        {
            return newRank switch
            {
                EnlistedRanks.Specialist => PromoteToSpecialist(mecClass),
                EnlistedRanks.LanceCorporal => PromoteToLanceCorporal(mecClass),
                EnlistedRanks.Corporal => PromoteToCorporal(mecClass),
                EnlistedRanks.Sergeant => PromoteToSergeant(mecClass),
                EnlistedRanks.TechSergeant => PromoteToTechSergeant(mecClass),
                EnlistedRanks.GunnerySergeant => PromoteToGunnerySergeant(mecClass),
                EnlistedRanks.MasterSergeant => PromoteToMasterSergeant(mecClass),
                _ => null,
            };
        }

        #region MEC Promotion Helpers
        /// <summary>
        /// Generates the stats upon leveling up a MEC from PFC to SPEC
        /// </summary>
        private static SoldierStats PromoteToSpecialist(this MEC_Classes mecClass)
        {
            int _hpIncrease = 1;
            int _willIncrease = 2;
            int _aimIncrease;

            switch (mecClass)
            {
                case MEC_Classes.Marauder:
                case MEC_Classes.Goliath:
                case MEC_Classes.Archer:
                    _aimIncrease = 2;
                    break;
                case MEC_Classes.Pathfinder:
                case MEC_Classes.Valkyrie:
                case MEC_Classes.Guardian:
                case MEC_Classes.Shogun:
                    _aimIncrease = 3;
                    break;
                case MEC_Classes.Jaegar:
                    _aimIncrease = 4;
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
        /// Generates the stats upon leveling up a MEC from SEPC to LCPL
        /// </summary>
        private static SoldierStats PromoteToLanceCorporal(this MEC_Classes mecClass)
        {
            int _hpIncrease = 0;
            int _willIncrease = 2;
            int _aimIncrease;

            switch (mecClass)
            {
                case MEC_Classes.Jaegar:
                    _aimIncrease = 4;
                    break;
                case MEC_Classes.Pathfinder:
                case MEC_Classes.Valkyrie:
                case MEC_Classes.Guardian:
                    _aimIncrease = 3;
                    break;
                case MEC_Classes.Marauder:
                case MEC_Classes.Archer:
                case MEC_Classes.Shogun:
                    _aimIncrease = 2;
                    break;
                case MEC_Classes.Goliath:
                    _hpIncrease = 1;
                    _aimIncrease = 1;
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
        /// Generates the stats upon leveling up a MEC from LCPL to CPL
        /// </summary>
        private static SoldierStats PromoteToCorporal(this MEC_Classes mecClass)
        {
            int _hpIncrease = 1;
            int _willIncrease = 2;
            int _aimIncrease;

            switch (mecClass)
            {
                case MEC_Classes.Jaegar:
                    _hpIncrease = 0;
                    _aimIncrease = 4;
                    break;
                case MEC_Classes.Pathfinder:
                case MEC_Classes.Valkyrie:
                case MEC_Classes.Guardian:
                    _aimIncrease = 3;
                    break;
                case MEC_Classes.Marauder:
                case MEC_Classes.Goliath:
                case MEC_Classes.Shogun:
                    _aimIncrease = 2;
                    break;
                case MEC_Classes.Archer:
                    _aimIncrease = 2;
                    _hpIncrease = 0;
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
        /// Generates the stats upon leveling up a MEC from CPL to SGT
        /// </summary>
        private static SoldierStats PromoteToSergeant(this MEC_Classes mecClass)
        {
            int _hpIncrease = 1;
            int _willIncrease = 2;
            int _aimIncrease;

            switch (mecClass)
            {
                case MEC_Classes.Jaegar:
                    _aimIncrease = 4;
                    break;
                case MEC_Classes.Pathfinder:
                case MEC_Classes.Valkyrie:
                case MEC_Classes.Guardian:
                    _hpIncrease = 0;
                    _aimIncrease = 3;
                    break;
                case MEC_Classes.Marauder:
                case MEC_Classes.Archer:
                case MEC_Classes.Shogun:
                    _aimIncrease = 2;
                    break;
                case MEC_Classes.Goliath:
                    _aimIncrease = 1;
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
        /// Generates the stats upon leveling up a MEC from SGT to TSGT
        /// </summary>
        private static SoldierStats PromoteToTechSergeant(this MEC_Classes mecClass)
        {
            int _hpIncrease = 1;
            int _willIncrease = 2;
            int _aimIncrease;

            switch (mecClass)
            {
                case MEC_Classes.Jaegar:
                    _hpIncrease = 0;
                    _aimIncrease = 4;
                    break;
                case MEC_Classes.Pathfinder:
                case MEC_Classes.Valkyrie:
                case MEC_Classes.Guardian:
                    _aimIncrease = 3;
                    break;
                case MEC_Classes.Marauder:
                case MEC_Classes.Goliath:
                case MEC_Classes.Shogun:
                    _aimIncrease = 2;
                    break;
                case MEC_Classes.Archer:
                    _aimIncrease = 2;
                    _hpIncrease = 0;
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
        /// Generates the stats upon leveling up a MEC from TSGT to GSGT
        /// </summary>
        private static SoldierStats PromoteToGunnerySergeant(this MEC_Classes mecClass)
        {
            int _hpIncrease = 0;
            int _willIncrease = 2;
            int _aimIncrease;

            switch (mecClass)
            {
                case MEC_Classes.Jaegar:
                    _aimIncrease = 4;
                    break;
                case MEC_Classes.Pathfinder:
                case MEC_Classes.Valkyrie:
                case MEC_Classes.Guardian:
                    _aimIncrease = 3;
                    break;
                case MEC_Classes.Marauder:
                case MEC_Classes.Archer:
                case MEC_Classes.Shogun:
                    _aimIncrease = 2;
                    break;
                case MEC_Classes.Goliath:
                    _hpIncrease = 1;
                    _aimIncrease = 1;
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
        /// Generates the stats upon leveling up a MEC from GSGT to MSGT
        /// </summary>
        private static SoldierStats PromoteToMasterSergeant(this MEC_Classes mecClass)
        {
            int _hpIncrease = 1;
            int _willIncrease = 2;

            int _aimIncrease;

            switch (mecClass)
            {
                case MEC_Classes.Jaegar:
                    _aimIncrease = 4;
                    break;
                case MEC_Classes.Pathfinder:
                case MEC_Classes.Valkyrie:
                case MEC_Classes.Guardian:
                case MEC_Classes.Shogun:
                    _aimIncrease = 3;
                    break;
                case MEC_Classes.Marauder:
                case MEC_Classes.Goliath:
                case MEC_Classes.Archer:
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
        #endregion
    }
}