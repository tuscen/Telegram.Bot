using System.Collections.Generic;
using System.Net.Http;
using Telegram.Bot.Extensions;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to send animation files (GIF or H.264/MPEG-4 AVC video without sound). On success,
/// the sent <see cref="Message"/> is returned. Bots can currently send animation files of up to
/// 50 MB in size, this limit may be changed in the future.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class SendAnimationRequest : FileRequestBase<Message>, IChatTargetable
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public ChatId ChatId { get; }

    /// <summary>
    /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? MessageThreadId { get; set; }

    /// <summary>
    /// Animation to send. Pass a <see cref="InputFileId"/> as String to send an animation
    /// that exists on the Telegram servers (recommended), pass an HTTP URL as a String for Telegram
    /// to get an animation from the Internet, or upload a new animation using multipart/form-data
    /// </summary>
    [DataMember(IsRequired = true)]
    public InputFile Animation { get; }

    /// <summary>
    /// Duration of sent animation in seconds
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? Duration { get; set; }

    /// <summary>
    /// Animation width
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? Width { get; set; }

    /// <summary>
    /// Animation height
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? Height { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.Thumbnail"/>
    [DataMember(EmitDefaultValue = false)]
    public InputFile? Thumbnail { get; set; }

    /// <summary>
    /// Animation caption (may also be used when resending animation by
    /// <see cref="InputFileId"/>), 0-1024 characters after entities parsing
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Caption { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ParseMode"/>
    [DataMember(EmitDefaultValue = false)]
    public ParseMode? ParseMode { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.CaptionEntities"/>
    [DataMember(EmitDefaultValue = false)]
    public IEnumerable<MessageEntity>? CaptionEntities { get; set; }

    /// <summary>
    /// Pass <see langword="true"/> if the photo needs to be covered with a spoiler animation
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? HasSpoiler { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.DisableNotification"/>
    [DataMember(EmitDefaultValue = false)]
    public bool? DisableNotification { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ProtectContent"/>
    [DataMember(EmitDefaultValue = false)]
    public bool? ProtectContent { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyToMessageId"/>
    [DataMember(EmitDefaultValue = false)]
    public int? ReplyToMessageId { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.AllowSendingWithoutReply"/>
    [DataMember(EmitDefaultValue = false)]
    public bool? AllowSendingWithoutReply { get; set; }

    /// <inheritdoc cref="Abstractions.Documentation.ReplyMarkup"/>
    [DataMember(EmitDefaultValue = false)]
    public IReplyMarkup? ReplyMarkup { get; set; }

    /// <summary>
    /// Initializes a new request with chatId and animation
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </param>
    /// <param name="animation">
    /// Animation to send. Pass a <see cref="InputFileId"/> as String to send an animation
    /// that exists on the Telegram servers (recommended), pass an HTTP URL as a String for Telegram to
    /// get an animation from the Internet, or upload a new animation using multipart/form-data
    /// </param>
    public SendAnimationRequest(ChatId chatId, InputFile animation)
        : base("sendAnimation")
    {
        ChatId = chatId;
        Animation = animation;
    }

    /// <inheritdoc />
    public override HttpContent? ToHttpContent() =>
        Animation is InputFileStream || Thumbnail is InputFileStream
            ? GenerateMultipartFormDataContent("animation", "thumbnail")
                .AddContentIfInputFile(media: Animation, name: "animation")
                .AddContentIfInputFile(media: Thumbnail, name: "thumbnail")
            : base.ToHttpContent();
}
