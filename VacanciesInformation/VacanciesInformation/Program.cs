using System;

namespace VacanciesInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int salary1 = 100000;
            int salary2 = 20000;
            VacanciesService vacancy = new VacanciesService();
            ServiceData data = vacancy.GetVacancies(salary1, salary2);
            int answer = 0;

            do
            {
                Console.WriteLine("\nКакую информацию вы хотите вывести? Введите число от 1 до 4:");
                Console.WriteLine("\n1. Названия профессий в вакансиях, объявленная зарплата" +
                    "\nкоторых превышает либо равна 100000 рублей;");
                Console.WriteLine("\n2. Названия ключевых навыков в вакансиях, объявленная" +
                    "\nзарплата которых превышает либо равна 100000 рублей;");
                Console.WriteLine("\n3. Названия профессий в вакансиях, объявленная зарплата"
                    + "\nкоторых менее 20000 рублей;");
                Console.WriteLine("\n4. Названия ключевых навыков в вакансиях, объявленная" +
                   "\nзарплата которых менее 20000 рублей.\n");

                int choose = 0;

                do
                {
                    Console.Write("Ваш выбор: ");

                    try
                    {
                        choose = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Неверный тип данных! Попробуйте снова!");

                    }

                    if (!(choose >= 1 && choose <= 4))
                    {
                        Console.WriteLine("Вам нужно ввести число от 1 до 4! Попробуйте снова\n");
                    }
                }
                while (!(choose >= 1 && choose <= 4));

                switch (choose)
                {
                    case 1:
                        foreach (string Vacancy in data.ProfessionsWithFirstSalary)
                        {
                            Console.WriteLine(Vacancy);
                        }
                        break;

                    case 2:
                        foreach (string Vacancy in data.SkillsForSalaryFirstSalary)
                        {
                            Console.WriteLine(Vacancy);
                        }
                        break;

                    case 3:
                        foreach (string Vacancy in data.ProfessionsWithSecondSalary)
                        {
                            Console.WriteLine(Vacancy);
                        }
                        break;

                    case 4:
                        foreach (string Vacancy in data.SkillsForSecondSalary)
                        {
                            Console.WriteLine(Vacancy);
                        }
                        break;
                }

                do
                {
                    Console.WriteLine("\nХотите продолжиить?\n1. Да\n2. Нет");
                    Console.Write("Ваш ответ: ");

                    try
                    {
                        answer = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Неверный тип данных! Попробуйте снова!");

                    }

                    if (!(answer == 1 || answer == 2))
                    {
                        Console.WriteLine("Вам нужно ввести либо 1, либо 2\n");
                    }
                } while (!(answer == 1 || answer == 2));
            } while (answer == 1);

            Console.ReadKey();
        }
    }
}
