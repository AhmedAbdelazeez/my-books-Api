using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data
{
    public class AppDbIntilizer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var services = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = services.ServiceProvider.GetService<AppdbContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "1st Book title",
                        Description = "1st book description",
                        IsRead = false,
                        DataRead = DateTime.Now.AddDays(-10),
                        Rate = 9,
                        Genra = "bigrofy",
                        
                        CoverUrl = "https.....",
                        DateAdded = DateTime.Now
                    },
                        new Book()
                        {
                            Title = "2st Book title",
                            Description = "2st book description",
                            IsRead = true,
                            
                            Genra = "bigrofy",
                            
                            CoverUrl = "https.....",
                            DateAdded = DateTime.Now
                        });
                    context.SaveChanges();
                  
                }
            }
        }
            
    }
}
