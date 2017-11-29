using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasWpf {
    class Point {

        private double x;
        private double y;

        public Point() {
            this.x = 0.0;
            this.y = 0.0;
        }

        public Point(double x, double y) {
            this.x = x;
            this.y = y;
        }

        public double distance(Point pt) {
            return Math.Sqrt((x - pt.x) * (x - pt.x) + (y - pt.y) * (y - pt.y));
        }

        public double getX() {
            return x;
        }

        public double getY() {
            return y;
        }

    }
}
