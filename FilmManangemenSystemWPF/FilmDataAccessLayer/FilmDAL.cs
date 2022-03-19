using EntityClass;
using ExceptionClass;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDataAccessLayer
{
    public class FilmDAL
    {
        public static SqlCommand CreateCommand()
        {
            SqlCommand cmd = null;

            try
            {

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["filmconn"].ConnectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return cmd;
        }
        
        //Actor table 
        public static bool AddActorDAL(Actor actor)
        {
            bool actorAdded = false;
            SqlCommand cmd = CreateCommand();

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_ActorAdd";
                cmd.Parameters.AddWithValue("@ActorFName", actor.ActorFirstName);
                cmd.Parameters.AddWithValue("@ActorLName", actor.ActorLastName);

                //cmd.Connection = conn;
                cmd.Connection.Open();
                int result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                if (result > 0)
                    actorAdded = true;
                
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            
            return actorAdded;
        }


        public static List<Actor> GetAllActorsDAL()
        {
            List<Actor> actorlist = null;
            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_ActorDisplayAll";
                cmd.Connection.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                actorlist = new List<Actor>();
                while (dr.Read())
                {
                    Actor actor = new Actor();
                    //Debug.Print(dr.GetInt32(0).ToString());

                    actor.ActorID = dr.GetInt32(0);
                    actor.ActorFirstName = dr.GetString(1);
                    actor.ActorLastName = dr.GetString(2);

                    actorlist.Add(actor);
                }
                cmd.Connection.Close();
                return actorlist;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
        }


        public static Actor SearchActorDAL(int id)
        {
            try
            {
                Actor actor = null;
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_ActorSearch";
                cmd.Parameters.AddWithValue("@ActorId", id);
                actor = new Actor();
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    actor.ActorID = dr.GetInt32(0);
                    actor.ActorFirstName = dr.GetString(1);
                    actor.ActorLastName = dr.GetString(2);

                }
                cmd.Connection.Close();
                return actor;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
        }

        public bool UpdateActorDAL(Actor actor)
        {
            bool actorUpdated = false;

            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_ActorUpdate";
                cmd.Parameters.AddWithValue("@ActorID", actor.ActorID);
                cmd.Parameters.AddWithValue("@ActorFName", actor.ActorFirstName);
                cmd.Parameters.AddWithValue("@ActorLName", actor.ActorLastName);
                cmd.Connection.Open();

                int result = cmd.ExecuteNonQuery();

                cmd.Connection.Close();

                if (result > 0)
                    actorUpdated = true;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return actorUpdated;
        }

        public static bool DeleteActorDAL(int id)
        {
            bool actorDeleted = false;
            try
            {
                SqlCommand cmd = CreateCommand();
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_ActorDelete";
                cmd.Parameters.AddWithValue("@ActorId", id);
                cmd.Connection.Open();

                int result = cmd.ExecuteNonQuery();

                cmd.Connection.Close();

                if (result > 0)
                    actorDeleted = true;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return actorDeleted;
        }


        //Language table DAL
        public static bool AddLanguageDAL(Language language)
        {
            bool languageAdded = false;

            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_LanguageAdd";
                cmd.Parameters.AddWithValue("@LanguageName", language.LanguageName);
                //cmd.Parameters.AddWithValue("@ActorLName", actor.ActorLastName);

                cmd.Connection.Open();

                int result = cmd.ExecuteNonQuery();

                cmd.Connection.Close();

                if (result > 0)
                    languageAdded = true;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return languageAdded;
        }


        public static List<Language> GetAllLanguagesDAL()
        {
            List<Language> languageList = null;
            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_LanguageDisplayAll";
                cmd.Connection.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                languageList = new List<Language>();
                while (dr.Read())
                {
                    Language language = new Language();
                    //Debug.Print(dr.GetInt32(0).ToString());

                    language.LanguageID = dr.GetInt32(0);
                    language.LanguageName = dr.GetString(1);
                    languageList.Add(language);
                }
                cmd.Connection.Close();
                return languageList;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
        }


        public static Language SearchLanguageDAL(int id)
        {
            try
            {
                Language language = null;
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_LanguageSearch";
                cmd.Parameters.AddWithValue("@LanguageId", id);
                language = new Language();
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    language.LanguageID = dr.GetInt32(0);
                    language.LanguageName = dr.GetString(1);
                    //actor.ActorLastName = dr.GetString(2);

                }
                cmd.Connection.Close();
                return language;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
        }

        public static bool UpdateLanguageDAL(Language language)
        {
            bool languageUpdated = false;

            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_LanguageUpdate";
                cmd.Parameters.AddWithValue("@LanguageID", language.LanguageID);
                cmd.Parameters.AddWithValue("@LanguageName", language.LanguageName);
                // cmd.Parameters.AddWithValue("@ActorLName", actor.ActorLastName);

                cmd.Connection.Open();

                int result = cmd.ExecuteNonQuery();

                cmd.Connection.Close();

                if (result > 0)
                    languageUpdated = true;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return languageUpdated;
        }

        public static bool DeleteLanguageDAL(int id)
        {
            bool languageDeleted = false;
            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_LanguageDelete";
                cmd.Parameters.AddWithValue("@LanguageId", id);

                cmd.Connection.Open();

                int result = cmd.ExecuteNonQuery();

                cmd.Connection.Close();

                if (result > 0)
                    languageDeleted = true;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return languageDeleted;
        }

        //Creating DAL of Category Table
        public static bool AddCategoryDAL(Category category)
        {
            bool categoryAdded = false;

            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_CategoryAdd";
                cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                //cmd.Parameters.AddWithValue("@ActorLName", actor.ActorLastName);

                cmd.Connection.Open();

                int result = cmd.ExecuteNonQuery();

                cmd.Connection.Close();

                if (result > 0)
                    categoryAdded = true;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return categoryAdded;
        }


        public static List<Category> GetAllCategoryDAL()
        {
            List<Category> categoryList = null;
            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_CategoryDisplayAll";
                cmd.Connection.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                categoryList = new List<Category>();
                while (dr.Read())
                {
                    Category category = new Category();
                    //Debug.Print(dr.GetInt32(0).ToString());

                    category.CategoryID = dr.GetInt32(0);
                    category.CategoryName = dr.GetString(1);
                    //actor.ActorLastName = dr.GetString(2);

                    categoryList.Add(category);
                }
                cmd.Connection.Close();
                return categoryList;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
        }


        public static Category SearchCategoryDAL(int id)
        {
            try
            {
                Category category = null;
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_CategorySearch";
                cmd.Parameters.AddWithValue("@CategoryId", id);
                category = new Category();
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    category.CategoryID = dr.GetInt32(0);
                    category.CategoryName = dr.GetString(1);
                    //actor.ActorLastName = dr.GetString(2);

                }
                cmd.Connection.Close();
                return category;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
        }

        public static bool UpdateCategoryDAL(Category category)
        {
            bool categoryUpdated = false;

            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_CategoryUpdate";
                cmd.Parameters.AddWithValue("@CategoryID", category.CategoryID);
                cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                //cmd.Parameters.AddWithValue("@ActorLName", actor.ActorLastName);

                cmd.Connection.Open();

                int result = cmd.ExecuteNonQuery();

                cmd.Connection.Close();

                if (result > 0)
                    categoryUpdated = true;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return categoryUpdated;
        }

        public static bool DeleteCategoryDAL(int id)
        {
            bool categoryDeleted = false;
            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_CategoryDelete";
                cmd.Parameters.AddWithValue("@CategoryId", id);

                cmd.Connection.Open();

                int result = cmd.ExecuteNonQuery();

                cmd.Connection.Close();

                if (result > 0)
                    categoryDeleted = true;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return categoryDeleted;
        }

        //Film Table Dal
        public static bool AddFilmDAL(Film film)
        {
            bool filmAdded = false;

            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_FilmAdd";
                cmd.Parameters.AddWithValue("@Description", film.Description);
                cmd.Parameters.AddWithValue("@Title", film.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", film.ReleaseYear);
                cmd.Parameters.AddWithValue("@RentalDuration", film.RentalDuration);
                cmd.Parameters.AddWithValue("@ReplaceCost", film.ReplacementCost);
                cmd.Parameters.AddWithValue("@LangId", film.LanguageId);
                cmd.Parameters.AddWithValue("@Length", film.Length);
                cmd.Parameters.AddWithValue("@Rating", film.Rating);
                cmd.Parameters.AddWithValue("@ActorId", film.ActorId);
                cmd.Parameters.AddWithValue("@CategoryId", film.CategoryId);


                
                cmd.Connection.Open();

                int result = cmd.ExecuteNonQuery();

                cmd.Connection.Close();

                if (result > 0)
                    filmAdded = true;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return filmAdded;
        }

        public static List<Film> GetAllFilmDAL()
        {
            List<Film> filmList = null;
            //try
            //{
            SqlCommand cmd = CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PRAVEEN.usp_FilmDisplayAll";
            cmd.Connection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            filmList = new List<Film>();
            while (dr.Read())
            {
                Film film = new Film();
                //Debug.Print(dr.GetInt32(0).ToString());

                film.FilmID = dr.GetInt32(0);
                film.Description = dr.GetString(1);
                film.Title = dr.GetString(2);
                film.ReleaseYear = dr.GetDateTime(3);
                film.RentalDuration = dr.GetDateTime(4);
                film.ReplacementCost = dr.GetSqlMoney(5).ToDouble();
                film.LanguageId = dr.GetInt32(6);
                film.Length = dr.GetSqlDecimal(7).ToDouble();
                film.Rating = dr.GetSqlDecimal(8).ToDouble();
                film.ActorId = dr.GetInt32(9);
                film.CategoryId = dr.GetInt32(10);
                //actor.ActorLastName = dr.GetString(2);

                filmList.Add(film);
            }
            cmd.Connection.Close();
            return filmList;
            //}
            //catch (Exception ex)
            //{
            //    throw new FilmException(ex.Message);
            //}
        }

        public static bool UpdateFilmDAL(Film film)
        {
            bool filmUpdated = false;

            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_FilmUpdate";
                cmd.Parameters.AddWithValue("@FilmID", film.FilmID);
                cmd.Parameters.AddWithValue("@Description", film.Description);
                cmd.Parameters.AddWithValue("@Title", film.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", film.ReleaseYear);
                cmd.Parameters.AddWithValue("@RentalDuration", film.RentalDuration);
                cmd.Parameters.AddWithValue("@ReplaceCost", film.ReplacementCost);
                cmd.Parameters.AddWithValue("@LangId", film.LanguageId);
                cmd.Parameters.AddWithValue("@Length", film.Length);
                cmd.Parameters.AddWithValue("@Rating", film.Rating);
                cmd.Parameters.AddWithValue("@ActorId", film.ActorId);
                cmd.Parameters.AddWithValue("@CategoryId", film.CategoryId);
                //cmd.Parameters.AddWithValue("@ActorLName", actor.ActorLastName);

                cmd.Connection.Open();

                int result = cmd.ExecuteNonQuery();

                cmd.Connection.Close();

                if (result > 0)
                    filmUpdated = true;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return filmUpdated;
        }

        public static bool DeleteFilmDAL(int id)
        {
            bool filmDeleted = false;
            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_FilmDelete";
                cmd.Parameters.AddWithValue("@FilmId", id);

                cmd.Connection.Open();

                int result = cmd.ExecuteNonQuery();

                cmd.Connection.Close();

                if (result > 0)
                    filmDeleted = true;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
            return filmDeleted;
        }


        public static List<Film> SearchFilmIdDAL(int id)
        {
            try
            {
                List<Film> filmList = null;
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_FilmIdSearch";
                cmd.Parameters.AddWithValue("@FilmId", id);
                //film = new Film();
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                filmList = new List<Film>();
                while (dr.Read())
                {
                    Film film = new Film();
                    //Debug.Print(dr.GetInt32(0).ToString());

                    film.FilmID = dr.GetInt32(0);
                    film.Description = dr.GetString(1);
                    film.Title = dr.GetString(2);
                    film.ReleaseYear = dr.GetDateTime(3);
                    film.RentalDuration = dr.GetDateTime(4);
                    film.ReplacementCost = dr.GetSqlMoney(5).ToDouble();
                    film.LanguageId = dr.GetInt32(6);
                    film.Length = dr.GetSqlDecimal(7).ToDouble();
                    film.Rating = dr.GetSqlDecimal(8).ToDouble();
                    film.ActorId = dr.GetInt32(9);
                    film.CategoryId = dr.GetInt32(10);
                    //actor.ActorLastName = dr.GetString(2);

                    filmList.Add(film);
                }
                cmd.Connection.Close();
                return filmList;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }
        }


        public static List<Film> SearchFilmNameDAL(string name)
        {
            try
            {
                List<Film> filmList = null;
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_FilmNameSearch";
                cmd.Parameters.AddWithValue("@FilmName", name);
                // film = new Film();
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                filmList = new List<Film>();
                while (dr.Read())
                {
                    Film film = new Film();
                    //Debug.Print(dr.GetInt32(0).ToString());

                    film.FilmID = dr.GetInt32(0);
                    film.Description = dr.GetString(1);
                    film.Title = dr.GetString(2);
                    film.ReleaseYear = dr.GetDateTime(3);
                    film.RentalDuration = dr.GetDateTime(4);
                    film.ReplacementCost = dr.GetSqlMoney(5).ToDouble();
                    film.LanguageId = dr.GetInt32(6);
                    film.Length = dr.GetSqlDecimal(7).ToDouble();
                    film.Rating = dr.GetSqlDecimal(8).ToDouble();
                    film.ActorId = dr.GetInt32(9);
                    film.CategoryId = dr.GetInt32(10);
                    //actor.ActorLastName = dr.GetString(2);

                    filmList.Add(film);
                }
                cmd.Connection.Close();
                return filmList;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }

        }

        public static List<Film> SearchFilmRatingDAL(double rating)
        {
            try
            {
                List<Film> filmList = null;
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_FilmRatingSearch";
                cmd.Parameters.AddWithValue("@Rating", rating);
                //film = new Film();
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                filmList = new List<Film>();
                while (dr.Read())
                {
                    Film film = new Film();
                    //Debug.Print(dr.GetInt32(0).ToString());

                    film.FilmID = dr.GetInt32(0);
                    film.Description = dr.GetString(1);
                    film.Title = dr.GetString(2);
                    film.ReleaseYear = dr.GetDateTime(3);
                    film.RentalDuration = dr.GetDateTime(4);
                    film.ReplacementCost = dr.GetSqlMoney(5).ToDouble();
                    film.LanguageId = dr.GetInt32(6);
                    film.Length = dr.GetSqlDecimal(7).ToDouble();
                    film.Rating = dr.GetSqlDecimal(8).ToDouble();
                    film.ActorId = dr.GetInt32(9);
                    film.CategoryId = dr.GetInt32(10);
                    //actor.ActorLastName = dr.GetString(2);

                    filmList.Add(film);
                }
                cmd.Connection.Close();
                return filmList;

            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }

        }


        public static List<Film> SearchFilmActorNameDAL(string actorName)
        {
            try
            {
                List<Film> filmList = null;
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_FilmActorName";
                cmd.Parameters.AddWithValue("@ActorName", actorName);
                //film = new Film();
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                filmList = new List<Film>();
                while (dr.Read())
                {
                    Film film = new Film();
                    //Debug.Print(dr.GetInt32(0).ToString());

                    film.FilmID = dr.GetInt32(0);
                    film.Description = dr.GetString(1);
                    film.Title = dr.GetString(2);
                    film.ReleaseYear = dr.GetDateTime(3);
                    film.RentalDuration = dr.GetDateTime(4);
                    film.ReplacementCost = dr.GetSqlMoney(5).ToDouble();
                    film.LanguageId = dr.GetInt32(6);
                    film.Length = dr.GetSqlDecimal(7).ToDouble();
                    film.Rating = dr.GetSqlDecimal(8).ToDouble();
                    film.ActorId = dr.GetInt32(9);
                    film.CategoryId = dr.GetInt32(10);
                    //actor.ActorLastName = dr.GetString(2);

                    filmList.Add(film);
                }
                cmd.Connection.Close();
                return filmList;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }

        }

        public static List<Film> SearchFilmLangNameDAL(string langName)
        {
            try
            {
                List<Film> filmList = null;
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_FilmLanguageName";
                cmd.Parameters.AddWithValue("@LanguageName", langName);
                //film = new Film();
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                filmList = new List<Film>();
                while (dr.Read())
                {
                    Film film = new Film();
                    //Debug.Print(dr.GetInt32(0).ToString());

                    film.FilmID = dr.GetInt32(0);
                    film.Description = dr.GetString(1);
                    film.Title = dr.GetString(2);
                    film.ReleaseYear = dr.GetDateTime(3);
                    film.RentalDuration = dr.GetDateTime(4);
                    film.ReplacementCost = dr.GetSqlMoney(5).ToDouble();
                    film.LanguageId = dr.GetInt32(6);
                    film.Length = dr.GetSqlDecimal(7).ToDouble();
                    film.Rating = dr.GetSqlDecimal(8).ToDouble();
                    film.ActorId = dr.GetInt32(9);
                    film.CategoryId = dr.GetInt32(10);
                    //actor.ActorLastName = dr.GetString(2);

                    filmList.Add(film);
                }
                cmd.Connection.Close();
                return filmList;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }

        }

        public static List<Film> SearchFilmCategoryNameDAL(string categoryName)
        {
            try
            {
                List<Film> filmList = null;
                SqlCommand cmd = CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PRAVEEN.usp_FilmCategoryName";
                cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                //film = new Film();
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                filmList = new List<Film>();
                while (dr.Read())
                {
                    Film film = new Film();
                    //Debug.Print(dr.GetInt32(0).ToString());

                    film.FilmID = dr.GetInt32(0);
                    film.Description = dr.GetString(1);
                    film.Title = dr.GetString(2);
                    film.ReleaseYear = dr.GetDateTime(3);
                    film.RentalDuration = dr.GetDateTime(4);
                    film.ReplacementCost = dr.GetSqlMoney(5).ToDouble();
                    film.LanguageId = dr.GetInt32(6);
                    film.Length = dr.GetSqlDecimal(7).ToDouble();
                    film.Rating = dr.GetSqlDecimal(8).ToDouble();
                    film.ActorId = dr.GetInt32(9);
                    film.CategoryId = dr.GetInt32(10);
                    //actor.ActorLastName = dr.GetString(2);

                    filmList.Add(film);
                }
                cmd.Connection.Close();
                return filmList;
            }
            catch (Exception ex)
            {
                throw new FilmException(ex.Message);
            }

        }
    }
}

