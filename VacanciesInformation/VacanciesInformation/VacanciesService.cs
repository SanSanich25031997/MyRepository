using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace VacanciesInformation
{
    public class VacanciesService
    {
        private const int FirstPage = 0;
        private const int PerPage = 100;
        private const string ApiHost = "https://api.hh.ru";
        private readonly IRestClient Client = new RestClient(ApiHost);
        private const string ApiResource = "/vacancies";
        private const string UserAgent = "HhGetVacanciesService";
        private const string DetailsQueryFormat = "{0}/{1}";
        private const string QueryFormat = "{0}?page={1}&per_page={2}";

        public IRestResponse VacanciesRequest(int page)
        {
            IRestRequest request = new RestRequest(string.Format(QueryFormat, ApiResource, page, PerPage), Method.GET);
            request.AddParameter("only_with_salary", "true");
            request.AddHeader("User-Agent", UserAgent);
            return Client.Execute(request);
        }

        public IRestResponse VacancyDetailsRequest(string id)
        {
            IRestRequest request = new RestRequest(string.Format(DetailsQueryFormat, ApiResource, id), Method.GET);
            request.AddHeader("User-Agent", UserAgent);
            return Client.Execute(request);
        }

        public ServiceData GetVacancies(int firstSalary, int secondSalary)
        {
            ServiceData data = new ServiceData(firstSalary, secondSalary);
            IRestResponse response = VacanciesRequest(FirstPage);
            int pagesCount = (int)JObject.Parse(response.Content)["pages"];
            JArray vacancies = JObject.Parse(response.Content)["items"] as JArray;

            for (int i = FirstPage; i < pagesCount; i++)
            {
                foreach (JToken vacancy in vacancies)
                {
                    if (vacancy["salary"].Type == JTokenType.Null) continue;

                    double salary = 0.00;
                    JToken salaryFrom = vacancy["salary"]["from"];
                    JToken salaryTo = vacancy["salary"]["to"];
                    JTokenType salaryFromType = salaryFrom.Type;
                    JTokenType salaryToType = salaryTo.Type;
                    JToken salaryCurrency = vacancy["salary"]["currency"];

                    if ((string)salaryCurrency != "RUR")
                    {
                        continue;
                    }
                    else if (salaryFromType != JTokenType.Null && salaryToType != JTokenType.Null)
                    {
                        salary = ((double)salaryFrom + (double)salaryTo) / 2;
                    }
                    else if (salaryFromType == JTokenType.Null && salaryToType != JTokenType.Null)
                    {
                        salary = (double)salaryTo;
                    }
                    else if (salaryFromType != JTokenType.Null && salaryToType == JTokenType.Null)
                    {
                        salary = (double)salaryFrom;
                    }


                    if (salary >= firstSalary)
                    {
                        List<string> vacanciesList = new List<string>();
                        vacanciesList.Add((string)vacancy["name"]);
                        List<string> uniqueVacanciesList = RemoveDuplicates(vacanciesList);

                        foreach (string item in uniqueVacanciesList)
                        {
                            data.ProfessionsWithFirstSalary.Add(item);
                        }

                        JToken details = JObject.Parse(VacancyDetailsRequest((string)vacancy["id"]).Content);
                        JArray skills = details["key_skills"] as JArray;

                        List<string> skillsList = new List<string>();

                        if (skills.HasValues)
                        {
                            foreach (JToken skill in skills)
                            {
                                skillsList.Add((string)skill["name"]);
                            }

                            List<string> uniqueSkillsList = RemoveDuplicates(skillsList);

                            foreach (string item in uniqueSkillsList)
                            {
                                data.SkillsForSalaryFirstSalary.Add(item);
                            }
                        }
                    }

                    else if (salary > 0 && salary < secondSalary)
                    {
                        List<string> vacanciesList = new List<string>();
                        vacanciesList.Add((string)vacancy["name"]);
                        List<string> uniqueVacanciesList = RemoveDuplicates(vacanciesList);

                        foreach (string item in uniqueVacanciesList)
                        {
                            data.ProfessionsWithFirstSalary.Add(item);
                        }

                        JToken details = JObject.Parse(VacancyDetailsRequest((string)vacancy["id"]).Content);
                        JArray skills = details["key_skills"] as JArray;

                        List<string> skillsList = new List<string>();

                        if (skills.HasValues)
                        {
                            foreach (JToken skill in skills)
                            {
                                skillsList.Add((string)skill["name"]);
                            }

                            List<string> uniqueSkillsList = RemoveDuplicates(skillsList);

                            foreach (string item in uniqueSkillsList)
                            {
                                data.SkillsForSecondSalary.Add(item);
                            }
                        }
                    }
                }

                response = VacanciesRequest(FirstPage + i + 1);
                vacancies = JObject.Parse(response.Content)["items"] as JArray;
            }

            return data;
        }

        public static List<string> RemoveDuplicates(List<string> items)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < items.Count; i++)
            {
                bool duplicate = false;

                for (int z = 0; z < i; z++)
                {
                    if (items[z] == items[i])
                    {
                        duplicate = true;
                        break;
                    }
                }

                if (!duplicate)
                {
                    result.Add(items[i]);
                }
            }

            return result;
        }
    }
}
