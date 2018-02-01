using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleTelegramBotApp.BLL.Interfaces;
using SimpleTelegramBotApp.DAL.Entities;

namespace SimpleTelegramBotApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Translations")]
    public class TranslationsController : Controller
    {
        private ICrudService<Translation> TranslationService { get; }

        public TranslationsController(ICrudService<Translation> translationService)
        {
            TranslationService = translationService;
        }

        // GET: api/Translations
        [HttpGet]
        public IEnumerable<Translation> GetTranslations()
        {
            return TranslationService.Get();
        }

        // GET: api/Translations/5
        [HttpGet("{id}")]
        public IActionResult GetTranslation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var translation = TranslationService.Get(id);

            return Ok(translation);
        }

        // PUT: api/Translations/5
        [HttpPut("{id}")]
        public IActionResult PutTranslation([FromRoute] int id, [FromBody] Translation translation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TranslationService.Update(translation);

            return NoContent();
        }

        // POST: api/Translations
        [HttpPost]
        public IActionResult PostTranslation([FromBody] Translation translation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TranslationService.Create(translation);

            return CreatedAtAction("GetTranslation", new { id = translation.Id }, translation);
        }

        // DELETE: api/Translations/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTranslation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TranslationService.Delete(id);

            return NoContent();
        }
    }
}