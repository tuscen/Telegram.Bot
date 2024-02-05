#if NET8_0_OR_GREATER
using System.Text.Json.Serialization;
#else
using Newtonsoft.Json.Converters;
#endif
using Telegram.Bot.Converters;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

/// <summary>
/// This object contains information about one member of the chat.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
[JsonConverter(typeof(ChatMemberConverter))]
#elif NET8_0_OR_GREATER
[JsonPolymorphic(TypeDiscriminatorPropertyName = "status")]
[JsonDerivedType(typeof(ChatMemberAdministrator), "administrator")]
[JsonDerivedType(typeof(ChatMemberBanned), "kicked")]
[JsonDerivedType(typeof(ChatMemberLeft), "left")]
[JsonDerivedType(typeof(ChatMemberMember), "member")]
[JsonDerivedType(typeof(ChatMemberOwner), "creator")]
[JsonDerivedType(typeof(ChatMemberRestricted), "restricted")]
#endif
[DataContract]
public abstract class ChatMember
{
    /// <summary>
    /// The member's status in the chat.
    /// </summary>
#if !NET8_0_OR_GREATER
    [JsonProperty]
#endif
    public abstract ChatMemberStatus Status { get; }

    /// <summary>
    /// Information about the user
    /// </summary>
    [DataMember(IsRequired = true)]
    public User User { get; set; } = default!;
}

/// <summary>
/// Represents a <see cref="ChatMember"/> that owns the chat and has all administrator privileges
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class ChatMemberOwner : ChatMember
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public override ChatMemberStatus Status => ChatMemberStatus.Creator;

    /// <summary>
    /// Custom title for this user
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? CustomTitle { get; set; }

    /// <summary>
    /// <see langword="true"/>, if the user's presence in the chat is hidden
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool IsAnonymous { get; set; }
}

/// <summary>
/// Represents a <see cref="ChatMember"/> that has some additional privileges
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class ChatMemberAdministrator : ChatMember
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public override ChatMemberStatus Status => ChatMemberStatus.Administrator;

    /// <summary>
    /// <see langword="true"/>, if the bot is allowed to edit administrator privileges of that user
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool CanBeEdited { get; set; }

    /// <summary>
    /// <see langword="true"/>, if the user's presence in the chat is hidden
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool IsAnonymous { get; set; }

    /// <summary>
    /// <see langword="true"/>, if the administrator can access the chat event log, chat statistics, message statistics
    /// in channels, see channel members, see anonymous administrators in supergroups and ignore slow mode.
    /// Implied by any other administrator privilege
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool CanManageChat { get; set; }

    /// <summary>
    /// <see langword="true"/>, if the administrator can delete messages of other users
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool CanDeleteMessages { get; set; }

    /// <summary>
    /// <see langword="true"/>, if the administrator can manage video chats
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool CanManageVideoChats { get; set; }

    /// <summary>
    /// <see langword="true"/>, if the administrator can restrict, ban or unban chat members
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool CanRestrictMembers { get; set; }

    /// <summary>
    /// <see langword="true"/>, if the administrator can add new administrators with a subset of his own privileges or
    /// demote administrators that he has promoted, directly or indirectly (promoted by administrators that
    /// were appointed by the user)
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool CanPromoteMembers { get; set; }

    /// <summary>
    /// <see langword="true"/>, if the administrator can change the chat title, photo and other settings
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool CanChangeInfo { get; set; }

    /// <summary>
    /// <see langword="true"/>, if the administrator can invite new users to the chat
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool CanInviteUsers { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if the administrator can post in the channel, channels only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanPostMessages { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if the administrator can edit messages of other users, channels only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanEditMessages { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if the administrator can pin messages, supergroups only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanPinMessages { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if the administrator can post stories in the channel; channels only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanPostStories { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if the administrator can edit stories posted by other users; channels only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanEditStories { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if the administrator can delete stories posted by other users; channels only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanDeleteStories { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if the user is allowed to create, rename, close, and reopen forum topics;
    /// supergroups only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanManageTopics { get; set; }

    /// <summary>
    /// Optional. Custom title for this user
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? CustomTitle { get; set; }
}

/// <summary>
/// Represents a <see cref="ChatMember"/> that has no additional privileges or restrictions.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class ChatMemberMember : ChatMember
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public override ChatMemberStatus Status => ChatMemberStatus.Member;
}

/// <summary>
/// Represents a <see cref="ChatMember"/> that is under certain restrictions in the chat. Supergroups only.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class ChatMemberRestricted : ChatMember
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public override ChatMemberStatus Status => ChatMemberStatus.Restricted;

    /// <summary>
    /// <see langword="true"/>, if the user is a member of the chat at the moment of the request
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool IsMember { get; set; }

    /// <summary>
    /// <see langword="true"/>, if the user can change the chat title, photo and other settings
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool CanChangeInfo { get; set; }

    /// <summary>
    /// <see langword="true"/>, if the user can invite new users to the chat
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool CanInviteUsers { get; set; }

    /// <summary>
    /// <see langword="true"/>, if the user can pin messages, supergroups only
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool CanPinMessages { get; set; }

    /// <summary>
    /// <see langword="true"/>, if the user can send text messages, contacts, locations and venues
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool CanSendMessages { get; set; }

    /// <summary>
    /// <see langword="true" />, if the user is allowed to send audios
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool CanSendAudios { get; set; }

    /// <summary>
    /// <see langword="true" />, if the user is allowed to send documents
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool CanSendDocuments { get; set; }

    /// <summary>
    /// <see langword="true" />, if the user is allowed to send photos
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool CanSendPhotos { get; set; }

    /// <summary>
    /// <see langword="true" />, if the user is allowed to send videos
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool CanSendVideos { get; set; }

    /// <summary>
    /// <see langword="true" />, if the user is allowed to send video notes
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool CanSendVideoNotes { get; set; }

    /// <summary>
    /// <see langword="true" />, if the user is allowed to send voice notes
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool CanSendVoiceNotes { get; set; }

    /// <summary>
    /// <see langword="true"/>, if the user is allowed to send polls
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool CanSendPolls { get; set; }

    /// <summary>
    /// <see langword="true"/>, if the user is allowed to send animations, games, stickers and use inline bots
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool CanSendOtherMessages { get; set; }

    /// <summary>
    /// <see langword="true"/>, if the user is allowed to add web page previews to their messages
    /// </summary>
    [DataMember(IsRequired = true)]
    public bool CanAddWebPagePreviews { get; set; }

    /// <summary>
    /// Date when restrictions will be lifted for this user, UTC time
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    [JsonConverter(typeof(BanTimeConverter))]
    public DateTime? UntilDate { get; set; }

    /// <summary>
    /// Optional. <see langword="true"/>, if the user is allowed to create forum topics
    /// supergroups only
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? CanManageTopics { get; set; }
}

/// <summary>
/// Represents a <see cref="ChatMember"/> that isn't currently a member of the chat, but may join it themselves
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class ChatMemberLeft : ChatMember
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public override ChatMemberStatus Status => ChatMemberStatus.Left;
}

/// <summary>
/// Represents a <see cref="ChatMember"/> that was banned in the chat and can't return to the chat
/// or view chat messages
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class ChatMemberBanned : ChatMember
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public override ChatMemberStatus Status => ChatMemberStatus.Kicked;

    /// <summary>
    /// Date when restrictions will be lifted for this user, UTC time
    /// </summary>
    [JsonConverter(typeof(BanTimeConverter))]
    [DataMember(EmitDefaultValue = true)]
    public DateTime? UntilDate { get; set; }
}
