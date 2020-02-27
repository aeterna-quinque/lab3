using System;

namespace Graphs
{
    class Graph
    {
        private int[,] adjacent;
        private int[,] incident;
        private int vortex = 0;
        private int edge = 0;

        public Graph()
        { }

        public void AdjInput()
        {
            Console.WriteLine("Ввод матрицы смежности");
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
            Console.Write('\n');
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

        private int EdgeInput()
        {
            if (edge == 0)
            {
                Console.Write("Введите количество граней: ");
                edge = int.Parse(Console.ReadLine());
            }
            Console.Write("Отсчет граней начинается с: ");
            int begin = int.Parse(Console.ReadLine());
            return begin;
        }

        public void IncInput()
        {
            Console.WriteLine("Ввод матрицы инцидентности");
            int beginvortex = VortexInput();
            int beginedge = EdgeInput();
            Console.WriteLine("Желаете построить ориентированный или неориентированный граф?" +
                " \n 0 - Неориентированный \t 1 - Ориентированный");
            byte choice = byte.Parse(Console.ReadLine());
            Console.WriteLine("Введите связь вершин и граней в графе");
            if (choice == 1) Console.WriteLine("1 - выходит из вершины\t -1 - входит в вершину\t 0 - нет связи");
            else Console.WriteLine("1 - есть связь\t 0 - нет связи");
            Console.WriteLine("Вершина --> Грань");
            for (int i = 0; i < vortex; i++)
            {
                for (int j = 0; j < edge; j++)
                {
                    Console.Write("{0} --> {1}:", i + beginvortex, j + beginedge);
                    incident[i, j] = int.Parse(Console.ReadLine());
                    if ((incident[i, j] != 0) & (Math.Abs(incident[i, j]) != 1)) throw new FormatException("Введено неверное значение.");
                    if (j == edge - 1) Console.Write('\n');
                }
            }
        }

        public void IncOutput()
        {
            int index = 0;
            foreach (int i in incident)
            {
                index++;
                Console.Write(i);
                if (index % edge == 0) Console.Write('\n');
                else Console.Write('\t');
            }
            Console.Write('\n');
        }
    }
}
