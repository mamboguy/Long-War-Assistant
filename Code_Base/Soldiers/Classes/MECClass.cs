using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Long_War_Assistant.Code_Base.Soldiers.Classes
{
    class MECClass : ISoldierClass
    {

        private MEC_Classes _mecClass;

        public MECClass(OrganicClass originalClass)
        {
            _mecClass = originalClass.GetSoldierClass().GetMECClass();
        }

        public SoldierStats GetPromotionStats(EnlistedRanks newRank)
        {
            throw new NotImplementedException();
        }
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
