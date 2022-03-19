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
    /// Interaction logic for FilmWindow.xaml
    /// </summary>
    public partial class FilmWindow : Window
    {
        List<Actor> actorList = FilmBL.GetAllActorsBL();
        public FilmWindow()
        {
            InitializeComponent();
            BindFilm(cb_ActorAdd, cb_CategoryAdd, cb_LanguageAdd);
            BindFilm(cb_ActorUpdate, cb_CategoryUpdate, cb_LanguageUpdate);
        }

        public void BindFilm(ComboBox cbActor, ComboBox cbCategory, ComboBox cbLanguage)
        {
            try
            {

                cbActor.ItemsSource = actorList;
                cbActor.DisplayMemberPath = "ActorFirstName";
                cbActor.SelectedValuePath = "ActorID";
                List<Category> categoryList = FilmBL.GetAllCategoryBL();
                cbCategory.ItemsSource = categoryList;
                cbCategory.DisplayMemberPath = "CategoryName";
                cbCategory.SelectedValuePath = "CategoryID";
                List<Language> languageList = FilmBL.GetAllLanguagesBL();
                cbLanguage.ItemsSource = languageList;
                cbLanguage.DisplayMemberPath = "LanguageName";
                cbLanguage.SelectedValuePath = "LanguageID";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Btn_FilmAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Film newFilm = new Film();
                newFilm.Title = txtFilmTitleAdd.Text;
                newFilm.Description = txtFilmDescAdd.Text;
                newFilm.ReleaseYear = Convert.ToDateTime(dpReleaseYear.Text);
                newFilm.RentalDuration = Convert.ToDateTime(dpRentalDuration.Text);
                newFilm.ReplacementCost = Convert.ToDouble(txtReplaceCostAdd.Text);
                newFilm.Length = Convert.ToDouble(txtLengthAdd.Text);
                newFilm.Rating = Convert.ToDouble(txtRatingAdd.Text);
                newFilm.LanguageId = Convert.ToInt32(cb_LanguageAdd.SelectedValue.ToString());
                newFilm.ActorId = Convert.ToInt32(cb_ActorAdd.SelectedValue.ToString());
                newFilm.CategoryId = Convert.ToInt32(cb_CategoryAdd.SelectedValue.ToString());


                bool status = FilmBL.AddFilmBL(newFilm);

                if (status)
                {
                    MessageBox.Show("Film Added");
                    Tab_FilmList_Loaded(sender, e);
                    //GetAllStudents();

                    //ClearFields();
                }
                else
                {
                    MessageBox.Show("Unable to Add Film");
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message); ;
            }
            //MessageBox.Show(cb_ActorAdd.SelectedValue.ToString());
            //MessageBox.Show(cb_CategoryAdd.SelectedValue.ToString());
            //MessageBox.Show(cb_LanguageAdd.SelectedValue.ToString());

        }

        private void Tab_FilmList_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Film> filmList = FilmBL.GetAllFilmBL();
                foreach (Film film in filmList)
                {
                    //dg_FilmList.Columns[6].SetValue(actorList.Where(f => f.ActorID == film.ActorId)) = .ToString();
                }
                //dg_FilmList.Columns[6]. = from actorname in actorList where actorname.ActorID == ()
                dg_FilmList.ItemsSource = filmList;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Btn_FilmUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Film updateFilm = new Film();
                updateFilm.FilmID = Convert.ToInt32(txtFilmIdUpdate.Text);
                updateFilm.Title = txtFilmTitleUpdate.Text;
                updateFilm.Description = txtFilmDescUpdate.Text;
                updateFilm.ReleaseYear = Convert.ToDateTime(dpReleaseYearUpdate.Text);
                updateFilm.RentalDuration = Convert.ToDateTime(dpRentDurationUpdate.Text);

                updateFilm.ReplacementCost = Convert.ToDouble(txtReplaceCostUpdate.Text);
                updateFilm.Length = Convert.ToDouble(txtLengthUpdate.Text);
                updateFilm.Rating = Convert.ToDouble(txtRatingAdd.Text);
                //MessageBox.Show(cb_LanguageUpdate.SelectedItem.ToString());
                updateFilm.LanguageId = Convert.ToInt32(cb_LanguageUpdate.SelectedItem.ToString());
                updateFilm.ActorId = Convert.ToInt32(cb_ActorUpdate.SelectedItem.ToString());
                updateFilm.CategoryId = Convert.ToInt32(cb_CategoryUpdate.SelectedItem.ToString());


                bool status = FilmBL.UpdateFilmBL(updateFilm);
                    
                if (status)
                {
                    MessageBox.Show("Film Updated");

                    //ClearFields();
                    // GetAllStudents();
                    Tab_FilmList_Loaded(sender, e);
                }
                else
                {
                    MessageBox.Show("Unable to Update Film");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_FilmDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtFilmIDDelete.Text);
                bool status = FilmBL.DeleteFilmBL(id);

                if (status)
                {
                    MessageBox.Show("Film Deleted");
                    //ClearFields();
                    //GetAllStudents();
                    Tab_FilmList_Loaded(sender, e);
                }
                else
                {
                    MessageBox.Show("Unable to delete Film");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void Btn_FilmSearch_Click(object sender, RoutedEventArgs e)
        {
            if (rb_IdSearch.IsChecked == true)
            {
                if (txtSearchName.Text != "")
                {
                    try
                    {
                        List<Film> filmList = null;
                        int id = Convert.ToInt32(txtSearchName.Text);
                        filmList = FilmBL.SearchFilmIdBL(id);

                        if (filmList.Count != 0)
                        {
                            MessageBox.Show("Film Found...");
                            dg_FilmSearchList.ItemsSource = filmList;
                        }
                        else
                        {
                            MessageBox.Show("Unable to Find Film....");
                            txtSearchName.Focusable = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("Please enter the search data in Textbox");
            }



            else if (rb_FilmNameSearch.IsChecked == true)
            {
                if (txtSearchName.Text != "")
                {
                    try
                    {
                        List<Film> filmList = null;
                        string filmName = txtSearchName.Text;
                        filmList = FilmBL.SearchFilmNameBL(filmName);

                        if (filmList.Count != 0)
                        {
                            MessageBox.Show("Film Found...");
                            dg_FilmSearchList.ItemsSource = filmList;
                        }
                        else
                        {
                            MessageBox.Show("Unable to Find Film....");
                            txtSearchName.Focusable = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("Please enter the search data in Textbox");

            }

            else if (rb_ActorNameSearch.IsChecked == true)
            {
                if (txtSearchName.Text != "")
                {
                    try
                    {
                        List<Film> filmList = null;
                        string filmActName = txtSearchName.Text;
                        filmList = FilmBL.SearchFilmActorNameBL(filmActName);

                        if (filmList.Count != 0)
                        {
                            MessageBox.Show("Film Found...");
                            dg_FilmSearchList.ItemsSource = filmList;
                        }
                        else
                        {
                            MessageBox.Show("Unable to Find Film....");
                            txtSearchName.Focusable = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("Please enter the search data in Textbox");

            }


            else if (rb_CategorySearch.IsChecked == true)
            {
                if (txtSearchName.Text != "")
                {
                    try
                    {
                        List<Film> filmList = null;
                        string filmCatName = txtSearchName.Text;
                        filmList = FilmBL.SearchFilmcategoryNameBL(filmCatName);

                        if (filmList.Count != 0)
                        {
                            MessageBox.Show("Film Found...");
                            dg_FilmSearchList.ItemsSource = filmList;
                        }
                        else
                        {
                            MessageBox.Show("Unable to Find Film....");
                            txtSearchName.Focusable = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("Please enter the search data in Textbox");
            }


            else if (rb_LanguageSearch.IsChecked == true)
            {
                if (txtSearchName.Text != "")
                {
                    try
                    {
                        List<Film> filmList = null;
                        string filmLangName = txtSearchName.Text;
                        filmList = FilmBL.SearchFilmlanguageNameBL(filmLangName);

                        if (filmList.Count != 0)
                        {
                            MessageBox.Show("Film Found...");
                            dg_FilmSearchList.ItemsSource = filmList;
                        }
                        else
                        {
                            MessageBox.Show("Unable to Find Film....");
                            txtSearchName.Focusable = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("Please enter the search data in Textbox");

            }

            else if (rb_RatingSearch.IsChecked == true)
            {
                if (txtSearchName.Text != "")
                {
                    try
                    {
                        List<Film> filmList = null;
                        double rating = double.Parse(txtSearchName.Text);
                        filmList = FilmBL.SearchFilmRatingBL(rating);

                        if (filmList.Count != 0)
                        {
                            MessageBox.Show("Film Found...");
                            dg_FilmSearchList.ItemsSource = filmList;
                        }
                        else
                        {
                            MessageBox.Show("Unable to Find Film....");
                            txtSearchName.Focusable = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("Please enter the search data in Textbox");


            }
            else
                MessageBox.Show("Please select the search category");

        }

        private void GotoDashboard(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow win = new MainWindow();
            win.Show();
        }

        private void btn_FilmUpdateReset_Click(object sender, RoutedEventArgs e)
        {
            txtFilmIdUpdate.Text = "";
            txtFilmTitleUpdate.Text = "";
            txtFilmDescUpdate.Text = "";
            dpReleaseYearUpdate.Text = "";
            dpRentDurationUpdate.Text = "";
            txtReplaceCostUpdate.Text = "";
            txtLengthUpdate.Text = "";
            txtRatingUpdate.Text = "";
        }

        private void btn_FilmAddReset_Click(object sender, RoutedEventArgs e)
        {
            txtFilmTitleAdd.Text = "";
            txtFilmDescAdd.Text = "";
            dpReleaseYear.Text = "";
            dpRentalDuration.Text = "";
            txtReplaceCostAdd.Text = "";
            txtLengthAdd.Text = "";
            txtRatingAdd.Text = "";
        }

        private void btn_FilmDeleteReset_Click(object sender, RoutedEventArgs e)
        {
            txtFilmIDDelete.Text = "";
        }

        private void btn_FilmSearchReset_Click(object sender, RoutedEventArgs e)
        {
            txtSearchName.Text = "";
        }
    }
}

