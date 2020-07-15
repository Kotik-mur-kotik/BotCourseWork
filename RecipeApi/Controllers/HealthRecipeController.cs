using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication1.Model;
using WebApplication1.Model.New;

namespace WebApplication1.Controllers
{
    [Route("recipe")]
    [ApiController]
    public class HealthRecipeController : ControllerBase
    {

        [HttpGet("{food}/{cond}/{health}/{count}")]
        public async Task<NewRecipe[]> Get(string food,string health,int count)
        {
            JObject search = JObject.Parse(await GetRecipe($"https://api.edamam.com/search?q={food}&app_id=468a8f52&app_key=8314cafe053a28fdff7df123f71e9b9b&from=0&to={count}&calories=591-722&Health={health}"));
            Recipe hit = JsonConvert.DeserializeObject<Recipe>(search.ToString());

            NewRecipies newRecipies = new NewRecipies();
            newRecipies.recipes = SetNewClasses(hit.Hits).ToArray();
            for (int i = 0; i < newRecipies.recipes.Length; i++)
            {
                newRecipies.recipes[i].Fat = Math.Round(JsonConvert.DeserializeObject<Total>(search["hits"][i]["recipe"]["totalNutrients"]["FAT"].ToString()).Quantity, 2);
                newRecipies.recipes[i].Carbs = Math.Round(JsonConvert.DeserializeObject<Total>(search["hits"][i]["recipe"]["totalNutrients"]["CHOCDF"].ToString()).Quantity, 2);
                newRecipies.recipes[i].Protein = Math.Round(JsonConvert.DeserializeObject<Total>(search["hits"][i]["recipe"]["totalNutrients"]["PROCNT"].ToString()).Quantity, 2);
            }
            return newRecipies.recipes;
        }
        public static async Task<string> GetRecipe(string URL)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(URL);
            HttpContent content = response.Content;
            string result = await content.ReadAsStringAsync();
            return result;
        }
        private static List<NewRecipe> SetNewClasses(Hit[] Recipies)
        {
            List<NewRecipe> recipes = new List<NewRecipe>();
            foreach (var reci in Recipies)
            {
                NewRecipe newRecipe = new NewRecipe();
                newRecipe.ImageUri = reci.Recipe.Image;
                newRecipe.IngredientLines = reci.Recipe.IngredientLines;
                newRecipe.Name = reci.Recipe.Label;
                newRecipe.Url = reci.Recipe.Url;
                newRecipe.TotalTime = reci.Recipe.TotalTime;
                newRecipe.Calories = Math.Round(reci.Recipe.Calories, 2);
                recipes.Add(newRecipe);
            }
            return recipes;
        }
    }
}
