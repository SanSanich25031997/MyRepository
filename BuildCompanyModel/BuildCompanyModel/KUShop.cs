using System;
using System.Collections.Generic;
using System.Text;

namespace BuildCompanyModel
{
    public class KUShop : Shop
    {
        public KUShop(int a = 135, int b = 145) : base(a, b) { }

        public override string CityName()
        {
            return "Каменск-Уральский";
        }
    }
}
