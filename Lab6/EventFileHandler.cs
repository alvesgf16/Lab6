using System.Runtime.Serialization;
using System.Xml;

namespace Lab6;

/// <summary>
/// Represents a class for handling event serialization and deserialization to/from XML files.
/// </summary>
/// <param name="aPath">The path to the XML file.</param>
public class EventFileHandler(string aPath)
{
    private readonly string _path = aPath;
    private readonly DataContractSerializer _serializer = new(typeof(Event));
    
    /// <summary>
    /// Serializes the specified Event object to XML and writes it to the file.
    /// </summary>
    /// <param name="anEvent">The Event object to serialize.</param>
    public void SerializeEventToXmlFile(Event anEvent)
    {
        using XmlWriter writer = XmlWriter.Create(_path);
        _serializer.WriteObject(writer, anEvent);
    }

    /// <summary>
    /// Deserializes an Event object from the XML file.
    /// </summary>
    /// <returns>The deserialized Event object.</returns>
    public Event DeserializeEventFromXml()
    {
        using XmlReader reader = XmlReader.Create(_path);
        return (Event)_serializer.ReadObject(reader)!;
    }

    /// <summary>
    /// Reads characters from the file.
    /// </summary>
    public void ReadFromFile()
    {
        WriteTextToFile();
        RetrieveCharactersFromFile();
    }

    private void WriteTextToFile()
    {
        using StreamWriter writer = new(_path);
        writer.Write("Hackathon");
    }

    private void RetrieveCharactersFromFile()
    {
        using FileStream fs = new(_path, FileMode.Open);
        ReadCharacterFromFile(fs, -"Hackathon".Length, "First");
        ReadCharacterFromFile(fs, -"Hackathon".Length / 2, "Middle");
        ReadCharacterFromFile(fs, -1, "Last");
    }

    private static void ReadCharacterFromFile(FileStream fs, int positionFromEnd, string characterDescription)
    {
        fs.Seek(positionFromEnd, SeekOrigin.End);
        Console.WriteLine($"The {characterDescription} Character is: \"{(char)fs.ReadByte()}\"");
    }
}
