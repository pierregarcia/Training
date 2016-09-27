using System;
using Newtonsoft.Json;

namespace PortableLibrary
{
    public class ClassPCL
    {
        public ClassPCL()
        {
            var json = JsonConvert.SerializeObject("test");
        }
    }
}
