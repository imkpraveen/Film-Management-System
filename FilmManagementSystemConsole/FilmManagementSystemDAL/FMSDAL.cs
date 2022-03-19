using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using static FilmManagementSystemEntityLayer.FMSEntity;

namespace FilmManagementSystemDAL
{
    /// <summary>
    /// Author : Praveenkumar
    /// Description : This is the Data Access Layer
    /// Date of Modification :
    /// Employee ID : 186494
    /// </summary>
    public class FMSDAL
    {
        //Actor Data Access Layer
        public static List<Actor> actorList = new List<Actor>();
        public static List<Category> categoryList = new List<Category>();
        public static List<Language> languageList = new List<Language>();
        public static string fileName1 = "ActorList";
        public static string fileName2 = "CategoryList";
        public static string fileName3 = "LanguageList";
        public static List<Film> filmList = new List<Film>();
        public static string fileName = "FilmList";
        #region Film
        public static bool AddFilmDAL(Film newFilm)
        {
            bool filmAdded = false;
            try
            {
                filmList.Add(newFilm);
                filmAdded = true;
                SetSerialization();
            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return filmAdded;
        }
        public static bool UpdateFilmDAL(Film updateFilm)
        {
            bool filmUpdated = false;
            try
            {


                for (int i = 0; i < filmList.Count; i++)
                {
                    Film film = filmList[i];
                    if (film.FilmID == updateFilm.FilmID)
                    {
                        filmList[i] = updateFilm;
                        SetSerialization();
                        break;
                    }
                }

                filmUpdated = true;
            }
            catch (Exception ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return filmUpdated;

        }
        public static bool DeleteFilmDAL(int deleteFilmID)
        {
            bool filmDeleted = false;
            try
            {
                for (int i = 0; i < filmList.Count; i++)
                {
                    Film film = filmList[i];
                    if (film.FilmID == deleteFilmID)
                    {
                        filmList.RemoveAt(i);
                        filmDeleted = true;
                        SetSerialization();
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return filmDeleted;

        }
        public static List<Film> GetAllFilmDAL()
        {
            return filmList;
        }
        public static Film SearchFilmByNameDAL(string searchTitle)
        {
            Film searchFilm = null;
            try
            {


                for (int i = 0; i < filmList.Count; i++)
                {
                    Film film = filmList[i];
                    if (film.Title == searchTitle)
                    {
                        searchFilm = filmList[i];
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return searchFilm;
        }
        public static Film SearchFilmByActorDAL(int searchActor)
        {
            Film searchFilm = null;
            try
            {


                for (int i = 0; i < filmList.Count; i++)
                {
                    Film film = filmList[i];
                    if (film.ActorId == searchActor)
                    {
                        searchFilm = filmList[i];
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return searchFilm;
        }
        public static Film SearchFilmByCategoryDAL(int searchCategory)
        {
            Film searchFilm = null;
            try
            {


                for (int i = 0; i < filmList.Count; i++)
                {
                    Film film = filmList[i];
                    if (film.CategoryId == searchCategory)
                    {
                        searchFilm = filmList[i];
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return searchFilm;
        }
        public static Film SearchFilmByLanguageDAL(int searchLanguage)
        {
            Film searchFilm = null;
            try
            {


                for (int i = 0; i < filmList.Count; i++)
                {
                    Film film = filmList[i];
                    if (film.LanguageId == searchLanguage)
                    {
                        searchFilm = filmList[i];
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return searchFilm;
        }
        public static Film SearchFilmByRatingDAL(int searchRating)
        {
            Film searchFilm = null;
            try
            {


                for (int i = 0; i < filmList.Count; i++)
                {
                    Film film = filmList[i];
                    if (film.Rating == searchRating)
                    {
                        searchFilm = filmList[i];
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return searchFilm;
        }
        public static Film SearchFilmByFilmIDDAL(int searchFilmID)
        {
            Film searchFilm = null;
            try
            {


                for (int i = 0; i < filmList.Count; i++)
                {
                    Film film = filmList[i];
                    if (film.FilmID == searchFilmID)
                    {
                        searchFilm = filmList[i];
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return searchFilm;
        }
        #endregion
        #region Actor
        public static bool AddActorDAL(Actor newActor)
        {
            bool actorAdded = false;
            try
            {
                actorList.Add(newActor);
                actorAdded = true;
                SetSerialization();
            }
            catch (FilmManagementSystemExceptionLayer.FMSException ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return actorAdded;
        }
        public static Actor SearchActorDAL(int searchFilmID)
        {
            //DeserializationActor();
            Actor searchFilm = null;
            try
            {
                searchFilm = actorList.Find(Actor => Actor.ActorID == searchFilmID);
            }
            catch (SystemException ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return searchFilm;
        }
        public static Actor SearchActorByNameDAL(string searchActorName)
        {
            //DeserializationActor();
            Actor searchActor = null;
            try
            {
                searchActor = actorList.Find(Actor => Actor.ActorFirstName == searchActorName);
            }
            catch (SystemException ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return searchActor;
        }
        public static bool DeleteActorDAL(int deleteActorID)
        {
            //actorList.Clear();
            //DeserializationActor();
            bool ActorDeleted = false;
            try
            {
                Actor deleteFilm = actorList.Find(Actor => Actor.ActorID == deleteActorID);

                if (deleteFilm != null)
                {
                    actorList.Remove(deleteFilm);
                    ActorDeleted = true;
                    SetSerialization();
                }
            }
            catch (DbException ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return ActorDeleted;

        }
        public static bool UpdateActorDAL(Actor updateActor)
        {
            bool ActorUpdated = false;
            try
            {
                for (int i = 0; i < actorList.Count; i++)
                {
                    if (actorList[i].ActorID == updateActor.ActorID)
                    {
                        updateActor.ActorFirstName = actorList[i].ActorFirstName;
                        updateActor.ActorLastName = actorList[i].ActorLastName;

                        ActorUpdated = true;
                        SetSerialization();
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return ActorUpdated;
        }
        public static  List<Actor> GetAllActorDAL()
        {
            //DeserializationActor();
            return actorList;
        }
        #endregion
        #region Category
        public static bool AddCategoryDAL(Category newCategory)
        {
            bool CategoryAdded = false;
            try
            {
                categoryList.Add(newCategory);
                SetSerialization();
                CategoryAdded = true;
            }
            catch (SystemException ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return CategoryAdded;

        }
        public static Category SearchCategoryByNameDAL(string searchCategoryName)
        {
            Category searchCategory = null;
            try
            {
                searchCategory = categoryList.Find(Category => Category.CategoryName == searchCategoryName);
            }
            catch (SystemException ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return searchCategory;
        }
        public static List<Category> GetAllCategoryDAL()
        {
            //DeserializationCategory();
            return categoryList;
        }
        public static Category SearchCategoryDAL(int searchFilmID)
        {
            //DeserializationCategory();
            Category searchFilm = null;
            try
            {
                searchFilm = categoryList.Find(Category => Category.CategoryID == searchFilmID);
            }
            catch (SystemException ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return searchFilm;
        }
        public static bool DeleteCategoryDAL(int deleteActorID)
        {
            bool ActorDeleted = false;
            try
            {
                //categoryList.Clear();
                //DeserializationCategory();
                Category deleteFilm = categoryList.Find(Category => Category.CategoryID == deleteActorID);

                if (deleteFilm != null)
                {
                    categoryList.Remove(deleteFilm);
                    ActorDeleted = true;
                    SetSerialization();
                }
            }
            catch (DbException ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return ActorDeleted;

        }
        public static bool UpdateCategoryDAL(Category updateActor)
        {
            bool ActorUpdated = false;
            try
            {
                for (int i = 0; i < categoryList.Count; i++)
                {
                    if (categoryList[i].CategoryID == updateActor.CategoryID)
                    {
                        updateActor.CategoryName = categoryList[i].CategoryName;

                        ActorUpdated = true;
                        SetSerialization();
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return ActorUpdated;
        }
        #endregion
        #region Language
        public static List<Language> GetAllLanguageDAL()
        {
            //DeserializationLanguage();
            return languageList;
        }
        public static Language SearchLanguageDAL(int searchFilmID)
        {
            //DeserializationLanguage();
            Language searchFilm = null;
            try
            {
                searchFilm = languageList.Find(Language => Language.LanguageID == searchFilmID);
            }
            catch (SystemException ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return searchFilm;
        }
        public static bool UpdateLanguageDAL(Language updateActor)
        {
            bool ActorUpdated = false;
            try
            {
                for (int i = 0; i < languageList.Count; i++)
                {
                    if (languageList[i].LanguageID == updateActor.LanguageID)
                    {
                        updateActor.LanguageName = languageList[i].LanguageName;

                        ActorUpdated = true;
                        SetSerialization();
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return ActorUpdated;
        }

        public static bool DeleteLanguagerDAL(int deleteActorID)
        {
            bool ActorDeleted = false;
            try
            {
                //languageList.Clear();
                //DeserializationLanguage();
                Language deleteFilm = languageList.Find(Language => Language.LanguageID == deleteActorID);

                if (deleteFilm != null)
                {
                    languageList.Remove(deleteFilm);
                    ActorDeleted = true;
                    SetSerialization();
                }
            }
            catch (DbException ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return ActorDeleted;

        }
        public static bool AddLanguageDAL(Language newLanguage)
        {
            bool LanguageAdded = false;
            try
            {
                languageList.Add(newLanguage);
                SetSerialization();
                LanguageAdded = true;
            }
            catch (SystemException ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return LanguageAdded;

        }

        public static Language SearchLanguageByNameDAL(string searchLanguageName)
        {
            Language searchLanguage = null;
            try
            {
                searchLanguage = languageList.Find(Language => Language.LanguageName == searchLanguageName);
            }
            catch (SystemException ex)
            {
                throw new FilmManagementSystemExceptionLayer.FMSException(ex.Message);
            }
            return searchLanguage;
        }
        #endregion
        #region Serialization & DeSerialization
        public static void SetSerialization()
        {
            try
            {
                using (Stream file = File.Open(fileName, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(file, filmList);
                    file.Close();
                }
                using (Stream file = File.Open(fileName1, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(file, actorList);
                    file.Close();
                }
                using (Stream file = File.Open(fileName2, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(file, categoryList);
                    file.Close();
                }
                using (Stream file = File.Open(fileName3, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(file, languageList);
                    file.Close();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //  Setting List if the file already exists
        public static void SetList()
        {
            DeserializeFile();
        }
        public static void DeserializeFile()
        {
            try
            {

                using (Stream file = File.Open(Directory.GetCurrentDirectory() + "\\" + fileName, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    filmList = bf.Deserialize(file) as List<Film>;
                    file.Close();
                }
                using (Stream file = File.Open(Directory.GetCurrentDirectory() + "\\" + fileName1, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    actorList = bf.Deserialize(file) as List<Actor>;
                    file.Close();
                }
                using (Stream file = File.Open(Directory.GetCurrentDirectory() + "\\" + fileName2, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    categoryList = bf.Deserialize(file) as List<Category>;
                    file.Close();
                }
                using (Stream file = File.Open(Directory.GetCurrentDirectory() + "\\" + fileName3, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    languageList = bf.Deserialize(file) as List<Language>;
                    file.Close();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            foreach (var film in filmList)
            {
                    Console.WriteLine("**********Film Details****************");
                    Console.WriteLine("Film ID : " + film.FilmID);
                    Console.WriteLine("Description : " + film.Description);
                    Console.WriteLine("Film Title : " + film.Title);
                    Console.WriteLine("Release Year : " + film.ReleaseYear);
                    Console.WriteLine("Rental Duration : " + film.RentalDuration);
                    Console.WriteLine("Replacement Cost : " + film.ReplacementCost);
                    Console.WriteLine("Language ID : " + film.LanguageId);
                    Console.WriteLine("Original Language ID : " + film.OriginalLanguageId);
                    Console.WriteLine("Special Features : " + film.SpecialFeatures);
                    Console.WriteLine("Length : " + film.Length);
                    Console.WriteLine("Rating : " + film.Rating);
                    Console.WriteLine("Actor ID : " + film.ActorId);
                    Console.WriteLine("Category ID : " + film.CategoryId);
            }
            foreach (var l in actorList)
            {
                Console.WriteLine("\n*************Actor Details**************");
                {
                       Console.WriteLine("Actor ID : " + l.ActorID);
                        Console.WriteLine("Actor First Name : " + l.ActorFirstName);
                        Console.WriteLine("Actor Last Name : " + l.ActorLastName);
                }
            }
            foreach (var l in categoryList)
            {
                Console.WriteLine("\n*************Category Details**************");
                {
                    Console.WriteLine("Category ID : " + l.CategoryID);
                    Console.WriteLine("Category Name : " + l.CategoryName);
                }
            }
            foreach (var l in languageList)
            {
                Console.WriteLine("\n*************Language Details************");
                {
                    Console.WriteLine("Language ID : " + l.LanguageID);
                    Console.WriteLine("Language Name : " + l.LanguageName);
                }
            }

        }
        #endregion
    }
}

