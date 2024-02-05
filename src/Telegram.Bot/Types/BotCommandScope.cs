using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

/// <summary>
/// This object represents the scope to which bot commands are applied
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#else
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(BotCommandScopeDefault))]
[JsonDerivedType(typeof(BotCommandScopeAllPrivateChats))]
[JsonDerivedType(typeof(BotCommandScopeAllGroupChats))]
[JsonDerivedType(typeof(BotCommandScopeAllChatAdministrators))]
[JsonDerivedType(typeof(BotCommandScopeChat))]
[JsonDerivedType(typeof(BotCommandScopeChatAdministrators))]
[JsonDerivedType(typeof(BotCommandScopeChatMember))]
#endif
public abstract class BotCommandScope
{
    /// <summary>
    /// Scope type
    /// </summary>
    [DataMember(IsRequired = true)]
    public abstract BotCommandScopeType Type { get; }

    /// <summary>
    /// Create a default <see cref="BotCommandScope"/> instance
    /// </summary>
    /// <returns></returns>
    public static BotCommandScopeDefault Default() => new();

    /// <summary>
    /// Create a <see cref="BotCommandScope"/> instance for all private chats
    /// </summary>
    /// <returns></returns>
    public static BotCommandScopeAllPrivateChats AllPrivateChats() => new();

    /// <summary>
    /// Create a <see cref="BotCommandScope"/> instance for all group chats
    /// </summary>
    public static BotCommandScopeAllGroupChats AllGroupChats() => new();

    /// <summary>
    /// Create a <see cref="BotCommandScope"/> instance for all chat administrators
    /// </summary>
    public static BotCommandScopeAllChatAdministrators AllChatAdministrators() =>
        new();

    /// <summary>
    /// Create a <see cref="BotCommandScope"/> instance for a specific <see cref="Chat"/>
    /// </summary>
    /// <param name="chatId">
    /// Unique identifier for the target <see cref="Chat"/> or username of the target supergroup
    /// </param>
    public static BotCommandScopeChat Chat(ChatId chatId) => new() { ChatId = chatId };

    /// <summary>
    /// Create a <see cref="BotCommandScope"/> instance for a specific member in a specific <see cref="Chat"/>
    /// </summary>
    /// <param name="chatId">
    /// Unique identifier for the target <see cref="Chat"/> or username of the target supergroup
    /// </param>
    public static BotCommandScopeChatAdministrators ChatAdministrators(ChatId chatId) =>
        new() { ChatId = chatId };

    /// <summary>
    /// Represents the <see cref="BotCommandScope">scope</see> of bot commands, covering a specific member of a group or supergroup chat.
    /// </summary>
    /// <param name="chatId">
    /// Unique identifier for the target <see cref="Chat"/> or username of the target supergroup
    /// </param>
    /// <param name="userId">Unique identifier of the target user</param>
    public static BotCommandScopeChatMember ChatMember(ChatId chatId, long userId) =>
        new() { ChatId = chatId, UserId = userId };
}

/// <inheritdoc cref="BotCommandScopeType.Default"/>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class BotCommandScopeDefault : BotCommandScope
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public override BotCommandScopeType Type => BotCommandScopeType.Default;
}

/// <inheritdoc cref="BotCommandScopeType.AllPrivateChats"/>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class BotCommandScopeAllPrivateChats : BotCommandScope
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public override BotCommandScopeType Type => BotCommandScopeType.AllPrivateChats;
}

/// <inheritdoc cref="BotCommandScopeType.AllGroupChats"/>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class BotCommandScopeAllGroupChats : BotCommandScope
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public override BotCommandScopeType Type => BotCommandScopeType.AllGroupChats;
}

/// <inheritdoc cref="BotCommandScopeType.AllChatAdministrators"/>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class BotCommandScopeAllChatAdministrators : BotCommandScope
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public override BotCommandScopeType Type => BotCommandScopeType.AllChatAdministrators;
}

/// <inheritdoc cref="BotCommandScopeType.Chat"/>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class BotCommandScopeChat : BotCommandScope
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public override BotCommandScopeType Type => BotCommandScopeType.Chat;

    /// <summary>
    /// Unique identifier for the target <see cref="Chat"/> or username of the target supergroup
    /// (in the format @supergroupusername)
    /// </summary>
    [DataMember(IsRequired = true)]
    public ChatId ChatId { get; set; } = default!;
}

/// <inheritdoc cref="BotCommandScopeType.ChatAdministrators"/>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class BotCommandScopeChatAdministrators : BotCommandScope
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public override BotCommandScopeType Type => BotCommandScopeType.ChatAdministrators;

    /// <summary>
    /// Unique identifier for the target <see cref="Chat"/> or username of the target supergroup
    /// (in the format @supergroupusername)
    /// </summary>
    [DataMember(IsRequired = true)]
    public ChatId ChatId { get; set; } = default!;
}

/// <inheritdoc cref="BotCommandScopeType.ChatMember"/>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class BotCommandScopeChatMember : BotCommandScope
{
    /// <inheritdoc />
    [DataMember(IsRequired = true)]
    public override BotCommandScopeType Type => BotCommandScopeType.ChatMember;

    /// <summary>
    /// Unique identifier for the target <see cref="Chat"/> or username of the target supergroup
    /// (in the format @supergroupusername)
    /// </summary>
    [DataMember(IsRequired = true)]
    public ChatId ChatId { get; set; } = default!;

    /// <summary>
    /// Unique identifier of the target user
    /// </summary>
    [DataMember(IsRequired = true)]
    public long UserId { get; set; }
}
