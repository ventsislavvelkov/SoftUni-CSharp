using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using MusicHub.Data.Models;
using MusicHub.Data.Models.Enums;
using MusicHub.DataProcessor.ImportDtos;
using MusicHub.XmlHelper;
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
            var sb = new StringBuilder();
            var producers = new List<Producer>();

            var producersDto = JsonConvert.DeserializeObject<ImportProducersDto[]>(jsonString);

            foreach (ImportProducersDto producerDto in producersDto)
            {
                if (!IsValid(producerDto) || !producerDto.Albums.All(IsValid))

                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var producer = new Producer()
                {
                    Name = producerDto.Name,
                    Pseudonym = producerDto.Pseudonym,
                    PhoneNumber = producerDto.PhoneNumber
                };

                foreach (ImportProducerAlbumsDto albumDto in producerDto.Albums)
                {
                    producer.Albums.Add(new Album()
                    {
                        Name = albumDto.Name,
                        ReleaseDate = DateTime.ParseExact(albumDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    });

                }

                var message = producer.PhoneNumber == null
                    ? string.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count)
                    : string.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, producer.Albums.Count);

                producers.Add(producer);
                sb.AppendLine(message);
            }

            context.Producers.AddRange(producers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            //XmlConverter is helper class
            var root = "Songs";
            var data = XMLConverter.Deserializer<ImportSongsDto>(xmlString, root);

            StringBuilder sb = new StringBuilder();

            foreach (var item in data)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (item.AlbumId == null || !context.Albums.Any(a => a.Id == item.AlbumId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!context.Writers.Any(w => w.Id == item.WriterId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //invalid genre
                Genre genre;
                var validGenre = Enum.TryParse<Genre>(item.Genre.ToString(), out genre);

                if (!validGenre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var song = new Song
                {
                    Name = item.Name,
                    CreatedOn = DateTime.ParseExact(item.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Duration = TimeSpan.Parse(item.Duration),
                    Price = item.Price,
                    Genre = genre,
                    AlbumId = item.AlbumId,
                    WriterId = item.WriterId
                };

                context.Songs.Add(song);
                sb.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration));
            }

            context.SaveChanges();
            return sb.ToString();
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