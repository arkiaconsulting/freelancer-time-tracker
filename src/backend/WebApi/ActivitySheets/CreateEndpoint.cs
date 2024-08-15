using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using WebApi.Framework.Json;

namespace WebApi.ActivitySheets;

internal static class CreateEndpoint
{
    public static void MapCreateActivitySheetEndpoint(this IEndpointRouteBuilder route) =>
        route.MapPut("/activity-sheets", Handle);

    private static async Task<IResult> Handle([FromBody] Request request)
    {
        await Task.CompletedTask;

        return Results.Ok();
    }

    internal sealed record Request([property: JsonRequired, JsonConverter(typeof(ActivitySheetNameConverter))] ActivitySheetName Name);
}
