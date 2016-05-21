using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja.Helpers
{
    // https://commons.wikimedia.org/wiki/Fuzzy_operator

    public static class FuzzyLogic
    {
        private static Double maximum(Double a, Double b)
        {
            if (a > b)
            {
                return a;
            }
            else return b;
        }

        private static Double minimum(Double a, Double b) {
            if (a < b)
            {
                return a;
            }
            else return b;
        }

        public static Double AND(Double a, Double b) {

            // Zadeh
            // return minimum(a, b);

            // Hyperbolic Paraboloid
            return a * b;
        }

        public static Double OR(Double a, Double b) {

            // Zadeh
            // return maximum(a, b);

            //Hyperbolic Paraboloid
            return a + b - (a * b);
        }

        public static Double NOT(Double a) {
            return 1.0d - a;
        }

        public static Double XOR(Double a, Double b) {
            // Zadeh
            // return a + b - 2.0.0d * (minimum(a, b));

            // Hyperbolic Paraboloid
            return a + b - (2.0d * a * b); 
        }

        public static Double IMPLIES(Double a, Double b) {

            // Zadeh
            // return 1.0.0d - minimum(a, 1.0.0d - b);

            // Hyperbolic Paraboloid
            return 1.0d - a + (a * b);
        }

        public static Double NAND(Double a, Double b) {

            // Zadeh
            // return 1.0.0d - minimum(a, b);

            // Hyperbolic Paraboloid
            return 1.0d - (a * b);
        }

        public static Double NOR(Double a, Double b)
        {

            // Zadeh
            // return 1.0.0d - maximum(a, b);

            // Hyperbolic Paraboloid
            return 1 - a - b + (a * b);
        }

        public static Double NOT_IMPLIES(Double a, Double b) {

            // Zadeh
            // return minimum(a, 1.0.0d - b);

            // Hyperbolic Paraboloid
            return a * (1.0d - b);
        }
    }
}
