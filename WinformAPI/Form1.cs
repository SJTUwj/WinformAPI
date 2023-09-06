using System.Text.Json.Nodes;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;

namespace WinformAPI
{
    public partial class Form1 : Form
    {
        string strMessage = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {                
                //后台地址
                string strInterFace = "http://127.0.0.1:8000" + "/items/" + textBox2.Text + "?q=" + textBox3.Text;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strInterFace);
                request.Method = "GET"; //声明一个HttpWebRequest请求
                request.Timeout = 60000;//设置连接超时时间
                //request.Headers.Set("Pragma", "no-cache");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamReceive = response.GetResponseStream();
                Encoding encoding = Encoding.UTF8;
                StreamReader streamReader = new StreamReader(streamReceive, encoding);
                string strResult = streamReader.ReadToEnd();
                this.textBox1.Text = strResult.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



    }
}