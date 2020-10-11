using System;
using System.Collections.Generic;
using System.Text;

namespace BuildCompanyModel
{
    public class VariantC : Variant
    {
        public VariantC()
        {
            quantityChoosed = rnd.Next(101, 201);
        }
    }
}
