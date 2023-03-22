using HttpClientService;

namespace WebDemo.Pages
{
    public partial class Index
    {
        protected override async Task OnInitializedAsync()
        {
            try
            {

                //string data = "{listProject {  code,  message,  success,  detail,  totalRows,  projects {    id,    title  }},project(projectId: \\\"165901634377634810\\\") {  code,  message,  success,  detail,  id,  title},sla {  code,  message,  success,  id,  detail}}";
                //var result = await httpService.QueryGraphQLAsync("http://localhost:5244/graphql", data, new AuthorizeHeader("bearer", "eyJhbGciOiJSUzI1NiIsImtpZCI6IkQ4RTE5MkQ5NEYwODM3MUJCNjI3QzI0OTEyNTM3NDNDIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE2NzkyOTMyNjcsImV4cCI6MTY3OTI5Njg2NywiaXNzIjoiaHR0cHM6Ly9sb2dpbi5lcnBzdGFjay5sYSIsImF1ZCI6WyJFUlBBZG1pbkNsaWVudF9hcGkiLCJNU1FQX0FQSSJdLCJjbGllbnRfaWQiOiJRVUVVRV9DT05TT0xFX1dFQiIsInN1YiI6Ijk3MzM5ZTZjLWE4NTgtNDU4My1hNGI1LWFhNzgzY2Q3MzEyNSIsImF1dGhfdGltZSI6MTY3OTI5MzI2NywiaWRwIjoibG9jYWwiLCJwcmVmZXJyZWRfdXNlcm5hbWUiOiJtc3FwIiwibmFtZSI6Im1zcXAiLCJpYXQiOjE2NzkyOTMyNjcsInNjb3BlIjpbIkVSUEFkbWluQ2xpZW50X2FwaSIsIk1TUVBfQVBJX1NDT1BFIiwib3BlbmlkIiwicHJvZmlsZSIsIm9mZmxpbmVfYWNjZXNzIl0sImFtciI6WyJwd2QiXX0.H3jWkiFQvG2kGGzroWt8mWoYuVqIpijqKeEnL6jg7BdUgEO0zYPkKanEyAlp6YNU6GpRrlE_-DLnlrQ2ZITrbNaj-BWyZlkm6dW6S-bUKmx9BacIyUWK9r6keP_EF7fTl5ihyZdqxfc1Jyd4eKN4IQUu4WrXPaXg3ByGowp-82XX3bFSjy9TAd4xHz8fOS2n9Pgy8heusVsmHRKxmQaxNRkklO_shIo58dT7sfEL-OsVbUfgZBPsg-qWcx-DN8-rfzoHB8DCtxV45-ePice1UDTivr8ZbQbs1LkjzOrAluKNprmwsfgFzsjcvvU39iCtH8PkI7DyRHyEyyzcK6CGeA"));

                //var pc = await result.GetData<ProjectClass>("listProject");


            }
            catch (Exception)
            {


            }
        }
    }

    public class ProjectClass
    {
        public string code { get; set; }
        public string message { get; set; }
        public bool success { get; set; }
        public string detail { get; set; }
        public int totalRows { get; set; }
        public Project[] projects { get; set; }
    }

    public class Project
    {
        public string id { get; set; }
        public string title { get; set; }
    }

}
