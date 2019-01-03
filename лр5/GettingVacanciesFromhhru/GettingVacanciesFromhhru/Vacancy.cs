using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace GettingVacanciesFromhhru
{
    public class Vacancy
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("salary")]
        public Salary Salary { get; set; }
        [JsonProperty("key_skills")]
        public List<Skill> KeySkills { get; set; }

        public override string ToString()
        {
            var skills = new StringBuilder();
            for (int i = 0; i < KeySkills.Count; i++)
            {
                skills.Append(KeySkills[i].SkillName);
                if (i != KeySkills.Count - 1)
                    skills.Append(", ");
            }
            if (skills.Length == 0)
                skills.Append("-");
            return string.Format("{0} |зарплата:{1} {2}| ключевые навыки:{3}",
                                           Name,Salary.GetSalary(), Salary.Currency, skills.ToString());
        }
    }
}