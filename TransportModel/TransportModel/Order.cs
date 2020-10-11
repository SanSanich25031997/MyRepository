using System;

namespace TransportModel
{
    public class Order
    {
        public int K { get; set; }
        public int L { get; set; }
        private Random rnd { get; set; }

        public Order()
        {
            rnd = new Random();
            K = rnd.Next(100, 501);
            L = rnd.Next(1, 16);
        }
    }
}
