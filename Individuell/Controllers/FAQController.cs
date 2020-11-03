using Individuell.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Individuell.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class FAQController : ControllerBase
    {
        private IFaqRepository _db;

        private ILogger<FAQController> _log;

        public FAQController(IFaqRepository db, ILogger<FAQController> log)
        {
            _db = db;
            _log = log;
        }

        [HttpGet]
        public async Task<ActionResult> HentTema()
        {
            List<FAQ> hentAlle = await _db.HentTema();
            return Ok(hentAlle);// returnerer alltid OK, null ved tom DB
        }
    }
}
