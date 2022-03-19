using EntityClass;
using FilmBusinessLayer;
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

namespace FilmManangemenSystemWPF
{
    /// <summary>
    /// Interaction logic for ActorWindow.xaml
    /// </summary>
    public partial class ActorWindow : Window
    {
        public ActorWindow()
        {
            InitializeComponent();
        }

        private void Btn_ActorAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Actor newActor = new EntityClass.Actor();
                newActor.ActorFirstName = txtFNameAdd.Text;
                newActor.ActorLastName = txtLNameAdd.Text;

                bool status = FilmBL.AddActorBL(newActor);

                if (status)
                {
                    MessageBox.Show("Actor Added");
                    Tab_List_Loaded(sender, e);
                    //GetAllStudents();

                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Unable to Add Actor");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); ;
            }
        }
        private void ClearFields()
        {
            txtLNameAdd.Text = "";
            txtFNameAdd.Text = "";
            txtIdUpdate.Text = "";
            txtIDDelete.Text = "";
            txtLNameUpdate.Text = "";
            txtFNameUpdate.Text = "";
        }
        private void Tab_List_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Actor> actorList = FilmBL.GetAllActorsBL();

                dg_ActorList.ItemsSource = actorList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Btn_ActorSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Actor actor = null;
                int id = Convert.ToInt32(txtIDSearch.Text);
                actor = FilmBL.SearchActorBL(id);

                if (actor != null)
                {
                    MessageBox.Show("Actor Found...");
                    lbl_Fname.Visibility = 0;
                    lbl_Lname.Visibility = 0;
                    txtFNameSearch.Content = actor.ActorFirstName;
                    txtLNameSearch.Content = actor.ActorLastName;

                }
                else
                {
                    MessageBox.Show("Unable to Find Actor....");
                    txtIDSearch.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_ActorUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Actor updateActor = new Actor();
                updateActor.ActorID = Convert.ToInt32(txtIdUpdate.Text);
                updateActor.ActorFirstName = txtFNameUpdate.Text;
                updateActor.ActorLastName = txtLNameUpdate.Text;


                bool status = FilmBL.UpdateActorBL(updateActor);

                if (status)
                {
                    MessageBox.Show("Actor Updated");

                    ClearFields();
                    // GetAllStudents();
                    Tab_List_Loaded(sender, e);
                }
                else
                {
                    MessageBox.Show("Unable to Update Actor");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_ActorDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(txtIDDelete.Text);
                bool status = FilmBL.DeleteActorBL(id);

                if (status)
                {
                    MessageBox.Show("Actor Deleted");
                    ClearFields();
                    //GetAllStudents();
                    Tab_List_Loaded(sender, e);
                }
                else
                {
                    MessageBox.Show("Unable to delete Actor");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
           private void GotoDashboard(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow win = new MainWindow();
            win.Show();
        }

        private void btn_ActorAddReset_Click(object sender, RoutedEventArgs e)
        {
            txtFNameAdd.Text = "";
            txtLNameAdd.Text = "";
        }

        private void btn_AcorSearchReset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_ActorUpdateReset_Click(object sender, RoutedEventArgs e)
        {
            txtFNameUpdate.Text = "";
            txtLNameUpdate.Text = "";
            txtIdUpdate.Text = "";
        }

        private void btn_ActorDeleteReset_Click(object sender, RoutedEventArgs e)
        {
            txtIDDelete.Text = "";
        }
    }
}
