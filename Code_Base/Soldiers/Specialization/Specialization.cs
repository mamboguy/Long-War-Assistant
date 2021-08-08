using Long_War_Assistant.Code_Base.Soldier;

namespace Long_War_Assistant.Code_Base.Soldiers.Specialization
{
    public abstract class Specialization
    {
        public Specialization() { }

        #region Specialization checks
        // Only an unspecialized solder can be specialized, so designed by default that a solder will not be able to specialize
        public virtual bool CanMakeMEC(XComSoldier soldier)
        {
            return false;
        }

        public virtual bool CanMakeOfficer(XComSoldier soldier)
        {
            return false;
        }

        public virtual bool CanMakePsi(XComSoldier soldier)
        {
            return false;
        }
        #endregion

        public abstract string GetSpecializationRank();

        public abstract void PromoteSpecialization();

        public abstract bool DoesSpecializationRankOverrideNormalRank();
    }
}