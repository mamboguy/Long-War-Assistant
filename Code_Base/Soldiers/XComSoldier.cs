using Long_War_Assistant.Code_Base.Soldiers;
using Long_War_Assistant.Code_Base.Soldiers.Specialization;
using System.Collections.Generic;

namespace Long_War_Assistant.Code_Base.Soldier
{
    public class XComSoldier
    {
        public XComSoldier() 
        {
            //Default a new soldier to being unspecialized
            _specialization = new Unspecialized_Specialization();
        }

        public SoldierStats Stats { get; set; }
        public Soldier_Classes SoldierClass { get; set; }
        public EnlistedRanks SoldierRank { get; set; }
        public List<Perk> PerkList { get; set; }

        private Specialization _specialization;


        /// <summary>
        /// Promotes a soldier to the next rank and levels up their stats
        /// </summary>
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

        /// <summary>
        /// MEC Soldiers are demoted when they are mec'd, so this handles the logic for that
        /// </summary>
        private void Demote()
        {

        }
    }
}