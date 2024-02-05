namespace Telegram.Bot.Types.Payments;

/// <summary>
/// This object represents information about an order.
/// </summary>
#if !NET8_0_OR_GREATER
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
#endif
[DataContract]
public class OrderInfo
{
    /// <summary>
    /// Optional. User name
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Name { get; set; }

    /// <summary>
    /// Optional. User's phone number
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Optional. User email
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public string? Email { get; set; }

    /// <summary>
    /// Optional. User shipping address
    /// </summary>
    [DataMember(EmitDefaultValue = false)]
    public ShippingAddress? ShippingAddress { get; set; }
}
