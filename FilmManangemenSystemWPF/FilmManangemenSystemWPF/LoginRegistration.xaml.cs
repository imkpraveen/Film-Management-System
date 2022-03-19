using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace FilmManangemenSystemWPF
{
    /// <summary>
    /// Interaction logic for LoginRegistration.xaml
    /// </summary>
    public partial class LoginRegistration : Window
    {
        SqlConnection conn =
         new SqlConnection(@"Data Source=192.168.1.31,1433;Initial Catalog=20June Dot NetBatch;Persist Security Info=True;User ID=Sqluser;Password=sqluser");
        SqlCommand cmd;
        public LoginRegistration()
        {
            InitializeComponent();
        }

        private void loginnavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            if (registrationgrid.Visibility == Visibility.Visible)
                registrationgrid.Visibility = Visibility.Hidden;

            logingrid.Visibility = Visibility.Visible;
        }
        private void regnavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            if (logingrid.Visibility == Visibility.Visible)
                logingrid.Visibility = Visibility.Hidden;

            registrationgrid.Visibility = Visibility.Visible;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[PRAVEEN].USP_CheckLogin";
            cmd.Parameters.AddWithValue("@Email", txtemail.Text);
            cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
            cmd.Connection = conn;

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                var newform = new MainWindow();
                newform.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Credientials");
            }

            conn.Close();

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[PRAVEEN].USP_Registration";
            cmd.Parameters.AddWithValue("@Name", txtregname.Text);
            cmd.Parameters.AddWithValue("@Email", txtregemail.Text);
            cmd.Parameters.AddWithValue("@PhoneNo", txtregphoneno.Text);
            cmd.Parameters.AddWithValue("@Password", txtregpassword.Text);
            cmd.Connection = conn;

            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();

            if (result > 0)
            {
                MessageBox.Show("Registration Successful!");
                if (registrationgrid.Visibility == Visibility.Visible)
                    registrationgrid.Visibility = Visibility.Hidden;

                logingrid.Visibility = Visibility.Visible;
            }
            else
                MessageBox.Show("Registration NOT done!");
        }
    }
}
