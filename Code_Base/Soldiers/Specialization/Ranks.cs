namespace Long_War_Assistant.Code_Base.Soldiers
{
    public enum EnlistedRanks
    {
        PFC,
        SPEC,
        LCPL,
        CPL,
        SGT,
        TSGT,
        GSGT,
        MSGT
    }

    public static class EnlistedRanksExtension
    {
        public static string RankImagePath(this EnlistedRanks rank)
        {
            return "pack://application:,,,/Forms/Images/SoldierViewer/RankImages/" + rank.ToString() + ".png";
        }

        public static bool IsAtLeastRank(this EnlistedRanks myRank, EnlistedRanks requiredRank)
        {
            return myRank >= requiredRank;
        }

        public static int GetRequiredExp(this EnlistedRanks ranks)
        {
            return ranks switch
            {
                EnlistedRanks.PFC => 0,
                EnlistedRanks.SPEC => 120,
                EnlistedRanks.LCPL => 350,
                EnlistedRanks.CPL => 700,
                EnlistedRanks.SGT => 1200,
                EnlistedRanks.TSGT => 2000,
                EnlistedRanks.GSGT => 3000,
                EnlistedRanks.MSGT => 4200,
                _ => -1,
            };
        }

        /// <summary>
        /// MEC'ing a troop is the only reason someone should be demoted.  As such, since only LCPLs and above can be
        /// MEC'd, then Privates and Specialists can't be demoted
        /// </summary>
        public static bool CanDemote(this EnlistedRanks rank)
        {
            //The only rank that can't be demoted are PFCs
            return rank switch
            {
                EnlistedRanks.PFC => false,
                EnlistedRanks.SPEC => false,
                _ => true,
            };
        }

        public static EnlistedRanks DemoteToPreviousRank(this EnlistedRanks ranks)
        {
            return ranks switch
            {
                EnlistedRanks.PFC or EnlistedRanks.SPEC => throw new System.NotSupportedException(),
                EnlistedRanks.LCPL => EnlistedRanks.SPEC,
                EnlistedRanks.CPL => EnlistedRanks.LCPL,
                EnlistedRanks.SGT => EnlistedRanks.CPL,
                EnlistedRanks.TSGT => EnlistedRanks.SGT,
                EnlistedRanks.GSGT => EnlistedRanks.TSGT,
                EnlistedRanks.MSGT => EnlistedRanks.GSGT,
                _ => throw new System.NotImplementedException()
            };
        }

        public static bool CanPromote(this EnlistedRanks rank)
        {
            return rank switch
            {
                // Only the MSgt can't promote, everyone else can
                EnlistedRanks.MSGT => false,
                _ => true,
            };
        }

        public static EnlistedRanks PromoteToNextRank(this EnlistedRanks ranks)
        {
            return ranks switch
            {
                EnlistedRanks.PFC => EnlistedRanks.SPEC,
                EnlistedRanks.SPEC => EnlistedRanks.LCPL,
                EnlistedRanks.LCPL => EnlistedRanks.CPL,
                EnlistedRanks.CPL => EnlistedRanks.SGT,
                EnlistedRanks.SGT => EnlistedRanks.TSGT,
                EnlistedRanks.TSGT => EnlistedRanks.GSGT,
                EnlistedRanks.GSGT => EnlistedRanks.MSGT,

                // This case will only happen if CanPromote is never checked.
                EnlistedRanks.MSGT => throw new System.NotSupportedException(),
                _ => EnlistedRanks.PFC,
            };
        }
    }
}