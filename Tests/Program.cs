using System;
using SoftwareConstructing.Main;

namespace Tests
{
    class Program
    {
        static MatrixGraph graph;
        static void Main(string[] args)
        {
            checkCreteAndAccess();
            checkSetAndGetStribgFlag();
            checkSetAllStribgFlags();
        }

        static void checkCreteAndAccess()
        {
            graph = new MatrixGraph(9);
            int a = graph[8, 8];
            Console.WriteLine("checkCreteAndAccess() passed");
        }

        static void checkSetAndGetStribgFlag()
        {
            graph = new MatrixGraph(9);
            graph.SetStringFlag(5, "visited");
            check(graph.GetStringFlag(5) == "visited", "flag not match");
            Console.WriteLine("checkSetAndGetStribgFlag() passed");
        }

        static void checkSetAllStribgFlags()
        {
            graph = new MatrixGraph(5);
            graph.SetAllStringFlags("visited");
            check(graph.GetStringFlag(0) == "visited", "flag not match");
            Console.WriteLine("checkSetAllStribgFlags() 1 passed");
            check(graph.GetStringFlag(1) == "visited", "flag not match");
            Console.WriteLine("checkSetAllStribgFlags() 2 passed");
            check(graph.GetStringFlag(2) == "visited", "flag not match");
            Console.WriteLine("checkSetAllStribgFlags() 3 passed");
            check(graph.GetStringFlag(3) == "visited", "flag not match");
            Console.WriteLine("checkSetAllStribgFlags() 4 passed");
            check(graph.GetStringFlag(4) == "visited", "flag not match");
            Console.WriteLine("checkSetAllStribgFlags() 5 passed");
        }


        static void check(bool expression, String message)
        {
            if (!expression)
            {
                throw new Exception(message);
            }
        }

    }
}
