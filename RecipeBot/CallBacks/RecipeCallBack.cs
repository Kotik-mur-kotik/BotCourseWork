using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace RecipeBot.CallBacks
{
    class RecipeCallBack : CallBack
    {
        public static InlineKeyboardMarkup keyboardUrl;
        public override string Name => "RECIPE";

        public override async void Execute(CallbackQueryEventArgs e, TelegramBotClient client, long id)
        {
            var user = DB.Users.Find(id);
            Recipe recipe = null;
            try
            {
                recipe = user.recipes[int.Parse(e.CallbackQuery.Data)];
                CreateButton(recipe);
                //user.Command = " ";
                if (recipe.ImageUri == null)
                {
                        await client.SendTextMessageAsync(e.CallbackQuery.From.Id, CreateStr(recipe.IngredientLines), replyMarkup: keyboardUrl);
                }
                else
                {
                    InputOnlineFile photo = new InputOnlineFile(recipe.ImageUri);
                    await client.SendPhotoAsync(e.CallbackQuery.From.Id, photo, caption: CreateStr(recipe.IngredientLines), replyMarkup: keyboardUrl);
                }
            }
            catch (InvalidOperationException exeption)
            {
                Console.WriteLine(exeption.Message);
                await client.SendTextMessageAsync(e.CallbackQuery.From.Id, CreateStr(recipe.IngredientLines), replyMarkup: keyboardUrl);

            }
            catch (ApiRequestException exeption)
            {
                Console.WriteLine(exeption.Message);
                await client.SendTextMessageAsync(e.CallbackQuery.From.Id, CreateStr(recipe.IngredientLines), replyMarkup: keyboardUrl);

            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
                await client.SendTextMessageAsync(e.CallbackQuery.From.Id, "There is some problem\n" +
                    "Use any command to fix it)");
            }
        }
        private void CreateButton(Recipe article)
        {
            keyboardUrl = new InlineKeyboardMarkup(new InlineKeyboardButton[][]
                                                 {
                                         new [] { InlineKeyboardButton.WithUrl("To see on original site", article.Url.ToString()),},
               });
        }
        private string CreateStr(string[] strings)
        {
            string s = string.Empty;
            foreach (var item in strings)
            {
                s += item + "\n";
            }
            return s;
        }
    }
}
