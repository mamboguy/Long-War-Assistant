using Long_War_Assistant.Code_Base.Soldiers.Classes;
using Long_War_Assistant.Forms.ClassSelector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Long_War_Assistant.Forms
{
    /// <summary>
    /// Interaction logic for SoldierClassSelectionScreen.xaml
    /// </summary>
    public partial class SoldierClassSelectionScreen : Window
    {

        private SoldierViewer _parent;

        public SoldierClassSelectionScreen(SoldierViewer parent)
        {
            InitializeComponent();

            List<SoldierClass> classes = new List<SoldierClass>()
            {
                SoldierClass.Scout,
                SoldierClass.Sniper,
                SoldierClass.Infantry,
                SoldierClass.Assault,
                SoldierClass.Gunner,
                SoldierClass.Rocketeer,
                SoldierClass.Medic,
                SoldierClass.Engineer,
            };

            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            foreach (SoldierClass item in classes)
            {
                classStackPanel.Children.Add(new ClassItem(this, item));
            }

            _parent = parent;
        }

        public void SetSelectedClass(SoldierClass selectedClass)
        {
            _parent.SetSelectedSoldierClass(selectedClass);

            this.Close();
        }
    }
}
