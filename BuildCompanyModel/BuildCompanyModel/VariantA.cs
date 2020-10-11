using System;
using System.Collections.Generic;
using System.Text;

namespace BuildCompanyModel
{
    public class VariantA : Variant
    {
        public VariantA()
        {
            quantityChoosed = rnd.Next(1, 9);
        }
    }
}
