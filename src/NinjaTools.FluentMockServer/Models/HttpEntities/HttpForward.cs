namespace NinjaTools.FluentMockServer.Models.HttpEntities
{
    /// <summary>
    /// Model to describe to which destination the <see cref="HttpRequest"/> to forward.
    /// </summary>
    public class HttpForward 
    {
        /// <summary>
        /// Gets and sets the Hostname to forward to.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gets and sets the Port to forward to.
        /// </summary>
        public int? Port { get; set; }
    }
}
