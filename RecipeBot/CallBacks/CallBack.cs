using Telegram.Bot;
using Telegram.Bot.Args;

namespace RecipeBot.CallBacks
{
    public abstract class CallBack:DataBase
    {
        public abstract string Name { get; }
        public abstract void Execute(CallbackQueryEventArgs e, TelegramBotClient client, long id);
        public bool Contains(string command)
        {
            return command.Contains(this.Name);
        }
    }
}
