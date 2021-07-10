using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DesignPatternTP.Utils
{
    public abstract class FabriqueDataBase
    {
        public abstract IDbContext Fabrication();

        public DbContext getDbContext()
        {
            IDbContext dbContext = Fabrication();
            return dbContext.getDbContext();
        }
    }
}