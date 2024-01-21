using BibleSearchApp.Models;
using System.Text.RegularExpressions;

namespace BibleSearchApp.Services
{
    /// <summary>
    ///
    ///     Service class for handling a search of the Service.
    ///     Implements the IBibleService interface.
    ///     
    ///     Technically, the BibleDAO could include the SanitizeInput method,
    ///     but this class allows for further development of features that
    ///     should not necessarily go into a DAO.
    /// 
    /// </summary>
    
    public class BibleSearchService : IBibleService
    {
        // reference the dao relevent to this service
        BibleDAO dao = new BibleDAO();

        // search the whole Service
        public List<VerseModel> SearchBible(string term)
        {
            return dao.SearchBible(term);
        }

        // only search the New Testament
        public List<VerseModel> SearchNT(string term)
        {
            return dao.SearchNT(term);
        }

        // only search the Old Testament
        public List<VerseModel> SearchOT(string term)
        {
            return dao.SearchOT(term);
        }

        // remove any numbers or special characters from the user's input
        // we only want words for this app
        public string SanitizeInput(string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return "";
            }
            return Regex.Replace(term, "[^a-zA-Z ]", "");
        }
    }

}
