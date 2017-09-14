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

namespace SE_Prac1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            //create temp var to hold value of each textbox, and validate whether it has a value or not
            Boolean txtname = String.IsNullOrWhiteSpace(txt_name.Text);
            Boolean txtaddr = String.IsNullOrWhiteSpace(txt_addr.Text);

            //if both var are null/white space then they are returned true
            if (txtname)
            {
                //show message
                MessageBox.Show("Please enter a name ;)))");
            }
            if (txtaddr)
            {
                //show message
                MessageBox.Show("Please enter an address ;))");
            }

            //check if age box has value and if it is within range
            Boolean txtage = String.IsNullOrWhiteSpace(txt_age.Text);
            int test;

            //if number can be parsed then do it boi
            Boolean parseage = Int32.TryParse(txt_age.Text, out test);
            if (txtage)
            {
                //show message
                MessageBox.Show("Please enter an age between 0 and 100 ;))");
            }
            else if (!parseage)
            {
                //show message if text is entered
                MessageBox.Show("why bro, why?");
            }
            else
            {
                //convert to int if number can be parsed
                int int_age = Int32.Parse(txt_age.Text);
                //set the range, and validate
                if (int_age < 0 || int_age > 100)
                {
                    //show message
                    MessageBox.Show("Please type in a value between 1 and 100 ;)))");
                }
            }

            //write data to a .csv file
            //check if the boxes have value
            if (!txtname || !txtage || !txtaddr)
            {
                string file_input = txt_name.Text + "," + txt_age.Text + "," + txt_addr.Text;

                //write string to a file
                System.IO.StreamWriter file = new System.IO.StreamWriter("H:\\test.csv", true);
                file.WriteLine(file_input);
                file.Close();
            }
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            txt_name.Clear();
            txt_age.Clear();
            txt_addr.Clear();

        }

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            txt_name.Clear();
            txt_age.Clear();
            txt_addr.Clear();

            //read from test.csv
            System.IO.StreamReader file_read = new System.IO.StreamReader("H:\\test.csv", true);
            
            var file_out = file_read.ReadLine();
            //split values by comma ","
            var file_value = file_out.Split(',');

            //insert values into boxes
            txt_name.Text = file_value[0];
            txt_age.Text = file_value[1];
            txt_addr.Text = file_value[2];

            file_read.Close();
        }
    }
}
