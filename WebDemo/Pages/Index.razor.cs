using HttpClientService;

namespace WebDemo.Pages
{
    public partial class Index
    {
        protected override async Task OnInitializedAsync()
        {
            try
            {

                string data = "{listProject {  code,  message,  success,  detail,  totalRows,  projects {    id,    title  }},project(projectId: \\\"165901634377634810\\\") {  code,  message,  success,  detail,  id,  title},sla {  code,  message,  success,  id,  detail}}";
                var result = await httpService.QueryGraphQLAsync("http://localhost:5244/graphql", data, new AuthorizeHeader("bearer", ""));

                var pc = await result.GetData<ProjectClass>("listProject");


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
