using SampleEntityCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleEntityCore.Data
{
    public class DbInitializer
    {
        public static void Initialize(POSDataContext context)
        {
            context.Database.EnsureCreated();
            if (context.Categories.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                        new Category {CategoryName="Monitor"},
                         new Category {CategoryName="PC"},
                          new Category {CategoryName="Mouse"},
                           new Category {CategoryName="Keyboard"},

            };

            foreach(var cat in categories)
            {
                context.Categories.Add(cat);
            }
            context.SaveChanges();
        }

    }
}
