using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace RecipeBot.Commands
{
    class StartCommand : Command
    {
        public override string Name => @"/start";

        public override async void Execute(Message message, TelegramBotClient client, long id)
        {
            var user = DB.Users.Find(id);

            await client.SendTextMessageAsync(message.Chat, $"Hi, {message.Chat.FirstName}, I hope that I will help you to cook something delicious");
            await client.SendTextMessageAsync(message.Chat, $"Send me a command:\n" +
                     "/count - to change the number of recipes\n" +
                     "/food -  to know recipes with this ingredient\n" +
                     "/health - to select health rule for recipes");
        }
    }
}
