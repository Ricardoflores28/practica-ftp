using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ftp_ricardo_flores
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //creando el request
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create("ftp://files.000webhost.com/public_html/" + "/" + Path.GetFileName("ruta archivo"));
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("usuario", "contraseña");
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;
            //Codigo para cargar el archivo
            FileStream stream = File.OpenRead("ruta del archivo");
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            stream.Close();
            //es para subir archivo
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
