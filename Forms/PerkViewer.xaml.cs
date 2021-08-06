using Long_War_Assistant.Code_Base.Perks;
using Long_War_Assistant.Code_Base;
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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class PerkViewer : UserControl
    {
        public PerkViewer()
        {
            InitializeComponent();

            LoadPerkList();
        }

        private void LoadPerkList()
        {
            List<Perk> _perkList = PerkList_XMLReader.ReadPerkList();

            foreach (Perk perk in _perkList)
            {
                perkList_Panel.Children.Add(new PerkControl(this, perk));
            }
        }

        public void UpdatePerkQuickView(Perk perk)
        {
            perkIcon_Image.Source = new BitmapImage(new Uri(perk.PerkImage));
            perkDescription_Label.Text = perk.PerkDescription;
            perkName_Label.Content = perk.PerkName;
        }
    }
}
