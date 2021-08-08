namespace Long_War_Assistant.Code_Base.Soldiers.Classes
{
    public interface ISoldierClass
    {
        SoldierStats GetPromotionStats(EnlistedRanks newRank);
    }
}
