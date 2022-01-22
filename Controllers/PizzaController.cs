using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    
    public PizzaController()
    {
    }
// GET all action
    [HttpGet]
    public ActionResult<List<Pizza>> Get() 
    {
      return  PizzaService.GetAll();
    }
    

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Pizza> GetById(int id) 
    {
        var pizza = PizzaService.Get(id);
        if(pizza == null)
        {
            return NotFound();
        }
      return pizza;
    }
    // POST action
    [HttpPost]
    public ActionResult AddPizza(Pizza pizza)
    {
       PizzaService.Add(pizza);
       return CreatedAtAction(nameof(AddPizza), new {id=pizza.Id},pizza);
    }

    // PUT action
    [HttpPut("{id}")]
    public ActionResult UpdatePizza(int id,Pizza pizza)
    {
     var _pizza =PizzaService.Get(id);
     if(_pizza.Id==pizza.Id)
     {
      PizzaService.Update(pizza);
     }
     return BadRequest();
    }

    // DELETE action
    [HttpDelete]
    public ActionResult DeletePizza(int id)
    {
        var pizza = PizzaService.Get(id);
        if(pizza!= null)
        {
          PizzaService.Delete(id);
        }
        return BadRequest();
    }
}