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
        private static float maximum(float a, float b)
        {
            if (a > b)
            {
                return a;
            }
            else return b;
        }

        private static float minimum(float a, float b) {
            if (a < b)
            {
                return a;
            }
            else return b;
        }

        public static float AND(float a, float b) {

            // Zadeh
            // return minimum(a, b);

            // Hyperbolic Paraboloid
            return a * b;
        }

        public static float OR(float a, float b) {

            // Zadeh
            // return maximum(a, b);

            //Hyperbolic Paraboloid
            return a + b - (a * b);
        }

        public static float NOT(float a) {
            return 1.0f - a;
        }

        public static float XOR(float a, float b) {
            // Zadeh
            // return a + b - 2.0f * (minimum(a, b));

            // Hyperbolic Paraboloid
            return a + b - (2.0f * a * b); 
        }

        public static float IMPLIES(float a, float b) {

            // Zadeh
            // return 1.0f - minimum(a, 1.0f - b);

            // Hyperbolic Paraboloid
            return 1.0f - a + (a * b);
        }

        public static float NAND(float a, float b) {

            // Zadeh
            // return 1.0f - minimum(a, b);

            // Hyperbolic Paraboloid
            return 1.0f - (a * b);
        }

        public static float NOR(float a, float b)
        {

            // Zadeh
            // return 1.0f - maximum(a, b);

            // Hyperbolic Paraboloid
            return 1 - a - b + (a * b);
        }

        public static float NOT_IMPLIES(float a, float b) {

            // Zadeh
            // return minimum(a, 1.0f - b);

            // Hyperbolic Paraboloid
            return a * (1.0f - b);
        }
    }
}
