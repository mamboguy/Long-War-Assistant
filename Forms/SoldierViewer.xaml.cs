using Long_War_Assistant.Code_Base.Soldier;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Long_War_Assistant.Forms
{
    /// <summary>
    /// Interaction logic for SoldierViewer.xaml
    /// </summary>
    public partial class SoldierViewer : UserControl
    {
        public SoldierViewer(List<XComSoldier> soldierList)
        {
            InitializeComponent();

            soldierList = new List<XComSoldier>()
            {
                new XComSoldier("Mambo"),
                new XComSoldier("Redire"),
                new XComSoldier("Krissy"),
                new XComSoldier("Grinder"),
                new XComSoldier("Warbird")
            };

            _soldierListView.ItemsSource = soldierList;
        }

        private void UpdateStats()
        {
            XComSoldier selectedSoldier = _soldierListView.SelectedItem as XComSoldier;

            _aimStatLabel.Content = selectedSoldier.Stats.Aim;
            _defenseStatLabel.Content = selectedSoldier.Stats.Defense;
            _hpStatLabel.Content = selectedSoldier.Stats.HP;
            _mobilityStatLabel.Content = selectedSoldier.Stats.Mobility;
            _willStatLabel.Content = selectedSoldier.Stats.Will;
            _damagereductionStatLabel.Content = selectedSoldier.Stats.DamageReduction;
        }

        private void SoldierList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateStats();
        }

        private void PromoteButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            XComSoldier selectedSoldier = _soldierListView.SelectedItem as XComSoldier;

            selectedSoldier.Promote();

            UpdateStats();
        }

        private void DemoteButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            XComSoldier selectedSoldier = _soldierListView.SelectedItem as XComSoldier;

            selectedSoldier.Demote();

            UpdateStats();
        }

        private void PsiButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            XComSoldier selectedSoldier = _soldierListView.SelectedItem as XComSoldier;

            selectedSoldier.MakePsi();

            UpdateStats();
        }
    }
}