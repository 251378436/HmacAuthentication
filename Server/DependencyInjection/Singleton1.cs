namespace Server.DependencyInjection
{
    public interface ISingleton1
    {
    }

    /// <summary>
    /// Single ton can not inject scoped directly, if needed can try to create scope in function
    /// </summary>
    public class Singleton1 : ISingleton1
    {
        public string Name { get; set; }
        public ITransit2 _transit2;
        public ISingleton2 _singleton2;

        public Singleton1(ITransit2 transit2, ISingleton2 singleton2)
        {
            Name = nameof(Singleton1);
            _transit2 = transit2;
            _singleton2 = singleton2;
        }
    }
}
