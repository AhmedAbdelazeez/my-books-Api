using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.viewmodel;
using my_books.Exceptoon;
using System;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuplisherController : ControllerBase
    {
        private PulisherService _pulisherService;
        public PuplisherController(PulisherService pulisherService)
        {
            _pulisherService=pulisherService;
        }
        [HttpGet("get-all-publisher")]
        public IActionResult getallpuplisher(string sortby,string searchString,int pagenumber)
        {
            
            try
            {
                var r = _pulisherService.GetAllPuplisger(sortby, searchString, pagenumber);
                return Ok(r);
            }
            catch
            {
                return BadRequest("Sory ,we couid Not Load the puplishers");
            }
        }
        [HttpPost("Add-Puplisher")]
        public IActionResult Addpublisher([FromBody] PuplisherVm puplisher)
        {
            try
            {
                var newpuplishea = _pulisherService.AddPuplisher(puplisher);
                return Created(nameof(Addpublisher), newpuplishea);
            }
            catch(PublisherExptionName ex)
            {
                return BadRequest($"{ ex.Message},Publisher name:{ex.publisherName}");
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult getbyid(int id)
        {
            var response = _pulisherService.Getpuplisherbyid(id);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("get-publisher-books-whith-autgors/{id}")]
        public IActionResult GetPuplisherData(int id)
        {
            var response =_pulisherService.GetPuplisherData(id);
            return Ok(response);
           
        }

        [HttpDelete("delete-puplsher-by-id/{id}")]
        public IActionResult DeletepuplisherbyId(int id)
        {
            try
            {
                _pulisherService.DeletepuplisherbyId(id);
                return Ok();
            }
            
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}
