using Orleans;

namespace Eliseev.Orleans.HelloWorld.Models.Graints.Hello
{
    public interface IHelloGrain : IGrainWithStringKey
    {
        ValueTask<string> SayHello(string greeting);
    }
}