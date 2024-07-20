using System.ComponentModel.DataAnnotations;

namespace Gamestore.Dtos;

public record class CreateGameDto(
[Required] [StringLength(50)] string Name,
int GenreId,
[Range(0,500)]  decimal Price,
DateOnly Release_date
    );

