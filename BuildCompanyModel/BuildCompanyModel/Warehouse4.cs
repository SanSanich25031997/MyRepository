using System;
using System.Collections.Generic;
using System.Text;

namespace BuildCompanyModel
{
    public class Warehouse4 : Warehouse
    {
        public Warehouse4(int europalletMass)
        {
            quantity = europalletMass;
        }

        public override void Add(int europalletMassToAdd)
        {
            quantity += europalletMassToAdd;
        }

        public override void Subtract(int europalletMassToSubtract)
        {
            if (quantity - europalletMassToSubtract >= 0)
                quantity -= europalletMassToSubtract;
            else
                Console.WriteLine("Недостаточно листов на складе!");
        }
    }
}
