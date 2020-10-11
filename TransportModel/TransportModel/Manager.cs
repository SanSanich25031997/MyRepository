using System.Collections.Generic;

namespace TransportModel
{
    public class Manager
    {
        public List<Order> orders { get; set; }
        public List<Suggestion> suggestions { get; set; }
        public static int TProc = 1;
        public Suggestion optimalSuggestion { get; set; }
        public int suggestionIndex { get; set; }

        public Manager()
        {
            orders = new List<Order>();           
        }

        public void DeclaraAnOrder(Order order)
        {
            orders.Add(order);
        }

        public void GetSuggestions(List<Suggestion> suggestions)
        {
            this.suggestions = suggestions;
        }

        public void ChooseOptimalSuggestion()
        {
            if (suggestions.Count != 0)
            {
                optimalSuggestion = new Suggestion(1000, 1000);

                for (int i = 0; i < suggestions.Count; i++)
                    if (suggestions[i].S < optimalSuggestion.S && suggestions[i].S != 0.00)
                    {
                        optimalSuggestion = suggestions[i];
                        suggestionIndex = i;
                    }
            }
        }

        public void AssignTheTask(Carrier[] carrier)
        {
            carrier[suggestionIndex].IsBusy = true;
        }

        public string GetCompletitionMessage()
        {
            return "Задание выполнено";
        }
    }
}
