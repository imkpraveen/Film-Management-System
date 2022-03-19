using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClass
{
    [Serializable()]
    public class Film
    {
        public int FilmID { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseYear { get; set; }
        public DateTime RentalDuration { get; set; }
        public double ReplacementCost { get; set; }
        public int LanguageId { get; set; }
        public double Length { get; set; }
        public double Rating { get; set; }
        public int ActorId { get; set; }
        public int CategoryId { get; set; }
    }
}
