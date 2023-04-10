using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation
{
    internal class Modules
    {
        public static string OpenDialog()
        {
            string path = "";
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = openFileDlg.ShowDialog();
            if (result == true)
            {
                path = openFileDlg.FileName;
            }
            return path;
        }
        public struct childrens
        {
            public string name { get; set; }
            public string birthday { get; set; }
            public string gender { get; set; }

        }
        public static List<childrens> ReadChildrens(string path)
        {
            ListOfChildrens.Clear();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');
                        try
                        {
                            ListOfChildrens.Add(new childrens { name = fields[0].Replace("\"", ""), birthday = fields[1].Replace("\"", ""), gender = fields[2].Replace("\"", "") });
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }
                }
                
            }
            catch { }
            return ListOfChildrens;
        }
        public static List<childrens> ListOfChildrens = new List<childrens>();
        public static List<childrens> PremierGroup = new List<childrens>();
        public static List<childrens> SecondGroup = new List<childrens>();
        public static List<childrens> ThirdGroup = new List<childrens>();
        public static List<childrens> FourthGroup = new List<childrens>();
        public static List<childrens> Boys = new List<childrens>();
        public static List<childrens> Girls = new List<childrens>();
        public static void SortChildrensByGroupes(List<childrens> Childrens)
        {
            PremierGroup.Clear();
            SecondGroup.Clear();
            ThirdGroup.Clear();
            FourthGroup.Clear();
            try
            {
                foreach (var item in Childrens)
                {
                    if (GetAgeOfChildren(Convert.ToDateTime(item.birthday)) <= 3 && GetAgeOfChildren(Convert.ToDateTime(item.birthday)) >= 1)
                    {
                        PremierGroup.Add(item);
                    }
                    else if (GetAgeOfChildren(Convert.ToDateTime(item.birthday)) > 3 && GetAgeOfChildren(Convert.ToDateTime(item.birthday)) <= 7)
                    {
                        SecondGroup.Add(item);
                    }
                    else if (GetAgeOfChildren(Convert.ToDateTime(item.birthday)) > 7 && GetAgeOfChildren(Convert.ToDateTime(item.birthday)) <= 14)
                    {
                        ThirdGroup.Add(item);
                    }
                    else if (GetAgeOfChildren(Convert.ToDateTime(item.birthday)) > 14 && GetAgeOfChildren(Convert.ToDateTime(item.birthday)) <= 18)
                    {
                        FourthGroup.Add(item);
                    }
                }
            }
            catch (Exception)
            { }
            WriteChildrens(PremierGroup, GetPath("Premier.txt"));
            WriteChildrens(SecondGroup, GetPath("Second.txt"));
            WriteChildrens(ThirdGroup, GetPath("Third.txt"));
            WriteChildrens(FourthGroup, GetPath("Fourth.txt"));
        }
        public static void SortChildrensByGender(List<childrens> Childrens)
        {
            Girls.Clear();
            Boys.Clear();
            try
            {
                foreach (var item in Childrens)
                {
                    if (item.gender == "Мальчик")
                    {
                        Boys.Add(item);
                    }
                    else if (item.gender == "Девочка")
                    {
                        Girls.Add(item);
                    }
                }
            }
            catch (Exception)
            { }
            WriteChildrens(Boys, GetPath("Boys.txt"));
            WriteChildrens(Girls, GetPath("Girls.txt"));
        }
        public static void WriteChildrens(List<childrens> Premier, string path)
        {
            using (StreamWriter writer = new StreamWriter(File.Create(path)))
            {

                foreach (childrens item in Premier)
                {
                    string line = $"{item.name},{item.birthday},{item.gender}";
                    writer.WriteLine(line);
                }
            }
        }
        public static int GetAgeOfChildren(DateTime birthday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            return age;
        }
        public static string GetPath(string fileName)
        { 
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            return path;
        }
    }
}