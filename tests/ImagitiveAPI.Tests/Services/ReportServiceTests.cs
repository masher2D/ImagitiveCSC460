using ImagitiveAPI.Data;
using ImagitiveAPI.Models;
using ImagitiveAPI.Services;
using ImagitiveLibrary.Core.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImagitiveAPI.Tests.Services;

[TestClass]
public class ReportServiceTests
{
    private static AppDBContext CreateContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<AppDBContext>()
            .UseInMemoryDatabase(dbName)
            .Options;

        return new AppDBContext(options);
    }

    private static async Task SeedBaseDataAsync(AppDBContext context)
    {
        context.Users.AddRange(
            new UserDBModel
            {
                UserId = 1,
                Username = "reporter",
                Email = "reporter@test.local",
                PasswordHash = "hash"
            },
            new UserDBModel
            {
                UserId = 2,
                Username = "artist",
                Email = "artist@test.local",
                PasswordHash = "hash"
            });

        context.Reasons.Add(new ReasonDBModel
        {
            ReasonId = 1,
            Name = "Inappropriate",
            IsActive = true
        });

        context.Artworks.Add(new ArtworkDBModel
        {
            ArtworkId = 10,
            UserId = 2,
            Title = "Test Artwork",
            Description = "desc",
            ImageURL = "/uploads/test.jpg",
            CompressedURL = string.Empty,
            WatermarkedURL = string.Empty,
            UploadDate = DateTime.UtcNow,
            ViewCount = 0,
            BoostViewsRemaining = 0,
            IsRemoved = false
        });

        await context.SaveChangesAsync();
    }

    [TestMethod]
    public async Task CreateReportAsync_Throws_WhenBothArtworkAndUserAreProvided()
    {
        await using var context = CreateContext(nameof(CreateReportAsync_Throws_WhenBothArtworkAndUserAreProvided));
        await SeedBaseDataAsync(context);
        var sut = new ReportService(context);

        var request = new PostReportRequest
        {
            ArtworkId = 10,
            ReportedUserId = 2,
            ReasonId = 1,
            Description = "bad"
        };

        var ex = await Assert.ThrowsExceptionAsync<Exception>(() => sut.CreateReportAsync(1, request));
        StringAssert.Contains(ex.Message, "exactly one");
    }

    [TestMethod]
    public async Task CreateReportAsync_CreatesUnresolvedArtworkReport()
    {
        await using var context = CreateContext(nameof(CreateReportAsync_CreatesUnresolvedArtworkReport));
        await SeedBaseDataAsync(context);
        var sut = new ReportService(context);

        var request = new PostReportRequest
        {
            ArtworkId = 10,
            ReasonId = 1,
            Description = "reporting artwork"
        };

        var result = await sut.CreateReportAsync(1, request);

        Assert.IsNotNull(result);
        Assert.AreEqual(10, result.ArtworkId);
        Assert.AreEqual("Unresolved", result.Status);
        Assert.AreEqual(1, await context.Reports.CountAsync());
    }

    [TestMethod]
    public async Task UpdateReportStatusAsync_Throws_OnInvalidStatus()
    {
        await using var context = CreateContext(nameof(UpdateReportStatusAsync_Throws_OnInvalidStatus));
        await SeedBaseDataAsync(context);

        context.Reports.Add(new ReportDBModel
        {
            ReportId = 100,
            ReporterId = 1,
            ArtworkId = 10,
            ReasonId = 1,
            Description = "seed",
            Status = "Unresolved",
            ReportedAt = DateTime.UtcNow
        });
        await context.SaveChangesAsync();

        var sut = new ReportService(context);

        await Assert.ThrowsExceptionAsync<InvalidOperationException>(
            () => sut.UpdateReportStatusAsync(100, "NotARealStatus"));
    }
}
