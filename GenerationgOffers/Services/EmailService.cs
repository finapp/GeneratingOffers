using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
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

            HtmlNode node = document.DocumentNode;

            

            return null;
        }

    }
}