using Long_War_Assistant.Code_Base.Soldier;

namespace Long_War_Assistant.Code_Base.Soldiers.Specialization
{
    public class MEC_Specialization : Specialization
    {
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
