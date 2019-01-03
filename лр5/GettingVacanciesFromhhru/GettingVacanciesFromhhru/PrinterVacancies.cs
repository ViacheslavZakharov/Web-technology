using System;
using System.Collections.Generic;
using System.Text;

namespace GettingVacanciesFromhhru
{
    public static class PrinterVacancies
    {
        public static void Print(List<Vacancy> vacancies)
        {
            Console.WriteLine("\t\t\t\tВакансии, зарплата в которых >=120 000 RUB");
            var number = 0;
            foreach (var vacancy in vacancies)
            {
                var salary = ConvertCurrency(vacancy);
                if (salary >= 120000)
                    PrintInformationVacancies(vacancy, ++number,salary);
            }
            Console.WriteLine("\n\t\t\t\tВакансии, зарплата в которых <15 000 RUB\n");
            number = 0;
            foreach (var vacancy in vacancies)
            {
                var salary = ConvertCurrency(vacancy);
                if (salary < 15000)
                    PrintInformationVacancies(vacancy, ++number, salary);
            }
        }

        private static void PrintInformationVacancies(Vacancy vacancy, int number, double salary)
        {
            var skills = new StringBuilder();
            for (int i = 0; i < vacancy.KeySkills.Count; i++)
            {
                skills.Append(vacancy.KeySkills[i].SkillName);
                if (i != vacancy.KeySkills.Count - 1)
                    skills.Append(", ");
            }
            if (skills.Length == 0)
                skills.Append("-");
            Console.WriteLine(string.Format("{0}) {1} |зарплата:{2} {3}| ключевые навыки:{4}",
                                           number, vacancy.Name, salary, vacancy.Salary.Currency, skills.ToString()));
        }

        /// <summary>
        /// Проверяет в какой валюте указана зарплата и переводит в рубли согласно курсу на 03.09.2019
        /// </summary>
        /// <param name="vacancy">проверяемая вакансия</param>
        /// <returns>возвращает переведенную зарплату типа double</returns>
        public static double ConvertCurrency(Vacancy vacancy)
        {
            var currency = vacancy.Salary.Currency;
            if (currency == "EUR")
                return ChangeCurrency(vacancy, 79.46);
            else if (currency == "BYR")
                return ChangeCurrency(vacancy, 32.07);
            else if (currency == "USD")
                return ChangeCurrency(vacancy, 69.47);
            else if (currency == "KZT")
                return ChangeCurrency(vacancy, 0.18);
            else if (currency == "UAH")
                return ChangeCurrency(vacancy, 2.51);
            else
                return ChangeCurrency(vacancy, 1);

        }

        /// <summary>
        /// вспомогательный метод умножающий на соответствующий коэфицент для получения валюты RUB
        /// </summary>
        /// <param name="vacancy"></param>
        /// <param name="koef"></param>
        /// <returns></returns>
        private static double ChangeCurrency(Vacancy vacancy, double koef)
        {
            vacancy.Salary.Currency = "RUB";
            return vacancy.Salary.GetSalary() * koef;
        }
    }
}