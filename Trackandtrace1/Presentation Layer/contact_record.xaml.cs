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
    /// Interaction logic for contact_record.xaml
    /// </summary>
    public partial class contact_record : Window
    {
        public contact_record()
        {
            InitializeComponent();
        }

        Contact user1 = new Contact();
        Contact user2 = new Contact();

        private void Select_cmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //depending on the choice of combobox, turn on/off some fields
            switch (select_cmBox.SelectedIndex)
            {
                case 0:
                    phoneNum_lbl.IsEnabled = true;
                    phone_inp_txtBox.IsEnabled = true;
                    fullName_lbl.IsEnabled = false;
                    name_inp_txtBox.IsEnabled = false;
                    name_inp_txtBox.Text = String.Empty;
                    findUser_btn.IsEnabled = true;
                    break;
                case 1:
                    fullName_lbl.IsEnabled = true;
                    name_inp_txtBox.IsEnabled = true;
                    phoneNum_lbl.IsEnabled = false;
                    phone_inp_txtBox.IsEnabled = false;
                    phone_inp_txtBox.Text = String.Empty;
                    findUser_btn.IsEnabled = true;
                    break;
            }
        }

        private void Select_cmBox_2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (select_cmBox_2.SelectedIndex)
            {
                case 0:
                    phoneNum_lbl_2.IsEnabled = true;
                    phone_inp_txtBox_2.IsEnabled = true;
                    fullName_lbl_2.IsEnabled = false;
                    name_inp_txtBox_2.IsEnabled = false;
                    name_inp_txtBox_2.Text = String.Empty;
                    findUser_btn_2.IsEnabled = true;
                    break;
                case 1:
                    fullName_lbl_2.IsEnabled = true;
                    name_inp_txtBox_2.IsEnabled = true;
                    phoneNum_lbl_2.IsEnabled = false;
                    phone_inp_txtBox_2.IsEnabled = false;
                    phone_inp_txtBox_2.Text = String.Empty;
                    findUser_btn_2.IsEnabled = true;
                    break;
            }
        }
        //Button for Find Person 1
        private void FindUser_btn_Click(object sender, RoutedEventArgs e)
        {
            //Making a string with an error message, that would be returned from function findCsvLine if line doesnt exists
            string error = "Error 1! Record Not Found. Please try again.";
            //flow control with switch and goto. Was with ifs and else's but currently is more readable and less repeated code.
            switch (select_cmBox.SelectedIndex)
            {
                case 0: //phone number selected
                    if (phone_inp_txtBox != null && !string.IsNullOrWhiteSpace(phone_inp_txtBox.Text))
                    {
                        string[] name_phone = CsvIO.findCsvLine(phone_inp_txtBox.Text, 2, "users.csv");
                        if (name_phone[0] == error)
                        { goto case 4; }
                        user1.User_name = name_phone[1];
                        user1.User_phone = name_phone[2];
                        goto case 5;
                    }
                    else
                    {
                        goto case 3;
                    }

                case 1: //name selected

                    if (name_inp_txtBox != null && !string.IsNullOrWhiteSpace(name_inp_txtBox.Text))
                    {
                        string[] name_phone = CsvIO.findCsvLine(name_inp_txtBox.Text, 1, "users.csv");
                        if (name_phone[0] == error)
                        { goto case 4; }
                        user1.User_name = name_phone[1];
                        user1.User_phone = name_phone[2];
                        goto case 5;
                    }
                    else
                    {
                        goto case 3;
                    }

                case 3: //input empty
                    MessageBox.Show("Please input search term!", "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;

                case 4: //user not found
                    MessageBox.Show("User not found in the database! Please try again!", "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
                    user1.User_name = String.Empty;
                    user1.User_phone = String.Empty;
                    break;

                case 5: //final check
                    MessageBoxResult result = MessageBox.Show("Is that the correct user? \n" + user1.User_name + " " + user1.User_phone, "User Found", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.No)
                    {
                        MessageBox.Show("Try Again.", "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
                        user1.User_name = String.Empty;
                        user1.User_phone = String.Empty;
                        phone_inp_txtBox.Text = String.Empty;
                        name_inp_txtBox.Text = String.Empty;
                    }

                    if (result == MessageBoxResult.Yes)
                    {

                        findUser_btn.IsEnabled = false;
                        save_btn.IsEnabled = true;
                        select_cmBox.IsEnabled = false;
                    }
                    break;
            }
        }

        //button for user 2, same code, different variables, considered functions, but could find how to make them with objects
        private void FindUser_btn_2_Click(object sender, RoutedEventArgs e)
        {
            string error = "Error 1! Record Not Found. Please try again."; //find csv function returns the same error

            switch (select_cmBox_2.SelectedIndex)
            {
                case 0: ///phone number
                    if (phone_inp_txtBox_2 != null && !string.IsNullOrWhiteSpace(phone_inp_txtBox_2.Text))
                    {
                        string[] name_phone = CsvIO.findCsvLine(phone_inp_txtBox_2.Text, 2, "users.csv");
                        if (name_phone[0] == error) //if error is returned
                        { goto case 4; }
                        user2.User_name = name_phone[1];
                        user2.User_phone = name_phone[2];
                        goto case 5;
                    }
                    else
                    {
                        goto case 3;
                    }

                case 1: //name
                    if (name_inp_txtBox_2 != null && !string.IsNullOrWhiteSpace(name_inp_txtBox_2.Text))
                    {
                        string[] name_phone = CsvIO.findCsvLine(name_inp_txtBox_2.Text, 1, "users.csv");
                        if (name_phone[0] == error)
                        { goto case 4; }
                        user2.User_name = name_phone[1];
                        user2.User_phone = name_phone[2];
                        goto case 5;
                    }
                    else
                    {
                        goto case 3;
                    }

                case 3: //input empty
                    MessageBox.Show("Please input search term!", "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;

                case 4: //user not found
                    MessageBox.Show("User not found in the database! Please try again!", "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
                    user2.User_name = String.Empty;
                    user2.User_phone = String.Empty;
                    break;

                case 5: //final check
                    MessageBoxResult result = MessageBox.Show("Is that the correct user? \n" + user2.User_name + " " + user2.User_phone, "User Found", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.No)
                    {
                        MessageBox.Show("Try Again.", "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
                        user2.User_name = String.Empty;
                        user2.User_phone = String.Empty;
                        phone_inp_txtBox_2.Text = String.Empty;
                        name_inp_txtBox_2.Text = String.Empty;
                    }

                    if (result == MessageBoxResult.Yes)
                    {
                        findUser_btn_2.IsEnabled = false;
                        save_btn.IsEnabled = true;
                        select_cmBox.IsEnabled = false;
                        DatePicker.IsEnabled = true;
                        Date_input_lbl.IsEnabled = true;
                        Time_pick_lbl.IsEnabled = true;
                    }
                    break;
            }
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {


            int caseSwitch = 1;
            switch (caseSwitch)
            {
                case 1: //check if input is valid

                    if (string.IsNullOrWhiteSpace(user1.User_name) || string.IsNullOrWhiteSpace(user1.User_name))
                    {
                        MessageBox.Show("Error! Idividual not selected. Try Again!", "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;

                    }
                    if (DatePicker.SelectedDate == null)
                    {
                        MessageBox.Show("Error! Date not selected. Try Again!", "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;

                    }
                    if (hour_text_box.Text == "Hour" || minute_text_box.Text == "Minute" || string.IsNullOrWhiteSpace(minute_text_box.Text) || string.IsNullOrWhiteSpace(hour_text_box.Text))
                    {
                        MessageBox.Show("Error! Time not selected. Try Again!", "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    }

                    else
                    { goto case 2; }

                case 2: //Time validation and input
                    bool success1 = Int32.TryParse(hour_text_box.Text, out int hours);
                    bool success2 = Int32.TryParse(minute_text_box.Text, out int minutes);

                    if (success1 && success2 && hours >= 0 && hours <= 23 && minutes >= 0 && minutes <= 59)
                    {
                        user1.Event_time = hours + ":" + minutes;

                        if (minutes < 10)
                        {
                            user1.Event_time = String.Empty;
                            string minutes_0 = string.Format("0{0}", minutes);
                            user1.Event_time = hours + ":" + minutes_0;
                        }
                        MessageBoxResult result_time = MessageBox.Show("Is that the correct Time? \n" + user1.Event_time, "Time Validation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result_time == MessageBoxResult.Yes)
                        {
                            goto case 3;
                        }
                        else
                        {
                            user1.Event_time = String.Empty;
                            MessageBox.Show("Please input time again!", "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Time Input! Please Try Again! ", "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    }

                case 3: //date validation and input in CSV
                    string date = DatePicker.SelectedDate.Value.ToString("MM/dd/yyyy");
                    MessageBoxResult result = MessageBox.Show("Is that the correct date? \n" + date, "Date Validation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        user1.Event_date = date;
                        string header = "ContactId,UserName1,UserPhone1,UserName2,UserPhone2,ContactDate,ContactTime";
                        string toCsv = user1.User_name + "," + user1.User_phone + "," + user2.User_name + "," + user2.User_phone + "," + user1.Event_date + "," + user1.Event_time;
                        CsvIO.importCSV("contact.csv", header, toCsv);
                        MessageBox.Show("Contact saved successfuly!");

                        MessageBoxResult again = MessageBox.Show("Contact saved successfuly! \n Do you want to record another contact?", "Dialog", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (again == MessageBoxResult.Yes)
                        {
                            user1.User_name = String.Empty;
                            user1.User_phone = String.Empty;
                            user2.User_name = String.Empty;
                            user2.User_phone = String.Empty;
                            user1.Event_date = String.Empty;
                            user1.Event_time = String.Empty;
                            select_cmBox.IsEnabled = true;
                            phone_inp_txtBox.Text = String.Empty;
                            name_inp_txtBox.Text = String.Empty;
                            hour_text_box.Text = String.Empty;
                            minute_text_box.Text = String.Empty;
                            phone_inp_txtBox_2.Text = String.Empty;
                            name_inp_txtBox_2.Text = String.Empty;
                        }
                        else
                        {
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please try again!", "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    break;
            }
        }

        private void Hour_text_box_MouseEnter(object sender, MouseEventArgs e)
        {
            if (hour_text_box.Text == "Hour")
            {
                hour_text_box.Text = String.Empty;
            }
        }

        private void Minute_text_box_MouseEnter(object sender, MouseEventArgs e)
        {
            if (minute_text_box.Text == "Minute")
            {
                minute_text_box.Text = String.Empty;
            }
        }
    }
}
