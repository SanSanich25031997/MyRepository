using System;

namespace TransportModel
{
    public class Suggestion
    {
        public double S { get; set; }
        public int suggestionIndex { get; set; }
        private Random rnd = new Random();

        public Suggestion(int K, int L)
        {
            S = Math.Round(0.8 * K * L + (rnd.NextDouble() * 0.4) * K * L, 2);
        }
    }
}
