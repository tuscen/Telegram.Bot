namespace Telegram.Bot.Types;

/// <summary>
/// This object represents a service message about a forum topic closed in the chat. Currently holds no information.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class ForumTopicClosed { }
