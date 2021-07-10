using DesignPatternTP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternTP.ModelAdapter
{
    public interface IAdapterSerieModel
    {
        SerieModel Adapter(Serie serie);
    }
}
