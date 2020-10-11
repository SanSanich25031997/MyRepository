using System;
using System.Collections.Generic;
using System.Text;

namespace BuildCompanyModel
{
    public class NTShop : Shop
    {
        public NTShop(int a = 140, int b = 150) : base(a, b) { }

        public override string CityName()
        {
            return "Нижний Тагил";
        }
    }
}
