using System.ComponentModel;

namespace BibleSearchApp.Models
{
    /// <summary>
    /// 
    ///     
    /// 
    /// </summary>

    public class VerseModel
    {
        // Properties

        // no validation annotations are added because the data related to this model is never created or edited by a user
        // data is read only from a database

        // these first 4 properties are not displayed anywhere in the app
        // so I did not add any annotations

        public int Id { get; set; }
        public int BookNumber { get; set; }
        public int ChapterNumber { get; set; }
        public int VerseNumber { get; set; }
        
        // DisplayName annotations were added to Reference and Text properties for the purpose of a table header
        // but the annotations are not currently used in the app because
        // I removed the table and created a custom scrollable list box

        [DisplayName("Reference")]
        public string Reference { get; set; }

        [DisplayName("Text")]
        public string Text {  get; set; }

        // full constructor
        public VerseModel(int id, int book, int chapter, int verse, string text)
        {
            Id = id;
            BookNumber = book;
            ChapterNumber = chapter;
            VerseNumber = verse;
            Reference = GetReferenceString(book, chapter, verse);
            Text = text;
        }

        // default constructor
        public VerseModel() { }

        // helper method for the constructor to generate the Reference property
        private string GetReferenceString(int book, int chapter, int verse)
        {
            return GetBookName(book) + " " + chapter + ":" + verse;
        }


        /// <summary>
        /// 
        ///     This helper method is used to convert the book number to a name
        ///     because the database table being used stores an index number to
        ///     reference a table containing the list of books.
        ///     
        ///     However, for the scope of this project, it was faster to have 
        ///     ChatGPT generate this method for me than to setup an extra table
        ///     and write the query statements to handle that setup.
        ///     
        ///     If needed to reference a table that was going to recieve data or
        ///     have it removed, it would have been necesssary to implement the
        ///     extra database table.
        ///     
        ///     I also could put this in a service as a static method and reference
        ///     it in the ToString method directly, but then it becomes a dependency.
        /// 
        /// </summary>
        /// <param name="bookNumber"></param>
        /// <returns></returns>


        private string GetBookName(int bookNumber)
        {
            string bookName;

            switch (bookNumber)
            {
                case 1:
                    bookName = "Genesis";
                    break;
                case 2:
                    bookName = "Exodus";
                    break;
                case 3:
                    bookName = "Leviticus";
                    break;
                case 4:
                    bookName = "Numbers";
                    break;
                case 5:
                    bookName = "Deuteronomy";
                    break;
                case 6:
                    bookName = "Joshua";
                    break;
                case 7:
                    bookName = "Judges";
                    break;
                case 8:
                    bookName = "Ruth";
                    break;
                case 9:
                    bookName = "1 Samuel";
                    break;
                case 10:
                    bookName = "2 Samuel";
                    break;
                case 11:
                    bookName = "1 Kings";
                    break;
                case 12:
                    bookName = "2 Kings";
                    break;
                case 13:
                    bookName = "1 Chronicles";
                    break;
                case 14:
                    bookName = "2 Chronicles";
                    break;
                case 15:
                    bookName = "Ezra";
                    break;
                case 16:
                    bookName = "Nehemiah";
                    break;
                case 17:
                    bookName = "Esther";
                    break;
                case 18:
                    bookName = "Job";
                    break;
                case 19:
                    bookName = "Psalms";
                    break;
                case 20:
                    bookName = "Proverbs";
                    break;
                case 21:
                    bookName = "Ecclesiastes";
                    break;
                case 22:
                    bookName = "Song of Solomon";
                    break;
                case 23:
                    bookName = "Isaiah";
                    break;
                case 24:
                    bookName = "Jeremiah";
                    break;
                case 25:
                    bookName = "Lamentations";
                    break;
                case 26:
                    bookName = "Ezekiel";
                    break;
                case 27:
                    bookName = "Daniel";
                    break;
                case 28:
                    bookName = "Hosea";
                    break;
                case 29:
                    bookName = "Joel";
                    break;
                case 30:
                    bookName = "Amos";
                    break;
                case 31:
                    bookName = "Obadiah";
                    break;
                case 32:
                    bookName = "Jonah";
                    break;
                case 33:
                    bookName = "Micah";
                    break;
                case 34:
                    bookName = "Nahum";
                    break;
                case 35:
                    bookName = "Habakkuk";
                    break;
                case 36:
                    bookName = "Zephaniah";
                    break;
                case 37:
                    bookName = "Haggai";
                    break;
                case 38:
                    bookName = "Zechariah";
                    break;
                case 39:
                    bookName = "Malachi";
                    break;                  //   OLD TESTAMENT /\ /\ /\  
                case 40:
                    bookName = "Matthew";   //   NEW TESTAMENT \/ \/ \/
                    break;
                case 41:
                    bookName = "Mark";
                    break;
                case 42:
                    bookName = "Luke";
                    break;
                case 43:
                    bookName = "John";
                    break;
                case 44:
                    bookName = "Acts";
                    break;
                case 45:
                    bookName = "Romans";
                    break;
                case 46:
                    bookName = "1 Corinthians";
                    break;
                case 47:
                    bookName = "2 Corinthians";
                    break;
                case 48:
                    bookName = "Galatians";
                    break;
                case 49:
                    bookName = "Ephesians";
                    break;
                case 50:
                    bookName = "Philippians";
                    break;
                case 51:
                    bookName = "Colossians";
                    break;
                case 52:
                    bookName = "1 Thessalonians";
                    break;
                case 53:
                    bookName = "2 Thessalonians";
                    break;
                case 54:
                    bookName = "1 Timothy";
                    break;
                case 55:
                    bookName = "2 Timothy";
                    break;
                case 56:
                    bookName = "Titus";
                    break;
                case 57:
                    bookName = "Philemon";
                    break;
                case 58:
                    bookName = "Hebrews";
                    break;
                case 59:
                    bookName = "James";
                    break;
                case 60:
                    bookName = "1 Peter";
                    break;
                case 61:
                    bookName = "2 Peter";
                    break;
                case 62:
                    bookName = "1 John";
                    break;
                case 63:
                    bookName = "2 John";
                    break;
                case 64:
                    bookName = "3 John";
                    break;
                case 65:
                    bookName = "Jude";
                    break;
                case 66:
                    bookName = "Revelation";
                    break;
                default:
                    bookName = "Unknown";
                    break;
            }

            return bookName;
        }
    }
}
