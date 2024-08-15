using Xunit.Abstractions;

namespace Tests.ActivitySheets;

internal sealed class BadRequestJsonTestCases : TheoryData<JsonPayloadTestCaseItem>
{
    public BadRequestJsonTestCases()
    {
        Add(new("name property is absent", /*lang=json,strict*/ """{}"""));
        Add(new("name property is empty", /*lang=json,strict*/ """{"name": ""}"""));
        Add(new("name property is null", /*lang=json,strict*/ """{"name": null}"""));
        Add(new("malformed payload", /*lang=json,strict*/ """{"""));
    }
}

internal sealed class JsonPayloadTestCaseItem : IXunitSerializable
{
    public string Description { get; private set; }
    public string Payload { get; private set; }

    public JsonPayloadTestCaseItem()
        : this(string.Empty, string.Empty)
    {
    }

    public JsonPayloadTestCaseItem(string description, string payload)
    {
        Description = description;
        Payload = payload;
    }

    public void Deserialize(IXunitSerializationInfo info)
    {
        Description = info.GetValue<string>(nameof(Description));
        Payload = info.GetValue<string>(nameof(Payload));
    }

    public void Serialize(IXunitSerializationInfo info)
    {
        info.AddValue(nameof(Description), Description);
        info.AddValue(nameof(Payload), Payload);
    }

    public override string ToString() => Description;
}