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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        SqlConnection conn =
         new SqlConnection(@"Data Source=192.168.1.31,1433;Initial Catalog=20June Dot NetBatch;User ID=sqluser;Password=sqluser");
        SqlCommand cmd;
        public Login()
        {
            InitializeComponent();
        }
        Registration registration = new Registration();
        MainWindow mainWindow = new MainWindow();
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxEmail.Text.Length == 0)
            {
                MessageBox.Show("Please Enter an Email!");
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("Enter a valid Email!");
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            if (passwordBox1.Password.Length == 0)
            {
                MessageBox.Show("Please Enter Password!");
                textBoxEmail.Focus();
            }
            else
            {
                string email = textBoxEmail.Text;
                string password = passwordBox1.Password;
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[PRAVEEN].USP_CheckLogin";
                cmd.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                cmd.Parameters.AddWithValue("@Password", passwordBox1.Password);
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        mainWindow.UserName.Text = dr.GetString(1) + " " + dr.GetString(2);
                        mainWindow.Show();
                        this.Close();
                    }
                    //var newform = new MainWindow();
                    //newform.Show();
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Credientials!");
                }

                conn.Close();
            }
        }
        private void ChkShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            MyTextBox.Visibility = Visibility.Visible;
            MyTextBox.Text = passwordBox1.Password;
            passwordBox1.Visibility = Visibility.Collapsed;
        }

        private void ChkShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            MyTextBox.Visibility = Visibility.Collapsed;
            passwordBox1.Password = MyTextBox.Text;
           passwordBox1.Visibility = Visibility.Visible;
        }
        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            registration.Show();
            Close();
        }
    }
} 

