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
    /// Interaction logic for LanguageWindow.xaml
    /// </summary>
    public partial class LanguageWindow : Window
    {
        public LanguageWindow()
        {
            InitializeComponent();
        }

        private void Btn_LanguageAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Language newLanguage = new Language();
                newLanguage.LanguageName = txtLanguageNameAdd.Text;
                //newActor.ActorLastName = txtLNameAdd.Text;

                bool status = FilmBL.AddLanguageBL(newLanguage);

                if (status)
                {
                    MessageBox.Show("Language Added");
                    Tab_LanguageList_Loaded(sender, e);
                    //GetAllStudents();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Unable to Add Language");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); ;
            }
        }

        private void ClearFields()
        {
            txtLanguageNameAdd.Text = "";
            txtLanguageNameUpdate.Text = "";
            txtLanguageIdUpdate.Text = "";
            //txtLanguageIDSearch.Text = "";
            txtLanguageIDDelete.Text = "";
        }

        private void Tab_LanguageList_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Language> languageList = FilmBL.GetAllLanguagesBL();

                dg_LanguageList.ItemsSource = languageList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_LanguageSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Language language = null;
                int id = Convert.ToInt32(txtLanguageIDSearch.Text);
                language = FilmBL.SearchLanguageBL(id);

                if (language != null)
                {
                    MessageBox.Show("Language Found...");
                    lbl_LanguageName.Visibility = 0;
                    txtLanguageNameSearch.Content = language.LanguageName;
                }
                else
                {
                    MessageBox.Show("Unable to Find Language....");
                    txtLanguageIDSearch.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_LanguageUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Language updateLanguage = new Language();
                updateLanguage.LanguageID = Convert.ToInt32(txtLanguageIdUpdate.Text);
                updateLanguage.LanguageName = txtLanguageNameUpdate.Text;
                // updateActor.ActorLastName = txtLNameUpdate.Text;


                bool status = FilmBL.UpdateLanguageBL(updateLanguage);

                if (status)
                {
                    MessageBox.Show("Language Updated");
                    ClearFields();
                    Tab_LanguageList_Loaded(sender, e);
                }
                else
                {
                    MessageBox.Show("Unable to Update Language");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_LanguageDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtLanguageIDDelete.Text);
                bool status = FilmBL.DeleteLanguageBL(id);

                if (status)
                {
                    MessageBox.Show("Language Deleted");
                    ClearFields();
                    //GetAllStudents();
                    Tab_LanguageList_Loaded(sender, e);
                }
                else
                {
                    MessageBox.Show("Unable to delete Language");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GotoDashboard(object sender, RoutedEventArgs e)
        {
            var MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void btn_LanguageAddReset_Click(object sender, RoutedEventArgs e)
        {
            txtLanguageNameAdd.Text = "";
        }

        private void btn_LanguageSearchReset_Click(object sender, RoutedEventArgs e)
        {
            txtLanguageIDSearch.Text = "";
        }

        private void btn_LanguageUpdateReset_Click(object sender, RoutedEventArgs e)
        {
            txtLanguageIdUpdate.Text = "";
            txtLanguageNameUpdate.Text = "";
        }

        private void btn_LanguageDeleteReset_Click(object sender, RoutedEventArgs e)
        {
            txtLanguageIDDelete.Text = "";
        }
    }
}
