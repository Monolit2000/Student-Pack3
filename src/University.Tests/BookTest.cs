﻿using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.SymbolStore;
using System.Linq;
using University.Data;
using University.Interfaces;
using University.Models;
using University.Services;
using University.ViewModels;

namespace University.Tests
{
    [TestClass]
    public class LibraryBooksTest
    {
        private IDialogService _dialogService;
        private DbContextOptions<UniversityContext> _options;

        [TestInitialize()]
        public void Initialize()
        {
            _options = new DbContextOptionsBuilder<UniversityContext>()
                .UseInMemoryDatabase(databaseName: "UniversityTestDB")
                .Options;
            SeedTestDB();
            _dialogService = new DialogService();
        }

        private void SeedTestDB()
        {
            using UniversityContext context = new UniversityContext(_options);
            {
                context.Database.EnsureDeleted();

                var books = new List<Book>
                {
                    new Book { BookId = 1, Title = "Book One", Author = "Author A", Publisher = "Publisher A", PublicationDate = new DateTime(2000, 01, 01), ISBN = "1234567890123", Genre = "Genre A", Description = "Description A" },
                    new Book { BookId = 2, Title = "Book Two", Author = "Author B", Publisher = "Publisher B", PublicationDate = new DateTime(2005, 05, 05), ISBN = "1234567890124", Genre = "Genre B", Description = "Description B" },
                    new Book { BookId = 3, Title = "Book Three", Author = "Author C", Publisher = "Publisher C", PublicationDate = new DateTime(2010, 10, 10), ISBN = "1234567890125", Genre = "Genre C", Description = "Description C" }
                };

          

                context.Books.AddRange(books);
                context.SaveChanges();
            }
        }

        #region Add

        [TestMethod]
        public void Show_all_books()
        {
            using UniversityContext context = new UniversityContext(_options);
            {
                AddBookViewModel addBookViewModel = new AddBookViewModel(context, _dialogService);
                bool hasData =  !string.IsNullOrEmpty(addBookViewModel.Title);
                Assert.IsFalse(hasData);
            }
        }

        [TestMethod]
        public void Add_book_without_libraries()
        {
            using UniversityContext context = new UniversityContext(_options);
            {
                AddBookViewModel addBookViewModel = new AddBookViewModel(context, _dialogService)
                {
                    Title = "New Book",
                    Author = "New Author",
                    Publisher = "New Publisher",
                    PublicationDate = new DateTime(2020, 01, 01),
                    ISBN = "9876543210123",
                    Genre = "New Genre",
                    Description = "New Description"
                };

                addBookViewModel.Save.Execute(null);

                bool newBookExists = context.Books.Any(b => b.Title == "New Book" && b.Author == "New Author");
                Assert.IsTrue(newBookExists);
            }
        }

        [TestMethod]
        public void Add_books()
        {
            using UniversityContext context = new UniversityContext(_options);
            {
                AddBookViewModel addBookViewModel = new AddBookViewModel(context, _dialogService);
                var book = context.Books.First();

                addBookViewModel.Title = "New Book";
                addBookViewModel.Author = "New Author";
                addBookViewModel.Publisher = "New Publisher";
                addBookViewModel.PublicationDate = new DateTime(2020, 01, 01);
                addBookViewModel.ISBN = "9876543210123";
                addBookViewModel.Genre = "New Genre";
                addBookViewModel.Description = "New Description";

                addBookViewModel.Save.Execute(null);

                bool newBookExists = context.Books.Any(b => b.Title == "New Book");
                Assert.IsTrue(newBookExists);
            }
        }

        [TestMethod]
        public void Add_book_without_title()
        {
            using UniversityContext context = new UniversityContext(_options);
            {
                AddBookViewModel addBookViewModel = new AddBookViewModel(context, _dialogService)
                {
                    Author = "Author without Title",
                    Publisher = "Publisher without Title",
                    PublicationDate = new DateTime(2020, 01, 01),
                    ISBN = "9876543210124",
                    Genre = "Genre without Title",
                    Description = "Description without Title"
                };

                addBookViewModel.Save.Execute(null);

                bool newBookExists = context.Books.Any(b => b.Author == "Author without Title");
                Assert.IsFalse(newBookExists);
            }
        }


        #endregion

        #region Edit

        // Тест для успешного редактирования книги
        [TestMethod]
        public void Edit_book_success()
        {
            using UniversityContext context = new UniversityContext(_options);
            {
                EditBookViewModel editBookViewModel = new EditBookViewModel(context, _dialogService)
                {
                    BookId = 1,
                    Title = "Updated Book One",
                    Author = "Updated Author A",
                    Publisher = "Updated Publisher A",
                    PublicationDate = new DateTime(2001, 01, 01),
                    ISBN = "1234567890123",
                    Genre = "Updated Genre A",
                    Description = "Updated Description A"
                };

                editBookViewModel.Save.Execute(null);

                var updatedBook = context.Books.FirstOrDefault(b => b.BookId == 1);

                Assert.IsNotNull(updatedBook);
                Assert.AreEqual("Updated Book One", updatedBook.Title);
                Assert.AreEqual("Updated Author A", updatedBook.Author);
                Assert.AreEqual("Updated Publisher A", updatedBook.Publisher);
                Assert.AreEqual(new DateTime(2001, 01, 01), updatedBook.PublicationDate);
                Assert.AreEqual("Updated Genre A", updatedBook.Genre);
                Assert.AreEqual("Updated Description A", updatedBook.Description);
            }
        }

        // Тест для редактирования книги с отсутствующими обязательными полями
        [TestMethod]
        public void Edit_book_missing_required_fields()
        {
            using UniversityContext context = new UniversityContext(_options);
            {
                EditBookViewModel editBookViewModel = new EditBookViewModel(context, _dialogService)
                {
                    BookId = 1,
                    Title = string.Empty,
                    Author = string.Empty,
                    Publisher = string.Empty,
                    PublicationDate = null,
                    ISBN = string.Empty,
                    Genre = string.Empty,
                    Description = string.Empty
                };

                editBookViewModel.Save.Execute(null);

                var book = context.Books.FirstOrDefault(b => b.BookId == 1);

                Assert.IsNotNull(book);
                Assert.AreEqual("Book One", book.Title);  // Title should not change
                Assert.AreEqual("Author A", book.Author); // Author should not change
            }
        }

        // Тест для редактирования несуществующей книги
        [TestMethod]
        public void Edit_nonexistent_book()
        {
            using UniversityContext context = new UniversityContext(_options);
            {
                EditBookViewModel editBookViewModel = new EditBookViewModel(context, _dialogService)
                {
                    BookId = 999,
                    Title = "Nonexistent Book",
                    Author = "Nonexistent Author",
                    Publisher = "Nonexistent Publisher",
                    PublicationDate = new DateTime(2020, 01, 01),
                    ISBN = "9999999999999",
                    Genre = "Nonexistent Genre",
                    Description = "Nonexistent Description"
                };

                editBookViewModel.Save.Execute(null);

                var book = context.Books.FirstOrDefault(b => b.BookId == 999);

                Assert.IsNull(book);
            }
        }

        [TestMethod]
        public void Edit_book()
        {
            using var context = new UniversityContext(_options);
            {
                var viewModel = new EditBookViewModel(context, _dialogService)
                {
                    BookId = 2,
                    Title = "Updated Book Two",
                    Author = "Updated Author B",
                    Publisher = "Updated Publisher B",
                    PublicationDate = new DateTime(2006, 06, 06),
                    ISBN = "1234567890126",
                    Genre = "Updated Genre B",
                    Description = "Updated Description B"
                };

                viewModel.Save.Execute(null);

                var updatedBook = context.Books.First(b => b.BookId == 2);

                Assert.AreEqual("Updated Book Two", updatedBook.Title);
                Assert.AreEqual("Updated Author B", updatedBook.Author);
                Assert.AreEqual("Updated Publisher B", updatedBook.Publisher);
                Assert.AreEqual(new DateTime(2006, 06, 06), updatedBook.PublicationDate);
                Assert.AreEqual("Updated Genre B", updatedBook.Genre);
                Assert.AreEqual("Updated Description B", updatedBook.Description);
            }
        }





        [TestMethod]
        public void Edit_books()
        {
            using var context = new UniversityContext(_options);
            {
                var viewModel = new EditBookViewModel(context, _dialogService)
                {
                    BookId = 1,
                    Title = "Updated Book One",
                    Author = "Updated Author A",
                    Publisher = "Updated Publisher A",
                    PublicationDate = new DateTime(2001, 01, 01),
                    ISBN = "1234567890126",
                    Genre = "Updated Genre A",
                    Description = "Updated Description A"
                };

                viewModel.Save.Execute(null);

                var updatedBook = context.Books.First(b => b.BookId == 1);

                Assert.AreEqual("Updated Book One", updatedBook.Title);
                Assert.AreEqual("Updated Author A", updatedBook.Author);
                Assert.AreEqual("Updated Publisher A", updatedBook.Publisher);
                Assert.AreEqual(new DateTime(2001, 01, 01), updatedBook.PublicationDate);
                Assert.AreEqual("Updated Genre A", updatedBook.Genre);
                Assert.AreEqual("Updated Description A", updatedBook.Description);
            }
        }

        #endregion
    }
}
