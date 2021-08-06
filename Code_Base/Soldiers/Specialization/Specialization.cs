using Long_War_Assistant.Code_Base.Soldier;

namespace Long_War_Assistant.Code_Base.Soldiers.Specialization
{
    public abstract class Specialization
    {

        public Specialization() { }
        /*
         * TODO - need to find a good place for this
         * 
         * 4 types
         *  - Unspecialized (default)
         *  - Officer
         *  - Psionic
         *  - MEC
         *  
         *  Can affect returned name (officers)
         *  Handle requirements for specialization promotions (officer + psi)
         */

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
    }
}