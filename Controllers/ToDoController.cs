using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPII.Data;
using WebAPII.Models;
using WebAPII.View;

namespace WebAPII.Controllers
{
    [ApiController]
    [Route(template: "v1/")]
    public class ToDoController : ControllerBase
    {
        //ToDo: 4 - Cria o método Get
        [HttpGet]
        [Route(template: "ToDos")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context)
        {
            var toDos = await context //AppDbContext
            .ToDos //DbSet <ToDo>
            .AsNoTracking() //IQueryable<ToDo>
            .ToListAsync(); //Task<List<...>>
            return Ok(toDos); //new List<ToDo>();
        }

        //ToDo: 6.1 - Cria o método Get com parâmetro Id
        [HttpGet]
        [Route(template: "ToDos/{id}")]
        public async Task<IActionResult> GetByIdAsysnc(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var toDo = await context
            .ToDos
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return toDo == null
            ? NotFound()
            : Ok(toDo);
        }

        //ToDo: 6.3 - Cria o método Post
        //Outra forma de definir o [Route()]... Direto no verbo    
        [HttpPost(template: "ToDos")]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateToDoViewModel modelToDo)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var toDo = new ToDo
            {
                Date = DateTime.Now,
                Done = false,
                Title = modelToDo.Title
            };

            try
            {
                //Salvando as informações em memória
                await context.ToDos.AddAsync(toDo);
                //Salvando as informações no banco
                await context.SaveChangesAsync();

                return Created(uri: $"v1/ToDos/{toDo.Id}", toDo);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut(template: "ToDos/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateToDoViewModel modelToDo,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //Retornando a informação do banco                (Em ToDo, Pega o Id == id ou retorna null, passado na requisição)  
            var toDo = await context.ToDos.FirstOrDefaultAsync(x => x.Id == id);

            if (toDo == null)
                return NotFound();

            try
            {
                //Realizando Update no EF
                toDo.Title = modelToDo.Title;

                context.ToDos.Update(toDo);
                await context.SaveChangesAsync();
                return Ok(toDo);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpDelete(template: "ToDos/{id}")]
        public async Task<ActionResult> DeleteAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var toDo = await context
            .ToDos
            .FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                context.ToDos.Remove(toDo);
                await context.SaveChangesAsync();

                return Ok($"Item com Id = {id}, deletado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }


    }
}