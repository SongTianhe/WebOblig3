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


        [HttpPut]
        public async Task<ActionResult> Rating(NorWayFAQ endreRating)
        {
            bool returnOK = await _db.Rating(endreRating);
            if (!returnOK)
            {
                _log.LogInformation("Endring av rating kunne ikke utføres!");
                return NotFound();
            }
            return Ok();
        }
    }
}
