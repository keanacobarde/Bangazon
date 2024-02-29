using Bangazon.DTOs;
using Bangazon.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

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

            //GETTING A USER'S ORDER BY UID
            app.MapGet("/cart/{uid}", (BangazonDbContext db, string uid) =>
            {
                User userForCart = db.Users.FirstOrDefault(u => u.Uid == uid);
                int userId = userForCart.Id;
                var cart = db.Orders.Where(o => o.CustomerId == userId)
                    .Include(order => order.Products);
                return cart;
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

            // EDITING AN ORDER
            app.MapPut("/orders/{id}/edit", (BangazonDbContext db, int id, Order orderUpdateInfo) =>
            {
                Order orderToUpdate = db.Orders.SingleOrDefault(o => o.Id == id);
                if (orderToUpdate == null)
                {
                    return Results.NotFound();
                }
                orderToUpdate.PaymentId = orderUpdateInfo.PaymentId;
                orderToUpdate.IsOrderOpen = orderUpdateInfo.IsOrderOpen;

                db.SaveChanges();
                return Results.NoContent();
            });

            // CREATING AN ORDER THEN, ADDING PRODUCTS
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

            //ADDING PRODUCTS
            app.MapPost("/orders/addProduct", (BangazonDbContext db, addProductDTO newProduct) =>
            {
                var order = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.Id == newProduct.OrderId);

                if (order == null)
                {
                    return Results.NotFound("Order not found.");
                }

                var product = db.Products.Find(newProduct.ProductId);

                if (product == null)
                {
                    return Results.NotFound("Product not found.");
                }

                order.Products.Add(product);

                db.SaveChanges();

                return Results.Created($"/orders/addProduct", newProduct);
            });

            //DELETE PRODUCTS FROM ORDERS
            app.MapDelete("/orders/{id}/products/{prodId}", (BangazonDbContext db, int id, int prodId) => 
            {
                var order = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.Id == id);
                if (order == null)
                {
                    return Results.NotFound("Order not found.");
                }

                var product = db.Products.Find(prodId);

                if (product == null)
                {
                    return Results.NotFound();
                }

                order.Products.Remove(product);
                db.SaveChanges();
                return Results.Ok();
            });

        }
    }
}
