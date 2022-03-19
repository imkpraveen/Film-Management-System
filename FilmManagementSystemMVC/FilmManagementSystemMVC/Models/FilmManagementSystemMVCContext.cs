using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FilmManagementSystemMVC.Models
{
    public class FilmManagementSystemMVCContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public FilmManagementSystemMVCContext() : base("name=FilmManagementSystemMVCContext")
        {
        }

        public System.Data.Entity.DbSet<FilmManagementSystemMVC.Models.Actor> Actors { get; set; }

        public System.Data.Entity.DbSet<FilmManagementSystemMVC.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<FilmManagementSystemMVC.Models.Film> Films { get; set; }

        public System.Data.Entity.DbSet<FilmManagementSystemMVC.Models.Language> Languages { get; set; }
    }
}
