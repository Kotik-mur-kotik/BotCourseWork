using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace RecipeBot
{
    public abstract class Filling : DataBase
    {
        public abstract string Name { get; }
        public abstract void Execute(Message message, TelegramBotClient client, long id);
        public bool Contains(string command)
        {
            if (command == null) return false;
            return command.Contains(this.Name);
        }
    }
}
