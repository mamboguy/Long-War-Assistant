using Long_War_Assistant.Code_Base.Soldiers;
using Long_War_Assistant.Code_Base.Soldiers.Classes;
using Long_War_Assistant.Code_Base.Soldiers.Specialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace Long_War_Assistant.Code_Base.Soldier
{
    public class XComSoldier : INotifyPropertyChanged
    {
        public XComSoldier(string name) : this()
        {
            Name = name;
        }

        public XComSoldier()
        {
            //Default a new soldier to being unspecialized and a PFC rank
            _specialization = new Unspecialized_Specialization();
            _soldierRank = EnlistedRanks.PFC;

            Stats = new SoldierStats();
        }

        private EnlistedRanks _soldierRank;


        public string Name { get; set; }
        public SoldierStats Stats { get; set; }
        public SoldierClass SoldierClass { get; set; }
        public EnlistedRanks SoldierRank { get { return _soldierRank; } set { _soldierRank = value; RaisePropertyChanged(""); } }
        public BitmapImage RankImage { get { return new BitmapImage(new Uri(SoldierRank.RankImagePath())); } }
        public List<Perk> PerkList { get; set; }
        public BitmapImage ClassImage { get { return new BitmapImage(new Uri("pack://application:,,,/Forms/Images/SoldierViewer/ClassIcons/" + SoldierClass.GetIconName() + _specialization.GetPsiString() + ".png")); } }
        public BitmapImage NationalityImage { get { return new BitmapImage(new Uri("pack://application:,,,/Forms/Images/SoldierViewer/CountryFlags/UnitedStates.png")); } }

        
        
        // TODO - Add in a field thats only purpose is to toggle to force a UI update when a soldier is changed
        private bool _refreshUI = true;
        public bool UIRefreshToggle { get { return _refreshUI; } set { _refreshUI = !_refreshUI; RaisePropertyChanged(""); } }

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

                RaisePropertyChanged("Promoted");
            }
        }

        /// <summary>
        /// MEC Soldiers are demoted when they are mec'd, so this handles the logic for that
        /// </summary>
        public void Demote()
        {
            // Check to see if a soldier is allowed to be demoted first
            if (SoldierRank.CanDemote())
            {
                // If allowed, demote the soldier
                SoldierRank = SoldierRank.DemoteToPreviousRank();

                // When demoted, the soldier is reverted to "apparent" rank of PFC so that perks can be selected
                // Stats are also reset to rookie level and then adjusted up by the MEC leveling stats

                RaisePropertyChanged("Demoted");
            }
        }

        public void MakePsi()
        {
            _specialization = new Psi_Specialization();

            RaisePropertyChanged("PSI");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string eventInvoker)
        {
            _refreshUI = !_refreshUI;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(eventInvoker));
        }
    }
}