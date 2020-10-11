using System;
using System.Collections.Generic;
using System.Text;

namespace BuildCompanyModel
{
    public class Driver
    {
        public bool isBusy { get; set; }
        public Order order { get; set; }
        public bool isDayShift { get; set; }

        public Driver(bool isDayShift)
        {
            this.isDayShift = isDayShift;
            isBusy = false;
        }

        public void GetAnOrder(Order order)
        {
            isBusy = true;
            order.isAccepted = true;
            this.order = order;
        }

        public void CompleteAnOrder()
        {
            isBusy = false;
        }

    }
}
