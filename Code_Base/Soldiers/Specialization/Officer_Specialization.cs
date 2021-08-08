using Long_War_Assistant.Code_Base.Soldier;
using System;

namespace Long_War_Assistant.Code_Base.Soldiers.Specialization
{
    public class Officer_Specialization : Specialization
    {
        private OfficerRank _officerRank;

        public override bool DoesSpecializationRankOverrideNormalRank()
        {
            return true;
        }

        public override string GetSpecializationRank()
        {
            return _officerRank.ToString();
        }

        public override void PromoteSpecialization()
        {
            _officerRank = _officerRank.Promote();
        }
    }

    public enum OfficerRank
    {
        Lieutenant,
        Captain,
        Major,
        Colonel,
        FieldCommander
    }

    public static class OfficerRanksExtension
    {
        public static string GetShortName(this OfficerRank ranks)
        {
            return ranks switch
            {
                OfficerRank.Lieutenant => "Lt",
                OfficerRank.Captain => "Capt",
                OfficerRank.Major => "Maj",
                OfficerRank.Colonel => "Col",
                OfficerRank.FieldCommander => "Cmdr",
                _ => "INVALID",
            };
        }

        public static OfficerRank Promote(this OfficerRank rank)
        {
            return rank switch
            {
                OfficerRank.Lieutenant => OfficerRank.Captain,
                OfficerRank.Captain => OfficerRank.Major,
                OfficerRank.Major => OfficerRank.Colonel,
                _ => OfficerRank.FieldCommander,
            };
        }

        public static bool CanPromote(this OfficerRank rank)
        {
            return rank switch
            {
                OfficerRank.FieldCommander => false,
                _ => true,
            };
        }
    }
}
