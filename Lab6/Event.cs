namespace Lab6;

/// <summary>
/// Represents an event with a number and location.
/// </summary>
/// <param name="number">The number of the event.</param>
/// <param name="location">The location of the event.</param>
[Serializable]
public class Event(int number, string location)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Event"/> class with default values.
    /// </summary>
    public Event() : this(0, "") { }

    /// <summary>
    /// Gets or sets the number of the event.
    /// </summary>
    public int EventNumber { get; set; } = number;

    /// <summary>
    /// Gets or sets the location of the event.
    /// </summary>
    public string Location { get; set; } = location;

    /// <inheritdoc/>
    public override string ToString() => $"Event No.: {EventNumber}\n" +
                                         $"Location: {Location}\n";
}
