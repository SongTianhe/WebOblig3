using Individuell.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Individuell.DAL
{
    public class FaqRepository : IFaqRepository
    {
        private readonly FaqContext _db;

        public FaqRepository(FaqContext db)
        {
            _db = db;
        }

        public async Task<List<FAQ>> HentTema()
        {
            try
            {
                
                List<FAQ> alleTema = await _db.FAQer.ToListAsync();
                return alleTema;
                /*
                List<FAQ> alleTema = await _db.FAQer.ToListAsync();
                List<NorWayFAQ> alleSpm = new List<NorWayFAQ>();
                foreach(var tema in alleTema)
                {
                    foreach (var spm in tema.Sporsmaler)
                    {
                        var enSpm = new NorWayFAQ()
                        {
                            Id = tema.Id,
                            Tema = tema.Tema,
                            Question = spm.Question,
                            Svar = spm.Svar,
                            Positiv = spm.Positiv,
                            Negativ = spm.Negativ
                        };
                        alleSpm.Add(enSpm);
                    }
                }
                return alleSpm;*/
            }
            catch
            {
                return null;
            }
        }

        
        public async Task<List<NorWayFAQ>> HentSpm(int id)
        {
            try
            {
                FAQ temaen = await _db.FAQer.FindAsync(id);
                List<NorWayFAQ> alleSpm = new List<NorWayFAQ>();

                foreach (var spm in temaen.Sporsmaler)
                {
                    var enSpm = new NorWayFAQ()
                    {
                        Tema = temaen.Tema,
                        Question = spm.Question,
                        Svar = spm.Svar,
                        Positiv = spm.Positiv,
                        Negativ = spm.Negativ
                    };
                    alleSpm.Add(enSpm);
                }

                return alleSpm;

                /*
                List<Sporsmal> alleSpm = await _db.Sporsmaler.ToListAsync();

                var finnSpm = (from spm in alleSpm
                               where spm.SId == id
                               select spm).ToList();

                return finnSpm;*/
            }
            catch
            {
                return null;
            }
        }
    }
}
