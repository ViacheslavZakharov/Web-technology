using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Net;

namespace GettingVacanciesFromhhru
{
    class Program
    {
        static void Main(string[] args)
        {
            var getterVacancies = new GetterVacancies("https://api.hh.ru", 2000, 100);
            Console.Write("Подождите некоторое время, происходит получение вакансий с сервера...");
            var vacancies = getterVacancies.GetVacancies();
            Console.Write("\r");
            if (vacancies != null)
                PrinterVacancies.Print(vacancies);
            else
                Console.WriteLine("Что-то пошло не так, вакансии получить не удалось.");
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }
    }
}
