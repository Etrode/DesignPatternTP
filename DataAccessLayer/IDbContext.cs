using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DesignPatternTP.Utils
{
    public interface IDbContext
    {
        DbContext getDbContext();
    }
}