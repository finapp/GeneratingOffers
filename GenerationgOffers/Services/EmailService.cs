using GenerationgOffers.IServices;
using GenerationgOffers.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GenerationgOffers.Services
{
    public class EmailService : IEmailService
    {
        private Offer offer;

        public EmailService()
        {
            offer = new Offer();
        }

        public string ValidateEmail(string email)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = new HtmlDocument();
            document.OptionOutputAsXml = true;
            document.LoadHtml(email);
            string t = "Dane klienta: Kwota limitu zł 50000   Email   katrans@katrans.pl      Firma   KATRANS SP. Z O.O.      Telefon 791869376       Branża  transport       Sprzedaż        2.000.000       Strona produktu http://www.smartfaktor.pl/produkty/faktoring/wycena";

            string text = document.DocumentNode.InnerText;

            List<string> words = GetWordsFromEmail(t);
            //List<string> words = GetWordsFromEmail(text);
            offer.limitAmount = GetLimitAmount(words);
            offer.companyEmail = GetCompanyEmail(words);
            offer.companyName = GetCompanyName(words);
            offer.telNumber = GetTelNumber(words);
            offer.line = GetLine(words);
            offer.sellValue = GetSellValue(words);

            return t;
        }

        public string GetCompanyName(List<string> words)
        {
            string name = string.Empty;
            bool isName = false;

            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].ToLower() == "firma")
                {
                    isName = true;
                }
                else if (isName)
                {
                    name = name + " " + words[i];
                }
                if (words[i + 1].ToLower() == "telefon")
                {
                    break;
                }
            }

            return name;
        }

        public int GetSellValue(List<string> words)
        {
            int sellValue;
            string sellValueString = string.Empty;

            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].ToLower() == "sprzedaż")
                {
                    sellValueString = words[i + 1];
                    break;
                }
            }

            string[] separators = new string[] { "." };
            string sellString = string.Empty;

            foreach (string word in sellValueString.Split(separators, StringSplitOptions.RemoveEmptyEntries))
            {
                sellString = sellString + word;
            }

            if (int.TryParse(sellString, out sellValue))
                return sellValue;

            return 0;
        }

        public string GetLine(List<string> words)
        {
            string line = string.Empty;

            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].ToLower() == "branża")
                {
                    line = words[i + 1];
                    break;
                }
            }

            return line;
        }

        public string GetTelNumber(List<string> words)
        {
            string tel = string.Empty;

            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].ToLower() == "telefon")
                {
                    tel = words[i + 1];
                    break;
                }
            }

            return tel;
        }

        public string GetCompanyEmail(List<string> words)
        {
            string email = string.Empty;

            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].ToLower() == "email")
                {
                    email = words[i + 1];
                    break;
                }
            }

            return email;
        }

        public int GetLimitAmount(List<string> words)
        {
            int amount = 0;
            foreach (var word in words)
            {
                if (int.TryParse(word, out amount))
                {
                    break;
                }
            }

            return amount;
        }

        public List<string> GetWordsFromEmail(string email)
        {
            List<string> words = new List<string>();
            string[] separators = new string[] { ",", ":", "\'", " ", "\'s", "\'n" };
            List<string> listOfWords = new List<string>();

            foreach (string word in email.Split(separators, StringSplitOptions.RemoveEmptyEntries))
            {
                words.Add(word);
            }

            foreach (var word in words)
            {
                var w = Regex.Replace(word, @"\s+", "");

                if (w != "")
                    listOfWords.Add(w);
            }

            return listOfWords;
        }
    }
}