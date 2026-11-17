using ImagitiveAPI.Data;
using ImagitiveAPI.Models;
using ImagitiveAPI.Requests;
using ImagitiveAPI.Services;
using ImagitiveAPI.Services.Interfaces;
using ImagitiveLibrary.Core.Models;
using ImagitiveLibrary.Core.Requests;
using ImagitiveLibrary.Core.Responses;
using ImageMagick;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImagitiveAPI.Tests.Services;

[TestClass]
public class ArtworkServicePerformanceTests
{
    private sealed class StubRatingService : IRatingService
    {
        public Task<double> GetAverageRatingAsync(int artworkId) => Task.FromResult(0d);

        public Task<RatingModel?> GetUserRatingAsync(int userId, int artworkId) => Task.FromResult<RatingModel?>(null);

        public Task<PostRatingResponse> PostRatingAsync(int userId, PostRatingRequest request)
            => Task.FromResult(new PostRatingResponse());

        public Task<PostRatingResponse> UpdateRatingAsync(int userId, PostRatingRequest request)
            => Task.FromResult(new PostRatingResponse());
    }

    private static AppDBContext CreateContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<AppDBContext>()
            .UseInMemoryDatabase(dbName)
            .Options;

        return new AppDBContext(options);
    }

    private static async Task SeedUserAsync(AppDBContext context)
    {
        context.Users.Add(new UserDBModel
        {
            UserId = 1,
            Username = "perf-user",
            Email = "perf-user@test.local",
            PasswordHash = "hash"
        });

        await context.SaveChangesAsync();
    }

    private static IFormFile CreateAnimatedGifFormFile()
    {
        const string providedGifPath = @"C:\Users\siliv\Downloads\fanum-fanum-throw-pirate-token.gif";
        if (File.Exists(providedGifPath))
        {
            var bytes = File.ReadAllBytes(providedGifPath);
            return BuildFormFile(bytes, Path.GetFileName(providedGifPath), "image/gif");
        }

        using var frames = new MagickImageCollection();
        for (var i = 0; i < 40; i++)
        {
            using var frame = new MagickImage(i % 2 == 0 ? MagickColors.SteelBlue : MagickColors.OrangeRed, 480, 360);
            frame.AnimationDelay = 2;
            frames.Add(frame.Clone());
        }

        using var output = new MemoryStream();
        frames.Write(output, MagickFormat.Gif);
        return BuildFormFile(output.ToArray(), "perf.gif", "image/gif");
    }

    private static IFormFile CreateJpegFormFile()
    {
        using var image = new MagickImage(MagickColors.CadetBlue, 1920, 1080);
        using var output = new MemoryStream();
        image.Write(output, MagickFormat.Jpeg);
        return BuildFormFile(output.ToArray(), "perf.jpg", "image/jpeg");
    }

    private static IFormFile BuildFormFile(byte[] bytes, string fileName, string contentType)
    {
        var stream = new MemoryStream(bytes);
        return new FormFile(stream, 0, stream.Length, "ImageFile", fileName)
        {
            Headers = new HeaderDictionary(),
            ContentType = contentType
        };
    }

    private static PostArtworkFormRequest CreateRequest(IFormFile file)
        => new()
        {
            Title = "Perf",
            Description = "Perf",
            Tags = ["tag"],
            ImageFile = file
        };

    [TestMethod]
    public async Task CreateArtworkAsync_AnimatedGif_Workload()
    {
        var previousDirectory = Directory.GetCurrentDirectory();
        var workDirectory = Path.Combine(Path.GetTempPath(), "imagitive-api-perf", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(workDirectory);
        Directory.SetCurrentDirectory(workDirectory);

        try
        {
            await using var context = CreateContext(nameof(CreateArtworkAsync_AnimatedGif_Workload));
            await SeedUserAsync(context);

            var sut = new ArtworkService(context, new StubRatingService());
            var request = CreateRequest(CreateAnimatedGifFormFile());

            var result = await sut.CreateArtworkAsync(1, request);

            Assert.IsNotNull(result);
        }
        finally
        {
            Directory.SetCurrentDirectory(previousDirectory);
            if (Directory.Exists(workDirectory))
            {
                Directory.Delete(workDirectory, recursive: true);
            }
        }
    }

    [TestMethod]
    public async Task CreateArtworkAsync_Jpeg_Workload()
    {
        var previousDirectory = Directory.GetCurrentDirectory();
        var workDirectory = Path.Combine(Path.GetTempPath(), "imagitive-api-perf", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(workDirectory);
        Directory.SetCurrentDirectory(workDirectory);

        try
        {
            await using var context = CreateContext(nameof(CreateArtworkAsync_Jpeg_Workload));
            await SeedUserAsync(context);

            var sut = new ArtworkService(context, new StubRatingService());
            var request = CreateRequest(CreateJpegFormFile());

            var result = await sut.CreateArtworkAsync(1, request);

            Assert.IsNotNull(result);
        }
        finally
        {
            Directory.SetCurrentDirectory(previousDirectory);
            if (Directory.Exists(workDirectory))
            {
                Directory.Delete(workDirectory, recursive: true);
            }
        }
    }
}
