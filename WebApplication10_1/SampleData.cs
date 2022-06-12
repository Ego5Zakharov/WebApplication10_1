using WebApplication10_1.Data;
using WebApplication10_1.Models;

namespace WebApplication10_1
{
    public static class SampleData
    {

        public static LibraryContext _context { get; set; }
        static List<Book> Books { get; }
        public static List<Book> GetAll() => Books;
        public static Book GetById(int id) => Books.FirstOrDefault(p => p.Id == id);

        public static void Delete(int id)
        {
            var product = GetById(id);

            if (product is null)
            {
                return;
            }
            _context.Books.Remove(product);
        }


        public static void Initialize1(LibraryContext context)
        {
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        Title = "Сборник стихотворений А.С.Пушкина1",
                        Author = "А.С.Пушкин",
                        Price = 600
                    },
                    new Book
                    {
                        Title = "Сборник стихотворений А.С.Пушкина2",
                        Author = "А.С.Пушкин",
                        Price = 500
                    },
                    new Book
                    {
                        Title = "Сборник стихотворений А.С.Пушкина3",
                        Author = "А.С.Пушкин",
                        Price = 400
                    },
                     new Book
                     {
                         Title = "Сборник стихотворений А.С.Пушкина3",
                         Author = "А.С.Пушкин555555",
                         Price = 400
                     }
                    );

                context.SaveChanges();
            }
        }

        //public static void Initialize2(UserContext context1)
        //{
        //    if (context1.Users.Any())
        //    {
        //        context1.Users.AddRange(
        //            new User
        //            {
        //                UserName = "Egor1",
        //                Path = "123",
        //                Books =
        //                {
        //                new Book { Title = "AboutMyPain1", Author = "Egor", Price = 5060 },
        //                new Book { Title = "AboutMyPain2", Author = "Egor", Price = 5400 },
        //                new Book { Title = "AboutMyPain3", Author = "Egor", Price = 5300 },
        //                new Book { Title = "AboutMyPain4", Author = "Egor", Price = 5010 },
        //                }
        //            },

        //           new User
        //           {
        //               UserName = "Egor2",
        //               Path = "123",
        //               Books =
        //                {
        //                new Book { Title = "AboutMyPain1", Author = "Egor", Price = 5060 },
        //                new Book { Title = "AboutMyPain2", Author = "Egor", Price = 5400 },
        //                new Book { Title = "AboutMyPain3", Author = "Egor", Price = 5300 },
        //                new Book { Title = "AboutMyPain4", Author = "Egor", Price = 5010 },
        //                }
        //           },
        //           new User
        //           {
        //               UserName = "Egor3",
        //               Path = "123",
        //               Books =
        //                {
        //                new Book { Title = "AboutMyPain1", Author = "Egor", Price = 5060 },
        //                new Book { Title = "AboutMyPain2", Author = "Egor", Price = 5400 },
        //                new Book { Title = "AboutMyPain3", Author = "Egor", Price = 5300 },
        //                new Book { Title = "AboutMyPain4", Author = "Egor", Price = 5010 },
        //                }
        //           });

        //        context1.SaveChanges();
        //    }
        //}
    }
}

