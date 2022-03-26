using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

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
                var ttt = TenderId;
              //  HttpContent order = new HttpContent();
                HttpResponseMessage response = await client.PostAsync("http://localhost:54462/api/Offer", null);

                response.EnsureSuccessStatusCode();
            }
        }
    }
}
