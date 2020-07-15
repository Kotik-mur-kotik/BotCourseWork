using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class Recipe
    {
        [JsonProperty("hits")]
        public Hit[] Hits { get; set; }
    }

    public class Hit
    {
        [JsonProperty("recipe")]
        public RecipeClass Recipe { get; set; }
    }

    public class RecipeClass
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("image")]
        public Uri Image { get; set; }

        [JsonProperty("ingredientLines")]
        public string[] IngredientLines { get; set; }

        [JsonProperty("calories")]
        public double Calories { get; set; }

        [JsonProperty("totalTime")]
        public long TotalTime { get; set; }
    }
    public partial class Total
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("quantity")]
        public double Quantity { get; set; }

        [JsonProperty("unit")]
        public Unit Unit { get; set; }
    }

    public enum Unit { Empty, G, Kcal, Mg, Μg };
}