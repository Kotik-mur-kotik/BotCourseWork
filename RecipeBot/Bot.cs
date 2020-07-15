using RecipeBot.CallBacks;
using RecipeBot.Commands;
using RecipeBot.Fillings;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;

namespace RecipeBot
{
    public static class Bot
    {
        public static TelegramBotClient client;
        public static string token = "1259984575:AAFeG3EMWUrSFDggrKXSWsFL1I5j3KjnADk";
        public static string Name = "happyrecipe_bot";

        private static List<Command> commandslist;
        public static IReadOnlyList<Command> Commands { get => commandslist.AsReadOnly(); }

        private static List<CallBack> callbacklist;
        public static IReadOnlyList<CallBack> CallBacks { get => callbacklist.AsReadOnly(); }

        private static List<Filling> freecatchinglist;
        public static IReadOnlyList<Filling> Fillings { get => freecatchinglist.AsReadOnly(); }
        public static TelegramBotClient Get()
        {
            commandslist = new List<Command>();
            commandslist.Add(new StartCommand());
            commandslist.Add(new CountCommand());
            commandslist.Add(new FoodCommand());
            commandslist.Add(new HealthCommand());

            callbacklist = new List<CallBack>();
            callbacklist.Add(new HealthCallBack());
            callbacklist.Add(new RecipeCallBack());

            freecatchinglist = new List<Filling>();
            freecatchinglist.Add(new NameOfFood());
            freecatchinglist.Add(new CountOfRecipes());

            client = new TelegramBotClient(token);
            return client;
        }

    }
}
