namespace Long_War_Assistant.Code_Base.Soldiers.Classes
{
    public enum SoldierClass
    {
        Scout,
        Sniper,
        Infantry,
        Assault,
        Gunner,
        Rocketeer,
        Medic,
        Engineer,
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
    public static class SoldierClassExtension
    {

        /// <summary>
        /// When a soldier is MEC'd, they become an equivalent MEC class based off their organic class
        /// </summary>
        /// <param name="soldierClass">Current class</param>
        /// <returns>New MEC class</returns>
        public static SoldierClass GetMECClass(this SoldierClass soldierClass)
        {
            return soldierClass switch
            {
                SoldierClass.Scout => SoldierClass.Pathfinder,
                SoldierClass.Sniper => SoldierClass.Jaegar,
                SoldierClass.Infantry => SoldierClass.Valkyrie,
                SoldierClass.Assault => SoldierClass.Marauder,
                SoldierClass.Gunner => SoldierClass.Goliath,
                SoldierClass.Rocketeer => SoldierClass.Archer,
                SoldierClass.Medic => SoldierClass.Guardian,
                SoldierClass.Engineer => SoldierClass.Shogun,
                _ => soldierClass, // Return itself if it is a MEC role
            };
        }

        /// <summary>
        /// Upon leveling up, a soldier gains varied stats based on a combination of class and rank
        /// This method is a one stop shop for getting the appropriate stat increase based off both.
        /// </summary>
        /// <param name="soldierClass">The soldier's current class</param>
        /// <param name="newRank">The rank the soldier is promoting to</param>
        /// <returns></returns>
        public static SoldierStats GetPromotionStats(this SoldierClass soldierClass, EnlistedRanks newRank)
        {
            return newRank switch
            {
                EnlistedRanks.SPEC => PromoteToSpecialist(soldierClass),
                EnlistedRanks.LCPL => PromoteToLanceCorporal(soldierClass),
                EnlistedRanks.CPL => PromoteToCorporal(soldierClass),
                EnlistedRanks.SGT => PromoteToSergeant(soldierClass),
                EnlistedRanks.TSGT => PromoteToTechSergeant(soldierClass),
                EnlistedRanks.GSGT => PromoteToGunnerySergeant(soldierClass),
                EnlistedRanks.MSGT => PromoteToMasterSergeant(soldierClass),
                _ => null,
            };
        }

        public static string GetIconName(this SoldierClass soldierClass)
        {
            //MECs have a single icon
            if (soldierClass.IsMECClass())
            {
                return "MEC";
            }

            //All other class's icon's are named the same as the enum value
            return soldierClass.ToString();
        }

        /// <summary>
        /// Determines if the current soldier's class is a MEC class or not
        /// </summary>
        public static bool IsMECClass(this SoldierClass soldierClass)
        {
            switch (soldierClass)
            {
                case SoldierClass.Jaegar:
                case SoldierClass.Pathfinder:
                case SoldierClass.Valkyrie:
                case SoldierClass.Marauder:
                case SoldierClass.Goliath:
                case SoldierClass.Archer:
                case SoldierClass.Guardian:
                case SoldierClass.Shogun:
                    return true;
                default:
                    return false;
            }
        }

        #region Promotion Helper Methods
        /// <summary>
        /// Generates the stats upon leveling up a soldier from PFC to SPEC
        /// </summary>
        private static SoldierStats PromoteToSpecialist(this SoldierClass soldierClass)
        {
            int _hpIncrease = GetHPBase(soldierClass, "SPEC");
            int _willIncrease = GetWillBase(soldierClass, "SPEC");
            int _aimIncrease;

            switch (soldierClass)
            {
                case SoldierClass.Scout:
                case SoldierClass.Sniper:
                    _aimIncrease = 4;
                    break;

                case SoldierClass.Infantry:
                    _aimIncrease = 3;
                    break;

                case SoldierClass.Assault:
                case SoldierClass.Gunner:
                case SoldierClass.Rocketeer:
                case SoldierClass.Engineer:
                    _hpIncrease = 1;
                    _aimIncrease = 3;
                    break;

                case SoldierClass.Medic:
                    _hpIncrease = 1;
                    _aimIncrease = 3;
                    _willIncrease = 6;
                    break;

                case SoldierClass.Marauder:
                case SoldierClass.Goliath:
                case SoldierClass.Archer:
                    _aimIncrease = 2;
                    break;

                case SoldierClass.Pathfinder:
                case SoldierClass.Valkyrie:
                case SoldierClass.Guardian:
                case SoldierClass.Shogun:
                    _aimIncrease = 3;
                    break;

                case SoldierClass.Jaegar:
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
        /// Gets a good default will value that makes combining switch statements easier
        /// </summary>
        /// <returns>Will default to use</returns>
        private static int GetWillBase(SoldierClass soldierClass, string rank)
        {
            // All MECs gain at least 2 will per level
            if (soldierClass.IsMECClass())
            {
                return 2;
            }

            // Organic classes start out with higher will and eventually get lower will per level
            return rank switch
            {
                "SPEC" or "LCPL" => 5,
                "CPL" or "SGT" or "TSGT" or "GSGT" or "MSGT" => 3,
                _ => -99,
            };
        }

        /// <summary>
        /// Gets a good default HP value that makes combining switch statements easier
        /// </summary>
        /// <returns>HP default to use</returns>
        private static int GetHPBase(SoldierClass soldierClass, string rank)
        {
            return rank switch
            {
                "SPEC" or "SGT" or "TSGT" => soldierClass.IsMECClass() ? 1 : 0,
                "LCPL" or "GSGT" => 0,
                "CPL" or "MSGT" => 1,
                _ => -99,
            };
        }

        /// <summary>
        /// Generates the stats upon leveling up a soldier from SPEC to LCPL
        /// </summary>
        public static SoldierStats PromoteToLanceCorporal(this SoldierClass soldierClass)
        {
            int _willIncrease = GetWillBase(soldierClass, "LCPL");
            int _hpIncrease = GetHPBase(soldierClass, "LCPL");
            int _aimIncrease;

            switch (soldierClass)
            {
                case SoldierClass.Scout:
                case SoldierClass.Infantry:
                case SoldierClass.Rocketeer:
                    _aimIncrease = 3;
                    break;
                case SoldierClass.Sniper:
                    _aimIncrease = 4;
                    break;
                case SoldierClass.Assault:
                case SoldierClass.Gunner:
                case SoldierClass.Engineer:
                    _aimIncrease = 2;
                    break;
                case SoldierClass.Medic:
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
        private static SoldierStats PromoteToCorporal(this SoldierClass soldierClass)
        {
            int _willIncrease = GetWillBase(soldierClass, "CPL");
            int _hpIncrease = GetHPBase(soldierClass, "CPL");
            int _aimIncrease;

            switch (soldierClass)
            {
                case SoldierClass.Scout:
                case SoldierClass.Sniper:
                    _aimIncrease = 4;
                    break;
                case SoldierClass.Infantry:
                case SoldierClass.Rocketeer:
                    _hpIncrease = 0;
                    _aimIncrease = 3;
                    break;
                case SoldierClass.Assault:
                case SoldierClass.Gunner:
                case SoldierClass.Engineer:
                    _aimIncrease = 3;
                    break;
                case SoldierClass.Medic:
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
        private static SoldierStats PromoteToSergeant(this SoldierClass soldierClass)
        {
            int _hpIncrease = GetHPBase(soldierClass, "SGT");
            int _willIncrease = GetWillBase(soldierClass, "SGT");
            int _aimIncrease;

            switch (soldierClass)
            {
                case SoldierClass.Scout:
                    _aimIncrease = 3;
                    break;
                case SoldierClass.Sniper:
                    _aimIncrease = 4;
                    _willIncrease = 2;
                    break;
                case SoldierClass.Assault:
                case SoldierClass.Gunner:
                case SoldierClass.Engineer:
                    _aimIncrease = 2;
                    break;
                case SoldierClass.Infantry:
                case SoldierClass.Rocketeer:
                    _hpIncrease = 1;
                    _aimIncrease = 3;
                    break;
                case SoldierClass.Medic:
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
        private static SoldierStats PromoteToTechSergeant(this SoldierClass soldierClass)
        {
            int _hpIncrease = 0;
            int _willIncrease = 3;
            int _aimIncrease;

            switch (soldierClass)
            {
                case SoldierClass.Scout:
                    _aimIncrease = 4;
                    break;
                case SoldierClass.Sniper:
                    _aimIncrease = 4;
                    _willIncrease = 2;
                    break;
                case SoldierClass.Infantry:
                case SoldierClass.Rocketeer:
                case SoldierClass.Medic:
                    _aimIncrease = 3;
                    break;
                case SoldierClass.Assault:
                case SoldierClass.Gunner:
                case SoldierClass.Engineer:
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
        private static SoldierStats PromoteToGunnerySergeant(this SoldierClass soldierClass)
        {
            int _hpIncrease = 0;
            int _willIncrease = 3;
            int _aimIncrease;

            switch (soldierClass)
            {
                case SoldierClass.Scout:
                case SoldierClass.Infantry:
                case SoldierClass.Rocketeer:
                    _aimIncrease = 3;
                    break;
                case SoldierClass.Sniper:
                    _aimIncrease = 4;
                    _willIncrease = 2;
                    break;
                case SoldierClass.Assault:
                case SoldierClass.Gunner:
                case SoldierClass.Medic:
                case SoldierClass.Engineer:
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
        private static SoldierStats PromoteToMasterSergeant(this SoldierClass soldierClass)
        {
            //All promotions to MSgt come with a health increase
            int _hpIncrease = 1;

            int _willIncrease = 3;
            int _aimIncrease;

            switch (soldierClass)
            {
                case SoldierClass.Scout:
                case SoldierClass.Sniper:
                    _aimIncrease = 4;
                    _willIncrease = 2;
                    break;
                case SoldierClass.Infantry:
                case SoldierClass.Assault:
                case SoldierClass.Gunner:
                case SoldierClass.Rocketeer:
                case SoldierClass.Medic:
                case SoldierClass.Engineer:
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
