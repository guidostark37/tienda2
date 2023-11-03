using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tienda
{
    public partial class Form2 : Form
    {

        
        public Form2()
        {
            InitializeComponent();
            cargarcarrito();


        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();


        }
        public void cargarcarrito()
        {
            ClsCarrito clsCarrito = new ClsCarrito();


            dgvcarrito.ColumnCount = 3;
            dgvcarrito.Columns[0].Name = "producto";
            dgvcarrito.Columns[1].Name = "producto";
            dgvcarrito.Columns[2].Name = "producto";
           


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
