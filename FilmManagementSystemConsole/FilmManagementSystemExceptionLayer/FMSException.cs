using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmManagementSystemExceptionLayer
{
    /// <summary>
    /// Author : Praveenkumar
    /// Description : This is the Exception Layer
    /// Date of Modification :
    /// Employee ID : 186494
    /// </summary>
    public class FMSException : ApplicationException
    {
        public FMSException() : base()
        { }
        public FMSException(string msg) : base(msg)
        { }
    }
}
