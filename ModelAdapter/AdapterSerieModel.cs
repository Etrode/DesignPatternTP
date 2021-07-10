using DesignPatternTP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatternTP.ModelAdapter
{
    public class AdapterSerieModel : IAdapterSerieModel
    {
        private ConstructorSerieModel constructorSerieModel;

        public AdapterSerieModel(ConstructorSerieModel constructorSerieModel)
        {
            this.constructorSerieModel = constructorSerieModel;
        }

        public SerieModel Adapter(Serie serie)
        {
            return this.constructorSerieModel.Construct(serie);
        }
    }
}