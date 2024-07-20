using Microsoft.EntityFrameworkCore;

namespace Gamestore.Data;

public static class DataExtensions
{
public  static async Task MigrateDbAsync(this WebApplication app){
    using var scope = app.Services.CreateScope();
    var dbcontext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
   await dbcontext.Database.MigrateAsync();
}
}
