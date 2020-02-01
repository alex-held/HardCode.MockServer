using System;
using System.Diagnostics;

namespace NinjaTools.FluentMockServer.API.Models
{
    /// <inheritdoc />
    /// <summary>
    /// Defines how the MockServer responds zu a matched requests.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
    public class ResponseAction : IEquatable<ResponseAction>
    {
        public string DebuggerDisplay() =>  $"{Response?.DebuggerDisplay()}";
        public HttpResponse Response { get; set; }

        #region Equality members

        /// <inheritdoc />
        public bool Equals(ResponseAction? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Response.Equals(other.Response);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ResponseAction) obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Response.GetHashCode();
        }

        public static bool operator ==(ResponseAction? left, ResponseAction? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ResponseAction? left, ResponseAction? right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}
