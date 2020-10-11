using System;
using System.Collections.Generic;
using System.Text;

namespace BuildCompanyModel
{
    public class VariantD : Variant
    {
        public VariantD()
        {
            quantityChoosed = rnd.Next(1, 101);
        }
    }
}
