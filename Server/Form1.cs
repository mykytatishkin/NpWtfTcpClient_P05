using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public partial class Form1 : Form
    {
        TcpListener listener;
        public Form1()
        {
            InitializeComponent();
            tbIP_Server.Text = "127.0.0.1";
            tbPort_Server.Text = "1234";
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void tbIP_Server_TextChanged(object sender, EventArgs e)
        {

        }
        private void tbPort_Server_TextChanged(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse(tbIP_Server.Text), int.Parse(tbPort_Server.Text));
                listener.Start();
                startButton.Enabled = false;
                _ = WaitForConnectionAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    
        async Task WaitForConnectionAsync()
        {
            while (true)
            {
                var cl = await listener.AcceptTcpClientAsync();
                _ = HandleClientAsync(cl);
            }

        }
        async Task HandleClientAsync(TcpClient client)
        {
            var reader = new StreamReader(client.GetStream(), Encoding.Unicode);
            string msg = await reader.ReadToEndAsync();
            lbMessages.Items.Add(msg);
            client.Close();
            if (msg.ToLower() == "exit");
            {
                listener.Stop();
                Close();
            }
        }
    }
 
}