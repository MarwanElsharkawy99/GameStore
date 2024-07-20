using Gamestore.Data;
using Gamestore.Dtos;
using Gamestore.Entities;
using Gamestore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.EndPoints;

public static class GamesEndpoint
{

    const string GetGameEndPointName = "Getgame";


    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {

        var group = app.MapGroup("games").WithParameterValidation();


        group.MapGet("/", async (GameStoreContext dbcontext) => await dbcontext.Games
        .Include(game=>game.Genre)
        
        .Select(game=>game.ToGameSummaryDto()).AsNoTracking().ToListAsync());



        group.MapGet("/{id}", async (int id,  GameStoreContext dbcontext) =>
        {
            Game? game = await dbcontext.Games.FindAsync(id);
            return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto()); 
        }).WithName(GetGameEndPointName);



        group.MapPost("/", async (CreateGameDto newgame,GameStoreContext dbContext) =>
        {

            Game game = newgame.ToEntity();
            dbContext.Games.Add(game);
         await  dbContext.SaveChangesAsync();

            
            return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game.ToGameDetailsDto());
        });

        group.MapPut("/{id}", async (int id, UpdateGameDto updateGame,GameStoreContext dbContext) =>
        {


            var existingGame = await  dbContext.Games.FindAsync(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }
         dbContext.Entry(existingGame).CurrentValues.SetValues(updateGame.ToEntity(id));
        await dbContext.SaveChangesAsync();


            return Results.NoContent();

        });

        group.MapDelete("/{id}", async (int id, GameStoreContext dbcontext) =>
        {
            await dbcontext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();
            return Results.NoContent();
        });
        
        return group;



    }











}
