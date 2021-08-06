namespace Long_War_Assistant.Code_Base.Soldiers
{
    public enum EnlistedRanks
    {
        Private,
        Specialist,
        LanceCorporal,
        Corporal,
        Sergeant,
        TechSergeant,
        GunnerySergeant,
        MasterSergeant
    }

    public enum OfficerRanks
    {
        Lieutenant,
        Captain,
        Major,
        Colonel,
        FieldCommander
    }

    public enum PsiRanks
    {
        Awakened,
        Sensitive,
        Talent,
        Adept,
        Psion,
        Master
    }

    public static class EnlistedRanksExtension
    {
        public static bool IsAtLeastRank(this EnlistedRanks myRank, EnlistedRanks requiredRank)
        {
            return myRank >= requiredRank;
        }

        public static int GetRequiredExp(this EnlistedRanks ranks)
        {
            return ranks switch
            {
                EnlistedRanks.Private => 0,
                EnlistedRanks.Specialist => 120,
                EnlistedRanks.LanceCorporal => 350,
                EnlistedRanks.Corporal => 700,
                EnlistedRanks.Sergeant => 1200,
                EnlistedRanks.TechSergeant => 2000,
                EnlistedRanks.GunnerySergeant => 3000,
                EnlistedRanks.MasterSergeant => 4000,
                _ => -1,
            };
        }

        public static string GetShortName(this EnlistedRanks ranks)
        {
            return ranks switch
            {
                EnlistedRanks.Private => "PFC",
                EnlistedRanks.Specialist => "Spec",
                EnlistedRanks.LanceCorporal => "LCpl",
                EnlistedRanks.Corporal => "Cpl",
                EnlistedRanks.Sergeant => "Sgt",
                EnlistedRanks.TechSergeant => "TSgt",
                EnlistedRanks.GunnerySergeant => "GSgt",
                EnlistedRanks.MasterSergeant => "MSgt",
                _ => "",
            };
        }

        /// <summary>
        /// MEC'ing a troop is the only reason someone should be demoted.  As such, since only LCPLs and above can be
        /// MEC'd, then Privates and Specialists can't be demoted
        /// </summary>
        /// <param name="rank"></param>
        /// <returns></returns>
        public static bool CanDemote(this EnlistedRanks rank)
        {
            //The only rank that can't be demoted are PFCs
            return rank switch
            {
                EnlistedRanks.Private => false,
                EnlistedRanks.Specialist => false,
                _ => true,
            };
        }

        public static EnlistedRanks DemoteToPreviousRank(this EnlistedRanks ranks)
        {
            return ranks switch
            {
                EnlistedRanks.Private => throw new System.NotSupportedException(),
                EnlistedRanks.Specialist => throw new System.NotSupportedException(),
                EnlistedRanks.LanceCorporal => EnlistedRanks.Specialist,
                EnlistedRanks.Corporal => EnlistedRanks.LanceCorporal,
                EnlistedRanks.Sergeant => EnlistedRanks.Corporal,
                EnlistedRanks.TechSergeant => EnlistedRanks.Sergeant,
                EnlistedRanks.GunnerySergeant => EnlistedRanks.TechSergeant,
                EnlistedRanks.MasterSergeant => EnlistedRanks.MasterSergeant,
                _ => throw new System.NotImplementedException()
            };
        }

        public static bool CanPromote(this EnlistedRanks rank)
        {
            return rank switch
            {
                // Only the MSgt can't promote, everyone else can
                EnlistedRanks.MasterSergeant => false,
                _ => true,
            };
        }

        public static EnlistedRanks PromoteToNextRank(this EnlistedRanks ranks)
        {
            return ranks switch
            {
                EnlistedRanks.Private => EnlistedRanks.Specialist,
                EnlistedRanks.Specialist => EnlistedRanks.LanceCorporal,
                EnlistedRanks.LanceCorporal => EnlistedRanks.Corporal,
                EnlistedRanks.Corporal => EnlistedRanks.Sergeant,
                EnlistedRanks.Sergeant => EnlistedRanks.TechSergeant,
                EnlistedRanks.TechSergeant => EnlistedRanks.GunnerySergeant,
                EnlistedRanks.GunnerySergeant => EnlistedRanks.MasterSergeant,

                // This case will only happen if CanPromote is never checked.
                EnlistedRanks.MasterSergeant => throw new System.NotSupportedException(),
                _ => EnlistedRanks.Private,
            };
        }
    }

    public static class OfficerRanksExtension
    {
        public static string GetShortName(this OfficerRanks ranks)
        {
            return ranks switch
            {
                OfficerRanks.Lieutenant => "Lt",
                OfficerRanks.Captain => "Capt",
                OfficerRanks.Major => "Maj",
                OfficerRanks.Colonel => "Col",
                OfficerRanks.FieldCommander => "FC",
                _ => "INVALID",
            };
        }
    }
}
