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
            HtmlNode node = document.DocumentNode;

            string text = document.DocumentNode.InnerText;
            var words = GetWordsFromEmail(t);

            int limitAmount;
            string emailName;
            string firmName;
            string telNumber;
            string trade;
            string amountString;

            //foreach (var word in words)
            //{
            //    if()
            //}
            return null;
        }

        public IEnumerable<string> GetWordsFromEmail(string email)
        {
            MatchCollection matches = Regex.Matches(email, @"\b[\w']*\b");

            return from m in matches.Cast<Match>()
                   where !string.IsNullOrEmpty(m.Value)
                   select TrimSuffix(m.Value);
        }

        static string TrimSuffix(string word)
        {
            int apostropheLocation = word.IndexOf('\'');
            if (apostropheLocation != -1)
            {
                word = word.Substring(0, apostropheLocation);
            }

            return word;
        }

    }
}