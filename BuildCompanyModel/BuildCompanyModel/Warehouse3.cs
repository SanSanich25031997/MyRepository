using System;
using System.Collections.Generic;
using System.Text;

namespace BuildCompanyModel
{
    public class Warehouse3 : Warehouse
    {
        public Warehouse3(int bathCount)
        {
            quantity = bathCount;
        }

        public override void Add(int bathToAdd)
        {
            quantity += bathToAdd;
        }

        public override void Subtract(int bathToSubtract)
        {
            if (quantity - bathToSubtract >= 0)
                quantity -= bathToSubtract;
            else
                Console.WriteLine("Недостаточно листов на складе!");
        }
    }
}
