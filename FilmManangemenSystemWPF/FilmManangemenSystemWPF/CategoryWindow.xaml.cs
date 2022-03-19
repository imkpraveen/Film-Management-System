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
    /// Interaction logic for CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {
        public CategoryWindow()
        {
            InitializeComponent();
        }

        private void Btn_CategoryAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Category newCategory = new Category();
                newCategory.CategoryName = txtCategoryNameAdd.Text;
                //newActor.ActorLastName = txtLNameAdd.Text;

                bool status = FilmBL.AddCategoryBL(newCategory);

                if (status)
                {
                    MessageBox.Show("Category Added");
                    Tab_CategoryList_Loaded(sender, e);
                    //GetAllStudents();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Unable to Add Category");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); ;
            }
        }
        private void ClearFields()
        {
            txtCategoryNameAdd.Text = "";
            txtCategoryNameUpdate.Text = "";
            txtCategoryIdUpdate.Text = "";
            txtCategoryIDDelete.Text = "";

        }

        private void Btn_CategorySearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Category category = null;
                int id = Convert.ToInt32(txtCategoryIDSearch.Text);
                category = FilmBL.SearchCategoryBL(id);

                if (category != null)
                {
                    MessageBox.Show("Category Found...");
                    lbl_CategoryName.Visibility = 0;
                    txtCategoryNameSearch.Content = category.CategoryName;
                }
                else
                {
                    MessageBox.Show("Unable to Find Category....");
                    txtCategoryIDSearch.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_CategoryUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Category updateCategory = new Category();
                updateCategory.CategoryID = Convert.ToInt32(txtCategoryIdUpdate.Text);
                updateCategory.CategoryName = txtCategoryNameUpdate.Text;
                // updateActor.ActorLastName = txtLNameUpdate.Text;


                bool status = FilmBL.UpdateCategoryBL(updateCategory);

                if (status)
                {
                    MessageBox.Show("Category Updated");
                    ClearFields();
                    Tab_CategoryList_Loaded(sender, e);
                }
                else
                {
                    MessageBox.Show("Unable to Update Category");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_CategoryDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtCategoryIDDelete.Text);
                bool status = FilmBL.DeleteCategoryBL(id);

                if (status)
                {
                    MessageBox.Show("Category Deleted");
                    ClearFields();
                    //GetAllStudents();
                    Tab_CategoryList_Loaded(sender, e);
                }
                else
                {
                    MessageBox.Show("Unable to delete Category");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Tab_CategoryList_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Category> categoryList = FilmBL.GetAllCategoryBL();

                dg_CategoryList.ItemsSource = categoryList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GotoDashboard(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow win = new MainWindow();
            win.Show();
        }

        private void btn_CategoryAddReset_Click(object sender, RoutedEventArgs e)
        {
            txtCategoryNameAdd.Text = "";
        }

        private void btn_CategorySearchReset_Click(object sender, RoutedEventArgs e)
        {
            txtCategoryIDSearch.Text = "";
        }

        private void btn_CategoryUpdateReset_Click(object sender, RoutedEventArgs e)
        {
            txtCategoryIdUpdate.Text = "";
            txtCategoryNameUpdate.Text = "";
        }

        private void btn_CategoryDeleteReset_Click(object sender, RoutedEventArgs e)
        {
            txtCategoryIDDelete.Text = "";
        }
    }
}
