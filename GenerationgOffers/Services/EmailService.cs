using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GenerationgOffers.Services
{
    public class EmailService
    {
        public string ValidateEmail(string email)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = new HtmlDocument();
            document.OptionOutputAsXml = true;
            document.LoadHtml(email);
            string t = "Dane klienta: Kwota limitu zł 50000   Email   katrans@katrans.pl      Firma   KATRANS SP. Z O.O.      Telefon 791869376       Branża  transport       Sprzedaż        2.000.000       Strona produktu http://www.smartfaktor.pl/produkty/faktoring/wycena";

            string text = document.DocumentNode.InnerText;

            List<string> words = GetWordsFromEmail(t);
            int limitAmount;
            string companyEmail;
            string companyName;
            string telNumber;
            string line;
            string sellString;
            string productPage;


            for (int i = 0; i < words.Count; i++)
            {

            }
      
            return t;
        }

        public int GetLimitAmount(List<string> words)
        {

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