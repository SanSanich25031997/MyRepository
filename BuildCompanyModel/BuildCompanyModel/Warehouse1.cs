using System;
using System.Collections.Generic;
using System.Text;

namespace BuildCompanyModel
{
    public class Warehouse1 : Warehouse
    {
        public Warehouse1(int metalSheetCount)
        {
            quantity = metalSheetCount;
        }

        public override void Add(int metalSheetToAdd)
        {
            quantity += metalSheetToAdd;
        }

        public override void Subtract(int metalSheetToSubtract)
        {
            if (quantity - metalSheetToSubtract >= 0)
                quantity -= metalSheetToSubtract;
            else
                Console.WriteLine("Недостаточно листов на складе!");
        }
    }
}
