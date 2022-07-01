using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Newtonsoft.Json;
using WebixDhtmlxDemos.Models.Webix;

namespace WebixDhtmlxDemos.Controllers.Webix
{

    class DynamicData
    {
        [JsonProperty("total_count")]
        public int Count;
        public int Pos;
        public List<Person> Data;
    }


    [Route("api/persons")]
    [ApiController]
    public class GridController : ControllerBase
    {
        // GET api/persons
        [HttpGet]
        public ActionResult Load()
        {
            using (var db = new DemosDbContext())
            {
                var persons = db.Persons.ToList();
                return Ok(persons);
            }
        }

        // GET api/persons
        [HttpGet("dynamic")]
        public ActionResult LoadDynamic([FromQuery] int count, [FromQuery] int start)
        {
            using (var db = new DemosDbContext())
            {
                if (count == 0)
                    count = 20;

                var persons = db.Persons.Skip(start).Take(count).ToList();
                return Ok(new DynamicData
                {
                    Count = db.Persons.Count(),
                    Pos = start,
                    Data = persons
                });
            }
        }


        // POST api/persons
        [HttpPost]
        public ActionResult Insert([FromBody] Person person)
        {
            using (var db = new DemosDbContext())
            {
                person.Id = 0;
                db.Persons.Add(person);
                db.SaveChanges();

                return Ok(new { person.Id });
            }
        }

        // PUT api/persons
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Person update)
        {
            using (var db = new DemosDbContext())
            {
                var ev = db.Persons.Where(a => a.Id == id).FirstOrDefault();

                ev.Name = update.Name;
                ev.Comments = update.Comments;
                ev.Active = update.Active;
                ev.BirthDate = update.BirthDate;

                db.Persons.Update(ev);
                db.SaveChanges();

                return Ok(new { ev.Id });
            }
        }

        // DELETE api/persons
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            using (var db = new DemosDbContext())
            {
                var ev = db.Persons.Where(a => a.Id == id).FirstOrDefault();
                db.Persons.Remove(ev);
                db.SaveChanges();
                return Ok(new { Id = id });
            }
        }
    }
}
