namespace Bangazon.Controllers
{
    public class Category
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/categories", (BangazonDbContext db) =>
            { 
                return db.Categories.ToList();
            });
        
        }
    }
}
