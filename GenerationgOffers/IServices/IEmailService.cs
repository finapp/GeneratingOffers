using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerationgOffers.IServices
{
    public interface IEmailService
    {
        string ValidateEmail(string email);
        string GetCompanyName(List<string> words);
        int GetSellValue(List<string> words);
        string GetLine(List<string> words);
        string GetTelNumber(List<string> words);
        string GetCompanyEmail(List<string> words);
        int GetLimitAmount(List<string> words);
        List<string> GetWordsFromEmail(string email);
    }
}
