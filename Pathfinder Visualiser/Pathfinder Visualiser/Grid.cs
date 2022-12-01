using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace New_Pathfinder
{
    internal class Grid
    {
        public bool isVisited = false;
        public bool isObstacle = false;
        public int distanceFromStart = 1024;
        public Point previousVertex = new Point();
    }

    //internal struct Vec2
    //{
    //    public int x, y;
    //}
}
