using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseGeneration
{
    class GenerationController
    {
        public static Queue<NoiseCell> QueueC;
        const int size = 128;
        NoiseCell[,] cells = new NoiseCell[size, size];

        public GenerationController() { }

    }
}
