using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace RecipeBot.Commands
{
    class FoodCommand : Command
    {
        public override string Name => "/food";

        public override async void Execute(Message message, TelegramBotClient client, long id)
        {
            var user = DB.Users.Find(id);
            if (user.Count == 0) user.Count = 5;
            user.Command = "nameTOFOOD";
            await client.SendTextMessageAsync(
                    message.Chat.Id, "Please, write a name of ingredient");
        }
    }
}
