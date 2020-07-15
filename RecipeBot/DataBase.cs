using RecipeBot.Users;
using System.Net.Http;
using System.Threading.Tasks;

namespace RecipeBot
{
    public class DataBase
    {
        public static UserContext DB = new UserContext();
        public static async Task<string> GetFood(string linkoffood)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(linkoffood);
            HttpContent content = response.Content;
            string result = await content.ReadAsStringAsync();
            return result;
        }
    }
}
