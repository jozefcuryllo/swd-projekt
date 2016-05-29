using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja.Helpers {

    static class Similarity {

        public static double levenshtein(List<int> pierwsza, List<int> druga) {
            String a = "";
            String b = "";

            foreach (int p in pierwsza) {
                a += String.Concat(p);
            }

            foreach (int p in druga) {
                b += String.Concat(p);
            }

            double rozmiar = a.Length;


            if (string.IsNullOrEmpty(a)) {
                if (!string.IsNullOrEmpty(b)) {
                    return b.Length;
                }
                return 0.0d;
            }

            if (string.IsNullOrEmpty(b)) {
                if (!string.IsNullOrEmpty(a)) {
                    return a.Length;
                }
                return 0.0d;
            }

            Int32 cost;
            Int32[,] d = new int[a.Length + 1, b.Length + 1];
            Int32 min1;
            Int32 min2;
            Int32 min3;

            for (Int32 i = 0; i <= d.GetUpperBound(0); i += 1) {
                d[i, 0] = i;
            }

            for (Int32 i = 0; i <= d.GetUpperBound(1); i += 1) {
                d[0, i] = i;
            }

            for (Int32 i = 1; i <= d.GetUpperBound(0); i += 1) {
                for (Int32 j = 1; j <= d.GetUpperBound(1); j += 1) {
                    cost = Convert.ToInt32(!(a[i - 1] == b[j - 1]));

                    min1 = d[i - 1, j] + 1;
                    min2 = d[i, j - 1] + 1;
                    min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }

            return d[d.GetUpperBound(0), d.GetUpperBound(1)] / rozmiar;

        }

    }
}
