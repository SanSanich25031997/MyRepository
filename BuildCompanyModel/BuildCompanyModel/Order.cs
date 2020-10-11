using System;
using System.Collections.Generic;
using System.Text;

namespace BuildCompanyModel
{
    public class Order
    {
        public List<Variant> order { get; set; }
        public bool isAccepted { get; set; }

        public Order()
        {
            order = new List<Variant>();
            isAccepted = false;
            order.Add(new VariantA());
            order.Add(new VariantB());
            order.Add(new VariantC());
            order.Add(new VariantD());
        }

    }
}
