using System;
using System.Net;
using System.Net.Http;

using JetBrains.Annotations;

using NinjaTools.FluentMockServer.Models;
using NinjaTools.FluentMockServer.Models.HttpEntities;
using NinjaTools.FluentMockServer.Models.ValueTypes;


namespace NinjaTools.FluentMockServer.Builders
{
    internal sealed class FluentExpectationBuilder : IFluentExpectationBuilder
    {
        private readonly MockServerSetup _setup;
        private Expectation _expectation;

        private IFluentExpectationBuilder _and;


        public FluentExpectationBuilder() : this(new MockServerSetup())
        {
        }

        internal FluentExpectationBuilder(MockServerSetup setup)
        {
            _expectation = new Expectation();
            _setup = setup;
        }

        /// <inheritdoc />
        public IBlankExpectation WithBaseUrl(string url)
        {
            _setup.BaseUrl = url;
            return this;
        }

        /// <inheritdoc />
        public IWithRequest OnHandling(HttpMethod method, Action<IFluentHttpRequestBuilder> requestFactory = null)
        {
            var builder = new FluentHttpRequestBuilder(method);
            requestFactory?.Invoke(builder);
            _expectation.HttpRequest = builder.Build();
            return this;
        }


        /// <inheritdoc />
        [NotNull]
        public IWithRequest OnHandlingAny(HttpMethod method = null)
        {
            if (method is null) {
                _expectation.HttpRequest = null;
                return this;
            }

            _expectation.HttpRequest = new HttpRequest()
            {
                HttpMethod = method
            };

            return this;
        }


        /// <inheritdoc />
        public IWithResponse RespondWith(int statusCode, Action<IFluentHttpResponseBuilder> responseFactory)
        {
            var builder = new FluentHttpResponseBuilder();
            responseFactory?.Invoke(builder);
            _expectation.HttpResponse = builder.Build();
            _expectation.HttpResponse.StatusCode = statusCode;
            return this;
        }

        /// <inheritdoc />
        public IWithResponse RespondWith(HttpStatusCode statusCode, Action<IFluentHttpResponseBuilder> responseFactory)
        {
            return RespondWith((int) statusCode, responseFactory);
        }


        /// <inheritdoc />
        public IWithResponse RespondOnce(int statusCode, Action<IFluentHttpResponseBuilder> responseFactory)
        {
            _expectation.Times = Times.Once;
            return RespondWith(statusCode, responseFactory);
        }


        /// <inheritdoc />
        public IWithResponse RespondOnce(HttpStatusCode statusCode, Action<IFluentHttpResponseBuilder> responseFactory)
        {
            return RespondOnce(( int ) statusCode, responseFactory);
        }

        /// <inheritdoc />
        public IWithResponse RespondTimes(int times, int statusCode, Action<IFluentHttpResponseBuilder> responseFactory = null)
        {
            _expectation.Times = new Times(times);
            var builder = new FluentHttpResponseBuilder();
            responseFactory?.Invoke(builder);
            _expectation.HttpResponse = builder.Build();
            _expectation.HttpResponse.StatusCode = statusCode;
            return this;
        }

        /// <inheritdoc />
        public IWithResponse RespondTimes(int times, HttpStatusCode statusCode, Action<IFluentHttpResponseBuilder> responseFactory = null)
        {
            return RespondTimes(times, (int) statusCode, responseFactory);
        }


        /// <inheritdoc />
        public IWithResponse WhichIsValidFor(int value, TimeUnit timeUnit = TimeUnit.Seconds)
        {
            _expectation.TimeToLive = new LifeTime(value, timeUnit);
            return this;
        }

        /// <inheritdoc />
        public MockServerSetup Setup()
        {
           _setup.Expectations.Add(_expectation);
           return _setup;
        }


        /// <inheritdoc />
        IFluentExpectationBuilder IWithResponse.And
        {
            get
            {
                Setup();
                return new FluentExpectationBuilder(_setup);
            }
        }
    }
}