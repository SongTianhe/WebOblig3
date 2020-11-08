using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Individuell.DAL
{
    public class FAQ
    {
        [Key]
        public int Id { get; set; }
        public string Tema { get; set; }

        public virtual List<Sporsmal> Sporsmaler { get;set; }
    }

    public class Sporsmal
    {
        [Key]
        public int SId { get; set; }
        public string Question { get; set; }
        public string Svar { get; set; }
        public int Positiv { get; set; }
        public int Negativ { get; set; }
    }

    public class Kontakter
    {
        [Key]
        public int KId { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Epost { get; set; }
        public string Melding { get; set; }
    }

    public class FaqContext : DbContext
    {
        public FaqContext (DbContextOptions<FaqContext> options)
                 : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<FAQ> FAQer { get; set; }
        public DbSet<Sporsmal> Sporsmaler { get; set; }
        public DbSet<Kontakter> Kontakter { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
