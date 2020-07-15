using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeBot
{
    public class Recipes
    {
        public Recipe[] recipes;
    }
    public class Recipe
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("imageUri")]
        public Uri ImageUri { get; set; }

        [JsonProperty("ingredientLines")]
        public string[] IngredientLines { get; set; }

        [JsonProperty("calories")]
        public double Calories { get; set; }

        [JsonProperty("totalTime")]
        public long TotalTime { get; set; }

        [JsonProperty("fat")]
        public double Fat { get; set; }

        [JsonProperty("protein")]
        public double Protein { get; set; }

        [JsonProperty("carbs")]
        public double Carbs { get; set; }
    }
}
