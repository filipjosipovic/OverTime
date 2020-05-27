using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

namespace OverTime
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Window1 window1;

        public MainWindow()
        {
            //DateTime x= DateTime.Now;
            //  date.Text = x.ToShortDateString().ToString();
            window1 = new Window1();
            InitializeComponent();
            window1.Show();
            window1.GetStudents();
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter stream = new StreamWriter("data.txt",true);
        
            stream.WriteLine(firstname.Text);
            stream.WriteLine(surname.Text);
            stream.WriteLine(fromTo.Text);
            stream.WriteLine(date.Text);
            stream.WriteLine(pclass.Text);
            stream.WriteLine();
            stream.Dispose();
            window1.GetStudents();
            window1.Abgelaufen();
           
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void fromTo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void date_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}