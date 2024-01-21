using BibleSearchApp.Models;

namespace BibleSearchApp.Services
{
    /// <summary>
    /// 
    ///     Interface to be implemented in any Service class
    ///     Controllers should reference this interface.
    ///     A reference to the service this interface should implement should be mapped in Program.cs
    /// 
    /// </summary>
    
    public interface IBibleService
    {
        public List<VerseModel> SearchBible(string term); // search whole bible
        public List<VerseModel> SearchOT(string term); // search old testament
        public List<VerseModel> SearchNT(string term); // search new testament
        public string SanitizeInput(string term); // remove non-alphabetical caharacters from input
    }
}
