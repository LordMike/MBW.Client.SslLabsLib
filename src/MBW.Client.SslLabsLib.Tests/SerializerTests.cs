using System;
using System.Threading.Tasks;
using MBW.Client.SslLabsLib.Response;
using MBW.Client.SslLabsLib.Serializer;
using MBW.Client.SslLabsLib.Tests.Helpers;
using Xunit;

namespace MBW.Client.SslLabsLib.Tests;

public class SerializerTests
{
    [Fact]
    public async Task InfoTest()
    {
        // Test various converters like formatting of property names and timespan converters.
        string json = """
                      {
                          "engineVersion":"2.2.0",
                          "criteriaVersion":"2009q",
                          "maxAssessments":25,
                          "currentAssessments":0,
                          "newAssessmentCoolOff":1000,
                          "messages":
                           ["This assessment service is provided free of charge by Qualys SSL Labs, subject to our terms and conditions: https://www.ssllabs.com/about/terms.html"]
                      }
                      """;

        Info info = await SystemTextJsonSsllabsSerializer.Instance.Deserialize<Info>(json);
        Assert.NotNull(info);

        Assert.Equal(TimeSpan.FromSeconds(1), info.NewAssessmentCoolOff);
        Assert.Equal(25, info.MaxAssessments);
        Assert.Equal(
            new[]
            {
                "This assessment service is provided free of charge by Qualys SSL Labs, subject to our terms and conditions: https://www.ssllabs.com/about/terms.html"
            }, info.Messages);
        Assert.Equal("2009q", info.CriteriaVersion);
    }
}