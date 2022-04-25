using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Runtime.Caching;
using System.Text;
using System.Windows.Forms;
using TDesk.Models;

namespace TDesk
{
    public partial class AddOrder : Form
    {
        //private readonly IMemoryCache _memoryCache;
        private int TenderId { get; set; }
        public AddOrder()
        {
            InitializeComponent();
        }

        public AddOrder(int tenderId)
        {
            TenderId = tenderId;
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var offer = new OfferDetails
            {
                TenderId = TenderId,
                OfferPrice = Convert.ToInt32(offerPrice.Text),
                CreatedBy = 1,
                CreatedOn = DateTime.Now
            };


            //var client = new RestClient("http://localhost:5000/api/Offer");
            ////client.Timeout = -1;
            //var request = new RestRequest("POST");
            //request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InVzZXIxIiwibmJmIjoxNjUwODkwMDg0LCJleHAiOjE2NTA4OTA2ODQsImlhdCI6MTY1MDg5MDA4NH0.rwIVKoC4ORxyIuQhrg1y46s6cnHEis7XdZC6trZN6cM");
            //request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("application/json", JsonConvert.SerializeObject(offer), ParameterType.RequestBody);
            //var response = client.ExecuteAsync(request);

            ObjectCache cache = MemoryCache.Default;
            string token = cache["token"] as string;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var content = new StringContent(JsonConvert.SerializeObject(offer), Encoding.UTF8, "application/json");
        //    HttpResponseMessage response = await client.PostAsync("http://localhost:5000/api/Offer", content);

           // response.EnsureSuccessStatusCode();
        }
    }
}
