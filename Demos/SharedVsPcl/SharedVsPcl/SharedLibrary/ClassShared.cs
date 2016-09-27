using System;
using Newtonsoft.Json;

namespace SharedLibrary
{
    public class ClassShared
    {
        public ClassShared()
        {
            var json = JsonConvert.SerializeObject("test");
        }

    }
}
