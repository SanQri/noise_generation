using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseGeneration
{
    class GenerationController
    {
        public static Queue<NoiseCell> QueueC = new Queue<NoiseCell>();
        public static Queue<NoiseCell> QueueP = new Queue<NoiseCell>();
        const int size = 128;
        public NoiseCell[,] cells = new NoiseCell[size, size];
        public int ccw = 0;
        public int ccg = 0;
        public int ccb = 0;
        public GenerationController()
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    cells[i, j] = new NoiseCell();
                    cells[i, j].value = 1;
                    cells[i, j].x = i;
                    cells[i, j].y = j;
                    cells[i, j].state = NoiseCell.State.white;
                }
            InitialGeneration(10, 128);
        }
        public GenerationController(int c, int a)
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    cells[i, j] = new NoiseCell();
                    cells[i, j].value = 1;
                    cells[i, j].x = i;
                    cells[i, j].y = j;
                    cells[i, j].state = NoiseCell.State.white;
                }
            InitialGeneration(c, a);
        }
        
        void InitialGeneration(int countOfPeaks, int amplitude)
        {
            Random r = new Random();
            for(int i = 0; i < countOfPeaks; i++)
            {
                int xIndex = r.Next(size - 1);
                int yIndex = r.Next(size - 1);
                cells[xIndex, yIndex].value = r.NextDouble() * amplitude;
                cells[xIndex, yIndex].state = NoiseCell.State.grey;
                QueueC.Enqueue(cells[xIndex, yIndex]);
                QueueP.Enqueue(cells[xIndex, yIndex]);
            }
            while(QueueC.Count > 0)
            {
                int xI = QueueC.Peek().x;
                int yI = QueueC.Peek().y;
                //////////////////////////////////////////////////////////////////
                if (cells[xI, yI].state == NoiseCell.State.white)
                {
                    double tSum = 0;
                    int tCount = 0;
                    for (int i = -4; i < 5; i++)
                        for (int j = -4; j < 5; j++)
                            if (xI + i < size && xI + i > 0 && yI + j < size && yI + j > 0)
                                if (cells[i + xI, j + yI].state != NoiseCell.State.white)
                                {
                                    tSum += cells[i + xI, j + yI].value;
                                    tCount++;
                                }
                    tSum /= tCount;
                    int scatter = 30;
                    int logRange = 3;
                    double tmp = Math.Log(tSum, 2);
                    tSum += r.NextDouble() * (Math.Log(tSum + logRange, 2) - tmp) * scatter;
                    tSum -= r.NextDouble() * scatter * (tmp - (Math.Log(tSum - logRange, 2)));
                    cells[xI, yI].value = tSum;
                    cells[xI, yI].state = NoiseCell.State.grey;
                }
                //////////////////////////////////////////////////////////////////
                if (cells[xI, yI].state == NoiseCell.State.grey)
                {
                    for (int i = -1; i < 2; i++)
                        for (int j = -1; j < 2; j++)
                            if (xI + i < size && xI + i >= 0 && yI + j < size && yI + j >= 0)
                                if (cells[i + xI, j + yI].state == NoiseCell.State.white)
                                    QueueC.Enqueue(cells[i + xI, j + yI]);
                    cells[xI, yI].state = NoiseCell.State.black;
                }
                //////////////////////////////////////////////////////////////////
                QueueC.Dequeue();
            }
            while(QueueP.Count > 0)
            {
                int xI = QueueP.Peek().x;
                int yI = QueueP.Peek().y;
                double tSum = 0;
                int tCount = 0;
                for (int i = -4; i < 5; i++)
                    for (int j = -4; j < 5; j++)
                        if (xI + i < size && xI + i >= 0 && yI + j < size && yI + j >= 0)
                            if (cells[i + xI, j + yI].state != NoiseCell.State.white)
                            {
                                tSum += cells[i + xI, j + yI].value;
                                tCount++;
                            }
                if (tCount == 0)
                    tSum = amplitude - 1;
                else
                    cells[xI, yI].value = tSum / tCount;
                QueueP.Dequeue();
            }
             for (int i = 0; i < size; i++)
                 for (int j = 0; j < size; j++)
                 {
                     if (cells[i, j].state == NoiseCell.State.grey)
                         ccg++;
                     if (cells[i, j].state == NoiseCell.State.white)
                         ccw++;
                     if (cells[i, j].state == NoiseCell.State.black)
                         ccb++;
                 }
        }


    }
}
