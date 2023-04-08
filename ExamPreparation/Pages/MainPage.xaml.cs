using Microsoft.Win32;
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
using System.IO;

namespace ExamPreparation.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = Modules.OpenDialog();
            List<Modules.childrens> Childrens = Modules.ReadChildrens(path);
            Modules.SortChildrens(Childrens);
            Childrens.Clear();
            Premier.ItemsSource = Modules.PremierGroup;
            Second.ItemsSource = Modules.SecondGroup;
            Third.ItemsSource = Modules.ThirdGroup;
            Fourth.ItemsSource = Modules.FourthGroup;

        }

        private void SavePremierClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
