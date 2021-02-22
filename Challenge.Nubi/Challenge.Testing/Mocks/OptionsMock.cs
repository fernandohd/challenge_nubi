using Microsoft.Extensions.Options;

namespace Challenge.Testing.Mocks
{
    public class OptionsMock<TOptions> : IOptions<TOptions> where TOptions : class, new()
    {
        public OptionsMock(TOptions value)
        {
            Value = value;
        }

        public TOptions Value { get; }
    }
}
