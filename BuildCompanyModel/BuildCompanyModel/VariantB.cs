using System;
using System.Collections.Generic;
using System.Text;

namespace BuildCompanyModel
{
    public class VariantB : Variant
    {
        public VariantB()
        {
            quantityChoosed = rnd.Next(1, 3);
        }
    }
}
