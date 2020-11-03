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
            List<FAQ> alleTema = await _db.FAQer.ToListAsync();
            return alleTema;
        }
    }
}
