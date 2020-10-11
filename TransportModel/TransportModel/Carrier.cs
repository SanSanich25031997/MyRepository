namespace TransportModel
{
    public class Carrier
    {
        public bool IsBusy { get; set; }
        public Order order { get; set; }
        public Suggestion suggestion { get; set; }
        public static int TForm = 3;
        public int TExc { get; set; }
        public bool IsComplete { get; set; }

        public Carrier()
        {
            IsBusy = false;
        }

        public void GetAnOrder(Order order)
        {
            this.order = order;
        }

        public void FormAnOffer()
        {
            suggestion = new Suggestion(order.K, order.L);
        }

        public string SendAnOffer()
        {
            return "Предложение рассмотрено";
        }

        public string GetRejection()
        {
            return "Отказано";
        }

        public string GetConfirmation()
        {
            return "Принято";
        }

        public void ExecuteTask()
        {
            TExc = order.L;
        }

        public void CompletitionReport()
        {
            IsComplete = true;
            IsBusy = false;
        }
    }
}
