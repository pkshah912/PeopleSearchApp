using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PeopleSearchApp.Models;

namespace PeopleSearchApp.DAL
{
    public class PeopleInitializer : System.Data.Entity.DropCreateDatabaseAlways<PeopleContext>
    {
        protected override void Seed(PeopleContext context)
        {
            var people = new List<Person>
            {
                new Person{FirstName="Pooja",LastName="Shah",Address="Rochester,NY",Age=25,Interests="Reading, Running",Image="butterfly.jpg"},
                new Person{FirstName="Sean",LastName="Strout",Address="New Jersey,NY",Age=45,Interests="Playing, Listening to Music",Image="city.jpg"},
                new Person{FirstName="James",LastName="Bond",Address="Boston,MA",Age=32,Interests="Painting, Ice skating",Image="desert.jpg"},
                new Person{FirstName="James",LastName="Heliotis",Address="Los Angeles,CA",Age=58,Interests="Surfing",Image="water.jpg"},
                new Person{FirstName="Naseer",LastName="Shah",Address="Houston,TX",Age=16,Interests="Reading, Swimming, Fishing",Image="sunset.jpg"},
                new Person{FirstName="Shah",LastName="Nasiruddin",Address="San Diego, CA",Age=20,Interests="Fishing",Image="tiger.jpg"},
                new Person{FirstName="Shahrukh",LastName="Khan",Address="San Jose, CA",Age=30,Interests="Fishing",Image="surf.jpg"}
            };
            people.ForEach(p => context.People.Add(p));
            context.SaveChanges();
        }
    }
}