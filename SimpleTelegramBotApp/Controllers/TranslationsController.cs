using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleTelegramBotApp.BLL.DTOs;
using SimpleTelegramBotApp.BLL.Interfaces;

namespace SimpleTelegramBotApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Translations")]
    public class TranslationsController : Controller
    {
        private ICrudService<TranslationDto> TranslationService { get; }

        public TranslationsController(ICrudService<TranslationDto> translationService)
        {
            TranslationService = translationService;
        }

        // GET: api/Translations
        [HttpGet]
        public IEnumerable<TranslationDto> GetTranslations()
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
        public IActionResult PutTranslation([FromRoute] int id, [FromBody] TranslationDto translation)
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
        public IActionResult PostTranslation([FromBody] TranslationDto translation)
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