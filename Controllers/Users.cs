using Bangazon.Models;

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

            app.MapGet("/users/{id}", (BangazonDbContext db, int id) => {
                User selectedUser = db.Users.FirstOrDefault(u => u.Id == id);
                if (selectedUser == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(selectedUser);
            });
        }
    }
}
