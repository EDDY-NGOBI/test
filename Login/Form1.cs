using System.Net.Http.Json;
using System.Text.Json;
using System;
using System.Text;

namespace Login
{
    public partial class Form1 : Form
    {
        HttpClient Client;
        public Form1()
        {
            InitializeComponent();
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:7165/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PostName name = new PostName() { Name=this.textBox1.Text};
            var postContent=new StringContent(JsonSerializer.Serialize(name,new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }),
               Encoding.UTF8,"application/json");
            
            var result = Client.PostAsync("Accounts", postContent).GetAwaiter().GetResult();
            var message = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            label1.Text=message;

           

        }
    }
}