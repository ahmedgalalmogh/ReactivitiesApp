using Microsoft.AspNetCore.Mvc;
using Application.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [EnableCors("CorsPolicy")]

    public class ActivitiesController:BaseApiController
    {
        [HttpGet] 
        public  async Task<ActionResult<List<Activity>>> GetActivities (){

                return await Mediator.Send(new List.Query());
        }
         [HttpGet("{id}")]
        public  async Task<ActionResult<Activity>> GetActivity (int id){

             return await Mediator.Send(new Details.Query{Id=id});

        }
        [HttpPost]
          public  async Task<ActionResult> CreateActivity (Activity _activity){

             return Ok(await Mediator.Send(new Create.Command{activity=_activity}));

        }
         [HttpPut("{id}")]
          public  async Task<ActionResult> Edit (int id,Activity _activity){
                _activity.Id=id;
             return Ok(await Mediator.Send(new Edit.Command{activity=_activity}));

        }
         [HttpDelete("{id}")]
          public  async Task<ActionResult> DeleteActivity (int id,Activity _activity){
              _activity.Id=id;
             return Ok(await Mediator.Send(new DeleteActivity.Command{activity=_activity}));

        }

    }
}