using Eliseev.Orleans.HelloWorld.Models.GrainsStates.Hello;
using Orleans.Runtime;
using System.IO;

namespace Eliseev.Orleans.HelloWorld.Models.Graints.Hello
{
    public sealed class HelloGrain : Grain, IHelloGrain
    {
        private IPersistentState<HelloGrainState> state;

        public HelloGrain(
             [PersistentState("strings", "OrleansStorage")]
             IPersistentState<HelloGrainState> state)
        {
            this.state = state;
        }

        public override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            if (state.State.Strings == null)
            {
                state.State.Strings = new List<string>();
            }

            return Task.CompletedTask;
        }


        public async ValueTask<string> SayHello(string greeting)
        {
            state.State.Strings.Add(greeting);
            await state.WriteStateAsync();
            return $"Hello, {string.Join(',', state.State.Strings)}!";
        }
    }
}
