namespace Server.DependencyInjection
{
    public interface IScoped2
    {
    }

    public class Scoped2 : IScoped2
    {
        public string Name { get; set; }

        public Scoped2()
        {
            Name = nameof(Scoped2);
        }
    }
}
