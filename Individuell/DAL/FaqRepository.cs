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

                //Sorter alle spørsmål ved "positiv", spørsmålet som har bedre vurdering hent ut først
                var order = temaen.Sporsmaler.OrderByDescending(r => r.Positiv);

                    foreach (var spm in order)
                    {
                    //Erklære at NorWayFAQ og id er id-en for spørsmålet, slike at kan bruk id-en til å hente det valgte spørsmålet etterpå.
                    var enSpm = new NorWayFAQ()
                        {
                            Id = spm.SId,
                            Tema = temaen.Tema,
                            Question = spm.Question,
                            Svar = spm.Svar,
                            Positiv = spm.Positiv,
                            Negativ = spm.Negativ
                        };
                        alleSpm.Add(enSpm);
                    }

                return alleSpm;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> LagreMelding(Kontakt innMelding)
        {
            try
            {
                var nyMelding = new Kontakter()
                {
                    Fornavn = innMelding.Fornavn,
                    Etternavn = innMelding.Etternavn,
                    Epost = innMelding.Epost,
                    Melding = innMelding.Melding
                };

                _db.Kontakter.Add(nyMelding);
                await _db.SaveChangesAsync();

                return true;

            }catch
            {
                return false;
            }
        }

        public async Task<bool> Rating(NorWayFAQ endreRating)
        {
            try
            {
                var endreObjekt = await _db.Sporsmaler.FindAsync(endreRating.Id);

                endreObjekt.Positiv = endreRating.Positiv;
                endreObjekt.Negativ = endreRating.Negativ;

                await _db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Kontakter>> HentKontakt()
        {
            try
            {

                List<Kontakter> alleKontakt = await _db.Kontakter.ToListAsync();
                return alleKontakt;

            }
            catch
            {
                return null;
            }
        }

    }
}
