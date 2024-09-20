using System.Text.Json;
using System.Text.Json.Serialization;

namespace EventSourcing.Infrastructure.EventSourcing;

public abstract class EventBase
{
    public string Serialize()
    {
        var options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        return JsonSerializer.Serialize(this, this.GetType(), options);
    }
}