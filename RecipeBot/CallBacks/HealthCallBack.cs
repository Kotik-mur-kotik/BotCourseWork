using RecipeBot.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace RecipeBot.CallBacks
{
    class HealthCallBack : CallBack
    {
        public override string Name => "HEALTH";

        public override async void Execute(CallbackQueryEventArgs e, TelegramBotClient client, long id)
        {
            var user = DB.Users.Find(id);
            if (e.CallbackQuery.Data.StartsWith('1'))
            {
                user.Condition = "Diet";
                user.Health = e.CallbackQuery.Data.Substring(1);
            }
            else if (e.CallbackQuery.Data.StartsWith('2'))
            {
                user.Condition = "Health";
                user.Health = e.CallbackQuery.Data.Substring(1);
            }
            if (user.Count == 0) user.Count = 5;
            user.Command = "nameTOFOOD";
            await client.SendTextMessageAsync(
                     e.CallbackQuery.From.Id, "Please, write a name of ingredient");

        }
    }
}
