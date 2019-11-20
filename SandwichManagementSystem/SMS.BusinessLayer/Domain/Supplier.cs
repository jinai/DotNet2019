﻿using SMS.Shared;
using System.Collections.Generic;
using System.Linq;

namespace SMS.BusinessLayer.Domain
{
    public class Supplier
    {
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public Language LanguageChoice { get; set; }
        public List<Sandwich> Sandwiches { get; }
        public List<Bread> Pains { get; }

        public Supplier()
        {
            this.Sandwiches = new List<Sandwich>();
            this.Pains = new List<Bread>();
        }

        public Supplier(string name, string contactName, string email, Language languageChoice) : this()
        {
            this.Name = name;
            this.ContactName = contactName;
            this.Email = email;
            this.LanguageChoice = languageChoice;
        }

        public override string ToString()
        {
            string result = $"{Name} ({Email})\n";
            result += string.Join("\n", Sandwiches.Select(s => s.ToString(LanguageChoice)));
            return result;
        }
    }
}