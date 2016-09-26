using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_searching
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph a = new Graph();
            bool loop = true;
            a.ShortestPath("A");
            //  a.DepthFirst("A");

            while (loop)
            {
                Console.WriteLine("You start at A.\nWhere do you want to go?");
                string go = Console.ReadLine();

                if (go == "quit")
                {
                    loop = false;
                }
                else
                {
                    try
                    {
                        Vertex gping = a.dict[go];
                        bool loop2 = true;
                        Console.WriteLine("The shortest path is: ");
                        while (loop2)
                        {
                            if (gping == a.dict["A"])
                            {
                                loop2 = false;
                            }
                            Console.WriteLine(gping.Name);
                            gping = gping.Nearest;

                        }
                        
                          
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("ERROR " + e.Message);
                    }
                }

            }

        }
    }
}
