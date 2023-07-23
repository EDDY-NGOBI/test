using System.Net.Http;
using System.Text;
using System.Text.Json;
using System;
using System.Windows.Forms;

namespace Login
{
    public partial class Form1 : Form
    {
        HttpClient client;

        public Form1()
        {
            InitializeComponent();
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7165/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int userId;
            if (!int.TryParse(textBox1.Text, out userId))
            {
                MessageBox.Show("Please enter a valid User ID.");
                return;
            }

            string password = textBox2.Text;

            var postData = new PostData { UserId = userId, Password = password };
            var postContent = new StringContent(JsonSerializer.Serialize(postData, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }),
               Encoding.UTF8, "application/json");

            var result = client.PostAsync("Accounts/Login", postContent).GetAwaiter().GetResult();
            var message = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            label3.Text = message;
        }
    }

    public class PostData
    {
        public int UserId { get; set; }
        public string Password { get; set; }
    }
}
