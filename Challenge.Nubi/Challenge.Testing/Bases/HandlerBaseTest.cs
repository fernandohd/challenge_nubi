using AutoMapper;
using Challenge.Testing.Builders;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace Challenge.Testing.Bases
{
    public abstract class HandlerBaseTest<THandler>
    {
        public ILogger<THandler> Logger { get; }
        public IMapper Mapper { get; }
        public CancellationToken CancellationToken { get; }
        public THandler Handler { get; set; }

        protected HandlerBaseTest()
        {
            Logger = new LoggerFactory().CreateLogger<THandler>();
            Mapper = MapperBuilder.GetMapper();
            CancellationToken = new CancellationToken();
        }
    }
}
