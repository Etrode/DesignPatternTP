using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DesignPatternTP.Utils
{
    public class SerieDbContextConcrete : IDbContext
    {
        public DbContext getDbContext()
        {
            DbContext serieDBEntities = new serieDBEntities();
            return serieDBEntities;
        }
    }
}