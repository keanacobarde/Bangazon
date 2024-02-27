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

            // FIND SINGLE USER W/ DETAILS
            app.MapGet("/users/{uid}", (BangazonDbContext db, string uid) => {
                User selectedUser = db.Users.FirstOrDefault(u => u.Uid == uid);
                if (selectedUser == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(selectedUser);
            });

            // FIND USER
            app.MapGet("/checkuser/{uid}", (BangazonDbContext db, string uid) => {
                User selectedUser = db.Users.FirstOrDefault(u => u.Uid == uid);
                if (selectedUser == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok();
            });

            // CREATING A USER
            app.MapPost("/register", (BangazonDbContext db, User newUser) =>
            {
                User checkUser = db.Users.FirstOrDefault(u => u.Uid == newUser.Uid);
                if (checkUser != null)
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
                }
                else
                { 
                    return Results.Conflict("User already exists");
                }
            });

            // EDITING A USER
            app.MapPut("/user/{id}/edit", (BangazonDbContext db, int id, User updateUserInfo) =>
            {
                User userToUpdate = db.Users.SingleOrDefault(u => u.Id == id);
                if (userToUpdate == null)
                {
                    return Results.NotFound();
                }
                userToUpdate.FirstName = updateUserInfo.FirstName;
                userToUpdate.LastName = updateUserInfo.LastName;
                userToUpdate.Email = updateUserInfo.Email;
                userToUpdate.Address = updateUserInfo.Address;
                userToUpdate.IsSeller = updateUserInfo.IsSeller;

                db.SaveChanges();
                return Results.NoContent();
            });
        }
    }
}
