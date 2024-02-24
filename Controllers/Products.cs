using Bangazon.Models;
using Microsoft.EntityFrameworkCore;

namespace Bangazon.Controllers
{
    public class Products
    {
        public static void Map(WebApplication app)
        {
            // GETTING ALL PRODUCTS
            app.MapGet("/products", (BangazonDbContext db) =>
            {
                return db.Products.ToList();
            });
            
            // GETTING ALL PRODUCTS GIVEN AN ID
            app.MapGet("/products/{id}", (BangazonDbContext db, int id) =>
            {
                Product selectedProduct = db.Products.FirstOrDefault(p => p.Id == id);
                if (selectedProduct == null)
                { 
                    return Results.NotFound();
                }
                return Results.Ok(selectedProduct);
            });

            // GETTING ALL PRODUCTS GIVEN AN ID, DELETING PRODUCTS
            app.MapDelete("/products/{id}", (BangazonDbContext db, int id) =>
            {
                Product selectedProduct = db.Products.FirstOrDefault(p => p.Id == id);
                if (selectedProduct == null)
                {
                    return Results.NotFound();
                }
                db.Products.Remove(selectedProduct);
                db.SaveChanges();
                return Results.Ok(db.Products);
            });

            // CREATING PRODUCTS
            app.MapPost("/products", (BangazonDbContext db, Product newProduct) =>
            {
                try
                {
                    db.Products.Add(newProduct);
                    db.SaveChanges();
                    return Results.Created($"/products/{newProduct.Id}", newProduct);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Invalid data submitted");
                }
            });
        }
    };
}
