namespace Server.DependencyInjection
{
    public interface ISingleton2
    {
    }

    public class Singleton2 : ISingleton2
    {
        public string Name { get; set; }

        public Singleton2()
        {
            Name = nameof(Singleton2);
        }
    }
}
