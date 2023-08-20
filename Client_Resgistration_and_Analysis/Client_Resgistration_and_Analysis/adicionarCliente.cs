using Client_Resgistration_and_Analysis.getEset;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Resgistration_and_Analysis
{
    public partial class adicionarCliente : Form
    {

        public event EventHandler DataInserted;
        public adicionarCliente()
        {
            InitializeComponent();
        }

        Conexao c = new Conexao();

        private void adicionarCliente_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            c.InsertDataIntoTestando(fname.Text, lname.Text, clienteTipo.Text);

            OnDataInserted(EventArgs.Empty);

            this.Close(); // Close the adicionarCliente form

        }


        protected virtual void OnDataInserted(EventArgs e)
        {
            DataInserted?.Invoke(this, e);
        }


    }
}
