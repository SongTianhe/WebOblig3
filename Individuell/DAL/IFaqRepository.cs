using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Individuell.DAL
{
    public interface IFaqRepository
    {
        Task<List<FAQ>> HentTema();
    }
}
