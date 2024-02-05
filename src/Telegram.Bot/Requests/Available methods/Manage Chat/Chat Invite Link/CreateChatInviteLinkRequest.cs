#if !NET8_0_OR_GREATER
using Newtonsoft.Json.Converters;
#endif
using Telegram.Bot.Converters;
using Telegram.Bot.Requests.Abstractions;

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Requests;

/// <summary>
/// Use this method to create an additional invite link for a chat. The bot must be an
/// administrator in the chat for this to work and must have the appropriate admin rights.
/// The link can be revoked using the method <see cref="RevokeChatInviteLinkRequest"/>.
/// Returns the new invite link as <see cref="Types.ChatInviteLink"/> object.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class CreateChatInviteLinkRequest : RequestBase<ChatInviteLink>, IChatTargetable
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public ChatId ChatId { get; }

    /// <summary>
    /// Invite link name; 0-32 characters
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Name { get; set; }

    /// <summary>
    /// Point in time when the link will expire
    /// </summary>
    [JsonConverter(typeof(UnixDateTimeConverter))]
    [DataMember(EmitDefaultValue = false)]
    public DateTime? ExpireDate { get; set; }

    /// <summary>
    ///	Maximum number of users that can be members of the chat simultaneously after joining the
    /// chat via this invite link; 1-99999
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public int? MemberLimit { get; set; }

    /// <summary>
    /// Set to <see langword="true"/>, if users joining the chat via the link need to be approved by chat administrators.
    /// If <see langword="true"/>, <see cref="MemberLimit"/> can't be specified
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CreatesJoinRequest { get; set; }

    /// <summary>
    /// Initializes a new request with chatId
    /// </summary>
    /// <param name="chatId">Unique identifier for the target chat or username of the target channel
    /// (in the format <c>@channelusername</c>)
    /// </param>
    public CreateChatInviteLinkRequest(ChatId chatId)
        : base("createChatInviteLink")
    {
        ChatId = chatId;
    }
}
