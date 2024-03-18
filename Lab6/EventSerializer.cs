namespace Lab6;

using System.Text.Json;

/// <summary>
/// Represents a serializer for events.
/// </summary>
/// <param name="aPath">The path to the JSON file.</param>
public class EventSerializer(string aPath)
{
    private readonly string _path = aPath;

    /// <summary>
    /// Serializes a list of events to JSON and writes it to the file.
    /// </summary>
    /// <param name="events">The list of events to serialize.</param>
    public void SerializeEventsToFile(List<Event> events)
    {
        string jsonString = JsonSerializer.Serialize(events);
        File.WriteAllText(_path, jsonString);
    }
    
    /// <summary>
    /// Deserializes events from the JSON file.
    /// </summary>
    /// <returns>The deserialized list of events.</returns>
    public List<Event> DeserializeEventsFromFile() => JsonSerializer.Deserialize<List<Event>>(File.ReadAllText(_path))!;
}
