using System;
using System.Collections.Generic;
using System.Text;

namespace BuildCompanyModel
{
    public class Shop
    {
        public int L { get; set; }
        protected Random rnd = new Random();
        public Order order { get; set; }

        public Shop(int a, int b)
        {
            L = rnd.Next(a, b);
        }

        public void MakeAnOrder(Order order)
        {
            this.order = order;
        }

        public virtual string CityName()
        {
            return "";
        }
    }
}
