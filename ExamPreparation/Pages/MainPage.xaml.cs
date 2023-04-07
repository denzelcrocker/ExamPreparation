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
        List<string[]> PremierGroupWrite = new List<string[]>();
        List<string[]> SecondGroupWrite = new List<string[]>();
        List<string[]> ThirdGroupWrite = new List<string[]>();
        List<string[]> FourthGroupWrite = new List<string[]>();
        public struct childrens
        { 
            public string name { get; set; }
            public string birthday { get; set; }
            public string gender { get; set; }
            public int age { get; set; }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = Modules.OpenDialog();
            List<childrens> PremierGroup = new List<childrens> ();
            List<childrens> SecondGroup = new List<childrens>();
            List<childrens> ThirdGroup = new List<childrens>();
            List<childrens> FourthGroup = new List<childrens>();
            using (StreamReader reader = new StreamReader(path))
            {
                DateTime now = DateTime.Today;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    DateTime birthday = Convert.ToDateTime(fields[1]);
                    int age = now.Year - birthday.Year;
                    if (age <= 3 && age >= 1)
                    {
                        PremierGroup.Add(new childrens() { name = fields[0], birthday = fields[1], gender = fields[2] });
                        PremierGroupWrite.Add(fields);
                    }
                    else if (age > 3 && age <= 7)
                    {
                        SecondGroup.Add(new childrens() { name = fields[0], birthday = fields[1], gender = fields[2] });
                        SecondGroupWrite.Add(fields);
                    }
                    else if (age > 7 && age <= 14)
                    {
                        ThirdGroup.Add(new childrens() { name = fields[0], birthday = fields[1], gender = fields[2] });
                        ThirdGroupWrite.Add(fields);
                    }
                    else if (age > 14 && age <= 18)
                    {
                        FourthGroup.Add(new childrens() { name = fields[0], birthday = fields[1], gender = fields[2] });
                        FourthGroupWrite.Add(fields);
                    }
                }
            }
            Premier.ItemsSource = PremierGroup;
            Second.ItemsSource = SecondGroup;
            Third.ItemsSource = ThirdGroup;
            Fourth.ItemsSource = FourthGroupWrite;
        }

        private void SavePremierClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
