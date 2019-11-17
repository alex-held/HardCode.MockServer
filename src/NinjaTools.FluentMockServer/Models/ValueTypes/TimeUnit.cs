using Newtonsoft.Json;


namespace NinjaTools.FluentMockServer.Models.ValueTypes
{
    using Serialization;



    /// <summary>
    /// Enumerate the available time unit.
    /// </summary>
    [JsonConverter(typeof(ContractResolver.UpperCaseEnumConverter))]
    public enum TimeUnit
    {
        /// <summary>
        /// The nanoseconds.
        /// </summary>
        Nanoseconds,

        /// <summary>
        /// The Microseconds.
        /// </summary>
        Microseconds,

        /// <summary>
        /// The Milliseconds.
        /// </summary>
        Milliseconds,

        /// <summary>
        /// The seconds.
        /// </summary>
        Seconds,

        /// <summary>
        /// The minutes.
        /// </summary>
        Minutes,

        /// <summary>
        /// The hours.
        /// </summary>
        Hours,

        /// <summary>
        /// The days.
        /// </summary>
        Days
    }
}
