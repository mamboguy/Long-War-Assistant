using Long_War_Assistant.Code_Base.Soldier;
using Long_War_Assistant.Code_Base.Soldiers.Classes;

namespace Long_War_Assistant.Code_Base.Soldiers.Specialization
{
    public class Unspecialized_Specialization : Specialization
    {

        public Unspecialized_Specialization() : base() { }

        public override bool CanMakeMEC(XComSoldier soldier)
        {
            // Requirements for becoming a MEC are:
            //      - At least Lance Corporal rank
            //      - Not an Officer or Psionic soldier (Unspecialized means they aren't)

            return soldier.SoldierRank.IsAtLeastRank(EnlistedRanks.LCPL);
        }

        public override bool CanMakeOfficer(XComSoldier soldier)
        {
            // Requirements for becoming an Officer are:
            //      - At least Corporal rank
            //      - Not a MEC or Psionic soldier (Unspecialized means they aren't)
            //      - Been on at least 5 missions (will not implement)

            return soldier.SoldierRank.IsAtLeastRank(EnlistedRanks.CPL);
        }

        public override bool CanMakePsi(XComSoldier soldier)
        {
            // Requirements for becoming an Officer are:
            //      - Not a MEC or Officer soldier (Unspecialized means they aren't)
            //      - Doesn't have Neural Damping gene mod


            // TODO - Implement the check for neural damping gene mod

            return base.CanMakePsi(soldier);
        }

        public override bool DoesSpecializationRankOverrideNormalRank()
        {
            return false;
        }

        public override string GetSpecializationRank()
        {
            return "";
        }

        public override void PromoteSpecialization()
        {
            // Do nothing
        }
    }
}
