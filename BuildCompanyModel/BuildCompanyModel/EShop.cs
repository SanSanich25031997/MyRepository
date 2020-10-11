using System;
using System.Collections.Generic;
using System.Text;

namespace BuildCompanyModel
{
    public class EShop : Shop
    {
        public EShop(int a = 20, int b = 40) : base(a, b) { }

        public override string CityName()
        {
            return "Екатеринбург";
        }
    }
}
