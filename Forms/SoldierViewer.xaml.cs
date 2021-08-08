using Long_War_Assistant.Code_Base.Soldier;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Long_War_Assistant.Forms
{
    /// <summary>
    /// Interaction logic for SoldierViewer.xaml
    /// </summary>
    public partial class SoldierViewer : UserControl
    {
        public SoldierViewer(XComSoldier soldier)
        {
            InitializeComponent();

            _aimStatLabel.Content = soldier.Stats.Aim;
        }

        /*
         * Aim, Defense, Will, Mobility, HP
         * 
         * BuildFacilities_I6F  - HP
         * Attack               - Aim
         * Defense              - Defense
         * SituationRoom_173    - Mobility
         * Promote_psi          - Will
         */
    }
}
