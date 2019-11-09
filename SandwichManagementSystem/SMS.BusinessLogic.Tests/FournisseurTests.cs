﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SMS.BusinessLogic.Tests
{
    [TestClass]
    public class FournisseurTests
    {
        public static Language EN = Language.English;
        public static Language FR = Language.French;
        public static Language NL = Language.Dutch;

        [TestMethod]
        public void Test_ToString()
        {
            // Arrange
            var ts1 = new TranslatedString("Peanut butter and jelly sandwich", "Sandwich beurre de cacahuète et confiture", "Broodje pindakaas en jam");
            var ts2 = new TranslatedString("Ham and cheese sandwich", "Sandwich jambon et fromage", "Broodje ham en kaas");
            var ts3 = new TranslatedString("Peanut butter", "Beurre de cacahuète", "Pindakaas");
            var ts4 = new TranslatedString("Jelly", "Confiture", "Jam");
            var ts5 = new TranslatedString("Ham", "Jambon", "Ham");
            var ts6 = new TranslatedString("Cheese", "Fromage", "Kaas");

            var fns1 = new Fournisseur("Fournisseur 1", "F1", "fournisseur1@gmail.com", EN);

            var sand1 = new Sandwich(ts1, fns1);
            var sand2 = new Sandwich(ts2, fns1);
            var sand3 = new Sandwich(new TranslatedString("A", "B", "C"), fns1);

            var ing1 = new Ingredient(ts3, true);
            var ing2 = new Ingredient(ts4);
            var ing3 = new Ingredient(ts5);
            var ing4 = new Ingredient(ts6);

            // Act
            sand1.Ingredients.Add(ing1);
            sand1.Ingredients.Add(ing2);
            sand2.Ingredients.Add(ing3);
            sand2.Ingredients.Add(ing4);

            fns1.Sandwiches.Add(sand1);
            fns1.Sandwiches.Add(sand2);
            fns1.Sandwiches.Add(sand3);

            // Assert
            Assert.AreEqual("Fournisseur 1 (fournisseur1@gmail.com)\nPeanut butter and jelly sandwich - Peanut butter*, Jelly\nHam and cheese sandwich - Ham, Cheese\nA - ", fns1.ToString());
            fns1.LanguageChoice = FR;
            Assert.AreEqual("Fournisseur 1 (fournisseur1@gmail.com)\nSandwich beurre de cacahuète et confiture - Beurre de cacahuète*, Confiture\nSandwich jambon et fromage - Jambon, Fromage\nB - ", fns1.ToString());
            fns1.LanguageChoice = NL;
            Assert.AreEqual("Fournisseur 1 (fournisseur1@gmail.com)\nBroodje pindakaas en jam - Pindakaas*, Jam\nBroodje ham en kaas - Ham, Kaas\nC - ", fns1.ToString());
        }
    }
}