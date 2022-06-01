using AcademyF_ATCIT.Week7.Core.Entities;
using AcademyF_ATCIT.Week7.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyF_ATCIT.Week7.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdineController : ControllerBase
    {
        private readonly IMainBusinessLayer _mainBL;
        public OrdineController(IMainBusinessLayer mainBL)
        {
            _mainBL = mainBL;
        }
        // GET: api/<BookController>
        [HttpGet]
        public IActionResult GetOrdine()//tipo di restituzione in ambito web
        {
            var ordini = _mainBL.FetchOrdine();

            return Ok(ordini);//Arriva da controllerbase 
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult GetOrdineById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Ordine id");
            var ordine = _mainBL.GetOrdineById(id);
            if (ordine is null)
                return NotFound();

            return Ok(ordine);
            //status 400
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult CreateOrdine(Ordine newOrdine)
        {
            if (newOrdine is null)
                return BadRequest("Invalid Ordine data");

            Ordine new_Ordine = _mainBL.AddOrdine(newOrdine);

            if (new_Ordine == null)
            {
                return StatusCode(500, "Cannot save Ordine");
            }
            return CreatedAtAction(nameof(GetOrdineById), new { id = newOrdine.ID }, newOrdine);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateOrdine(int id, Ordine editedOrdine)
        {
            if (id <= 0 || editedOrdine is null)
                return BadRequest("Invalid Ordine data");
            if (id != editedOrdine.ID)
                return BadRequest("Invalid Ordine MISMATCH");

            Ordine editedUpdated = _mainBL.UpdateOrdine(editedOrdine);
            if (editedUpdated==null)
                return StatusCode(500, "Cannot update Ordine");
            return Ok();

        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string code)
        {

            var ordine = _mainBL.DeleteOrdineByCode(code);
            if (ordine is null)
                return NotFound();
            return Ok(ordine);
           
        }
    
}
}
