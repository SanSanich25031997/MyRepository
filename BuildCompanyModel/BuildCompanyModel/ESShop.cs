using System;
using System.Collections.Generic;
using System.Text;

namespace BuildCompanyModel
{
    public class ESShop : Shop
    {
        public ESShop(int a = 20, int b = 40) : base(a, b) { }

        public override string CityName()
        {
            return "Город-спутник Екатернибурга";
        }
    }
}
