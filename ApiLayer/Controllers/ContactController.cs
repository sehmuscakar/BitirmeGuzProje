using BusinessLayer.Abstract;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IPostContactManager _postContactManager;

        public ContactController(IPostContactManager postContactManager)
        {
            _postContactManager = postContactManager;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _postContactManager.GetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddContact(PostContact postContact)
        {
            _postContactManager.Add(postContact);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var values = _postContactManager.GetByID(id);
            _postContactManager.Remove(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateContact(PostContact postContact)
        {
            _postContactManager.Update(postContact);
            return Ok();
        }


        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var values = _postContactManager.GetByID(id);
            return Ok(values);
        }

    }
}
