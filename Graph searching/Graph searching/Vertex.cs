using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_searching
{
    class Vertex
    {
        String name;
        bool visited;
        int totaldistance;
        Vertex nearest;
        bool permanent;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public bool Visited
        {
            get
            {
                return visited;
            }

            set
            {
                visited = value;
            }
        }

        public int Totaldistance
        {
            get
            {
                return totaldistance;
            }

            set
            {
                totaldistance = value;
            }
        }

        public Vertex Nearest
        {
            get
            {
                return nearest;
            }

            set
            {
                nearest = value;
            }
        }

        public bool Permanent
        {
            get
            {
                return permanent;
            }

            set
            {
                permanent = value;
            }
        }

        public Vertex(string n)
        {
            name = n;
            visited = false;
        }

        public void  reset()
        {
            Totaldistance = int.MaxValue;
            Nearest = null;
            Permanent = false;
        }



    }
}
