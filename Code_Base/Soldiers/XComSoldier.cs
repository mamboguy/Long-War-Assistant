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

        private string _firstName;
        private string _lastName;
        private string _callsign;

        public XComSoldier(string firstName, string lastName) : this()
        {
            _firstName = firstName;
            _lastName = lastName;
            _callsign = "";
        }

        public XComSoldier()
        {
            //Default a new soldier to being unspecialized and a PFC rank
            _specialization = new Unspecialized_Specialization();
            _soldierRank = EnlistedRanks.PFC;
            SoldierClass = SoldierClass.NONE;

            Stats = new SoldierStats();
        }

        private EnlistedRanks _soldierRank;


        public string Name { get { return _firstName + " " + _callsign + " " + _lastName; } }
        public string SoldierClassString
        {
            get
            {
                if (SoldierClass == SoldierClass.NONE)
                {
                    return "";
                }
                else
                {
                    return SoldierClass.ToString();
                }
            }
        }

        public string Aim { get { return Stats.Aim.ToString(); } }
        public string Will { get { return Stats.Will.ToString(); } }
        public string HP { get { return Stats.HP.ToString(); } }
        public string Mobility { get { return Stats.Mobility.ToString(); } }
        public string Defense { get { return Stats.Defense.ToString(); } }
        public SoldierStats Stats { get; set; }
        public SoldierClass SoldierClass { get; set; }
        public EnlistedRanks SoldierRank { get { return _soldierRank; } set { _soldierRank = value; } }
        public BitmapImage RankImage { get { return new BitmapImage(new Uri(SoldierRank.RankImagePath())); } }
        public List<Perk> PerkList { get; set; }
        public BitmapImage ClassImage { get { return new BitmapImage(new Uri("pack://application:,,,/Forms/Images/SoldierViewer/ClassIcons/" + SoldierClass.GetIconName() + _specialization.GetPsiString() + ".png")); } }
        public BitmapImage NationalityImage { get { return new BitmapImage(new Uri("pack://application:,,,/Forms/Images/SoldierViewer/CountryFlags/UnitedStates.png")); } }
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

        // TODO - Add in a field thats only purpose is to toggle to force a UI update when a soldier is changed
        private string _refreshUI = "";
        public string UIRefreshToggle
        {
            get { return _refreshUI; }
            set { _refreshUI = value; RaisePropertyChanged(""); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string eventInvoker)
        {
            if (_refreshUI == "")
            {
                //Only refresh the UI once by toggling the Property rather than the variable
                UIRefreshToggle = " ";
            }
            else
            {
                _refreshUI = "";
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(eventInvoker));
        }
    }
}