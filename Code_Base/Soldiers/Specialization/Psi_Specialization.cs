using Long_War_Assistant.Code_Base.Soldier;

namespace Long_War_Assistant.Code_Base.Soldiers.Specialization
{
    public class Psi_Specialization : Specialization
    {

        private PsiRank _psiRank;

        public Psi_Specialization()
        {
            //Default to lowest psi rank
            _psiRank = PsiRank.Awakened;
        }

        public override bool DoesSpecializationRankOverrideNormalRank()
        {
            return false;
        }

        public override string GetSpecializationRank()
        {
            return _psiRank.ToString();
        }

        public override void PromoteSpecialization()
        {
            _psiRank = _psiRank.Promote();
        }

        public override string GetPsiString()
        {
            return "_Psi";
        }
    }

    public enum PsiRank
    {
        Awakened,
        Sensitive,
        Talent,
        Adept,
        Psion,
        Master
    }

    public static class PsiRanksExtension
    {
        public static PsiRank Promote(this PsiRank psiRank)
        {
            return psiRank switch
            {
                PsiRank.Awakened => PsiRank.Sensitive,
                PsiRank.Sensitive => PsiRank.Talent,
                PsiRank.Talent => PsiRank.Adept,
                PsiRank.Adept => PsiRank.Psion,
                _ => PsiRank.Master,
            };
        }

        public static bool CanPromote(this PsiRank psiRank)
        {
            return psiRank switch
            {
                PsiRank.Master => false,
                _ => true
            };
        }
    }
}
