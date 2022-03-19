using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FilmManangemenSystemWPF
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        SqlConnection conn =
         new SqlConnection(@"Data Source=192.168.1.31,1433;Initial Catalog=20June Dot NetBatch;User ID=sqluser;Password=sqluser");
        SqlCommand cmd;

        public Registration()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
        public void Reset()
        {
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxEmail.Text = "";
            passwordBox1.Password = "";
            passwordBoxConfirm.Password = "";
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxEmail.Text.Length == 0)
            {
                MessageBox.Show("Enter an Email!");
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("Enter a valid Email!");
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {
                string firstname = textBoxFirstName.Text;
                string lastname = textBoxLastName.Text;
                string email = textBoxEmail.Text;
                string password = passwordBox1.Password;
                if (passwordBox1.Password.Length == 0)
                {
                    MessageBox.Show("Enter Password.");
                    passwordBox1.Focus();
                }
                else if (passwordBoxConfirm.Password.Length == 0)
                {
                    MessageBox.Show("Enter Confirm password!");
                    passwordBoxConfirm.Focus();
                }
                else if (passwordBox1.Password != passwordBoxConfirm.Password)
                {
                    MessageBox.Show("Confirm password must be same as password.");
                    passwordBoxConfirm.Focus();
                }
                else
                {
                    cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[PRAVEEN].USP_Registration";
                    cmd.Parameters.AddWithValue("@FirstName", textBoxFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", textBoxLastName.Text);
                    cmd.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                    cmd.Parameters.AddWithValue("@Password", passwordBox1.Password);
                    cmd.Parameters.AddWithValue("@ConfirmPassword", passwordBoxConfirm.Password);
                    cmd.Connection = conn;

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (result > 0)
                    {
                        this.Hide();
                        MessageBox.Show("You have Registered successfully.");
                        Login l = new Login();
                        l.Show();
                    }
                    //Reset();
                }
            }
        }
    }
}

