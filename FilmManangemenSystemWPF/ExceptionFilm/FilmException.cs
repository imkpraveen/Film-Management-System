using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionClass
{
    public class FilmException : ApplicationException
    {
        public FilmException() : base()
        { }
        public FilmException(string msg) : base(msg)
        { }
    }
}
