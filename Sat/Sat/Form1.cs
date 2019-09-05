using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sat.SatService;
namespace Sat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string datos = "";
            try
            {
                
                using (SatService.ConsultaCFDIServiceClient
                    client = new SatService.ConsultaCFDIServiceClient("BasicHttpBinding_IConsultaCFDIService"))
                {
                    textBox2.Text += "Calling WebService...";
                    datos = "?re="+re.Text+"&rr="+rr.Text+"&tt="+monto.Text+"&id="+folio.Text;
                    SatService.Acuse acuse = client.Consulta(datos);
                    if (acuse == null)
                    {
                        textBox2.Text += "ERROR:: Acuse is null";

                    }
                    else
                    {
                        textBox2.Text += "\r\nEstado:: " + acuse.Estado + "\r\nCodigoEstatus::" + acuse.CodigoEstatus;
                    }
                }
            }
            catch (Exception ex)
            {
                textBox2.Text += "Exception:: " + ex.Message;
                MessageBox.Show("ERROR::" + ex.Message);
            }
        }
    }
}
