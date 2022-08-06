namespace Server.DependencyInjection
{
    public interface ITransit1
    {
    }

    public class Transit1 : ITransit1
    {
        public string Name { get; set; }
        public ITransit2 _transit2;
        public IScoped2 _scoped2;
        public ISingleton2 _singleton2;

        public Transit1(ITransit2 transit2, IScoped2 scoped2, ISingleton2 singleton2)
        {
            Name = nameof(Transit1);
            _transit2 = transit2;
            _scoped2 = scoped2;
            _singleton2 = singleton2;
        }
    }
}