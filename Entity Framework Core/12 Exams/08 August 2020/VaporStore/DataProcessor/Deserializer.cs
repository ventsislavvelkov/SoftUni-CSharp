using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.Dto.Import;
using VaporStore.XmlHelper;

namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data;

	public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
            var games = JsonConvert.DeserializeObject<ImportGamesDevelopersGenreTagsDto[]>(jsonString);

            var gamesAdd = new List<Game>();
            var tags = new List<Tag>();
            var genres = new List<Genre>();
            var developers = new List<Developer>();
            var sb = new StringBuilder();

            foreach (var game in games)
            {
                var currentGameTags = new List<Tag>();

                if (!IsValid(game) || game.Tags.Length == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var newGame = new Game()
                {
                    Name = game.Name,
                    Price = game.Price,
                    ReleaseDate = DateTime.ParseExact(game.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                };

                var currentDev = developers.FirstOrDefault(x => x.Name == game.Developer);

                if (currentDev == null)
                {
                    var newDev = new Developer() { Name = game.Developer };

                    if (IsValid(newDev))
                    {
                        developers.Add(newDev);
                    }
                    newGame.Developer = newDev;
                }
                else
                {
                    newGame.Developer = currentDev;
                }

                var currentGenre = genres.FirstOrDefault(g => g.Name == game.Genre);

                if (currentGenre == null)
                {
                    var newGenre = new Genre() { Name = game.Genre };

                    if (IsValid(newGenre))
                    {
                        genres.Add(newGenre);
                    }
                    newGame.Genre = newGenre;
                }
                else
                {
                    newGame.Genre = currentGenre;
                }

                foreach (var tag in game.Tags)
                {
                    if (tags.Any(x => x.Name == tag))
                    {
                        if (IsValid(tag))
                        {
                            currentGameTags.Add(tags.First(x => x.Name == tag));
                        }

                    }
                    else
                    {
                        tags.Add(new Tag { Name = tag });
                        currentGameTags.Add(tags.First(x => x.Name == tag));
                    }

                }

                foreach (var tag in currentGameTags)
                {
                    newGame.GameTags.Add(new GameTag() { Game = newGame, Tag = tag });
                }

                tags.AddRange(currentGameTags);
                gamesAdd.Add(newGame);
                sb.AppendLine($"Added {newGame.Name} ({newGame.Genre.Name}) with {newGame.GameTags.Count} tags");
            }
            context.Games.AddRange(gamesAdd);
            context.Tags.AddRange(tags);
            context.Developers.AddRange(developers);
            context.Genres.AddRange(genres);
            context.SaveChanges();
            return sb.ToString().TrimEnd();

        }

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            StringBuilder sb = new StringBuilder();

            var importUserDTOs = JsonConvert.DeserializeObject<List<ImportUserDto>>(jsonString);

            foreach (var dto in importUserDTOs)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (dto.Cards.Count == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                foreach (var importCardDTO in dto.Cards)
                {
                    if (!IsValid(importCardDTO))
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }
                }

                var newUser = new User
                {
                    Username = dto.Username,
                    FullName = dto.FullName,
                    Age = dto.Age,
                    Email = dto.Email,
                };



                foreach (var cardsDto in dto.Cards)
                {
                    newUser.Cards.Add(new Card()
                    {
                        Number = cardsDto.Number,
                        Cvc = cardsDto.Cvc,
                        Type = 
                    });
                }


                context.Add(newUser);
                context.SaveChanges();

                sb.AppendLine($"Imported {newUser.Username} with {newUser.Cards.Count} cards");
                context.Users.Add(newUser);
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
            //const string rootElement = "Purchases";
            //var purchasesDto = XMLConverter.Deserializer<ImportPurchasesDto>(xmlString, rootElement);

            var sb = new StringBuilder();
            //var games = new List<Game>();

            //foreach (ImportPurchasesDto dto in purchasesDto)
            //{
            //    if (!IsValid(dto))
            //    {
            //        sb.AppendLine("Invalid Data");
            //        continue;
            //    }

            //    var purchas = new Purchase()
            //    {
            //        Type = (Type)dto.Type,
                    
            //    }


            //    var currentGame = games.FirstOrDefault(g => g.Name == dto.Game);

            //    if (currentGame == null)
            //    {
            //        var newGame = new Game() { Name = dto.Game };

            //        if (IsValid(newGame))
            //        {
            //            games.Add(newGame);
            //        }
            //        purchas.Game = newGame;
            //    }
            //    else
            //    {
            //        purchas.Game = currentGame;
            //    }

            //}
            return sb.ToString().TrimEnd();
        }

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}


