using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNoise
{
    class RandomMap
    {
        const int size = 128;
        public Cell[,] cells = new Cell[size, size];
        public RandomMap() 
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    cells[i, j] = new Cell();
                }            
        }
        public RandomMap(int frequency, double amplitude)
        {
            Random r = new Random();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    cells[i, j] = new Cell();
                    cells[i, j].x = i;
                    cells[i, j].y = j;
                    cells[i, j].value = -1;
                }
            for(int i = 0; i < size; i += frequency)
                for(int j = 0; j < size; j += frequency)
                {
                    cells[i, j].value = r.NextDouble() * amplitude;
                }
            if (frequency != 1)
            {
                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                    {
                        double tSumVal = 0;
                        int tSqSumDist = 0;
                        int t = frequency * frequency;
                        for (int ii = -1 * frequency; ii <= 1 * frequency; ii++)
                        {
                            for (int jj = -1 * frequency; jj <= 1 * frequency; jj++)
                            {
                                if(((i + ii) % frequency == 0) && ((j + jj) % frequency == 0))
                                {
                                    if(i + ii > 0 && i + ii < size && j + jj > 0 && j + jj < size)
                                    {
                                        int tmp = ii * ii + jj * jj;
                                        tSqSumDist += tmp;
                                        tSumVal += (t - tmp) * cells[ii + i, jj + j].value;
                                    }
                                }
                            }
                        }
                        cells[i, j].value = tSumVal / tSqSumDist;
                    }
            }
        }
    }
}
