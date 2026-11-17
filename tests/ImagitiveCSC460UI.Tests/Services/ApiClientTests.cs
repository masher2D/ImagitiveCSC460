using ImagitiveUI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http.Headers;

namespace ImagitiveCSC460UI.Tests.Services;

[TestClass]
public class ApiClientTests
{
    [TestMethod]
    public void SetToken_SetsBearerAuthorizationHeader()
    {
        ApiClient.Client.DefaultRequestHeaders.Authorization = null;

        ApiClient.SetToken("test-token");

        AuthenticationHeaderValue? auth = ApiClient.Client.DefaultRequestHeaders.Authorization;
        Assert.IsNotNull(auth);
        Assert.AreEqual("Bearer", auth!.Scheme);
        Assert.AreEqual("test-token", auth.Parameter);
    }
}
