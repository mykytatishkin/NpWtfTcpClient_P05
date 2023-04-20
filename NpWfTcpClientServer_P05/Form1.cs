using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NpWfTcpClientServer_P05
{
    public partial class Form1 : Form
    {
        TcpClient client;
        public Form1()
        {
            InitializeComponent();
            tbIP.Text = "127.0.0.1";
            tbPort.Text = "1234";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var endPoint = new IPEndPoint(IPAddress.Parse(tbIP.Text), int.Parse(tbPort.Text));
                client = new TcpClient();
                client.Connect(endPoint);
                //var stream = client.GetStream();
                //var buffer = Encoding.Unicode.GetBytes(tbMessage.Text);
                //stream.Write(buffer, 0, buffer.Length);

                var writer = new StreamWriter(client.GetStream(), Encoding.Unicode);
                writer.Write(tbMessage.Text);
                writer.Flush();
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }
        }
    }
}