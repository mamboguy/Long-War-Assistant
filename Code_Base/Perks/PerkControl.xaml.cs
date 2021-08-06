using Long_War_Assistant.Forms;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Long_War_Assistant.Code_Base.Perks
{
    /// <summary>
    /// Interaction logic for PerkControl.xaml
    /// </summary>
    public partial class PerkControl : UserControl
    {

        private readonly Perk _perk;
        private readonly PerkViewer _parent;

        public PerkControl(PerkViewer parent, Perk perk)
        {
            InitializeComponent();

            perkNameLabel.Content = perk.PerkName;
            perkIcon_Image.Source = new BitmapImage(new Uri(perk.PerkImage));

            _parent = parent;
            _perk = perk;
        }

        private void Control_MouseEnter(object sender, MouseEventArgs e)
        {
            _parent.UpdatePerkQuickView(_perk);
        }
    }
}
