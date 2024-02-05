using System.Collections.Generic;

namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to change search keywords assigned to a regular or custom emoji sticker.
/// The sticker must belong to a sticker set created by the bot.
/// Returns <see langword="true"/> on success.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class SetStickerKeywordsRequest : RequestBase<bool>
{
    /// <summary>
    /// <see cref="InputFileId">File identifier</see> of the sticker
    /// </summary>
    [DataMember(IsRequired = true)]
    public InputFileId Sticker { get; }

    /// <summary>
    /// Optional. A JSON-serialized list of 0-20 search keywords for the sticker
    /// with total length of up to 64 characters
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public IEnumerable<string>? Keywords { get; set; }

    /// <summary>
    /// Initializes a new request with sticker
    /// </summary>
    /// <param name="sticker">
    /// <see cref="InputFileId">File identifier</see> of the sticker
    /// </param>
    public SetStickerKeywordsRequest(InputFileId sticker)
        : base("setStickerKeywords")
    {
        Sticker = sticker;
    }
}
