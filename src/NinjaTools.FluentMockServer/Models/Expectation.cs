﻿using NinjaTools.FluentMockServer.Models.HttpEntities;
using NinjaTools.FluentMockServer.Models.ValueTypes;


namespace NinjaTools.FluentMockServer.Models
{
    /// <summary>
    /// Model to set up an Expectation on the MockServer.
    /// </summary>
    public class Expectation
    {
        /// <summary>
        /// The <see cref="HttpRequest"/> to match.
        /// </summary>
        public HttpRequest HttpRequest { get; set; }

        /// <summary>
        /// The <see cref="HttpResponse"/> to respond with.
        /// </summary>
        public HttpResponse HttpResponse { get; set; }

        public HttpTemplate HttpResponseTemplate { get; set; }

        /// <summary>
        /// The Target specification to forward the matched <see cref="HttpRequest"/> to.
        /// </summary>
        public HttpForward HttpForward { get; set; }


        public HttpTemplate HttpForwardTemplate { get; set; }

        /// <summary>
        /// An <see cref="HttpError"/> to respond with in case the <see cref="HttpRequest"/> has been matched.
        /// </summary>
        public HttpError HttpError { get; set; }

        /// <summary>
        /// How many times the MockServer should expect this setup.
        /// </summary>
        public Times Times { get; set; }

        /// <summary>
        /// How long the MockServer should expect this setup.
        /// </summary>
        public LifeTime TimeToLive { get; set; }
    }
}
