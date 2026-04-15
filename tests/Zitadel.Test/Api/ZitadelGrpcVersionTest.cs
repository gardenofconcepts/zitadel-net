using Xunit;

using Zitadel.Api;

namespace Zitadel.Test.Api;

public class ZitadelGrpcVersionTest
{
    [Fact]
    public void Exposes_Supported_Tag()
    {
        Assert.Equal("v4.13.1", ZitadelGrpcVersion.SupportedTag);
    }
}
