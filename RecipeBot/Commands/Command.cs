using RecipeBot.Users;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace RecipeBot.Commands
{
    public abstract class Command : DataBase
    {
        public abstract string Name { get; }
        public abstract void Execute(Message message, TelegramBotClient client, long id);
        public bool Contains(string command)
        {
            return command.Contains(this.Name);
        }
    }
}