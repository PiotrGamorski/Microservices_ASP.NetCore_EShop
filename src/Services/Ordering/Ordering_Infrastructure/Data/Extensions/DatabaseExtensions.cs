using Microsoft.AspNetCore.Builder;

namespace Ordering_Infrastructure.Data.Extensions
{
    public static class DatabaseExtensions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        { 
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.MigrateAsync().GetAwaiter().GetResult();

            await SeedAsync(context);
        }

        private static async Task SeedAsync(ApplicationDbContext context)
        {
            await SeedCustomerAsync(context);
            await SeedProductAsync(context);
            await SeedOrderWithItemsAsync(context);
        }

        private static async Task SeedCustomerAsync(ApplicationDbContext context)
        {
            if(await context.Customers.AnyAsync()) return;

            await context.Customers.AddRangeAsync(InitialData.Customers);
            await context.SaveChangesAsync();
        }

        private static async Task SeedProductAsync(ApplicationDbContext context)
        {
            if (await context.Products.AnyAsync()) return;

            await context.Products.AddRangeAsync(InitialData.Products);
            await context.SaveChangesAsync();
        }

        private static async Task SeedOrderWithItemsAsync(ApplicationDbContext context)
        {
            if (await context.Orders.AnyAsync()) return;

            await context.Orders.AddRangeAsync(InitialData.OrdersWithItems);
            await context.SaveChangesAsync();
        }
    }
}
