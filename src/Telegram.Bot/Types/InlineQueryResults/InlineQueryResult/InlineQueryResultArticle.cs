

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.InlineQueryResults;

/// <summary>
/// Represents a link to an article or web page.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class InlineQueryResultArticle : InlineQueryResult
{
    /// <summary>
    /// Type of the result, must be article
    /// </summary>
    [DataMember(IsRequired = true)]
    public override InlineQueryResultType Type => InlineQueryResultType.Article;

    /// <summary>
    /// Title of the result
    /// </summary>
    [DataMember(IsRequired = true)]
    public string Title { get; }

    /// <summary>
    /// Content of the message to be sent
    /// </summary>
    [DataMember(IsRequired = true)]
    public InputMessageContent InputMessageContent { get; }

    /// <summary>
    /// Optional. URL of the result.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Url { get; set; }

    /// <summary>
    /// Optional. Pass <see langword="true"/>, if you don't want the URL to be shown in the message.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public bool? HideUrl { get; set; }

    /// <summary>
    /// Optional. Short description of the result.
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Description { get; set; }

    /// <inheritdoc cref="Documentation.ThumbnailUrl" />
    [DataMember(EmitDefaultValue = false)]
    public string? ThumbnailUrl { get; set; }

    /// <inheritdoc cref="Documentation.ThumbnailWidth" />
    [DataMember(EmitDefaultValue = false)]
    public int? ThumbnailWidth { get; set; }

    /// <inheritdoc cref="Documentation.ThumbnailHeight" />
    [DataMember(EmitDefaultValue = false)]
    public int? ThumbnailHeight { get; set; }

    /// <summary>
    /// Initializes a new <see cref="InlineQueryResultArticle"/> object
    /// </summary>
    /// <param name="id">Unique identifier of this result</param>
    /// <param name="title">Title of the result</param>
    /// <param name="inputMessageContent">Content of the message to be sent</param>
    public InlineQueryResultArticle(string id, string title, InputMessageContent inputMessageContent)
        : base(id)
    {
        Title = title;
        InputMessageContent = inputMessageContent;
    }
}
