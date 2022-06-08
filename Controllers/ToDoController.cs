using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPII.Models;

namespace WebAPII.Controllers
{
    [ApiController]
    [Route(template: "v1/")]
    public class ToDoController : ControllerBase
    {
        [HttpGet]
        [Route(template: "ToDos")]
        public List<ToDo> Get() => new List<ToDo>();
    }
}