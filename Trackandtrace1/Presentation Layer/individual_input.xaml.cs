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
using Trackandtrace1.Data_Layer;

namespace Trackandtrace1
{
    /// <summary>
    /// Interaction logic for individual_input.xaml
    /// </summary>
    public partial class individual_input : Window
    {
        public individual_input()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {             
                    if (string.IsNullOrWhiteSpace(FullName_TxtBox.Text) || string.IsNullOrWhiteSpace(PhoneNumber_TxtBox.Text))
                    {
                        MessageBox.Show("Error! Empty field detected.", "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    else if (FullName_TxtBox.Text.Any(char.IsDigit))
                    {
                        MessageBox.Show("Error! Name should contain only letters.", "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    else if (PhoneNumber_TxtBox.Text.Length != 10 || PhoneNumber_TxtBox.Text.Any(char.IsLetter))
                    {
                        MessageBox.Show("Please input a correct phone number, whitout coutry code.", "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        User User1 = new User();
                        User1.Name = FullName_TxtBox.Text;
                        User1.Phone_number = PhoneNumber_TxtBox.Text;
                        string header = "Id,UserName,UserPhone";
                        string toCsv = User1.Name + "," + User1.Phone_number;
                CsvIO.importCSV("users.csv", header, toCsv);

                MessageBoxResult result = MessageBox.Show("Individual: " + User1.Name + ", with phone number: " + User1.Phone_number + ", added successful! \n Do you want to add another user?", "Dialog", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                {
                    FullName_TxtBox.Text = String.Empty;
                    PhoneNumber_TxtBox.Text = String.Empty;
                    User1.Name = String.Empty;
                    User1.Phone_number = String.Empty;
                }
                    else
                {
                    Close();
                }
            }  
        }
    }
}
