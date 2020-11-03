using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Individuell.DAL
{
    public static class DBInit
    {
        public static void Seed(IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();

            var db = serviceScope.ServiceProvider.GetService<FaqContext>();

            //db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var tema1 = new FAQ { Tema = "Før Reiser" };
            var tema2 = new FAQ { Tema = "Om Billett" };

            db.FAQer.Add(tema1);
            db.FAQer.Add(tema2);

            db.SaveChanges();
        }
    }
}
