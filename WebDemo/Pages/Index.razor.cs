using HttpClientService;

namespace WebDemo.Pages
{
    public partial class Index
    {
        protected override async Task OnInitializedAsync()
        {
            try
            {

                string data = "{listBranches(branchID: \\\"5001\\\") {  code,  message,  success,  detail,  branches {    id,    branchName  }}}";
                var result = await httpService.QueryGraphQLAsync("http://localhost:5223/graphql", data, 100);

                var pc = await result.GetData<dynamic>("listBranches");


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
