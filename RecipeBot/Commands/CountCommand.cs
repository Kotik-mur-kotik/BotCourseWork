using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace RecipeBot.Commands
{
    class CountCommand : Command
    {
        public override string Name => "/count";

        public override async void Execute(Message message, TelegramBotClient client, long id)
        {
            var user = DB.Users.Find(id);
            await client.SendTextMessageAsync(message.Chat, $"Please, write how many recipes you want to get!)");
            user.Command = "Count of recipes";
        }
    }
}
