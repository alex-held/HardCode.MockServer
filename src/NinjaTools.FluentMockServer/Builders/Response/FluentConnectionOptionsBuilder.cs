using NinjaTools.FluentMockServer.Models.ValueTypes;


namespace NinjaTools.FluentMockServer.Builders
{
    internal class FluentConnectionOptionsBuilder : IFluentConnectionOptionsBuilder
    {
        private readonly ConnectionOptions _options;

        public FluentConnectionOptionsBuilder()
        {
            _options = new ConnectionOptions();
        }


        public ConnectionOptions Build() => _options;
    }
}