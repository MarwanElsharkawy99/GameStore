using Gamestore.Dtos;
using Gamestore.Entities;

namespace Gamestore.Mapping;

public static class GameMapping
{
public static Game ToEntity(this CreateGameDto game){
return new Game(){

                Name=game.Name,
                GenreId = game.GenreId,
                Price=game.Price,
                Release_date=game.Release_date
            };
}

public static GameSummaryDto ToGameSummaryDto(this Game game){
      return new(
                game.Id,
                game.Name,
                game.Genre!.Name,
                game.Price,
                game.Release_date
            );
}

public static GameDetailsDto ToGameDetailsDto(this Game game){
      return new(
                game.Id,
                game.Name,
                game.GenreId,
                game.Price,
                game.Release_date
            );
}


public static Game ToEntity(this UpdateGameDto game, int id){
return new Game(){
    
                Id=id,
                Name=game.Name,
                GenreId = game.GenreId,
                Price=game.Price,
                Release_date=game.Release_date
            };
}




}
