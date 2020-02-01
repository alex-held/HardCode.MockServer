using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using JetBrains.Annotations;
using NinjaTools.FluentMockServer.Models.ValueTypes;

namespace NinjaTools.FluentMockServer.FluentAPI
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [PublicAPI]
    public interface IBlankExpectation : IFluentInterface
    {
        IWithRequest OnHandling(HttpMethod method = null, [CanBeNull] Action<IFluentHttpRequestBuilder> requestFactory = null);
        IWithRequest OnHandlingAny([CanBeNull] HttpMethod method = null);
    }

    /// <inheritdoc cref="IBlankExpectation" />
    /// <summary>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [PublicAPI]
    public interface IFluentExpectationBuilder : IBlankExpectation , IWithRequest, IWithResponse
    {
      
    }
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [PublicAPI]
    public interface IWithResponse : IFluentInterface
    {
        IFluentExpectationBuilder And { get; }
        IWithResponse WhichIsValidFor(int value, TimeUnit timeUnit = TimeUnit.Seconds);
        MockServerSetup Setup();
    }
        
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [PublicAPI]
    public interface IWithRequest : IFluentInterface
    {
        IWithResponse RespondWith(int statusCode, Action<IFluentHttpResponseBuilder> responseFactory = null);
        IWithResponse RespondWith(HttpStatusCode statusCode, Action<IFluentHttpResponseBuilder> responseFactory = null);

        IWithResponse RespondOnce(int statusCode, Action<IFluentHttpResponseBuilder> responseFactory = null);
        IWithResponse RespondOnce(HttpStatusCode statusCode, Action<IFluentHttpResponseBuilder> responseFactory = null);

        IWithResponse RespondTimes(int times, int statusCode, Action<IFluentHttpResponseBuilder> responseFactory = null);
    }
}
