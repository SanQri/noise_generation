using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseGeneration
{
    class NoiseCell
    {
        public int x = 0;
        public int y = 0;
        public enum State
        {
            white = 0,
            grey = 1,
            black = 2
        }
        public State state = State.white;

        public double value = 1;


    }
}
