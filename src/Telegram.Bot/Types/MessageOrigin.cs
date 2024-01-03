using Newtonsoft.Json.Converters;
using Telegram.Bot.Converters;

namespace Telegram.Bot.Types;

/// <summary>
/// This object describes the origin of a message. It can be one of
/// <list type="bullet">
/// <item><see cref="MessageOriginUser"/></item>
/// <item><see cref="MessageOriginHiddenUser"/></item>
/// <item><see cref="MessageOriginChat"/></item>
/// <item><see cref="MessageOriginChannel"/></item>
/// </list>
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
[JsonConverter(typeof(MessageOriginConverter))]
public abstract class MessageOrigin
{
    /// <summary>
    /// Type of the message origin
    /// </summary>
    [JsonProperty]
    public abstract string Type { get; }

    /// <summary>
    /// Date the message was sent originally
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public abstract DateTime Date { get; }
}

/// <summary>
/// The message was originally sent by a known user.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class MessageOriginUser : MessageOrigin
{
    /// <summary>
    /// Type of the message origin, always "user"
    /// </summary>
    public override string Type => "user";

    /// <inheritdoc/>
    [JsonProperty(Required = Required.Always)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public override DateTime Date { get; }

    /// <summary>
    /// User that sent the message originally
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public User SenderUser { get; } = default!;
}

/// <summary>
/// The message was originally sent by an unknown user.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class MessageOriginHiddenUser : MessageOrigin
{
    /// <summary>
    /// Type of the message origin, always "hidden_user"
    /// </summary>
    public override string Type => "hidden_user";

    /// <inheritdoc/>
    [JsonProperty(Required = Required.Always)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public override DateTime Date { get; }

    /// <summary>
    /// Name of the user that sent the message originally
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string SenderUserName { get; } = default!;
}

/// <summary>
/// The message was originally sent on behalf of a chat to a group chat.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class MessageOriginChat : MessageOrigin
{
    /// <summary>
    /// Type of the message origin, always "chat"
    /// </summary>
    public override string Type => "chat";

    /// <inheritdoc/>
    [JsonProperty(Required = Required.Always)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public override DateTime Date { get; }

    /// <summary>
    /// Chat that sent the message originally
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public Chat SenderChat { get; } = default!;

    /// <summary>
    /// Optional. For messages originally sent by an anonymous chat administrator,
    /// original message author signature
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? AuthorSignature { get; set; }
}

/// <summary>
/// The message was originally sent to a channel chat.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class MessageOriginChannel : MessageOrigin
{
    /// <summary>
    /// Type of the message origin, always "channel"
    /// </summary>
    public override string Type => "channel";

    /// <inheritdoc/>
    [JsonProperty(Required = Required.Always)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public override DateTime Date { get; }

    /// <summary>
    /// Channel chat to which the message was originally sent
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public Chat Chat { get; } = default!;

    /// <summary>
    /// Unique message identifier inside the chat
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public int MessageId { get; } = default!;

    /// <summary>
    /// Optional. Signature of the original post author
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? AuthorSignature { get; set; }
}
