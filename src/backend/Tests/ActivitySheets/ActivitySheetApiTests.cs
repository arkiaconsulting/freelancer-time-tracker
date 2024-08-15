using FluentAssertions;
using System.Net.Mime;
using System.Text;
using Tests.Framework;

namespace Tests.ActivitySheets;

[Trait("Category", "Unit")]
public sealed class ActivitySheetApiTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;

    public ActivitySheetApiTests(CustomWebApplicationFactory factory) =>
        _factory = factory;

    [Fact(DisplayName = "Creating an activity sheet with a name should answer 200")]
    public async Task Test01()
    {
        var payload = /*lang=json,strict*/ """
{
    "name": "May 2024"
}
""";
        var client = _factory.CreateClient();

        var response = await client.PutAsync("/activity-sheets", new StringContent(payload, Encoding.UTF8, MediaTypeNames.Application.Json));

        response.Should().Be200Ok();
    }

    [Theory(DisplayName = "Creating an activity sheet without a name should answer 400")]
    [ClassData(typeof(BadRequestJsonTestCases))]
    internal async Task Test02(JsonPayloadTestCaseItem item)
    {
        var client = _factory.CreateClient();

        var response = await client.PutAsync("/activity-sheets", new StringContent(item.Payload, Encoding.UTF8, MediaTypeNames.Application.Json));

        response.Should().Be400BadRequest();
    }
}
