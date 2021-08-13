using Long_War_Assistant.Code_Base.Soldiers.Classes;
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

namespace Long_War_Assistant.Forms.ClassSelector
{
    /// <summary>
    /// Interaction logic for ClassItem.xaml
    /// </summary>
    public partial class ClassItem : UserControl
    {

        private SoldierClassSelectionScreen _parent;

        public ClassItem(SoldierClassSelectionScreen parent, SoldierClass className)
        {
            InitializeComponent();

            _parent = parent;

            tabPanel.Tag = className.ToString();
            classTextLabel.Content = className.ToString();
            imageLabel.Source = new BitmapImage(new Uri("pack://application:,,,/Forms/Images/SoldierViewer/ClassIcons/" + className.ToString() + ".png"));
            SelectedClass = className;
        }

        public SoldierClass SelectedClass { get; private set; }
        private void GotMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _parent.SetSelectedClass(SelectedClass);
        }
    }
}
