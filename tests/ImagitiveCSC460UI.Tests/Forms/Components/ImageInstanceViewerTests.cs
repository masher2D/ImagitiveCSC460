using ImagitiveCSC460UI.Forms.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace ImagitiveCSC460UI.Tests.Forms.Components;

[TestClass]
public class ImageInstanceViewerTests
{
    [TestMethod]
    public void SetArtworkDetails_AssignsAllProperties()
    {
        RunInSta(() =>
        {
            using var image = new Bitmap(8, 8);
            using var control = new ImageInstanceViewer();

            control.SetArtworkDetails(
                title: "Title",
                description: "Description",
                image: image,
                username: "ArtistUser",
                avgRating: "★★★★☆");

            Assert.AreEqual("Title", control.ArtworkTitle);
            Assert.AreEqual("Description", control.ArtworkDescription);
            Assert.AreEqual("ArtistUser", control.ArtworkUsername);
            Assert.AreEqual("★★★★☆", control.ArtworkAvgRating);
            Assert.IsNotNull(control.ArtworkImage);
        });
    }

    private static void RunInSta(Action action)
    {
        Exception? ex = null;

        var thread = new Thread(() =>
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                ex = e;
            }
        });

        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        thread.Join();

        if (ex is not null)
        {
            throw ex;
        }
    }
}
