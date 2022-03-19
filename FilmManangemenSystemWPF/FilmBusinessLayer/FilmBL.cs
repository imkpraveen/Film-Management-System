using EntityClass;
using ExceptionClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmBusinessLayer;
using FilmDataAccessLayer;
using System.Text.RegularExpressions;

namespace FilmBusinessLayer
{
    public class FilmBL
    {
        public static bool ValidateFilm(Film film)
        {
            bool result = true;
            StringBuilder sb = new StringBuilder();
            if (film.FilmID < 0)
            {
                result = false;
                sb.Append("FilmID cannot be negative\n");
            }
            if(!Regex.IsMatch(film.FilmID.ToString(),@"^[0-9]"))
            {
                result = false;
                sb.Append("Film ID should be digits!\n");
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
            if(!Regex.IsMatch(film.Description, @"[A-Z][a-z]+"))
            {
                result = false;
                sb.Append("Description should be only characters!\n");
            }

            if (film.Title == string.Empty)
            {
                result = false;
                sb.Append("Film Title cannot be blank\n");
            }
            if (!Regex.IsMatch(film.Title, @"[A-Z][a-z]+"))
            {
                result = false;
                sb.Append("Film Title should be only characters!\n");
            }
            if (film.ReplacementCost.ToString() == string.Empty)
            {
                result = false;
                sb.Append("Replacement Cost cannot be blank\n");
            }
            if(!Regex.IsMatch(film.ReplacementCost.ToString(),@"^[0-9]"))
            {
                result = false;
                sb.Append("Replacement Cost should be digit only!\n");
            }
            if (film.LanguageId.ToString() == string.Empty)
            {
                result = false;
                sb.Append("Language ID cannot be blank\n");
            }
            if (!Regex.IsMatch(film.LanguageId.ToString(),@"^[0-9]"))
            {
                result = false;
                sb.Append("Language Id should be digit only!\n");
            }
            if (film.Length.ToString() == string.Empty)
            {
                result = false;
                sb.Append("Length cannot be blank\n");
            }
            if (!Regex.IsMatch(film.Length.ToString(),@"^[0-9]"))
            {
                result = false;
                sb.Append("Length should be digit only!\n");
            }
            if (film.Rating.ToString() == string.Empty)
            {
                result = false;
                sb.Append("Rating cannot be blank\n");
            }
            if (!Regex.IsMatch(film.Rating.ToString(),@"^[0-9]"))
            {
                result = false;
                sb.Append("Rating should be digits only!\n");
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
            if (!Regex.IsMatch(film.CategoryId.ToString(),@"^[0-9]"))
            {
                    result = false;
                    sb.Append("Category ID should be digits only!\n");
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
                //film.Length = Math.Round(film.Length, 2);
                result = false;
                sb.Append("Length cannot be negative\n");
            }
            if (film.Rating < 0)
            {
                //film.Length = Math.Round(film.Length, 2);
                result = false;
                sb.Append("Rating cannot be negative\n");
            }


            if (result == false)
            {
                throw new FilmException(sb.ToString());
            }
            if (result == true)
            {
                film.Length = Math.Round(film.Length, 2);
                film.Rating = Math.Round(film.Rating, 1);
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
                sb.Append("LanguageID cannot be negative\n");
            }
            if(!Regex.IsMatch(language.LanguageID.ToString(),@"^[0-9]"))
            {
                result = false;
                sb.Append("Language ID should be digit only!\n");
            }
            if (language.LanguageName == string.Empty)
            {
                result =false;
                sb.Append("Language Name cannot be blank\n");
            }
            if (!Regex.IsMatch(language.LanguageName,@"^[A-Za-z]"))
            {
                result = false;
                sb.Append("Language Name should be character only!\n");
            }
            if (result == false)
            {
                throw new FilmException(sb.ToString());
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
                sb.Append("CategoryID cannot be negative\n");
            }
            if (!Regex.IsMatch(category.CategoryID.ToString(),@"^[0-9]"))
            {
                result = false;
                sb.Append("Category ID should be digit only!\n");
            }
            if (category.CategoryName == string.Empty)
            {
                result = false;
                sb.Append("Category Name cannot be blank\n");
            }
            if (!Regex.IsMatch(category.CategoryName,@"^[A-Za-z]"))
            {
                result = false;
                sb.Append("Category Name should be character only!\n");
            }
            if (result == false)
            {
                throw new FilmException(sb.ToString());
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
                sb.Append("ActorID cannot be negative\n");
            }
            if(!Regex.IsMatch(actor.ActorID.ToString(),@"^[0-9]"))
            {
                result = false;
                sb.Append("Actor ID should be digits only!\n");
            }
            if (actor.ActorFirstName == string.Empty)
            {
                result = false;
                sb.Append("Actor First Name cannot be blank\n");
            }
            if(!Regex.IsMatch(actor.ActorFirstName,@"^[A-Za-z]"))
            {
                result = false;
                sb.Append("Actor First Name should characters only!\n");
            }
            if (actor.ActorLastName == string.Empty)
            {
                result = false;
                sb.Append("Actor Last Name cannot be blank\n");
            }
            if(!Regex.IsMatch(actor.ActorLastName,@"^[A-Za-z]+"))
            {
                result = false;
                sb.Append("Actor Last Name should characters only!\n");
            }
            if (result == false)
            {
                throw new FilmException(sb.ToString());
            }
            return result;
        }
        public static bool AddActorBL(Actor actor)
        {
            bool actorAdded = false;
            try
            {
                if (ValidateActor(actor))
                {
                    actorAdded = FilmDataAccessLayer.FilmDAL.AddActorDAL(actor);
                }

            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return actorAdded;
        }


        public static List<Actor> GetAllActorsBL()
        {
            List<Actor> actorList = null;

            actorList = FilmDataAccessLayer.FilmDAL.GetAllActorsDAL();
            return actorList;
        }


        public static Actor SearchActorBL(int ActorId)
        {
            try
            {
                Actor actor = null;
                actor = FilmDataAccessLayer.FilmDAL.SearchActorDAL(ActorId);
                return actor;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
        }

        public static bool UpdateActorBL(Actor actor)
        {
            bool actorUpdated = false;
            try
            {
                if (ValidateActor(actor))
                {
                    FilmDAL filmDAL = new FilmDAL();
                    actorUpdated = filmDAL.UpdateActorDAL(actor);
                }
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return actorUpdated;
        }

        public static bool DeleteActorBL(int id)
        {
            bool actorDeleted = false;
            try
            {
                if (id > 0)
                {
                    actorDeleted = FilmDAL.DeleteActorDAL(id);
                }
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return actorDeleted;
        }

        //Language BL
        public static bool AddLanguageBL(Language language)
        {
            bool actorAdded = false;
            try
            {
                if (ValidateLanguage(language))
                {
                    actorAdded = FilmDAL.AddLanguageDAL(language);
                }

            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return actorAdded;
        }


        public static List<Language> GetAllLanguagesBL()
        {
            List<Language> languageList = null;

            languageList = FilmDAL.GetAllLanguagesDAL();
            return languageList;
        }


        public static Language SearchLanguageBL(int LanguageId)
        {
            try
            {
                Language language = null;
                language = FilmDAL.SearchLanguageDAL(LanguageId);
                return language;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }

        }

        public static bool UpdateLanguageBL(Language language)
        {
            bool languageUpdated = false;
            try
            {
                if (ValidateLanguage(language))
                {
                    languageUpdated = FilmDAL.UpdateLanguageDAL(language);
                }
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return languageUpdated;
        }

        public static bool DeleteLanguageBL(int id)
        {
            bool languageDeleted = false;
            try
            {
                if (id > 0)
                {
                    languageDeleted = FilmDAL.DeleteLanguageDAL(id);
                }

            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return languageDeleted;
        }


        //Category BL
        public static bool AddCategoryBL(Category category)
        {
            bool categoryAdded = false;
            try
            {
                if (ValidateCategory(category))
                {
                    categoryAdded = FilmDAL.AddCategoryDAL(category);
                }

            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return categoryAdded;
        }


        public static List<Category> GetAllCategoryBL()
        {
            List<Category> categoryList = null;

            categoryList = FilmDAL.GetAllCategoryDAL();
            return categoryList;
        }


        public static Category SearchCategoryBL(int categoryId)
        {
            try
            {
                Category category = null;
                category = FilmDAL.SearchCategoryDAL(categoryId);
                return category;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
        }

        public static bool UpdateCategoryBL(Category category)
        {
            bool categoryUpdated = false;
            try
            {
                if (ValidateCategory(category))
                {
                    categoryUpdated = FilmDAL.UpdateCategoryDAL(category);
                }
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return categoryUpdated;
        }

        public static bool DeleteCategoryBL(int id)
        {
            bool categoryDeleted = false;
            try
            {
                if (id > 0)
                {
                    categoryDeleted = FilmDAL.DeleteCategoryDAL(id);
                }
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return categoryDeleted;
        }


        //Film Table BL
        public static bool AddFilmBL(Film film)
        {
            bool filmAdded = false;
            try
            {
                if (ValidateFilm(film))
                {
                    filmAdded = FilmDAL.AddFilmDAL(film);
                }

            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return filmAdded;
        }

        public static List<Film> GetAllFilmBL()
        {
            List<Film> filmList = null;

            filmList = FilmDAL.GetAllFilmDAL();
            return filmList;
        }


        public static bool UpdateFilmBL(Film film)
        {
            bool filmUpdated = false;
            try
            {
                if (ValidateFilm(film))
                {
                    filmUpdated = FilmDAL.UpdateFilmDAL(film);
                }
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
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
                    filmDeleted = FilmDAL.DeleteFilmDAL(id);
                }
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return filmDeleted;
        }

        public static List<Film> SearchFilmIdBL(int filmId)
        {
            try
            {
                List<Film> filmList = null;
                filmList = FilmDAL.SearchFilmIdDAL(filmId);
                return filmList;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
        }

        public static List<Film> SearchFilmNameBL(string filmName)
        {
            try
            {
                List<Film> filmList = null;
                filmList = FilmDAL.SearchFilmNameDAL(filmName);
                return filmList;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
        }

        public static List<Film> SearchFilmRatingBL(double rating)
        {
            try
            {
                List<Film> filmList = null;
                filmList = FilmDAL.SearchFilmRatingDAL(rating);
                return filmList;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
        }

        public static List<Film> SearchFilmActorNameBL(string actorName)
        {
            try
            {
                List<Film> filmList = null;
                filmList = FilmDAL.SearchFilmActorNameDAL(actorName);
                return filmList;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
        }

        public static List<Film> SearchFilmlanguageNameBL(string langName)
        {
            try
            {
                List<Film> filmList = null;
                filmList = FilmDAL.SearchFilmLangNameDAL(langName);
                return filmList;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
        }

        public static List<Film> SearchFilmcategoryNameBL(string categoryName)
        {
            try
            {
                List<Film> filmList = null;
                filmList = FilmDAL.SearchFilmCategoryNameDAL(categoryName);
                return filmList;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
        }
    }
}

