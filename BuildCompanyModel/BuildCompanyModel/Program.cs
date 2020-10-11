using System;
using System.Collections.Generic;

namespace BuildCompanyModel
{
    class Program
    {
        static string[] possibleLoadingVariants = {"Тяжелый негабарит и Легкий европалет не больше 100 кг",
            "Тяжелый негабарит и Европалета не больше 200 кг",
            "Европалета не больше 200 кг и Легкий европалет не больше 100 кг",
            "Сантехника не больше 2 ванн и Европалета не больше 200 кг",
            "Сантехника не больше 2 ванн и Легкий европалет не больше 100 кг",
            "Легкий европалет не больше 100 кг",
            "Европалета не больше 200 кг",
            "Тяжелый негабарит, Сантехника не больше 2 ванн и Европалета не больше 200 кг",
            "Тяжелый негабарит, Сантехника не больше 2 ванн и Легкий европалет не больше 100 кг"};

        static void Main(string[] args)
        {
            Simulation();

            Console.ReadKey();
        }

        public static void Simulation()
        {
            Random rnd = new Random();
            const int N = 20;

            int dayAverageVelocity = 40;
            int dayPaymentPerHour = 800;
            int nightAverageVelocity = 55;
            int nightPaymentPerHour = 1000;

            List<Shop> shops = new List<Shop>();
            ShopListFilling(ref shops);

            for (int i = 0; i < shops.Count; i++)
                shops[i].MakeAnOrder(new Order());

            Driver[] drivers = new Driver[N];
            Dictionary<int, bool> isDayDriverBusy = new Dictionary<int, bool>();
            Dictionary<int, bool> isNightDriverBusy = new Dictionary<int, bool>();

            int dayWorkersCount = 0;
            int nightWorkersCount = 0;

            for (int i = 0; i < drivers.Length; i++)
            {
                if (i % 2 == 0)
                {
                    drivers[i] = new Driver(true);
                    isDayDriverBusy[i] = false;
                    dayWorkersCount++;
                }
                else
                {
                    drivers[i] = new Driver(false);
                    isNightDriverBusy[i] = false;
                    nightWorkersCount++;
                }
            }

            Car[] cars = new Car[N];
            for (int i = 0; i < cars.Length; i++)
                cars[i] = new Car();

            List<Warehouse> warehouses = new List<Warehouse>();
            WarehouseListFilling(ref warehouses);

            Dictionary<int, int> driverOrderDictionary = new Dictionary<int, int>();
            for (int i = 0; i < N; i++)
                driverOrderDictionary[i] = -1;

            Dictionary<int, int> driverCompletitionTime = new Dictionary<int, int>();
            for (int i = 0; i < N; i++)
                driverCompletitionTime[i] = 0;

            Dictionary<int, int> driverWorkTime = new Dictionary<int, int>();
            for (int i = 0; i < N; i++)
                driverWorkTime[i] = 0;

            Dictionary<int, int> completedOrders = new Dictionary<int, int>();
            for (int i = 0; i < N; i++)
                completedOrders[i] = 0;

            Dictionary<int, int> carLoadedTime = new Dictionary<int, int>();
            for (int i = 0; i < N; i++)
                carLoadedTime[i] = 0;

            int tKamaz = rnd.Next(1, 166);

            int shopIndex = 0;
            int driverIndex = 0;

            int allOrdersCount = 0;
            int completedOrdersCount = 0;

            for (int t = 1; t <= 168; t++)
            {
                if (t == tKamaz)
                {
                    Console.WriteLine();
                    Console.WriteLine("{0}-й час недели", t);
                    Console.WriteLine("Камаз выгружает товар!");
                    for (int i = 0; i < warehouses.Count; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                warehouses[i].Add(rnd.Next(1000, 2000));
                                break;
                            case 1:
                                warehouses[i].Add(rnd.Next(1000, 2000));
                                break;
                            case 2:
                                warehouses[i].Add(rnd.Next(200, 500));
                                break;
                            case 3:
                                warehouses[i].Add(rnd.Next(5000, 10000));
                                break;
                            case 4:
                                warehouses[i].Add(rnd.Next(3000, 5000));
                                break;
                        }
                    }
                    t += 3;
                }

                Console.WriteLine();
                Console.WriteLine("{0}-й час недели", t);

                if (t % 24 >= 8 && t % 24 < 20)
                {
                    int busyDriversCount = 0;
                    for (int i = 0; i < drivers.Length; i += 2)
                        if (isDayDriverBusy[i] == true)
                            busyDriversCount++;

                    if (busyDriversCount < isDayDriverBusy.Count - 1)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            do
                            {
                                shopIndex = rnd.Next(0, N);
                                driverIndex = rnd.Next(0, dayWorkersCount) * 2;

                                if (!shops[shopIndex].order.isAccepted && !drivers[driverIndex].isBusy)
                                {
                                    drivers[driverIndex].GetAnOrder(shops[shopIndex].
                                    order);
                                    allOrdersCount++;
                                }

                            } while (shops[shopIndex].order.isAccepted == false);

                            isDayDriverBusy[driverIndex] = true;
                            driverOrderDictionary[driverIndex] = shopIndex;
                            Console.WriteLine("{0}-й водитель получает заказ", driverIndex + 1);
                            Console.WriteLine("Состав заказа: {0}", possibleLoadingVariants[rnd.Next(0,
                            possibleLoadingVariants.Length)]);
                            Console.WriteLine("Город: {0}", shops[shopIndex].CityName());
                            Console.WriteLine();

                            if (!cars[driverIndex].isLoad)
                            {
                                int warehouseNumber = rnd.Next(0, 2);

                                for (; warehouseNumber < warehouses.Count; warehouseNumber++)
                                {
                                    if (warehouseNumber == 0)
                                    {
                                        warehouses[warehouseNumber].Subtract(shops
                                        [shopIndex].order.order[warehouseNumber].quantityChoosed);
                                        warehouseNumber++;
                                    }
                                    else
                                        warehouses[warehouseNumber].Subtract(shops
                                        [shopIndex].order.order[warehouseNumber - 1].
                                        quantityChoosed);
                                }
                                cars[driverIndex].isLoad = true;
                                driverCompletitionTime[driverIndex] = t + 1 + Convert.ToInt32(Math.Ceiling((double)shops[shopIndex].L
                                / dayAverageVelocity)) * 2 + 1;
                                driverWorkTime[driverIndex] += 1 + Convert.ToInt32(Math.Ceiling((double)shops[shopIndex].L
                                / dayAverageVelocity)) * 2 + 1;
                                carLoadedTime[driverIndex] += 1 + Convert.ToInt32(Math.Ceiling((double)shops[shopIndex].L
                                / dayAverageVelocity)) + 1;
                            }
                        }
                    }

                    for (int i = 0; i < drivers.Length; i += 2)
                    {
                        if (t >= driverCompletitionTime[i])
                        {
                            if (drivers[i].isBusy == true)
                            {
                                completedOrdersCount++;
                                completedOrders[i]++;
                                drivers[i].isBusy = false;
                                cars[i].isLoad = false;
                                shops[driverOrderDictionary[i]].order.isAccepted = false;
                                isDayDriverBusy[i] = false;
                                Console.WriteLine("{0}-й водитель закончил заказ", i + 1);
                            }
                        }
                    }
                }

                else
                {
                    int busyDriversCount = 0;
                    for (int i = 1; i < drivers.Length; i += 2)
                        if (isNightDriverBusy[i] == true)
                            busyDriversCount++;

                    if (busyDriversCount < isNightDriverBusy.Count - 1)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            do
                            {
                                shopIndex = rnd.Next(0, N);
                                driverIndex = rnd.Next(0, nightWorkersCount) * 2 + 1;

                                if (!shops[shopIndex].order.isAccepted && !drivers[driverIndex].isBusy)
                                {
                                    drivers[driverIndex].GetAnOrder(shops[shopIndex].
                                    order);
                                    allOrdersCount++;
                                }

                            } while (shops[shopIndex].order.isAccepted == false);

                            isNightDriverBusy[driverIndex] = true;
                            driverOrderDictionary[driverIndex] = shopIndex;
                            Console.WriteLine("{0}-й водитель получает заказ", driverIndex + 1);
                            Console.WriteLine("Состав заказа: {0}", possibleLoadingVariants[rnd.Next(0, possibleLoadingVariants.Length)]);
                            Console.WriteLine("Город: {0}", shops[shopIndex].CityName());
                            Console.WriteLine();

                            if (!cars[driverIndex].isLoad)
                            {
                                int warehouseNumber = rnd.Next(0, 2);

                                for (; warehouseNumber < warehouses.Count; warehouseNumber++)
                                {
                                    if (warehouseNumber == 0)
                                    {
                                        warehouses[warehouseNumber].Subtract(shops
                                        [shopIndex].order.order[warehouseNumber].quantityChoosed);
                                        warehouseNumber++;
                                    }
                                    else
                                        warehouses[warehouseNumber].Subtract(shops
                                        [shopIndex].order.order[warehouseNumber - 1].quantityChoosed);
                                }
                                cars[driverIndex].isLoad = true;
                                driverCompletitionTime[driverIndex] = t + 1 + Convert.ToInt32(Math.Ceiling((double)shops[shopIndex].L
                                / nightAverageVelocity)) * 2 + 1;
                                driverWorkTime[driverIndex] += 1 + Convert.ToInt32(Math.Ceiling((double)shops[shopIndex].L
                                / nightAverageVelocity)) * 2 + 1;
                                carLoadedTime[driverIndex] += 1 + Convert.ToInt32(Math.Ceiling((double)shops[shopIndex].L
                                 / dayAverageVelocity)) + 1;
                            }
                        }
                    }

                    for (int i = 1; i < drivers.Length; i += 2)
                    {
                        if (t >= driverCompletitionTime[i])
                        {
                            if (drivers[i].isBusy == true)
                            {
                                completedOrdersCount++;
                                completedOrders[i]++;
                                drivers[i].isBusy = false;
                                cars[i].isLoad = false;
                                shops[driverOrderDictionary[i]].order.isAccepted = false;
                                isNightDriverBusy[i] = false;
                                Console.WriteLine("{0}-й водитель закончил заказ", i + 1);
                            }
                        }
                    }
                }
            }

            int totalPayment = 0;
            int totalDayPayment = 0;
            int totalNightPayment = 0;

            Console.WriteLine();
            for (int i = 0; i < driverWorkTime.Count; i++)
            {
                totalPayment += driverWorkTime[i] * dayPaymentPerHour;
                if (i % 2 == 0)
                {
                    totalDayPayment += driverWorkTime[i] * dayPaymentPerHour;
                    Console.WriteLine("{0}-й водитель заработал за неделю {1} рублей", i + 1, driverWorkTime[i] * dayPaymentPerHour);
                }
                else
                {
                    totalNightPayment += driverWorkTime[i] * nightPaymentPerHour;
                    Console.WriteLine("{0}-й водитель заработал за неделю {1} рублей", i + 1, driverWorkTime[i] * nightPaymentPerHour);
                }
            }

            Console.WriteLine();
            for (int i = 0; i < completedOrders.Count; i++)
            {
                if (i % 2 == 0)
                    Console.WriteLine("{0}-ый водитель выполнил за неделю {1} заказов", i + 1, completedOrders[i]);
                else
                    Console.WriteLine("{0}-ый водитель выполнил за неделю {1} заказов", i + 1, completedOrders[i]);
            }

            double totalLoadedTime = 0;
            Console.WriteLine();
            for (int i = 0; i < carLoadedTime.Count; i++)
            {
                totalLoadedTime += (double)carLoadedTime[i] / 168 * 100;
                Console.WriteLine("Загруженность {0}-го грузовика за неделю составляет {1:0.00}%", i + 1, (double)carLoadedTime[i] / 168 * 100);
            }

            Console.WriteLine();
            Console.WriteLine("Процент выполненных заданий составляет {0:0.00}%", (double)completedOrdersCount / allOrdersCount * 100);
            Console.WriteLine("Средняя загрузка одного грузовика составляет {0:0.00}%", totalLoadedTime / carLoadedTime.Count);
            Console.WriteLine("Суммарный заработок водителей составляет {0:0.00} рублей", totalPayment);
            Console.WriteLine("Средний заработок в дневную смену составляет {0:0.00} рублей", (double)totalDayPayment / dayWorkersCount);
            Console.WriteLine("Средний заработок в ночную смену составляет {0:0.00} рублей", (double)totalNightPayment / nightWorkersCount);
        }

        public static void ShopListFilling(ref List<Shop> shops)
        {
            const int EShopCount = 7;
            const int KUShopCount = 4;
            const int NTShopCount = 5;
            const int ESShopCount = 4;
            for (int i = 0; i < EShopCount; i++)
                shops.Add(new EShop());
            for (int i = 0; i < KUShopCount; i++)
                shops.Add(new KUShop());
            for (int i = 0; i < NTShopCount; i++)
                shops.Add(new NTShop());
            for (int i = 0; i < ESShopCount; i++)
                shops.Add(new ESShop());
        }

        public static void WarehouseListFilling(ref List<Warehouse> warehouses)
        {
            warehouses.Add(new Warehouse1(2000));
            warehouses.Add(new Warehouse2(2000));
            warehouses.Add(new Warehouse3(600));
            warehouses.Add(new Warehouse4(40000));
            warehouses.Add(new Warehouse5(20000));
        }

    }
}
