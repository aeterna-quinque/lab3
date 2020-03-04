using System;
using System.Collections.Generic;

namespace Graphs
{
    class Graph
    {
        private int[,] adjacent;
        private int[,] incident;
        private int vortex = 0;
        private int edge = 0;
        private bool[] visited;
        private int begin = 0;
        private int[] distance;

        public Graph()
        { }

        public void AdjInput(bool dkstr)
        {
            Console.WriteLine("Ввод матрицы смежности");
            VortexInput();
            adjacent = new int[vortex, vortex];
            if (dkstr) Console.WriteLine("Введите связь вершин в графе\n " +
                "0 - связи нет \t 1 - связь есть ");
            else Console.WriteLine("Введите расстояние между вершинами");
            for (int i = 0; i < vortex; i++)
            {
                for (int j = 0; j < vortex; j++)
                {
                    Console.Write("{0}-->{1}: ", i + begin, j + begin);
                    adjacent[i, j] = int.Parse(Console.ReadLine());
                    if ((!dkstr) && (adjacent[i, j] != 0) && (adjacent[i, j] != 1))
                        throw new FormatException("Введено недопустимое значение");
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

        private void VortexInput()
        {
            if (vortex == 0)
            {
                Console.Write("Введите количество вершин: ");
                vortex = int.Parse(Console.ReadLine());
            }
            Console.Write("Отсчет вершин начинается с: ");
            begin = int.Parse(Console.ReadLine());
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
            VortexInput();
            int beginedge = EdgeInput();
            Console.WriteLine("Желаете построить ориентированный или неориентированный граф?" +
                " \n 0 - Неориентированный \t 1 - Ориентированный");
            byte choice = byte.Parse(Console.ReadLine());
            Console.WriteLine("Введите связь вершин и граней в графе");
            if (choice == 1) Console.WriteLine("1 - выходит из вершины\t -1 - входит в вершину\t 0 - нет связи");
            else Console.WriteLine("1 - есть связь\t 0 - нет связи");
            Console.WriteLine("Вершина --> Грань");
            incident = new int[vortex, edge];
            for (int i = 0; i < vortex; i++)
            {
                for (int j = 0; j < edge; j++)
                {
                    Console.Write("{0} --> {1}:", i + begin, j + beginedge);
                    incident[i, j] = int.Parse(Console.ReadLine());
                    if ((incident[i, j] != 0) & (Math.Abs(incident[i, j]) != 1))
                        throw new FormatException("Введено неверное значение.");
                    if (j == edge - 1) Console.Write('\n');
                }
            }
            IncOutput();
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

        public void Dfs()
        {
            Console.WriteLine("Поиск в глубину\n");
            AdjInput(false);
            visited = new bool[vortex];
            visited[0] = true;
            Console.WriteLine("Узел {0} посещен", 0 + begin);
            for (int i = 0; i < vortex; i++)
            {
                if ((adjacent[0, i] == 1) & (!visited[i])) DfsHelper(i);
            }
        }

        private void DfsHelper(int i)
        {
            visited[i] = true;
            Console.WriteLine("Узел {0} посещен", i+begin);
            for (int j = 0; j < vortex; j++)
            {
                if ((adjacent[i, j] == 1) & (!visited[j]))
                {
                    DfsHelper(j);
                }
            }
        }

        public void Bfs()
        {
            Console.WriteLine("Поиск в ширину\n");
            AdjInput(false);
            visited = new bool[vortex];
            visited[0] = true;
            Console.WriteLine("Узел {0} посещен", begin);
            for (int i = 0; i < vortex; i++)
            {
                for (int j = 0; j < vortex; j++)
                {
                    if ((adjacent[i, j] == 1) & (!visited[j]))
                    {
                        visited[j] = true;
                        Console.WriteLine("Узел {0} посещен", j + begin);
                    }
                }
            }
        }

        private void DijkstraOutput()
        {
            Console.WriteLine("Расстояние между вершинами");
            for (int i = 0; i < vortex; i++)
            {
                Console.WriteLine("1 --> {0} = {1}", i + begin, distance[i]);                
            }
        }

        public void Dijkstra()
        {
            Console.WriteLine("Алгоритм Дейкстры\n");
            AdjInput(true);
            distance = new int[vortex];
            visited = new bool[vortex];
            visited[0] = true;
            distance[0] = 0;
            for (int i = 0; i < vortex; i++)
            {
                for (int j = 0; j < vortex; j++)
                {
                    if (adjacent[i, j] != 0)
                    {
                        if (!visited[j])
                        {
                            visited[j] = true;
                            Console.WriteLine("Узел {0} посещен", j + begin);
                            distance[j] = adjacent[i, j] + distance[i];
                        }
                        else
                        {
                            Console.WriteLine("Узел {0} посещен", j + begin);
                            int sum = adjacent[i, j] + distance[i];
                            if (sum < distance[j]) distance[j] = sum;
                        }
                    }
                }
            }
            DijkstraOutput();
        }
    }
}
