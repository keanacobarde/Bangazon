using Bangazon.Models;
using Microsoft.EntityFrameworkCore;

namespace Bangazon.Controllers
{
    public class Orders
    {
        public static void Map(WebApplication app)
        {
            // GETTING ALL ORDERS
            app.MapGet("/orders", (BangazonDbContext db) => 
            { 
                return db.Orders
                .Include(orders => orders.Products)
                .ToList();
            });

            // GETTING ALL ORDERS GIVEN AN ID, DELETING ORDERS
            app.MapDelete("/orders/{id}", (BangazonDbContext db, int id) =>
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

            // CREATING AN ORDER
            app.MapPost("/orders", (BangazonDbContext db, Order newOrder) =>
            {
                try
                {
                    db.Orders.Add(newOrder);
                    db.SaveChanges();
                    return Results.Created($"/api/reservations/{newOrder.Id}", newOrder);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Invalid data submitted");
                }
            });

        }
    }
}
