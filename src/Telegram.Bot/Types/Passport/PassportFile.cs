#if NET8_0_OR_GREATER
using System.Text.Json.Serialization;
using Telegram.Bot.Converters;
#else
using Newtonsoft.Json.Converters;
#endif

// ReSharper disable once CheckNamespace
namespace Telegram.Bot.Types.Passport;

/// <summary>
/// This object represents a file uploaded to Telegram Passport. Currently all Telegram Passport files are in JPEG format when decrypted and don't exceed 10MB.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class PassportFile : FileBase
{
    /// <summary>
    /// DateTime when the file was uploaded
    /// </summary>
    [DataMember(IsRequired = true)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime FileDate { get; set; }
}
