using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_searching
{
    class Graph
    {
        int[,] adjmatrix = new int[5, 5]
            {
                //A
                {0,5,4,0,0 },
                //B 
                {0,0,0,10,0},
                //C
                {0,0,0,0,2 },
                //D
                {0,0,6,0,0 },
                //E
                {0,0,0,0,0 }
            };
       public Dictionary<string, Vertex> dict = new Dictionary<string, Vertex>();
        List<Vertex> li = new List<Vertex>();

        public Graph()
        {
            Vertex A = new Vertex("A");
            Vertex B = new Vertex("B");
            Vertex C = new Vertex("C");
            Vertex D = new Vertex("D");
            Vertex E = new Vertex("E");
            





            dict.Add("A", A);
            dict.Add("B", B);
            dict.Add("C", C);
            dict.Add("D", D);
            dict.Add("E", E);
            

            li.Add(A);
            li.Add(B);
            li.Add(C);
            li.Add(D);
            li.Add(E);
            

        }
        public void ShortestPath(string a)
        { 
            Reset();
        li[0].Permanent = true;
            li[0].Totaldistance = 0;
            Vertex current;

            int number = 0;
            current = li[number];
           // current.Permanent = true;
            //current.Totaldistance = 0;
            bool loop = true;
            Vertex possible = null;
            int next;
            int line = li.IndexOf(current);
            while (loop)

            {
                current = li[number];

                //this checks for any nonpermanet
                for (int i = 0; i < li.Count; i++)
                {
                    if (li[i].Permanent)
                    {
                        loop = false;
                    }
                    else
                    {
                        loop = true;
                        break;
                    }
                }


                for (int i = 0; i < li.Count; i++)
                {
                    if (adjmatrix[line, i]!=0 && li[i].Permanent==false)
                    {
                        
                            if (li[i].Totaldistance == int.MaxValue)
                            {
                                li[i].Permanent = true;
                                li[i].Nearest = current;
                                li[i].Totaldistance = adjmatrix[line, i];
                                Console.WriteLine("This node " + li[i].Name + " nearest " + li[i].Nearest.Name + " total d " + li[i].Totaldistance);
                            }
                            else
                            {
                                if (current.Totaldistance <= li[i].Totaldistance)
                                {
                                    li[i].Nearest = current;
                                    li[i].Totaldistance = adjmatrix[line, i];
                                    Console.WriteLine(" AAAAA This node " + li[i].Name + " nearest " + li[i].Nearest.Name + " total d " + li[i].Totaldistance);
                                }

                            
                        }
                    }
                    else { }
                }
                
                if (number < li.Count)
                {
                    number++;
                    line++;
                }
               
                 next = int.MaxValue;
              /*  for (int i = 0; i < adjmatrix.GetLongLength(line)-1; i++)
                {
                    

                    if (li[i].Totaldistance< next)
                    {
                        possible = li[i];
                    }


                }
               dict[possible.Name].Permanent = true;
                li[li.IndexOf(dict[possible.Name])].Permanent = true;
                current = dict[possible.Name];

                

    */
            }//end of loop

        }

        public void Reset()
        {
            for(int i = 0; i < li.Count; i++)
            {
                li[i].Visited = false;
                li[i].reset();
            }

        }


       public  Vertex GetUnvisitedNeighbor(string name)
        {
            try {
                Vertex test = dict[name];
                int line = li.IndexOf(test);

                for (int i = 0; i < adjmatrix.GetLongLength(line); i++)
                {
                    if (adjmatrix[line, i] >0)
                    {
                        if (li[i].Visited == false)
                        {
                            return li[i];
                        }
                    }
                }


              
            }
            catch(Exception e)
            {
                Console.WriteLine("getting visited neighbor error " + e.Message);
            }
            return null;
        }




        public void DepthFirst(string name)
        {
            bool loop = true;
            Stack<Vertex> stacking=new Stack<Vertex>();

            try {
                Vertex test = dict[name];
                int line = li.IndexOf(test);

                Reset();

            Console.WriteLine(test.Name);
                stacking.Push(test);
                test.Visited = true;

                while (loop)
                {
                    test = GetUnvisitedNeighbor(stacking.Peek().Name);
                    if (test == null)
                    {
                        stacking.Pop();
                    }
                    else
                    {
                        Console.WriteLine(test.Name);
                        stacking.Push(test);
                        test.Visited = true;
                    }

                    if (stacking.Count == 0)
                    {
                        loop = false;
                    }

                }


 }
           catch(Exception e)
            {
                Console.WriteLine("ERROR,ERROR,ERROR "+e.Message);

            }
        }


    }
}
