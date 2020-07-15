using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace RecipeBot.Fillings
{
    class NameOfFood : Filling
    {
        public override string Name => "nameTOFOOD";

        public override async void Execute(Message message, TelegramBotClient client, long id)
        {
            var user = DB.Users.Find(id);
            try
            {
                user.foodname = string.Empty;
                bool add = false;
                foreach (string s in message.Text.Split(' '))
                {
                    if (user.foodname.Length == 0) { user.foodname = s; }
                    else { if (!add) { user.foodname += "&" + s; add = true; } }
                }

                JArray search = JArray.Parse(await GetFood($"https://reciipee.azurewebsites.net/recipe/{user.foodname}/{user.Condition}/{user.Health}/{user.Count}"));
                user.recipes = JsonConvert.DeserializeObject<Recipe[]>(search.ToString());
                if(user.recipes.Length<1)
                {
                    await client.SendTextMessageAsync(message.Chat.Id, "Sorry, I looked at all data bases \nbut I cannot find this food");
                    await client.SendTextMessageAsync(message.Chat.Id, "Please, Write a name of another food");
                    return;
                }
                InlineKeyboardMarkup keyboardRecipe = new InlineKeyboardMarkup(CreateKeyBoard(user.recipes));
                user.Command = "RECIPE";
                await client.SendTextMessageAsync(message.Chat.Id, "Select a recipe for more information", replyMarkup: keyboardRecipe);

            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
                await client.SendTextMessageAsync(message.Chat.Id, "Sorry, I looked at all data bases \nbut I cannot find this food");
                await client.SendTextMessageAsync(message.Chat.Id, "Please, Write a name of another food");
                return;
            }
            catch (JsonReaderException e)
            {
                Console.WriteLine(e.Message);
                await client.SendTextMessageAsync(message.Chat.Id, "Sorry, i looked at all data bases \nbut I cannot find this food");
                await client.SendTextMessageAsync(message.Chat.Id, "Please, write a name of another food");
                return;
            }
        }
        private List<List<InlineKeyboardButton>> CreateKeyBoard(Recipe[] recipes)
        {
            List<List<InlineKeyboardButton>> buttons = new List<List<InlineKeyboardButton>>();
            for (int i = 0; i < recipes.Length; i++)
            {
                List<InlineKeyboardButton> inlines = new List<InlineKeyboardButton>();
                inlines.Add(new InlineKeyboardButton() { CallbackData = $"{i}", Text = recipes[i].Name });
                buttons.Add(inlines);
            }
            return buttons;
        }
    }
}
