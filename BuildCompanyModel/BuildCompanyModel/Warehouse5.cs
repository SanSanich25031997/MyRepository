using System;
using System.Collections.Generic;
using System.Text;

namespace BuildCompanyModel
{
    public class Warehouse5 : Warehouse
    {
        public Warehouse5(int lightEuropalletMass)
        {
            quantity = lightEuropalletMass;
        }

        public override void Add(int lightEuropalletMassToAdd)
        {
            quantity += lightEuropalletMassToAdd;
        }

        public override void Subtract(int lightEuropalletMassToSubtract)
        {
            if (quantity - lightEuropalletMassToSubtract >= 0)
                quantity -= lightEuropalletMassToSubtract;
            else
                Console.WriteLine("Недостаточно листов на складе!");
        }
    }
}
