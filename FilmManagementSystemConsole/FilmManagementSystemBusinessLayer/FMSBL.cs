using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmManagementSystemExceptionLayer;
using FilmManagementSystemDAL;
using System.IO;
using FilmManagementSystemEntityLayer;
using static FilmManagementSystemEntityLayer.FMSEntity;

namespace FilmManagementSystemBusinessLayer
{
    /// <summary>
    /// Author : Praveenkumar
    /// Description : This is the Business Layer
    /// Date of Modification :
    /// Employee ID : 186494
    /// </summary>
    public class FMSBL
    {
        #region Validation Film,Actor,Category,Language
        public static bool ValidateFilm(Film film)
        {
            bool result = true;
            StringBuilder sb = new StringBuilder();
            if (film.FilmID < 0)
            {
                result = false;
                sb.Append("FilmID cannot be negative\n");
            }
            if (film.ReleaseYear.ToString() == string.Empty)
            {
                result = false;
                sb.Append("Release Year cannot be blank\n");
            }
            if (film.RentalDuration.ToString() == string.Empty)
            {
                result = false;
                sb.Append("Release Year cannot be blank\n");
            }
            if (film.Description == string.Empty)
            {
                result = false;
                sb.Append("Film Description cannot be blank\n");
            }

            if (film.Title == string.Empty)
            {
                result = false;
                sb.Append("Film Title cannot be blank\n");
            }
            if (film.ReplacementCost.ToString() == string.Empty)
            {
                result = false;
                sb.Append("Replacement Cost cannot be blank\n");
            }
            if (film.LanguageId.ToString() == string.Empty)
            {
                result = false;
                sb.Append("Language ID cannot be blank\n");
            }
            if (film.OriginalLanguageId.ToString() == string.Empty)
            {
                result = false;
                sb.Append("Original Language ID cannot be blank\n");
            }
            if (film.SpecialFeatures == string.Empty)
            {
                result = false;
                sb.Append("Special Features cannot be blank\n");
            }
            if (film.Length.ToString() == string.Empty)
            {
                result = false;
                sb.Append("Length cannot be blank\n");
            }
            if (film.Rating.ToString() == string.Empty)
            {
                result = false;
                sb.Append("Rating cannot be blank\n");
            }
            if (film.LanguageId.ToString() == string.Empty)
            {
                result = false;
                sb.Append("Language ID cannot be blank\n");
            }
            if (film.ReplacementCost < 0)
            {
                result = false;
                sb.Append("Film replacement cost cannot be negative\n");
            }
            if (film.FilmID.ToString() == string.Empty)
            {
                result = false;
                sb.Append("Film ID cannot be blank\n");
            }
            if (film.LanguageId < 0)
            {
                result = false;
                sb.Append("Language Id cannot be negative\n");
            }
            if (film.OriginalLanguageId < 0)
            {
                result = false;
                sb.Append("Original Language Id cannot be negative\n");
            }
            if (film.ActorId.ToString() == string.Empty)
            {
                result = false;
                sb.Append("Actor ID cannot be blank\n");
            }
            if (film.CategoryId.ToString() == string.Empty)
            {
                result = false;
                sb.Append("Category ID cannot be blank\n");
            }
            if (film.ActorId < 0)
            {
                result = false;
                sb.Append("Actor Id cannot be negative\n");
            }
            if (film.CategoryId < 0)
            {
                result = false;
                sb.Append("Category Id cannot be negative\n");
            }
            if (film.Length < 0)
            {
                result = false;
                sb.Append("Length cannot be negative\n");
            }
            if (film.Rating < 0)
            {
                result = false;
                sb.Append("Rating cannot be negative\n");
            }


            if (result == false)
            {
                throw new FMSException(sb.ToString());
            }
            if (result == true)
            {
                film.Length = Math.Round(film.Length, 2);
                film.Rating = Math.Round(film.Rating, 1);
            }
            return result;
        }
        public static bool ValidateActor(Actor actor)
        {
            bool result = true;
            StringBuilder sb = new StringBuilder();
            if (actor.ActorID < 0)
            {
                result = false;
                sb.Append("ActorID cannot be negative");
            }
            if (actor.FilmID < 0)
            {
                result = false;
                sb.Append("FilmID cannot be negative");
            }
            if (actor.ActorFirstName == string.Empty)
            {
                result = false;
                sb.Append("Actor First Name cannot be blank");
            }

            if (actor.ActorLastName == string.Empty)
            {
                result = false;
                sb.Append("Actor Last Name cannot be blank");
            }

            if (result == false)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(sb.ToString());
            }
            return result;
        }
        public static bool ValidateLanguage(Language language)
        {
            bool result = true;
            StringBuilder sb = new StringBuilder();
            if (language.LanguageID < 0)
            {
                result = false;
                sb.Append("LanguageID cannot be negative");
            }
            if (language.LanguageName == string.Empty)
            {
                result = false;
                sb.Append("Language Name cannot be blank");
            }

            if (result == false)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(sb.ToString());
            }
            return result;
        }
        public static bool ValidateCategory(Category category)
        {
            bool result = true;
            StringBuilder sb = new StringBuilder();
            if (category.CategoryID < 0)
            {
                result = false;
                sb.Append("CategoryID cannot be negative");
            }
            if (category.CategoryName == string.Empty)
            {
                result = false;
                sb.Append("Category Name cannot be blank");
            }

            if (result == false)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(sb.ToString());
            }
            return result;
        }
        #endregion
        #region Film
        //Actor Business Layer
        public static bool AddFilmBL(Film film)
        {
            bool filmAdded = false;
            try
            {
                if (ValidateFilm(film))
                {
                    filmAdded = FilmManagementSystemDAL.FMSDAL.AddFilmDAL(film);
                }

            }
            catch (Exception ex)
            {
                throw new FMSException(ex.Message);
            }
            return filmAdded;
        }
        public static bool UpdateFilmBL(Film film)
        {
            bool filmUpdated = false;
            try
            {
                if (ValidateFilm(film))
                {
                    filmUpdated = FilmManagementSystemDAL.FMSDAL.UpdateFilmDAL(film);
                }
            }
            catch (Exception ex)
            {
                throw new FMSException(ex.Message);
            }
            return filmUpdated;
        }
        public static bool DeleteFilmBL(int id)
        {
            bool filmDeleted = false;
            try
            {
                if (id > 0)
                {
                    filmDeleted = FilmManagementSystemDAL.FMSDAL.DeleteFilmDAL(id);
                }
            }
            catch (Exception ex)
            {
                throw new FMSException(ex.StackTrace);
            }
            return filmDeleted;
        }
        public static List<Film> GetAllFilmBL()
        {
            List<Film> filmList = null;

            filmList = FilmManagementSystemDAL.FMSDAL.GetAllFilmDAL();
            return filmList;
        }
        public static Language SearchFilmByLanguageBL(string searchLanguageName)
        {
            Language searchLanguage = null;
            try
            {
                searchLanguage = FilmManagementSystemDAL.FMSDAL.SearchLanguageByNameDAL(searchLanguageName);
            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchLanguage;

        }
        public static Film SearchFilmByNameBL(string searchTitle)
        {
            try
            {
                Film film = null;
                film = FilmManagementSystemDAL.FMSDAL.SearchFilmByNameDAL(searchTitle);
                return film;
            }
            catch (Exception ex)
            {
                throw new FMSException(ex.Message);
            }

        }
        public static Film SearchFilmByActorBL(int searchActor)
        {
            try
            {
                Film film = null;
                film = FilmManagementSystemDAL.FMSDAL.SearchFilmByActorDAL(searchActor);
                return film;
            }
            catch (Exception ex)
            {
                throw new FMSException(ex.Message);
            }

        }
        public static Category SearchFilmByCategoryBL(string searchCategoryName)
        {
            Category searchCategory = null;
            try
            {
                //FilmDAL filmDAL = new FilmDAL();
                searchCategory = FilmManagementSystemDAL.FMSDAL.SearchCategoryByNameDAL(searchCategoryName);
            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchCategory;

        }
        public static Film SearchFilmByCategoryBL(int searchCategory)
        {
            try
            {
                Film film = null;
                film = FilmManagementSystemDAL.FMSDAL.SearchFilmByCategoryDAL(searchCategory);
                return film;
            }
            catch (Exception ex)
            {
                throw new FMSException(ex.Message);
            }

        }
        public static Film SearchFilmByLanguageBL(int searchLanguage)
        {
            try
            {
                Film film = null;
                film = FilmManagementSystemDAL.FMSDAL.SearchFilmByLanguageDAL(searchLanguage);
                return film;
            }
            catch (Exception ex)
            {
                throw new FMSException(ex.Message);
            }

        }
        public static Film SearchFilmByRatingBL(int searchRating)
        {
            try
            {
                Film film = null;
                film = FilmManagementSystemDAL.FMSDAL.SearchFilmByRatingDAL(searchRating);
                return film;
            }
            catch (Exception ex)
            {
                throw new FMSException(ex.Message);
            }

        }
        public static Film SearchFilmByFilmIDBL(int searchFilmID)
        {
            try
            {
                Film film = null;
                film = FilmManagementSystemDAL.FMSDAL.SearchFilmByFilmIDDAL(searchFilmID);
                return film;
            }
            catch (Exception ex)
            {
                throw new FMSException(ex.Message);
            }

        }
        #endregion
        #region Actor
        public static bool AddActorBL(Actor newActor)
        {
            bool ActorAdded = false;
            try
            {
                if (ValidateActor(newActor))
                {
                    //FilmDAL filmDAL = new FilmDAL();
                    ActorAdded = FilmManagementSystemDAL.FMSDAL.AddActorDAL(newActor);
                }
            }
            catch (FilmManagementSystemExceptionLayer.FMSException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ActorAdded;
        }
        public static Actor SearchActorBL(int searchFilmID)
        {
            Actor searchFilm = null;
            try
            {
                //FilmDAL filmDAL = new FilmDAL();
                searchFilm = FilmManagementSystemDAL.FMSDAL.SearchActorDAL(searchFilmID);
            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchFilm;

        }
        public static bool DeleteActorBL(int deleteActorID)
        {
            bool FilmDeleted = false;
            try
            {
                if (deleteActorID > 0)
                {
                    //FilmDAL filmDAL = new FilmDAL();
                    FilmDeleted = FilmManagementSystemDAL.FMSDAL.DeleteActorDAL(deleteActorID);

                }
                else
                {
                    throw new FilmManagementSystemExceptionLayer.FMSException("Invalid Actor ID");
                }
            }
            catch (FilmManagementSystemExceptionLayer.FMSException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return FilmDeleted;
        }
        public static bool UpdateActorBL(Actor updateActor)
        {
            bool FilmUpdated = false;
            try
            {
                if (ValidateActor(updateActor))
                {
                    //FilmDAL filmDAL = new FilmDAL();
                    FilmUpdated = FilmManagementSystemDAL.FMSDAL.UpdateActorDAL(updateActor);
                }
            }
            catch (FilmManagementSystemExceptionLayer.FMSException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return FilmUpdated;
        }
        public static List<Actor> GetAllActorBL()
        {
            List<Actor> ActorList = null;
            try
            {
                //FilmDAL filmDAL = new FilmDAL();
                ActorList = FilmManagementSystemDAL.FMSDAL.GetAllActorDAL();
            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ActorList;
        }
        public static Actor SearchByActorNameBL(string searchActorName)
        {
            Actor searchActor = null;
            try
            {
                searchActor = FilmManagementSystemDAL.FMSDAL.SearchActorByNameDAL(searchActorName);
            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchActor;

        }
        #endregion
        #region Language
        public static bool UpdateLanguageBL(Language updateFilm)
        {
            bool FilmUpdated = false;
            try
            {
                if (ValidateLanguage(updateFilm))
                {
                    //FilmDAL filmDAL = new FilmDAL();
                    FilmUpdated = FilmManagementSystemDAL.FMSDAL.UpdateLanguageDAL(updateFilm);
                }
            }
            catch (FilmManagementSystemExceptionLayer.FMSException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return FilmUpdated;
        }

        public static bool DeleteLanguageBL(int deleteFilmID)
        {
            bool FilmDeleted = false;
            try
            {
                if (deleteFilmID > 0)
                {
                    FilmDeleted = FilmManagementSystemDAL.FMSDAL.DeleteLanguagerDAL(deleteFilmID);

                }
                else
                {
                    throw new FilmManagementSystemExceptionLayer.FMSException("Invalid Language ID");
                }
            }
            catch (FilmManagementSystemExceptionLayer.FMSException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return FilmDeleted;
        }
        public static bool AddLanguageBL(Language newLanguage)
        {
            bool LanguageAdded = false;
            try
            {
                if (ValidateLanguage(newLanguage))
                {
                    //FilmDAL filmDAL = new FilmDAL();
                    LanguageAdded = FilmManagementSystemDAL.FMSDAL.AddLanguageDAL(newLanguage);
                }
            }
            catch (FilmManagementSystemExceptionLayer.FMSException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return LanguageAdded;
        }
        public static List<Language> GetAllLanguageBL()
        {
            List<Language> LanguageList = null;
            try
            {
                //FilmDAL filmDAL = new FilmDAL();
                LanguageList = FilmManagementSystemDAL.FMSDAL.GetAllLanguageDAL();
            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return LanguageList;
        }
        public static Language SearchLanguageBL(int searchFilmID)
        {
            Language searchFilm = null;
            try
            {
                searchFilm = FilmManagementSystemDAL.FMSDAL.SearchLanguageDAL(searchFilmID);
            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchFilm;

        }
        #endregion
        #region Category
        public static Category SearchCategoryBL(int searchFilmID)
        {
            Category searchFilm = null;
            try
            {
                //FilmDAL filmDAL = new FilmDAL();
                searchFilm = FilmManagementSystemDAL.FMSDAL.SearchCategoryDAL(searchFilmID);
            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchFilm;

        }
        public static bool AddCategoryBL(Category newCategory)
        {
            bool CategoryAdded = false;
            try
            {
                if (ValidateCategory(newCategory))
                {
                    //FilmDAL filmDAL = new FilmDAL();
                    CategoryAdded = FilmManagementSystemDAL.FMSDAL.AddCategoryDAL(newCategory);
                }
            }
            catch (FilmManagementSystemExceptionLayer.FMSException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CategoryAdded;
        }
        public static bool UpdateCategoryBL(Category updateFilm)
        {
            bool FilmUpdated = false;
            try
            {
                if (ValidateCategory(updateFilm))
                {
                    //FilmDAL filmDAL = new FilmDAL();
                    FilmUpdated = FilmManagementSystemDAL.FMSDAL.UpdateCategoryDAL(updateFilm);
                }
            }
            catch (FilmManagementSystemExceptionLayer.FMSException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return FilmUpdated;
        }

        public static bool DeleteCategoryBL(int deleteFilmID)
        {
            bool FilmDeleted = false;
            try
            {
                if (deleteFilmID > 0)
                {
                    //FilmDAL filmDAL = new FilmDAL();
                    FilmDeleted = FilmManagementSystemDAL.FMSDAL.DeleteCategoryDAL(deleteFilmID);

                }
                else
                {
                    throw new FilmManagementSystemExceptionLayer.FMSException("Invalid Category ID");
                }
            }
            catch (FilmManagementSystemExceptionLayer.FMSException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return FilmDeleted;
        }
        public static List<Category> GetAllCategoryBL()
        {
            List<Category> CategoryList = null;
            try
            {
                //FilmDAL filmDAL = new FilmDAL();
                CategoryList = FilmManagementSystemDAL.FMSDAL.GetAllCategoryDAL();
            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return CategoryList;
        }
        #endregion
        #region Serialization & DeSerialization
        public static void SetSerialization()
        {

            if (FilmManagementSystemDAL.FMSDAL.filmList != null ||
                FilmManagementSystemDAL.FMSDAL.actorList != null ||
                FilmManagementSystemDAL.FMSDAL.categoryList != null ||
                FilmManagementSystemDAL.FMSDAL.languageList != null
                )
            {
                FilmManagementSystemDAL.FMSDAL.SetSerialization();
            }
        }
        public static void SetList()
        {
            try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\" + FilmManagementSystemDAL.FMSDAL.fileName))
                    FilmManagementSystemDAL.FMSDAL.SetList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
