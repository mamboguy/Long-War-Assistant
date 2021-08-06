using Long_War_Assistant.Forms;
using System.Windows;

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
            _currentView_Panel.Children.Clear();
            _currentView_Panel.Children.Add(new PerkViewer());
        }

        private void NothingButton_Click(object sender, RoutedEventArgs e)
        {
            _currentView_Panel.Children.Clear();
        }
    }
}
