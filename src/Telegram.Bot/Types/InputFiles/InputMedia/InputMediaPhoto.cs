using Telegram.Bot.Types.Enums;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types;

/// <summary>
/// Represents a photo to be sent
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class InputMediaPhoto :
    InputMedia,
    IAlbumInputMedia
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public override InputMediaType Type => InputMediaType.Photo;

    /// <summary>
    /// Optional. Pass <see langword="true"/> if the photo needs to be covered with a spoiler animation
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? HasSpoiler { get; set; }

    /// <summary>
    /// Initializes a new photo media to send with an <see cref="InputFile"/>
    /// </summary>
    /// <param name="media">File to send</param>
    public InputMediaPhoto(InputFile media)
        : base(media)
    { }
}
