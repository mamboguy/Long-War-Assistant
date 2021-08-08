using Long_War_Assistant.Code_Base.Soldier;
using System;

namespace Long_War_Assistant.Code_Base.Soldiers.Classes
{
    public class OrganicClass : ISoldierClass
    {

        private Organic_Classes _soldierClass;

        public OrganicClass() { }

        public void SetOrganicClass(Organic_Classes newClass)
        {
            _soldierClass = newClass;
        }

        public Organic_Classes GetSoldierClass()
        {
            return _soldierClass;
        }

        public SoldierStats GetPromotionStats(EnlistedRanks newRank)
        {
            return _soldierClass.GetPromotionStats(newRank);
        }
    }


    public enum Organic_Classes
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

    /// <summary>
    /// Extension methods for the Soldier class enum
    /// </summary>
    public static class OrganicClassesExtension
    {

        /// <summary>
        /// When a soldier is MEC'd, they become an equivalent MEC class based off their organic class
        /// </summary>
        /// <param name="soldierClass">Current class</param>
        /// <returns>New MEC class</returns>
        public static MEC_Classes GetMECClass(this Organic_Classes soldierClass)
        {
            return soldierClass switch
            {
                Organic_Classes.Scout => MEC_Classes.Pathfinder,
                Organic_Classes.Sniper => MEC_Classes.Jaegar,
                Organic_Classes.Infantry => MEC_Classes.Valkyrie,
                Organic_Classes.Assault => MEC_Classes.Marauder,
                Organic_Classes.Gunner => MEC_Classes.Goliath,
                Organic_Classes.Rocketeer => MEC_Classes.Archer,
                Organic_Classes.Medic => MEC_Classes.Guardian,
                Organic_Classes.Engineer => MEC_Classes.Shogun,
                _ => throw new System.UnauthorizedAccessException(),
            };
        }

        /// <summary>
        /// Upon leveling up, a soldier gains varied stats based on a combination of class and rank
        /// This method is a one stop shop for getting the appropriate stat increase based off both.
        /// </summary>
        /// <param name="soldierClass">The soldier's current class</param>
        /// <param name="newRank">The rank the soldier is promoting to</param>
        /// <returns></returns>
        public static SoldierStats GetPromotionStats(this Organic_Classes soldierClass, EnlistedRanks newRank)
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
        private static SoldierStats PromoteToSpecialist(this Organic_Classes soldierClass)
        {
            int _willIncrease = 5;
            int _hpIncrease = 0;
            int _aimIncrease;

            switch (soldierClass)
            {
                case Organic_Classes.Scout:
                case Organic_Classes.Sniper:
                    _aimIncrease = 4;
                    break;

                case Organic_Classes.Infantry:
                    _aimIncrease = 3;
                    break;

                case Organic_Classes.Assault:
                case Organic_Classes.Gunner:
                case Organic_Classes.Rocketeer:
                case Organic_Classes.Engineer:
                    _hpIncrease = 1;
                    _aimIncrease = 3;
                    break;

                case Organic_Classes.Medic:
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
        public static SoldierStats PromoteToLanceCorporal(this Organic_Classes soldierClass)
        {
            int _willIncrease = 5;
            int _hpIncrease = 0;
            int _aimIncrease;

            switch (soldierClass)
            {
                case Organic_Classes.Scout:
                case Organic_Classes.Infantry:
                case Organic_Classes.Rocketeer:
                    _aimIncrease = 3;
                    break;
                case Organic_Classes.Sniper:
                    _aimIncrease = 4;
                    break;
                case Organic_Classes.Assault:
                case Organic_Classes.Gunner:
                case Organic_Classes.Engineer:
                    _aimIncrease = 2;
                    break;
                case Organic_Classes.Medic:
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
        private static SoldierStats PromoteToCorporal(this Organic_Classes soldierClass)
        {
            int _willIncrease = 3;
            int _hpIncrease = 1;
            int _aimIncrease;

            switch (soldierClass)
            {
                case Organic_Classes.Scout:
                case Organic_Classes.Sniper:
                    _aimIncrease = 4;
                    break;
                case Organic_Classes.Infantry:
                case Organic_Classes.Rocketeer:
                    _hpIncrease = 0;
                    _aimIncrease = 3;
                    break;
                case Organic_Classes.Assault:
                case Organic_Classes.Gunner:
                case Organic_Classes.Engineer:
                    _aimIncrease = 3;
                    break;
                case Organic_Classes.Medic:
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
        private static SoldierStats PromoteToSergeant(this Organic_Classes soldierClass)
        {
            int _hpIncrease = 0;
            int _willIncrease = 3;
            int _aimIncrease;

            switch (soldierClass)
            {
                case Organic_Classes.Scout:
                    _aimIncrease = 3;
                    break;
                case Organic_Classes.Sniper:
                    _aimIncrease = 4;
                    _willIncrease = 2;
                    break;
                case Organic_Classes.Assault:
                case Organic_Classes.Gunner:
                case Organic_Classes.Engineer:
                    _aimIncrease = 2;
                    break;
                case Organic_Classes.Infantry:
                case Organic_Classes.Rocketeer:
                    _hpIncrease = 1;
                    _aimIncrease = 3;
                    break;
                case Organic_Classes.Medic:
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
        private static SoldierStats PromoteToTechSergeant(this Organic_Classes soldierClass)
        {
            int _hpIncrease = 0;
            int _willIncrease = 3;
            int _aimIncrease;

            switch (soldierClass)
            {
                case Organic_Classes.Scout:
                    _aimIncrease = 4;
                    break;
                case Organic_Classes.Sniper:
                    _aimIncrease = 4;
                    _willIncrease = 2;
                    break;
                case Organic_Classes.Infantry:
                case Organic_Classes.Rocketeer:
                case Organic_Classes.Medic:
                    _aimIncrease = 3;
                    break;
                case Organic_Classes.Assault:
                case Organic_Classes.Gunner:
                case Organic_Classes.Engineer:
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
        private static SoldierStats PromoteToGunnerySergeant(this Organic_Classes soldierClass)
        {
            int _hpIncrease = 0;
            int _willIncrease = 3;
            int _aimIncrease;

            switch (soldierClass)
            {
                case Organic_Classes.Scout:
                case Organic_Classes.Infantry:
                case Organic_Classes.Rocketeer:
                    _aimIncrease = 3;
                    break;
                case Organic_Classes.Sniper:
                    _aimIncrease = 4;
                    _willIncrease = 2;
                    break;
                case Organic_Classes.Assault:
                case Organic_Classes.Gunner:
                case Organic_Classes.Medic:
                case Organic_Classes.Engineer:
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
        private static SoldierStats PromoteToMasterSergeant(this Organic_Classes soldierClass)
        {
            //All promotions to MSgt come with a health increase
            int _hpIncrease = 1;

            int _willIncrease = 3;
            int _aimIncrease;

            switch (soldierClass)
            {
                case Organic_Classes.Scout:
                case Organic_Classes.Sniper:
                    _aimIncrease = 4;
                    _willIncrease = 2;
                    break;
                case Organic_Classes.Infantry:
                case Organic_Classes.Assault:
                case Organic_Classes.Gunner:
                case Organic_Classes.Rocketeer:
                case Organic_Classes.Medic:
                case Organic_Classes.Engineer:
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
