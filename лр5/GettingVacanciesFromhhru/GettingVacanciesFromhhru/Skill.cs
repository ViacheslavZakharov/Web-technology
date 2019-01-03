using Newtonsoft.Json;

namespace GettingVacanciesFromhhru
{
    public class Skill
    {
        [JsonProperty("name")]
        public string SkillName { get; set; }
    }
}