﻿namespace Gamestore.Entities;

public class Game
{
public int Id { get; set; }

public required string Name { get; set; }

public int GenreId { get; set; }

public  Genre? Genre { get; set; }


public decimal Price { get; set; }

public DateOnly Release_date { get; set; }


}
