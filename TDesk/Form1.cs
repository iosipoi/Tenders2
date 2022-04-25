using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using TDesk.Models;

namespace TDesk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:5000/api/Tenders");

                //HttpResponseMessage response = await client.GetAsync("http://localhost:3000/tenders");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<IEnumerable<Tender>>(responseBody);

                this.dataGridView1.DataSource = list;
            }
        }

        [STAThread]
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var tenderId = e.RowIndex+1;

            var orderForm = new AddOrder(tenderId);

            orderForm.Show();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                //HttpResponseMessage response = await client.GetAsync("http://localhost:54462/api/Tenders");

                HttpResponseMessage response = await client.GetAsync("http://localhost:3000/tenders");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<IEnumerable<Tender>>(responseBody);

                this.dataGridView1.DataSource = list;
            }
        }
    }
}
