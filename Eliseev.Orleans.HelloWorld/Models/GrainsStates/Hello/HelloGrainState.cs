using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliseev.Orleans.HelloWorld.Models.GrainsStates.Hello
{
    [Serializable]
    public class HelloGrainState
    {
        public List<string> Strings { get; set; }
    }
}
