﻿using Individuell.DAL;
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
    public class KontaktController : ControllerBase
    {
        private IFaqRepository _db;

        private ILogger<KontaktController> _log;

        public KontaktController(IFaqRepository db, ILogger<KontaktController> log)
        {
            _db = db;
            _log = log;
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

        [HttpGet]
        public async Task<ActionResult> HentKontakt()
        {
            List<Kontakter> hentAlle = await _db.HentKontakt();
            return Ok(hentAlle);// returnerer alltid OK, null ved tom DB
        }
    }
}
