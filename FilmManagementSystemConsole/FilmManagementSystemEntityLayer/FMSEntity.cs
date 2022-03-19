using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmManagementSystemEntityLayer
{
    public class FMSEntity
    {
        //Actor Entity
        [Serializable()]
        public class Actor
        {
            public int ActorID { get; set; }
            public string ActorFirstName { get; set; }
            public string ActorLastName { get; set; }
            public int FilmID { get; set; }
        }

        //Film Entity
        [Serializable]
        public class Film
        {
            public int FilmID { get; set; }
            public string Description { get; set; }
            public string Title { get; set; }
            public DateTime ReleaseYear { get; set; }
            public DateTime RentalDuration { get; set; }
            public double ReplacementCost { get; set; }
            public int LanguageId { get; set; }
            public int OriginalLanguageId { get; set; }
            public string SpecialFeatures { get; set; }
            public double Length { get; set; }
            public double Rating { get; set; }
            public int ActorId { get; set; }
            public int CategoryId { get; set; }
        }

        //Category Entity
        [Serializable()]
        public class Category
        {
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
            public int FilmID { get; set; }
        }

        //Language Entity
        [Serializable()]
        public class Language
        {
            public int LanguageID { get; set; }
            public string LanguageName { get; set; }
            public int FilmID { get; set; }
        }
    }
}
