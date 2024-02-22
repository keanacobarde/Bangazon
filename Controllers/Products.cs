using Bangazon.Models;

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
        }
    };
}
