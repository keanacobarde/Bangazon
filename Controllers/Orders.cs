using Bangazon.Models;

namespace Bangazon.Controllers
{
    public class ORDERS
    {
        public static void Map(WebApplication app)
        {
            // GETTING ALL ORDERS
            app.MapGet("/orders", (BangazonDbContext db) => 
            { 
                return db.Orders.ToList();
            });

            // GETTING ALL ORDERS GIVEN AN ID, DELETING ORDERS
            app.MapGet("/orders/{id}", (BangazonDbContext db, int id) =>
            {
                Order selectedOrder = db.Orders.FirstOrDefault(p => p.Id == id);
                if (selectedOrder == null)
                {
                    return Results.NotFound();
                }
                db.Orders.Remove(selectedOrder);
                db.SaveChanges();
                return Results.Ok(db.Orders);
            });
        }
    }
}
