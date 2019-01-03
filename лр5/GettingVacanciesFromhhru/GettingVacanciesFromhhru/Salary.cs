using Newtonsoft.Json;
using System;

namespace GettingVacanciesFromhhru
{
    public class Salary
    {
        [JsonProperty("from")]
        public string SalaryFrom { get; set; }
        [JsonProperty("to")]
        public string SalaryTo { get; set; }

        [JsonProperty("currency")]
        public string Currency {get; set;}

        /// <summary>
        /// конструктор с тремя аргументами
        /// </summary>
        /// <param name="salaryFrom">нижняя граница вилки оклада</param>
        /// <param name="salaryTo">верхняя граница вилки оклада</param>
        /// <param name="currency">валюта</param>
        public Salary(string salaryFrom,string salaryTo,string currency)
        {
            SalaryFrom = salaryFrom;
            SalaryTo = salaryTo;
            Currency = currency;
        }

        /// <summary>
        /// проверяет указана ли у вакансии зарплата
        /// </summary>
        /// <returns></returns>
        public bool CheckSalary()
        {
            return SalaryFrom!=string.Empty && SalaryTo!=string.Empty;
        }

        public double GetSalary()
        {
            if (SalaryFrom != null && SalaryTo != null)
                return (ParseFromStringToDouble(SalaryFrom) + ParseFromStringToDouble(SalaryTo)) / 2;
            else if (SalaryFrom != null)
                return ParseFromStringToDouble(SalaryFrom);
            else
                return ParseFromStringToDouble(SalaryTo);
        }

        private double ParseFromStringToDouble(string salary)
        {
            try
            {
               return double.Parse(salary);
            }
            catch(InvalidCastException)
            {
                Console.WriteLine("Не удалось преобразовать string в double");
                return new double();
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", GetSalary().ToString(),Currency);
        }
    }
}