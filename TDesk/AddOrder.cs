using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using TDesk.Models;

namespace TDesk
{
    public partial class AddOrder : Form
    {
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
            using (HttpClient client = new HttpClient())
            {
                var offer = new OfferDetails 
                { 
                    TenderId=TenderId,
                    OfferPrice=Convert.ToInt32(offerPrice.Text),
                    CreatedBy=1,
                    CreatedOn=DateTime.Now
                };

                var content = new StringContent(JsonConvert.SerializeObject(offer), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("http://localhost:54462/api/Offer", content);

                response.EnsureSuccessStatusCode();
            }
        }
    }
}
