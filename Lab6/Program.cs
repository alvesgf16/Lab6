using Lab6;

internal class Program
{
    private static void Main(string[] args)
    {
        // Creating event instances
        Event event1 = new (1, "Calgary");
        Event event2 = new (2, "Edmonton");
        Event event3 = new (3, "Spokane");
        Event event4 = new (4, "Tacoma");

        // Creating a list of events
        List<Event> events = new ([event1, event2, event3, event4]);

        // Setting file paths
        string basePath = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName;
        string txtPath = basePath + "/event.txt";
        string jsonPath = basePath + "/events.json";

        // Initializing file handlers
        EventFileHandler handler = new (txtPath);
        EventSerializer serializer = new (jsonPath);

        // Serializing an event to XML file
        handler.SerializeEventToXmlFile(event1);
        // Deserializing an event from XML
        Event deserializedEvent = handler.DeserializeEventFromXml();
        Console.WriteLine(deserializedEvent);

        // Serializing events to a JSON file
        serializer.SerializeEventsToFile(events);
        // Deserializing events from a JSON file
        List<Event> deserializedEvents = serializer.DeserializeEventsFromFile();
        deserializedEvents.ForEach(Console.WriteLine);

        // Reading characters from file
        handler.ReadFromFile();
    }
}