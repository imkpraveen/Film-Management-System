using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FilmManagementSystemEntityLayer.FMSEntity;

namespace FilmManagementSystemPresentationLayer
{
    /// <summary>
    /// Author : Praveenkumar
    /// Description : This is the Presentation Layer
    /// Date of Modification :
    /// Employee ID : 186494
    /// </summary>
    class Program
    {
        #region Main Menu
        public static void Main(string[] args)
        {

            int choice;
            do
            {
                PrintMainMenu();
                Console.WriteLine("Enter Choice :");
                choice = Int32.Parse(Console.ReadLine());
                Console.WriteLine(Directory.GetCurrentDirectory() + "");

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Film();
                        break;
                    case 2:
                        Console.Clear();
                        Actor();
                        break;
                    case 3:
                        Console.Clear();
                        Category();
                        break;
                    case 4:
                        Console.Clear();
                        Language();
                        break;
                    case 7:
                        Console.Clear();
                        return;
                    case 5:
                        Console.Clear();
                        SetSerialization();
                        break;
                    case 6:
                        Console.Clear();
                        DeSerialization();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            } while ((choice > 0 && choice < 7));
        }
        private static void PrintMainMenu()
        {
            Console.WriteLine("\n***********Film Management System ***********");
            Console.WriteLine("1. Film Details");
            Console.WriteLine("2. Actor Details");
            Console.WriteLine("3. Category Details");
            Console.WriteLine("4. Language Details");
            Console.WriteLine("5. Serialization");
            Console.WriteLine("6. DeSerialization");
            Console.WriteLine("7. Exit");

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetSerialization();
        }
        #endregion
        #region Film
        private static void Film()
        {
            Console.Clear();
            int choice;
            do
            {
                PrintFilmMenu();
                Console.WriteLine("Enter your Choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddFilm();
                        break;
                    case 2:
                        DisplayFilm();
                        break;
                    case 3:
                        SearchFilm();
                        break;
                    case 4:
                        UpdateFilm();
                        break;
                    case 5:
                        DeleteFilm();
                        break;
                    case 6:
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid Choice.\nPlease enter Correct Choice");
                        break;
                }
            } while (choice != -1);
        }
        private static void PrintFilmMenu()
        {
            Console.WriteLine("\n*********** Film Menu***********");
            Console.WriteLine("1. Add Film");
            Console.WriteLine("2. List All Film");
            Console.WriteLine("3. Search Film");
            Console.WriteLine("4. Update Film");
            Console.WriteLine("5. Delete Film");
            Console.WriteLine("6. Back to Main Menu");
            Console.WriteLine("******************************************\n");

        }
       private static void AddFilm()
        {
            try
            {
                Film newFilm = new Film();
                Console.WriteLine("Enter Film ID :");
                newFilm.FilmID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Description :");
                newFilm.Description = Console.ReadLine();
                Console.WriteLine("Enter Title :");
                newFilm.Title = Console.ReadLine();
                Console.WriteLine("Enter Release Year : ");
                newFilm.ReleaseYear = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter Rental Duration : ");
                newFilm.RentalDuration = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter Replacement Cost");
                newFilm.ReplacementCost = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Language ID : ");
                newFilm.LanguageId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Original Language ID : ");
                newFilm.OriginalLanguageId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Special Features : ");
                newFilm.SpecialFeatures = Console.ReadLine();
                Console.WriteLine("Enter Length");
                newFilm.Length = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Rating");
                newFilm.Rating = int.Parse(Console.ReadLine());
                Console.WriteLine("Actor ID");
                newFilm.ActorId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Category ID : ");
                newFilm.CategoryId = int.Parse(Console.ReadLine());
                bool filmAdded = FilmManagementSystemBusinessLayer.FMSBL.AddFilmBL(newFilm);
                if (filmAdded)
                    Console.WriteLine("Film Added");
                else
                    Console.WriteLine("Film not Added");
            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DisplayFilm()
        {
            try
            {
                List<Film> filmList = FilmManagementSystemBusinessLayer.FMSBL.GetAllFilmBL();
                if (filmList != null && filmList.Count > 0)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("FilmID\tDescription\tTitle\tReleaseYear\tRentalDuration\tReplacementCost\tLanguageId\tOriginalLanguageId\tSpecialFeatures\tLength\tRating\tActorId\tCategoryId");
                    Console.WriteLine("******************************************************************************");
                    foreach (Film film in filmList)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}"
                           , film.FilmID
                           , film.Description
                           , film.Title
                           , film.ReleaseYear
                           , film.RentalDuration
                           , film.ReplacementCost
                           , film.LanguageId
                           , film.OriginalLanguageId
                           , film.SpecialFeatures
                           , film.Length
                           , film.Rating
                           , film.ActorId
                           , film.CategoryId);
                    }
                    Console.WriteLine("******************************************************************************");

                }
                else
                {
                    Console.WriteLine("No Film Details Available");
                }
            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdateFilm()
        {
            try
            {
                int updateFilmID;
                Console.WriteLine("Enter Film ID to Update Details:");
                updateFilmID = Convert.ToInt32(Console.ReadLine());
                Film updatedFilm = FilmManagementSystemBusinessLayer.FMSBL.SearchFilmByFilmIDBL(updateFilmID);
                if (updatedFilm != null)
                {
                    Console.WriteLine("Update Description :");
                    updatedFilm.Description = Console.ReadLine();
                    Console.WriteLine("Update Title :");
                    updatedFilm.Title = Console.ReadLine();
                    Console.WriteLine("Update ReleaseYear :");
                    updatedFilm.ReleaseYear = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Update RentalDuration :");
                    updatedFilm.RentalDuration = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Update ReplacementCost :");
                    updatedFilm.ReplacementCost = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Update LanguageId :");
                    updatedFilm.LanguageId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Update OriginalLanguageId :");
                    updatedFilm.OriginalLanguageId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Update SpecialFeatures :");
                    updatedFilm.SpecialFeatures = Console.ReadLine();
                    Console.WriteLine("Update Length :");
                    updatedFilm.Length = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Update Rating :");
                    updatedFilm.Rating = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Updated Category ID : ");
                    updatedFilm.CategoryId = int.Parse(Console.ReadLine());
                    bool actorUpdated = FilmManagementSystemBusinessLayer.FMSBL.UpdateFilmBL(updatedFilm);
                    if (actorUpdated)
                        Console.WriteLine("Film Details Updated");
                    else
                        Console.WriteLine("Film Details not Updated ");
                }
                else
                {
                    Console.WriteLine("No Film Details Available");
                }


            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void SearchFilm()
        {
            Console.WriteLine("1. Search Film by ID");
            Console.WriteLine("2. Search Film by Title");
            Console.WriteLine("3. Search Film by Actor");
            Console.WriteLine("4. Search Film by Category");
            Console.WriteLine("5. Search Film by Language");
            Console.WriteLine("6. Search Film by Rating");
            Console.WriteLine("7. Search By ");
            int opt = Convert.ToInt32(Console.ReadLine());
            switch(opt)
            {
                case 1:
                    int searchFilmID;
                    Console.WriteLine("Enter Film ID : ");
                    searchFilmID = Convert.ToInt32(Console.ReadLine());
                    Film searchFilm = FilmManagementSystemBusinessLayer.FMSBL.SearchFilmByFilmIDBL(searchFilmID);
                    if (searchFilm != null)
                    {
                        Console.WriteLine("******************************************************************************");
                        Console.WriteLine("FilmID\t\tDescription\t\tTitle\t\tReleaseYear\t\tRentalDuration\t\tReplacementCost\t\tLanguageId\t\tOriginalLanguageId\t\tSpecialFeatures\t\tLength\t\tRating\t\tActorId\t\tCategoryId");
                        Console.WriteLine("******************************************************************************");
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t\t{6}\t\t{7}\t\t{8}\t\t{9}\t\t{10}\t\t{11}\t\t{12}"
                               , searchFilm.FilmID
                               , searchFilm.Description
                               , searchFilm.Title
                               , searchFilm.ReleaseYear
                               , searchFilm.RentalDuration
                               , searchFilm.ReplacementCost
                               , searchFilm.LanguageId
                               , searchFilm.OriginalLanguageId
                               , searchFilm.SpecialFeatures
                               , searchFilm.Length
                               , searchFilm.Rating
                               , searchFilm.ActorId
                               , searchFilm.CategoryId);
                        Console.WriteLine("******************************************************************************");
                    }
                    else
                    {
                        Console.WriteLine("No Film Details Available");
                    }
                    break;
                case 2:
                    string searchFilmTitle;
                    Console.WriteLine("Enter Film Title to Search:");
                    searchFilmTitle = Console.ReadLine();
                    Film searchFilmName = FilmManagementSystemBusinessLayer.FMSBL.SearchFilmByNameBL(searchFilmTitle);
                    if (searchFilmTitle != null)
                    {
                        Console.WriteLine("******************************************************************************");
                        Console.WriteLine("FilmID\t\tDescription\t\tTitle\t\tReleaseYear\t\tRentalDuration\t\tReplacementCost\t\tLanguageId\t\tOriginalLanguageId\t\tSpecialFeatures\t\tLength\t\tRating\t\tActorId\t\tCategoryId");
                        Console.WriteLine("******************************************************************************");
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t\t{6}\t\t{7}\t\t{8}\t\t{9}\t\t{10}\t\t{11}\t\t{12}"
                               , searchFilmName.FilmID
                               , searchFilmName.Description
                               , searchFilmName.Title
                               , searchFilmName.ReleaseYear
                               , searchFilmName.RentalDuration
                               , searchFilmName.ReplacementCost
                               , searchFilmName.LanguageId
                               , searchFilmName.OriginalLanguageId
                               , searchFilmName.SpecialFeatures
                               , searchFilmName.Length
                               , searchFilmName.Rating
                               , searchFilmName.ActorId
                               , searchFilmName.CategoryId);
                        Console.WriteLine("******************************************************************************");
                    }
                    else
                    {
                        Console.WriteLine("No Film Details Available");
                    }
                    break;
                case 3:
                    int searchActorId;
                    Console.WriteLine("Enter Actor ID to Search:");
                    searchActorId = int.Parse(Console.ReadLine());
                    Film searchFilmActor = FilmManagementSystemBusinessLayer.FMSBL.SearchFilmByActorBL(searchActorId);
                    if (searchFilmActor != null)
                    {
                        Console.WriteLine("******************************************************************************");
                        Console.WriteLine("FilmID\t\tDescription\t\tTitle\t\tReleaseYear\t\tRentalDuration\t\tReplacementCost\t\tLanguageId\t\tOriginalLanguageId\t\tSpecialFeatures\t\tLength\t\tRating\t\tActorId\t\tCategoryId");
                        Console.WriteLine("******************************************************************************");
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t\t{6}\t\t{7}\t\t{8}\t\t{9}\t\t{10}\t\t{11}\t\t{12}"
                               , searchFilmActor.FilmID
                               , searchFilmActor.Description
                               , searchFilmActor.Title
                               , searchFilmActor.ReleaseYear
                               , searchFilmActor.RentalDuration
                               , searchFilmActor.ReplacementCost
                               , searchFilmActor.LanguageId
                               , searchFilmActor.OriginalLanguageId
                               , searchFilmActor.SpecialFeatures
                               , searchFilmActor.Length
                               , searchFilmActor.Rating
                               , searchFilmActor.ActorId
                               , searchFilmActor.CategoryId);
                        Console.WriteLine("******************************************************************************");
                    }
                    else
                    {
                        Console.WriteLine("No Film Details Available");
                    }
                    break;
                case 4:
                    int searchCategoryId;
                    Console.WriteLine("Enter Category ID to Search:");
                    searchCategoryId = int.Parse(Console.ReadLine());
                    Film searchFilmCategory = FilmManagementSystemBusinessLayer.FMSBL.SearchFilmByCategoryBL(searchCategoryId);
                    if (searchFilmCategory != null)
                    {
                        Console.WriteLine("******************************************************************************");
                        Console.WriteLine("FilmID\t\tDescription\t\tTitle\t\tReleaseYear\t\tRentalDuration\t\tReplacementCost\t\tLanguageId\t\tOriginalLanguageId\t\tSpecialFeatures\t\tLength\t\tRating\t\tActorId\t\tCategoryId");
                        Console.WriteLine("******************************************************************************");
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t\t{6}\t\t{7}\t\t{8}\t\t{9}\t\t{10}\t\t{11}\t\t{12}"
                               , searchFilmCategory.FilmID
                               , searchFilmCategory.Description
                               , searchFilmCategory.Title
                               , searchFilmCategory.ReleaseYear
                               , searchFilmCategory.RentalDuration
                               , searchFilmCategory.ReplacementCost
                               , searchFilmCategory.LanguageId
                               , searchFilmCategory.OriginalLanguageId
                               , searchFilmCategory.SpecialFeatures
                               , searchFilmCategory.Length
                               , searchFilmCategory.Rating
                               , searchFilmCategory.ActorId
                               , searchFilmCategory.CategoryId);
                        Console.WriteLine("******************************************************************************");
                    }
                    else
                    {
                        Console.WriteLine("No Film Details Available");
                    }
                    break;
                case 5:
                    int searchLanguageId;
                    Console.WriteLine("Enter Language ID to Search:");
                    searchLanguageId = int.Parse(Console.ReadLine());
                    Film searchFilmLang = FilmManagementSystemBusinessLayer.FMSBL.SearchFilmByLanguageBL(searchLanguageId);
                    if (searchFilmLang != null)
                    {
                        Console.WriteLine("******************************************************************************");
                        Console.WriteLine("FilmID\t\tDescription\t\tTitle\t\tReleaseYear\t\tRentalDuration\t\tReplacementCost\t\tLanguageId\t\tOriginalLanguageId\t\tSpecialFeatures\t\tLength\t\tRating\t\tActorId\t\tCategoryId");
                        Console.WriteLine("******************************************************************************");
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t\t{6}\t\t{7}\t\t{8}\t\t{9}\t\t{10}\t\t{11}\t\t{12}"
                               , searchFilmLang.FilmID
                               , searchFilmLang.Description
                               , searchFilmLang.Title
                               , searchFilmLang.ReleaseYear
                               , searchFilmLang.RentalDuration
                               , searchFilmLang.ReplacementCost
                               , searchFilmLang.LanguageId
                               , searchFilmLang.OriginalLanguageId
                               , searchFilmLang.SpecialFeatures
                               , searchFilmLang.Length
                               , searchFilmLang.Rating
                               , searchFilmLang.ActorId
                               , searchFilmLang.CategoryId);
                        Console.WriteLine("******************************************************************************");
                    }
                    else
                    {
                        Console.WriteLine("No Film Details Available");
                    }
                    break;
                case 6:
                    int searchRating;
                    Console.WriteLine("Enter Rating to Search:");
                    searchRating = int.Parse(Console.ReadLine());
                    Film searchFilmRating = FilmManagementSystemBusinessLayer.FMSBL.SearchFilmByRatingBL(searchRating);
                    if (searchFilmRating != null)
                    {
                        Console.WriteLine("******************************************************************************");
                        Console.WriteLine("FilmID\t\tDescription\t\tTitle\t\tReleaseYear\t\tRentalDuration\t\tReplacementCost\t\tLanguageId\t\tOriginalLanguageId\t\tSpecialFeatures\t\tLength\t\tRating\t\tActorId\t\tCategoryId");
                        Console.WriteLine("******************************************************************************");
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t\t{6}\t\t{7}\t\t{8}\t\t{9}\t\t{10}\t\t{11}\t\t{12}"
                               , searchFilmRating.FilmID
                               , searchFilmRating.Description
                               , searchFilmRating.Title
                               , searchFilmRating.ReleaseYear
                               , searchFilmRating.RentalDuration
                               , searchFilmRating.ReplacementCost
                               , searchFilmRating.LanguageId
                               , searchFilmRating.OriginalLanguageId
                               , searchFilmRating.SpecialFeatures
                               , searchFilmRating.Length
                               , searchFilmRating.Rating
                               , searchFilmRating.ActorId
                               , searchFilmRating.CategoryId);
                        Console.WriteLine("******************************************************************************");
                    }
                    else
                    {
                        Console.WriteLine("No Film Details Available");
                    }
                    break;
                default:
                    Console.WriteLine("Wrong option.");
                    break;
            }
        }
        private static void DeleteFilm()
        {
            try
            {
                int deletefilmid;
                Console.WriteLine("Enter Film ID to delete:");
                deletefilmid = Convert.ToInt32(Console.ReadLine());
                bool employeeDeleted = FilmManagementSystemBusinessLayer.FMSBL.DeleteFilmBL(deletefilmid);
                if (employeeDeleted)
                    Console.WriteLine("Film Deleted");
                else
                    Console.WriteLine("Film NOT Deleted ");


            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        #endregion
        #region Actor
        private static void Actor()
        {
            Console.Clear();
            int choice;
            do
            {
                PrintActorMenu();
                Console.WriteLine("Enter your Choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddActor();
                        break;
                    case 2:
                        SearchActorByName();
                        break;
                    case 3:
                        DeleteActor();
                        break;
                    case 4:
                        UpdateActor();
                        break;
                    case 5:
                        ListAllActor();
                        break;
                    case 6:
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != -1);
        }
        private static void ListAllActor()
        {
            try
            {
                List<Actor> ActorList = FilmManagementSystemBusinessLayer.FMSBL.GetAllActorBL();
                if (ActorList != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("ActorID\t\tActor First Name\t\tActor Last Name");
                    Console.WriteLine("******************************************************************************");
                    foreach (Actor searchActor in ActorList)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}", searchActor.ActorID, searchActor.ActorFirstName, searchActor.ActorLastName);
                    }
                    Console.WriteLine("******************************************************************************");

                }
                else
                {
                    Console.WriteLine("No Actor Details Available");
                }
            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void AddActor()
        {
            try
            {
                Actor newActor = new Actor();
                Console.WriteLine("Enter ActorID :");
                newActor.ActorID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Actor First Name");
                newActor.ActorFirstName = Console.ReadLine();
                Console.WriteLine("Enter Actor Last Name");
                newActor.ActorLastName = Console.ReadLine();

                bool ActorAdded = FilmManagementSystemBusinessLayer.FMSBL.AddActorBL(newActor);
                if (ActorAdded)
                    Console.WriteLine("Actor Added");
                else
                    Console.WriteLine("Actor not Added");
            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void SearchActorByName()
        {
            try
            {
                string searchActorName;
                Console.WriteLine("Enter Actor Name to Search:");
                searchActorName = Console.ReadLine();
                Actor searchActor = FilmManagementSystemBusinessLayer.FMSBL.SearchByActorNameBL(searchActorName);
                if (searchActor != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("ActorID\t\tActor First Name\t\tActor Last Name");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}", searchActor.ActorID, searchActor.ActorFirstName, searchActor.ActorLastName);
                    Console.WriteLine("******************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Actor Details Available");
                }

            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void DeleteActor()
        {
            try
            {
                int deleteFilmID;
                Console.WriteLine("Enter ActorID to Delete:");
                deleteFilmID = Convert.ToInt32(Console.ReadLine());
                Actor deleteFilm = FilmManagementSystemBusinessLayer.FMSBL.SearchActorBL(deleteFilmID);
                if (deleteFilm != null)
                {
                    bool Filmdeleted = FilmManagementSystemBusinessLayer.FMSBL.DeleteActorBL(deleteFilmID);
                    if (Filmdeleted)
                        Console.WriteLine("Actor Deleted");
                    else
                        Console.WriteLine("Actor not Deleted ");
                }
                else
                {
                    Console.WriteLine("No Actor Details Available");
                }


            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void UpdateActor()
        {
            try
            {
                int updateActorID;
                Console.WriteLine("Enter ActorID to Update Details:");
                updateActorID = Convert.ToInt32(Console.ReadLine());
                Actor updatedFilm = FilmManagementSystemBusinessLayer.FMSBL.SearchActorBL(updateActorID);
                if (updatedFilm != null)
                {
                    Console.WriteLine("Update Actor First name :");
                    updatedFilm.ActorFirstName = Console.ReadLine();
                    Console.WriteLine("Update Actor Last Name :");
                    updatedFilm.ActorLastName = Console.ReadLine();

                    bool FilmUpdated = FilmManagementSystemBusinessLayer.FMSBL.UpdateActorBL(updatedFilm);
                    if (FilmUpdated)
                        Console.WriteLine("Actor Details Updated");
                    else
                        Console.WriteLine("Actor Details not Updated ");
                }
                else
                {
                    Console.WriteLine("No Actor Details Available");
                }


            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void PrintActorMenu()
        {
            Console.WriteLine("\n*********** Actor Menu***********");
            Console.WriteLine("1. Add Actor");
            Console.WriteLine("2. Search Actor by Name");
            Console.WriteLine("3. Delete Actor");
            Console.WriteLine("4. Update Actor");
            Console.WriteLine("5. List All Actors");
            Console.WriteLine("6. Back to Main Menu");
            Console.WriteLine("******************************************\n");

        }
        #endregion
        #region Category
        private static void Category()
        {
            Console.Clear();
            int choice;
            do
            {
                PrintCategoryMenu();
                Console.WriteLine("Enter your Choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddCategory();
                        break;

                    case 6:
                        Console.Clear();
                        return;
                    case 2:
                        SearchCategoryByName();
                        break;

                    case 3:
                        DeleteCategory();
                        break;
                    case 4:
                        UpdateCategory();
                        break;
                    case 5:
                        ListAllCategory();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != -1);
        }
        private static void SearchCategoryByName()
        {
            try
            {
                string searchCategoryName;
                Console.WriteLine("Enter Category to Search:");
                searchCategoryName = Console.ReadLine();
                Category searchCategory = FilmManagementSystemBusinessLayer.FMSBL.SearchFilmByCategoryBL(searchCategoryName);
                if (searchCategory != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("CategoryID\t\tCategory Name");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}", searchCategory.CategoryID, searchCategory.CategoryName);
                    Console.WriteLine("******************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Category Details Available");
                }

            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }




        private static void AddCategory()
        {
            try
            {
                Category newCategory = new Category();
                Console.WriteLine("Enter CategoryID :");
                newCategory.CategoryID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Category Name");
                newCategory.CategoryName = Console.ReadLine();


                bool CategoryAdded = FilmManagementSystemBusinessLayer.FMSBL.AddCategoryBL(newCategory);
                if (CategoryAdded)
                    Console.WriteLine("Category Added");
                else
                    Console.WriteLine("Category not Added");
            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static void UpdateCategory()
        {
            try
            {
                int updateActorID;
                Console.WriteLine("Enter CategoryID to Update Details:");
                updateActorID = Convert.ToInt32(Console.ReadLine());
                Category updatedFilm = FilmManagementSystemBusinessLayer.FMSBL.SearchCategoryBL(updateActorID);
                if (updatedFilm != null)
                {
                    Console.WriteLine("Update Category name :");
                    updatedFilm.CategoryName = Console.ReadLine();

                    bool FilmUpdated = FilmManagementSystemBusinessLayer.FMSBL.UpdateCategoryBL(updatedFilm);
                    if (FilmUpdated)
                        Console.WriteLine("Category Details Updated");
                    else
                        Console.WriteLine("Category Details not Updated ");
                }
                else
                {
                    Console.WriteLine("No Category Details Available");
                }


            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static void DeleteCategory()
        {
            try
            {
                int deleteFilmID;
                Console.WriteLine("Enter CategoryID to Delete:");
                deleteFilmID = Convert.ToInt32(Console.ReadLine());
                Category deleteFilm = FilmManagementSystemBusinessLayer.FMSBL.SearchCategoryBL(deleteFilmID);
                if (deleteFilm != null)
                {
                    bool Filmdeleted = FilmManagementSystemBusinessLayer.FMSBL.DeleteCategoryBL(deleteFilmID);
                    if (Filmdeleted)
                        Console.WriteLine("Category Deleted");
                    else
                        Console.WriteLine("Category not Deleted ");
                }
                else
                {
                    Console.WriteLine("No Category Details Available");
                }
            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ListAllCategory()
        {
            try
            {
                List<Category> ActorList = FilmManagementSystemBusinessLayer.FMSBL.GetAllCategoryBL();
                if (ActorList != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("CategoryID\t\tCategory Name");
                    Console.WriteLine("******************************************************************************");
                    foreach (Category searchCategory in ActorList)
                    {
                        Console.WriteLine("{0}\t\t{1}", searchCategory.CategoryID, searchCategory.CategoryName);
                    }
                    Console.WriteLine("******************************************************************************");

                }
                else
                {
                    Console.WriteLine("No Category Details Available");
                }
            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void PrintCategoryMenu()
        {
            Console.WriteLine("\n*********** Category Details***********");
            Console.WriteLine("1. Add Category");
            Console.WriteLine("2. Search Category by Name");
            Console.WriteLine("3. Delete Category");
            Console.WriteLine("4. Update Category");
            Console.WriteLine("5. List All Categorys");
            Console.WriteLine("6. Back To Main Menu");
            Console.WriteLine("******************************************\n");

        }
        #endregion
        #region Language
        private static void Language()
        {
            Console.Clear();
            int choice;
            do
            {
                PrintLanguageMenu();
                Console.WriteLine("Enter your Choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddLanguage();
                        break;

                    case 6:
                        Console.Clear();
                        return;
                    case 2:
                        SearchLanguageByName();
                        break;
                    case 3:
                        DeleteLanguage();
                        break;
                    case 4:
                        UpdateLanguage();
                        break;
                    case 5:
                        ListAllLanguage();
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != -1);
        }



        private static void SearchLanguageByName()
        {
            try
            {
                string searchLanguageName;
                Console.WriteLine("Enter Language Name to Search:");
                searchLanguageName = Console.ReadLine();
                Language searchLanguage = FilmManagementSystemBusinessLayer.FMSBL.SearchFilmByLanguageBL(searchLanguageName);
                if (searchLanguage != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("LanguageID\t\tLanguage Name");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}", searchLanguage.LanguageID, searchLanguage.LanguageName);
                    Console.WriteLine("******************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Language Details Available");
                }

            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }




        private static void AddLanguage()
        {
            try
            {
                Language newLanguage = new Language();
                Console.WriteLine("Enter LanguageID :");
                newLanguage.LanguageID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Language Name");
                newLanguage.LanguageName = Console.ReadLine();


                bool LanguageAdded = FilmManagementSystemBusinessLayer.FMSBL.AddLanguageBL(newLanguage);
                if (LanguageAdded)
                    Console.WriteLine("Language Added");
                else
                    Console.WriteLine("Language not Added");
            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdateLanguage()
        {
            try
            {
                int updateActorID;
                Console.WriteLine("Enter LanguageID to Update Details:");
                updateActorID = Convert.ToInt32(Console.ReadLine());
                Language updatedFilm = FilmManagementSystemBusinessLayer.FMSBL.SearchLanguageBL(updateActorID);
                if (updatedFilm != null)
                {
                    Console.WriteLine("Update Language name :");
                    updatedFilm.LanguageName = Console.ReadLine();

                    bool FilmUpdated = FilmManagementSystemBusinessLayer.FMSBL.UpdateLanguageBL(updatedFilm);
                    if (FilmUpdated)
                        Console.WriteLine("Language Details Updated");
                    else
                        Console.WriteLine("Language Details not Updated ");
                }
                else
                {
                    Console.WriteLine("No Language Details Available");
                }


            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static void DeleteLanguage()
        {
            try
            {
                int deleteFilmID;
                Console.WriteLine("Enter LanguageID to Delete:");
                deleteFilmID = Convert.ToInt32(Console.ReadLine());
                Language deleteFilm = FilmManagementSystemBusinessLayer.FMSBL.SearchLanguageBL(deleteFilmID);
                if (deleteFilm != null)
                {
                    bool Filmdeleted = FilmManagementSystemBusinessLayer.FMSBL.DeleteLanguageBL(deleteFilmID);
                    if (Filmdeleted)
                        Console.WriteLine("Language Deleted");
                    else
                        Console.WriteLine("Language not Deleted ");
                }
                else
                {
                    Console.WriteLine("No Language Details Available");
                }
            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ListAllLanguage()
        {
            try
            {
                List<Language> ActorList = FilmManagementSystemBusinessLayer.FMSBL.GetAllLanguageBL();
                if (ActorList != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("LanguageID\t\tLanguage Name");
                    Console.WriteLine("******************************************************************************");
                    foreach (Language searchCategory in ActorList)
                    {
                        Console.WriteLine("{0}\t\t{1}", searchCategory.LanguageID, searchCategory.LanguageName);
                    }
                    Console.WriteLine("******************************************************************************");

                }
                else
                {
                    Console.WriteLine("No Language Details Available");
                }
            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintLanguageMenu()
        {
            Console.WriteLine("\n*********** Language Menu***********");
            Console.WriteLine("1. Add Language");
            Console.WriteLine("2. Search Language by Name");
            Console.WriteLine("3. Delete Language");
            Console.WriteLine("4. Update Language");
            Console.WriteLine("5. List All Language");
            Console.WriteLine("6. Back To Main Menu");
            Console.WriteLine("******************************************\n");

        }
        #endregion Language
        #region Serialization & DeSerialization
        private static void SetSerialization()
        {
            FilmManagementSystemBusinessLayer.FMSBL.SetSerialization();
            Console.WriteLine("Serailization Done.");
        }
        private static void DeSerialization()
        {
            FilmManagementSystemBusinessLayer.FMSBL.SetList();
            Console.WriteLine("DeSerailization Done.");
        }
        #endregion
    }
}


