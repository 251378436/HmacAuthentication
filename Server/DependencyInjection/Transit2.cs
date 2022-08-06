namespace Server.DependencyInjection
{
    public interface ITransit2
    {
    }

    public class Transit2 : ITransit2
    {
        public string Name { get; set; }

        public Transit2()
        {
            Name = nameof(Transit2);
        }
    }
}