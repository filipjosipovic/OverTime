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
using System.IO;
using System.Threading;
using System.Timers;
using System.Windows.Navigation;

namespace OverTime
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public static List<TextBlock> zulöschen;
        public static List<TextBlock> ChildrenVor;
        public static List<TextBlock> ChildrenNach;
        public static List<TextBlock> ChildrenClass;
        public static List<TextBlock> ChildrenDate;
        public static List<TextBlock> ChildrenFromTo;
        public Window1()
        {
            InitializeComponent();

            PopulateGrids();

            GetStudents();
        }
        private void PopulateGrids()
        {
            ChildrenVor = new List<TextBlock>();
            for (int i = 0; i < 10; i++)
            {
                ChildrenVor.Add(new TextBlock());
            }
            foreach (var item in ChildrenVor)
            {
                Window1Vorname.Children.Add(item);
            }

            //
            ChildrenNach = new List<TextBlock>();
            for (int i = 0; i < 10; i++)
            {
                ChildrenNach.Add(new TextBlock());
            }
            foreach (var item in ChildrenNach)
            {
                Window1Nachname.Children.Add(item);
            }
            //

            ChildrenClass = new List<TextBlock>();
            for (int i = 0; i < 10; i++)
            {
                ChildrenClass.Add(new TextBlock());
            }
            foreach (var item in ChildrenClass)
            {
                Window1Class.Children.Add(item);
            }
            //
            ChildrenDate = new List<TextBlock>();
            for (int i = 0; i < 10; i++)
            {
                ChildrenDate.Add(new TextBlock());
            }
            foreach (var item in ChildrenDate)
            {
                Window1Date.Children.Add(item);
            }
            //
            ChildrenFromTo = new List<TextBlock>();
            for (int i = 0; i < 10; i++)
            {
                ChildrenFromTo.Add(new TextBlock());
            }
            foreach (var item in ChildrenFromTo)
            {
                Window1FromTo.Children.Add(item);
            }
        }

        public void GetStudents()
        {
            StreamReader reader = new StreamReader("data.txt");
            int i = 0;
            try
            {
                while (!reader.EndOfStream)
                {
                    string vor, nach, date, fromto, clas;

                    vor = reader.ReadLine();
                    nach = reader.ReadLine();
                    fromto = reader.ReadLine();
                    date = reader.ReadLine();
                    clas = reader.ReadLine();
                    reader.ReadLine();
                    if (new DateTime(int.Parse(date.Substring(6, 4)), int.Parse(date.Substring(3, 2)), int.Parse(date.Substring(0, 2))) > DateTime.Now)
                    {
                        ChildrenVor[i].Text  =  vor;
                        ChildrenNach[i].Text = nach;
                        ChildrenDate[i].Text = date;
                        ChildrenFromTo[i].Text = fromto;
                        ChildrenClass[i].Text = clas;
                        i++;
                    }
                }
            }
            catch (Exception)
            {
                //Du hast nichts gesehen
            }
            reader.Dispose();
        }
        public void Abgelaufen()
        {
            GetStudents();
        }
    }
}