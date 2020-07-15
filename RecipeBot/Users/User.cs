using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeBot.Users
{
    public class User
    {
        public long Id { get; set; }
        public string ChatId { get; set; }
        public string Command { get; set; }
        public string Name { get; set; }
        public string Health { get; set; }
        public string foodname { get; set; }
        public string Condition { get; set; }
        public int Count { get; set; }
        public Recipe[] recipes;
    }
}
