using Individuell.DAL;
using Individuell.Model;
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

        
        [HttpGet("{id}")]
        public async Task<ActionResult> HentSpm(int id)
        {
            if (ModelState.IsValid)
            {
                var temaen = await _db.HentSpm(id);
                if (temaen == null)
                {
                    _log.LogInformation("Fant ikke kunden");
                    return NotFound();
                }
                return Ok(temaen);
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult> LagreMelding(Kontakt innMelding)
        {
            if (ModelState.IsValid)
            {
                bool returnOK = await _db.LagreMelding(innMelding);
                if (!returnOK)
                {
                    _log.LogInformation("Meldingen kan ikke lagres!");
                    return BadRequest();
                }
                return Ok();
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest();
        }
    }
}
