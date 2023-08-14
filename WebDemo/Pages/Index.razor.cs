using HttpClientService;
using System.Text.Json;

namespace WebDemo.Pages
{
    public partial class Index
    {
        protected override async Task OnInitializedAsync()
        {
            try
            {

                //string data = "{listBranches(branchID: \\\"5001\\\") {  code,  message,  success,  detail,  branches {    id,    branchName  }}}";
                //var result = await httpService.QueryGraphQLAsync("http://localhost:5223/graphql", data, 100);

                //var pc = await result.GetData<dynamic>("listBranches");
                var result = await httpService.Get<CommponResponse>("https://wallet.local:7067/api/WalletService/GetWallet/123");
                Console.WriteLine(result.Success);
                Console.WriteLine(JsonSerializer.Serialize(result.Response));
            }
            catch (Exception)
            {
                throw;

            }
        }
    }


    public class CommponResponse
    {
        public string id { get; set; }
        public int amount { get; set; }
        public int status { get; set; }
        public string createDate { get; set; }
    }

    public class Employee
    {
        public int id { get; set; }
        public string imageUrl { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string contactNumber { get; set; }
        public int age { get; set; }
        public string dob { get; set; }
        public decimal salary { get; set; }
        public string address { get; set; }
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
