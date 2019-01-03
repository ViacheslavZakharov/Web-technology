using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace GettingVacanciesFromhhru
{
    class GetterVacancies
    {
        public RestClient client { get; set; }
        public List<Vacancy> listVacancies;
        public readonly int maxNumberVacancies;
        public readonly int maxNumberVacanciesOnOnePage;
        private int numberPage;

        /// <summary>
        /// конструктор, принимающий имя Web-api
        /// </summary>
        /// <param name="host">название сервиса</param>
        /// <param name="maxNumberVacancies">макс. кол-во вакансий возвращаемое сервисом</param>
        /// <param name="maxNumberVacanciesOnOnePage">макс. кол-во вакансий на одной странице</param>
        public GetterVacancies(string host, int maxNumberVacancies, int maxNumberVacanciesOnOnePage)
        {
            client=new RestClient(host);
            listVacancies = new List<Vacancy>();
            this.maxNumberVacancies = maxNumberVacancies;
            this.maxNumberVacanciesOnOnePage = maxNumberVacanciesOnOnePage;
            numberPage = maxNumberVacancies / maxNumberVacanciesOnOnePage;
        }

        public List<Vacancy> GetVacancies()
        {
            for(int page=0;page<numberPage;page++)
            {
                var requestVacanciesOnPage = new RestRequest(string.Format("vacancies?per_page={0}&page={1}",
                                                                maxNumberVacanciesOnOnePage, page), Method.GET);
                var responseVacanciesOnPage = client.Execute(requestVacanciesOnPage);
                if(responseVacanciesOnPage.StatusCode==HttpStatusCode.OK)
                {
                    var listVacanciesJson = (JArray)JToken.Parse(responseVacanciesOnPage.Content)["items"];
                    foreach(var vacancy in listVacanciesJson)
                    {
                        var requestVacancy = new RestRequest(string.Format("vacancies/{0}",
                                                            vacancy["id"].ToString()),Method.GET);
                        var responseVacancy = client.Execute(requestVacancy);
                        if(responseVacancy.StatusCode==HttpStatusCode.OK)
                        {
                            var vacancyDeserialized = Deserialize(responseVacancy.Content);
                            if (vacancyDeserialized != null)
                                listVacancies.Add(vacancyDeserialized);
                        }
                    }
                }
            }
            return listVacancies;
            //throw new NotImplementedException();
        }

        public Vacancy Deserialize(string jsonString)
        {
            var vacancyDeserialized = JsonConvert.DeserializeObject<Vacancy>(jsonString);
            //если зарплата не указана то возвращам null
            return vacancyDeserialized.Salary == null ? null : vacancyDeserialized;
        }
    }
}
