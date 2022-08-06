namespace Server.DependencyInjection
{
    public interface IScoped1
    {
    }

    public class Scoped1 : IScoped1
    {
        public string Name { get; set; }
        public ITransit2 _transit2;
        public IScoped2 _scoped2;
        public ISingleton2 _singleton2;

        public Scoped1(ITransit2 transit2, IScoped2 scoped2, ISingleton2 singleton2)
        {
            Name = nameof(Scoped1);
            _transit2 = transit2;
            _scoped2 = scoped2;
            _singleton2 = singleton2;
        }
    }
}
