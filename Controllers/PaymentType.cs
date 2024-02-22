namespace Bangazon.Controllers
{
    public class PaymentType
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/paymenttype", (BangazonDbContext db) =>
            {
                return db.PaymentTypes.ToList();
            });
        }
    }
}
