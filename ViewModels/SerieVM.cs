using DesignPatternTP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatternTP.ViewModels
{
    public class SerieVM
    {
        public List<SerieModel> ListeSeries { get; set; } = new List<SerieModel>();
        public int Total { get; set; }
        public int Pages { get; set; }
    }
}