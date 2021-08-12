using Long_War_Assistant.Code_Base.Soldier;
using System;

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

        /// <summary>
        /// This method returns the modifier to get the appropriate class icon if the soldier is a Psi
        /// Only the psi class will return something here, so default to no return value
        /// </summary>
        public virtual string GetPsiString()
        {
            return "";
        }
    }
}