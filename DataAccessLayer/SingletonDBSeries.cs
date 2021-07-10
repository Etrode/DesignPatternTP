using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DesignPatternTP.Utils
{
    public class SingletonDBSeries
    {
        private static SingletonDBSeries instance;
        private DbContext dbContext;

        private SingletonDBSeries() { }
        private SingletonDBSeries(DbContext dbContext) {
            this.dbContext = dbContext;   
        }

        public static SingletonDBSeries getInstance()
        {
            if (instance == null)
            {
                FabriqueDataBase fabriqueDbSeries = new FabriqueDbSeries();
                instance = new SingletonDBSeries(fabriqueDbSeries.getDbContext());
            }
            return instance;
        }

        public DbContext getDbContext()
        {
            return this.dbContext;
        }
    }
}