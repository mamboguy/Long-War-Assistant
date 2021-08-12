using Long_War_Assistant.Code_Base;
using Long_War_Assistant.Code_Base.Soldier;
using Long_War_Assistant.Forms;
using System.Windows;
using System.Windows.Controls;

namespace Long_War_Assistant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PerkList_Button_Click(object sender, RoutedEventArgs e)
        {
            LoadCurrentPanel(new PerkViewer());
        }

        private void NothingButton_Click(object sender, RoutedEventArgs e)
        {
            LoadCurrentPanel(null);
        }

        private void SoldierListButton_Click(object sender, RoutedEventArgs e)
        {
            LoadCurrentPanel(new SoldierViewer(null));
        }

        private void LoadCurrentPanel(Control newControl)
        {
            _currentView_Panel.Children.Clear();

            if (newControl != null)
            {
                _currentView_Panel.Children.Add(newControl);
            }
        }
    }
}
