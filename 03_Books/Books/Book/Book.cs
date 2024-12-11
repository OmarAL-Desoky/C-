using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
   public class Book
   {
        private const int MIN_PAGES = 24;
        private const int CONSTRUCTOR_MIN_PAGES = 300;
        private const int MIN_READ_PAGES = 1;
        private const int ISBN_LENGTH = 13;

        private const int NUMBER_TO_MULTIPLY_WITH_WHEN_EVEN = 1;
        private const int NUMBER_TO_MULTIPLY_WITH_WHEN_ODD = 3;

        private string isbn;
        private string title;
        private int pages;
        private int bookmark;

        public string Isbn
        {
            get
            {
                return isbn;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length != 13 || !ContainsOnlyDigits(value) || !IsIsbnValid(value))
                {
                    value = "UNGUELTIG";
                }

                this.isbn = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = "Ohne Titel";
                }

                this.title = value;
            }
        }


        public int Pages
        {
            get
            {
                return this.pages;
            }
            set
            {
                if(value < MIN_PAGES)
                {
                    value = MIN_PAGES;
                }
                
                this.pages = value;
                this.Bookmark = MIN_READ_PAGES;
            }
        }

        public int Bookmark
        {
            get
            {
                return this.bookmark;
            }
            private set
            {
                this.bookmark = value;
            }
        }

        public Book()
            :this("UNGUELTIG", "Ohne Titel", CONSTRUCTOR_MIN_PAGES)
        {
        }

        public Book(string isbn, string title, int pages)
        {
            this.Isbn = isbn;
            this.Title = title;
            this.Pages = pages;
        }

        public void Read(int pagesRead)
        {
            int result = this.bookmark + pagesRead;

            if(result > this.pages)
            {
                this.bookmark = this.pages;
            }
            else
            {
                if(pagesRead > 0)
                {
                    this.bookmark += pagesRead;
                }
            }
        }

        public override string ToString()
        {
            string result = $"{this.title}, {this.pages} Seiten (ISBN: {this.isbn})";
            return result;
        }

        public static bool ContainsOnlyDigits(string isbn)
        {
            bool containsOnlyDigits = true;

            for(int i = 0; i < isbn.Length - 1 && containsOnlyDigits; i++)
            {
                if (!('0' <= isbn[i] && isbn[i] <= '9'))
                {
                    containsOnlyDigits = false;
                }
            }

            return containsOnlyDigits;
        }

        public static bool IsIsbnValid(string isbn)
        {
            bool isValid = false;

            if(isbn.Length == ISBN_LENGTH && ContainsOnlyDigits(isbn))
            {
                int sum = 0;
                for(int i = 0; i < isbn.Length - 1; i++)
                {
                    if(i % 2 == 0)
                    {
                        sum += ((isbn[i] - '0') * NUMBER_TO_MULTIPLY_WITH_WHEN_EVEN);
                    }
                    else
                    {
                        sum += ((isbn[i] - '0') * NUMBER_TO_MULTIPLY_WITH_WHEN_ODD);
                    }
                }

                sum %= 10;
                sum = 10 - sum % 10;

                if (sum == (isbn[isbn.Length - 1] - '0'))
                {
                    isValid = true;
                }
            }

            return isValid;
        }
    }
}
