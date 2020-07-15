using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model.New
{
    public class NewRecipe
    {
        public string Name { get; set; }
        public Uri Url { get; set; }
        public Uri ImageUri { get; set; }
        public string[] IngredientLines { get; set; }
        public double Calories { get; set; }
        public long TotalTime { get; set; }
        public double Fat { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
    }
}
