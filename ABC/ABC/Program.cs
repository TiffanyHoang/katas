﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace ABC
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = new Output();
            var runner = new AppRunner(output);
            runner.Run();
        }
    }
}





    
