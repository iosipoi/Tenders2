using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Runtime.Caching;
using System.Text;
using System.Windows.Forms;
using TDesk.Models;

namespace TDesk
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            var user = new User
            {
                Nume = userName.Text,
                Password = pswText.Text
            };

            HttpClient client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:5000/api/Users/authenticate", content);

            var result = JsonConvert.DeserializeObject<User>(response.Content.ReadAsStringAsync().Result);

            if (result.Token != null)
            {
                ObjectCache cache = MemoryCache.Default;
                string tcache = cache["token"] as string;
                string userid = cache["userid"] as string;
                if (tcache == null)
                {
                    CacheItemPolicy policy = new CacheItemPolicy();
                    cache.Set("token", result.Token, policy);
                    cache.Set("userid", result.Id.ToString(), policy);
                }
            }
          
            response.EnsureSuccessStatusCode();
            this.Close();
        }
    }
}
