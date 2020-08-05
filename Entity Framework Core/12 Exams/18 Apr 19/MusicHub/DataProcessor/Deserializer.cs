using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MusicHub.Data.Models;
using MusicHub.DataProcessor.ImportDtos;
using Newtonsoft.Json;

namespace MusicHub.DataProcessor
{
    using System;

    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter 
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone 
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong 
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
          var sb = new StringBuilder();
          var writers = new List<Writer>();

          var writersDto = JsonConvert.DeserializeObject<ImportWritersDto[]>(jsonString);

          foreach (ImportWritersDto dto in writersDto)
          {
              if (!IsValid(dto))
              {
                  sb.AppendLine(ErrorMessage);
                  continue;
              }

              var writer = new Writer()
              {
                  Name = dto.Name,
                  Pseudonym = dto.Pseudonym
              };

              writers.Add(writer);
              sb.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
          }

          context.Writers.AddRange(writers);
          context.SaveChanges();

          return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}