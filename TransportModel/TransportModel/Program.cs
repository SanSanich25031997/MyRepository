using System;
using System.Collections.Generic;

namespace TransportModel
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulation();
            Console.ReadKey();
        }

        static void Simulation()
        {
            Random rnd = new Random();

            Dictionary<int, int> orderData = new Dictionary<int, int>();
            int orderNumber = 0;

            for (int dayNumber = 1; dayNumber <= 366;)
            {
                orderData[orderNumber] = dayNumber;
                orderNumber++;
                dayNumber += rnd.Next(2, 9);
            }

            int orderCount = orderNumber;

            Manager manager = new Manager();
            Order order;

            for (int i = 0; i < orderData.Count; i++)
            {
                order = new Order();
                manager.DeclaraAnOrder(order);
            }

            const int CountOfCarriers = 9;
            Carrier[] carriers = new Carrier[CountOfCarriers];

            for (int i = 0; i < carriers.Length; i++)
                carriers[i] = new Carrier();

            Dictionary<int, int> carriersCompletitionDay = new Dictionary<int, int>();

            Dictionary<int, int> carriersWorkDays = new Dictionary<int, int>();
            for (int i = 0; i < CountOfCarriers; i++)
                carriersWorkDays[i] = 0;

            Dictionary<int, int> carriersCompletedOrders = new Dictionary<int, int>();
            for (int i = 0; i < CountOfCarriers; i++)
                carriersCompletedOrders[i] = 0;

            orderNumber = 0;

            for (int dayNumber = 1; dayNumber <= 366;)
            {
                while (orderNumber < orderCount)
                {
                    if (dayNumber >= orderData[orderNumber])
                    {
                        Console.WriteLine("День поступления заказа № {0} - {1}", orderNumber + 1, orderData[orderNumber]);
                        Console.WriteLine($"День объявления задания менеджером № {rnd.Next(1, 4)} - {dayNumber}");
                        //Console.WriteLine("Время простоя заказа № {0} составляет {1} {2}", orderNumber + 1,
                            //dayNumber - orderData[orderNumber], DeclensionOfDay(dayNumber - orderData[orderNumber]));

                        bool IsFree = true;
                        List<Suggestion> suggestions = new List<Suggestion>();
                        List<int> freeCarriersIndices = new List<int>();
                        List<int> busyCarriersIndices = new List<int>();

                        for (int i = 0; i < CountOfCarriers; i++)
                        {
                            if (carriersCompletitionDay.ContainsKey(i) && carriers[i].IsBusy)
                            {
                                if (dayNumber >= carriersCompletitionDay[i])
                                {
                                    carriers[i].IsBusy = false;
                                    carriersCompletedOrders[i]++;
                                }
                            }

                            if (!carriers[i].IsBusy)
                            {
                                freeCarriersIndices.Add(i);
                                carriers[i].GetAnOrder(manager.orders[orderNumber]);
                                carriers[i].FormAnOffer();
                                suggestions.Add(new Suggestion(manager.orders[orderNumber].K, manager.orders[orderNumber].L));
                                Console.WriteLine("{0}-й перевозчик предлагает {1} за перевозку", i + 1, suggestions[i].S);
                            }
                            else
                            {
                                suggestions.Add(new Suggestion(0, 0));
                                busyCarriersIndices.Add(i);
                            }
                        }

                        if (busyCarriersIndices.Count != CountOfCarriers)
                        {
                            IsFree = false;
                            manager.GetSuggestions(suggestions);
                            dayNumber += Carrier.TForm;
                            manager.ChooseOptimalSuggestion();
                            dayNumber += Manager.TProc;
                            manager.AssignTheTask(carriers);
                            Console.WriteLine("Задание {0} перевозчиком {1}", carriers[manager.suggestionIndex].GetConfirmation().ToLower(), manager.suggestionIndex + 1);
                            carriers[manager.suggestionIndex].ExecuteTask();
                            carriersWorkDays[manager.suggestionIndex] += carriers[manager.suggestionIndex].TExc;
                            carriersCompletitionDay[manager.suggestionIndex] = dayNumber + carriers[manager.suggestionIndex].TExc;
                        }

                        if (!IsFree)
                            orderNumber++;

                        else
                            dayNumber++;

                        Console.WriteLine();
                    }
                    else
                        dayNumber++;
                    if (dayNumber > 366)
                        break;
                }
            }

            Console.WriteLine("Длина очереди равна 0");
            Console.WriteLine();

            for (int i = 0; i < carriersWorkDays.Count; i++)
                Console.WriteLine("{0}-й перевозчик работал в течение года {1} {2}", i + 1, carriersWorkDays[i], DeclensionOfDay(carriersWorkDays[i]));
            Console.WriteLine();

            for (int i = 0; i < carriersCompletedOrders.Count; i++)
                Console.WriteLine("{0}-й перевозчик выполнил за год {1} заказов", i + 1, carriersCompletedOrders[i]);
        }
        

        static string DeclensionOfDay(int dayNumber)
        {
            if (dayNumber % 10 == 1 && dayNumber % 100 != 11)
                return "день";
            else if ((dayNumber % 10 == 2 && dayNumber % 100 != 12) || (dayNumber % 10 == 3 && dayNumber % 100 != 13)
                || (dayNumber % 10 == 4 && dayNumber % 100 != 14))
                return "дня";
            else
                return "дней";
        }
    }
}
