using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Books.Test
{
    [TestClass]
    public class BookTest
    {
        [TestMethod]
        public void TestEmptyConstructor()
        {
            Book book = new Book();

            Assert.AreEqual("UNGUELTIG", book.Isbn);
            Assert.AreEqual("Ohne Titel", book.Title);
            Assert.AreEqual(300, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestConstructor()
        {
            Book book = new Book("9783438013255", "Die Bibel", 900);

            Assert.AreEqual("9783438013255", book.Isbn);
            Assert.AreEqual("Die Bibel", book.Title);
            Assert.AreEqual(900, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestConstructorIsbnEmpty()
        {
            Book book = new Book("", "Die Bibel", 900);

            Assert.AreEqual("UNGUELTIG", book.Isbn);
            Assert.AreEqual("Die Bibel", book.Title);
            Assert.AreEqual(900, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestConstructorIsbnNull()
        {
            Book book = new Book(null, "Die Bibel", 900);

            Assert.AreEqual("UNGUELTIG", book.Isbn);
            Assert.AreEqual("Die Bibel", book.Title);
            Assert.AreEqual(900, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestConstructorIsbnInvalid()
        {
            Book book = new Book("1234567890123", "Die Bibel", 900);

            Assert.AreEqual("UNGUELTIG", book.Isbn);
            Assert.AreEqual("Die Bibel", book.Title);
            Assert.AreEqual(900, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestConstructorIsbnTooShort()
        {
            Book book = new Book("978149207258", "Die Bibel", 900);

            Assert.AreEqual("UNGUELTIG", book.Isbn);
            Assert.AreEqual("Die Bibel", book.Title);
            Assert.AreEqual(900, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestConstructorIsbnTooLong()
        {
            Book book = new Book("97814920725822", "Die Bibel", 900);

            Assert.AreEqual("UNGUELTIG", book.Isbn);
            Assert.AreEqual("Die Bibel", book.Title);
            Assert.AreEqual(900, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestConstructorIsbnContainsLetter()
        {
            Book book = new Book("9781A92072588", "Die Bibel", 900);

            Assert.AreEqual("UNGUELTIG", book.Isbn);
            Assert.AreEqual("Die Bibel", book.Title);
            Assert.AreEqual(900, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestConstructorTitleEmpty()
        {
            Book book = new Book("9783438013255", "", 900);

            Assert.AreEqual("9783438013255", book.Isbn);
            Assert.AreEqual("Ohne Titel", book.Title);
            Assert.AreEqual(900, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestConstructorTitleNull()
        {
            Book book = new Book("9783438013255", null, 900);

            Assert.AreEqual("9783438013255", book.Isbn);
            Assert.AreEqual("Ohne Titel", book.Title);
            Assert.AreEqual(900, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestConstructorPagesNegative()
        {
            Book book = new Book("9783438013255", "Die Bibel", -3);

            Assert.AreEqual("9783438013255", book.Isbn);
            Assert.AreEqual("Die Bibel", book.Title);
            Assert.AreEqual(24, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestConstructorPagesMuchTooSmall()
        {
            Book book = new Book("9783438013255", "Die Bibel", 7);

            Assert.AreEqual("9783438013255", book.Isbn);
            Assert.AreEqual("Die Bibel", book.Title);
            Assert.AreEqual(24, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestConstructorPagesTooSmall()
        {
            Book book = new Book("9783438013255", "Die Bibel", 23);

            Assert.AreEqual("9783438013255", book.Isbn);
            Assert.AreEqual("Die Bibel", book.Title);
            Assert.AreEqual(24, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestConstructorPagesSmallButValid()
        {
            Book book = new Book("9783438013255", "Die Bibel", 25);

            Assert.AreEqual("9783438013255", book.Isbn);
            Assert.AreEqual("Die Bibel", book.Title);
            Assert.AreEqual(25, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestSetTitle()
        {
            Book book = new Book("9783438013255", "Die Bibel", 1306);

            book.Title = "Java ist auch eine Insel";

            Assert.AreEqual("9783438013255", book.Isbn);
            Assert.AreEqual("Java ist auch eine Insel", book.Title);
            Assert.AreEqual(1306, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestSetTitleEmpty()
        {
            Book book = new Book("9783438013255", "Die Bibel", 1306);

            book.Title = "";

            Assert.AreEqual("9783438013255", book.Isbn);
            Assert.AreEqual("Ohne Titel", book.Title);
            Assert.AreEqual(1306, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestSetTitleNull()
        {
            Book book = new Book("9783438013255", "Die Bibel", 1306);

            book.Title = null;

            Assert.AreEqual("9783438013255", book.Isbn);
            Assert.AreEqual("Ohne Titel", book.Title);
            Assert.AreEqual(1306, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestSetPages()
        {
            Book book = new Book("9783438013255", "Die Bibel", 1306);

            book.Pages = 725;

            Assert.AreEqual("9783438013255", book.Isbn);
            Assert.AreEqual("Die Bibel", book.Title);
            Assert.AreEqual(725, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestSetPagesNegative()
        {
            Book book = new Book("9783438013255", "Die Bibel", 1306);

            book.Pages = -300;

            Assert.AreEqual("9783438013255", book.Isbn);
            Assert.AreEqual("Die Bibel", book.Title);
            Assert.AreEqual(24, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestSetPagesMuchTooSmall()
        {
            Book book = new Book("9783438013255", "Die Bibel", 1306);

            book.Pages = 10;

            Assert.AreEqual("9783438013255", book.Isbn);
            Assert.AreEqual("Die Bibel", book.Title);
            Assert.AreEqual(24, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestSetPagesTooSmall()
        {
            Book book = new Book("9783438013255", "Die Bibel", 1306);

            book.Pages = 23;

            Assert.AreEqual("9783438013255", book.Isbn);
            Assert.AreEqual("Die Bibel", book.Title);
            Assert.AreEqual(24, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestSetPagesSmallButValid()
        {
            Book book = new Book("9783438013255", "Die Bibel", 1306);

            book.Pages = 25;

            Assert.AreEqual("9783438013255", book.Isbn);
            Assert.AreEqual("Die Bibel", book.Title);
            Assert.AreEqual(25, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestRead()
        {
            Book book = new Book("9783438013255", "Die Bibel", 900);

            book.Read(100);

            Assert.AreEqual("9783438013255", book.Isbn);
            Assert.AreEqual("Die Bibel", book.Title);
            Assert.AreEqual(900, book.Pages);
            Assert.AreEqual(101, book.Bookmark);
        }

        [TestMethod]
        public void TestSetPagesResetsBookmark()
        {
            Book book = new Book("9783438013255", "Die Bibel", 900);

            book.Read(100);

            book.Pages = 1200;

            Assert.AreEqual("9783438013255", book.Isbn);
            Assert.AreEqual("Die Bibel", book.Title);
            Assert.AreEqual(1200, book.Pages);
            Assert.AreEqual(1, book.Bookmark);
        }

        [TestMethod]
        public void TestReadMultipleCalls()
        {
            Book book = new Book("9783438013255", "Die Bibel", 900);

            book.Read(100);
            book.Read(50);
            book.Read(100);
            book.Read(70);
            book.Read(3);

            Assert.AreEqual("9783438013255", book.Isbn);
            Assert.AreEqual("Die Bibel", book.Title);
            Assert.AreEqual(900, book.Pages);
            Assert.AreEqual(324, book.Bookmark);
        }

        [TestMethod]
        public void TestReadNegativeValue()
        {
            Book book = new Book("9783438013255", "Die Bibel", 900);

            book.Read(100);
            book.Read(-50);

            Assert.AreEqual("9783438013255", book.Isbn);
            Assert.AreEqual("Die Bibel", book.Title);
            Assert.AreEqual(900, book.Pages);
            Assert.AreEqual(101, book.Bookmark);
        }

        [TestMethod]
        public void TestReadTooManyPages()
        {
            Book book = new Book("9783438013255", "Die Bibel", 900);

            book.Read(1000);

            Assert.AreEqual("9783438013255", book.Isbn);
            Assert.AreEqual("Die Bibel", book.Title);
            Assert.AreEqual(900, book.Pages);
            Assert.AreEqual(900, book.Bookmark);
        }

        [TestMethod]
        public void TestReadTooManyPagesInMultipleCalls()
        {
            Book book = new Book("9783438013255", "Die Bibel", 900);

            book.Read(500);

            Assert.AreEqual(501, book.Bookmark);

            book.Read(50);

            Assert.AreEqual(551, book.Bookmark);

            book.Read(200);

            Assert.AreEqual(751, book.Bookmark);

            book.Read(145);

            Assert.AreEqual(896, book.Bookmark);

            book.Read(5);

            Assert.AreEqual(900, book.Bookmark);

            book.Read(1);

            Assert.AreEqual(900, book.Bookmark);
        }

        [TestMethod]
        public void TestToString()
        {
            Book book = new Book("9783438013255", "Die Bibel", 900);

            Assert.AreEqual("Die Bibel, 900 Seiten (ISBN: 9783438013255)", book.ToString());
        }

        [TestMethod]
        public void TestIsIsbnValidWithValidIsbns()
        {
            Assert.AreEqual(true, Book.IsIsbnValid("9783836228732"));
            Assert.AreEqual(true, Book.IsIsbnValid("9783438013255"));
            Assert.AreEqual(true, Book.IsIsbnValid("8601419987948"));
            Assert.AreEqual(true, Book.IsIsbnValid("9780307743688"));
            Assert.AreEqual(true, Book.IsIsbnValid("9780340992586"));
        }

        [TestMethod]
        public void TestIsIsbnValidWithInvalidIsbns()
        {
            Assert.AreEqual(false, Book.IsIsbnValid("978149207258"));
            Assert.AreEqual(false, Book.IsIsbnValid("97814920725822"));
            Assert.AreEqual(false, Book.IsIsbnValid("1234567890123"));
            Assert.AreEqual(false, Book.IsIsbnValid("9781492072582"));
            Assert.AreEqual(false, Book.IsIsbnValid("9780562538190"));
            Assert.AreEqual(false, Book.IsIsbnValid("97abc62538190"));
        }
    }
}
