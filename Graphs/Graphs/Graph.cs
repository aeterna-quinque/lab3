using System;

namespace Graphs
{
    class Graph
    {
        private int[,] adjacent;
        private int[,] incident;
        private int vortex = 0;
        private int edge;

        public Graph()
        { }

        public void AdjInput()
        {
            int begin = VortexInput();
            adjacent = new int[vortex, vortex];
            Console.WriteLine("Введите связь вершин в графе.\n " +
                "0 - связи нет \t 1 - связь есть ");
            for (int i = 0; i < vortex; i++)
            {
                for (int j = 0; j < vortex; j++)
                {
                    Console.Write("{0}-->{1}: ", i+begin, j+begin);
                    adjacent[i, j] = int.Parse(Console.ReadLine());
                    if ((adjacent[i, j] != 0) & (adjacent[i, j] != 1)) throw new FormatException("Введено неверное значение.");
                    if (j == vortex - 1) Console.Write('\n');
                }
            }
            AdjOutput();
        }

        public void AdjOutput()
        {
            int index = 0;
            foreach (int i in adjacent)
            {
                index++;
                Console.Write(i);
                if (index % vortex == 0) Console.Write('\n');
                else Console.Write('\t');
            }
        }

        private int VortexInput()
        {
            if (vortex == 0)
            {
                Console.Write("Введите количество вершин: ");
                vortex = int.Parse(Console.ReadLine());
            }
            Console.Write("Отсчет вершин начинается с: ");
            int begin = int.Parse(Console.ReadLine());
            return begin;
        }

        public void IncInput()
        {
            VortexInput();
            Console.WriteLine("Введите количество ребер: ");
            edge = int.Parse(Console.ReadLine());
            Console.WriteLine("Желаете построить ориентированный или неориентированный граф?" +
                " \n 0 - Неориентированный \t 1 - Ориентированный");
            bool choice = bool.Parse(Console.ReadLine());
        }
    }
}
