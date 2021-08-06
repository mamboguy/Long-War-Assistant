using Long_War_Assistant.Code_Base.Soldiers;

namespace Long_War_Assistant.Code_Base.Soldier
{
    public abstract class Soldier
    {
        public Soldier() { }

        public SoldierStats Stats { get; set; }
        public Soldier_Classes SoldierClass { get; set; }
        public EnlistedRanks SoldierRank { get; set; }

        public void Promote()
        {
            // Check if promotion is allowed for the soldier first.
            if (SoldierRank.CanPromote())
            {
                // If allowed, promote based off the current rank.
                SoldierRank = SoldierRank.PromoteToNextRank();

                // Get the class' additional stats based off the new promotion.
                SoldierStats _additionalStats = SoldierClass.GetPromotionStats(SoldierRank);

                // Add the stats to the soldiers' current stats.
                Stats.AddAdditionalStats(_additionalStats);
            }
        }
    }
}