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
            ObjectCache cache = MemoryCache.Default;
            string token = cache["token"] as string;
            string userid = cache["userid"] as string;

            var offer = new OfferDetails
            {
                TenderId = TenderId,
                OfferPrice = Convert.ToInt32(offerPrice.Text),
                CreatedBy = Convert.ToInt32(userid),
                CreatedOn = DateTime.Now
            };

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var content = new StringContent(JsonConvert.SerializeObject(offer), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:5000/api/Offer", content);

            response.EnsureSuccessStatusCode();
            this.Close();
        }
    }
}
