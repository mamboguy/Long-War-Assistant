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

        public static bool CanPromote(this EnlistedRanks rank)
        {
            return rank switch
            {
                //Only the MSgt can't promote, everything else can
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
                //This case should never happen
                EnlistedRanks.MasterSergeant => EnlistedRanks.Private,
                _ => EnlistedRanks.Private,
            };
        }
    }
}
