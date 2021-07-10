using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatternTP.Utils
{
    public class FabriqueDbSeries : FabriqueDataBase
    {
        public override IDbContext Fabrication()
        {
            return new SerieDbContextConcrete();
        }
    }
}