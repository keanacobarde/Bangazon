using Bangazon.Models;
using Microsoft.EntityFrameworkCore;

namespace Bangazon.Controllers
{
    public class Users
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/users", (BangazonDbContext db) => 
            { 
                return db.Users.ToList();
            });

            app.MapGet("/users/{uid}", (BangazonDbContext db, string uid) => {
                User selectedUser = db.Users.FirstOrDefault(u => u.Uid == uid);
                if (selectedUser == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(selectedUser);
            });

            // CREATING A USER
            app.MapPost("/register", (BangazonDbContext db, User newUser) =>
            {
                try
                {
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    return Results.Created($"/users/{newUser.Id}", newUser);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Invalid data submitted");
                }
            });
        }
    }
}
