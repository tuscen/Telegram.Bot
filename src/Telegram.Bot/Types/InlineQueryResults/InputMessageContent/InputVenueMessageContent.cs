

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents the content of a <see cref="Venue"/> message to be sent as the result of an
/// <see cref="InlineQuery">inline query</see>.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class InputVenueMessageContent : InputMessageContent
{
    /// <summary>
    /// Latitude of the venue in degrees
    /// </summary>
    [DataMember(IsRequired = true)]
    public double Latitude { get; }

    /// <summary>
    /// Longitude of the venue in degrees
    /// </summary>
    [DataMember(IsRequired = true)]
    public double Longitude { get; }

    /// <summary>
    /// Name of the venue
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Title { get; }

    /// <summary>
    /// Address of the venue
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Address { get; }

    /// <summary>
    /// Optional. Foursquare identifier of the venue, if known
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? FoursquareId { get; set; }

    /// <summary>
    /// Optional. Foursquare type of the venue. (For example, “arts_entertainment/default”,
    /// “arts_entertainment/aquarium” or “food/icecream”.)
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? FoursquareType { get; set; }

    /// <summary>
    /// Google Places identifier of the venue
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? GooglePlaceId { get; set; }

    /// <summary>
    /// Google Places type of the venue.
    /// <a href="https://developers.google.com/places/web-service/supported_types"/>
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? GooglePlaceType { get; set; }

    /// <summary>
    /// Initializes a new inline query result
    /// </summary>
    /// <param name="title">The name of the venue</param>
    /// <param name="address">The address of the venue</param>
    /// <param name="latitude">The latitude of the venue</param>
    /// <param name="longitude">The longitude of the venue</param>
    public InputVenueMessageContent(string title, string address, double latitude, double longitude)
    {
        Title = title;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }
}
