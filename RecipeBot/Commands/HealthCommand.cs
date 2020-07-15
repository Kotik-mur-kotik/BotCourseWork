using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace RecipeBot.Commands
{
    class HealthCommand : Command
    {
        public static InlineKeyboardMarkup HealthKeyboard = new InlineKeyboardMarkup(new InlineKeyboardButton[][]
                                        {
                                         new [] {
                                                    InlineKeyboardButton.WithCallbackData("Balanced","1balanced"),
                                                    InlineKeyboardButton.WithCallbackData("High-Protein","1high-protein"),
                                         },
                                         new [] {
                                                    InlineKeyboardButton.WithCallbackData("Low-Carb","1low-carb"),
                                                    InlineKeyboardButton.WithCallbackData("Low-Fat","1low-fat"),
                                         },
                                         new [] {
                                                    InlineKeyboardButton.WithCallbackData("Without gluten","2gluten-free"),
                                                    InlineKeyboardButton.WithCallbackData("No oil added","2N0-oil-added"),
                                          },
                                         new [] {
                                                    InlineKeyboardButton.WithCallbackData("Vegan","vegan"),
                                                    InlineKeyboardButton.WithCallbackData("Vegetarian","2vegetarian"),
                                          },
                                         new [] {
                                                    InlineKeyboardButton.WithCallbackData("No sugar","2low-sugar"),
                                                    InlineKeyboardButton.WithCallbackData("No matter","2alcohol-free"),
                                          },
                                       });
        public override string Name => "/health";

        public override async void Execute(Message message, TelegramBotClient client, long id)
        {
            var user = DB.Users.Find(id);
            user.Command = "HEALTH";
            await client.SendTextMessageAsync(message.Chat, "Please select your health rule", replyMarkup: HealthKeyboard);
        }
    }
}
