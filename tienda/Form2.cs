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
        public DataGridViewButtonColumn GB = new DataGridViewButtonColumn();
        public DataGridViewButtonColumn GB2 = new DataGridViewButtonColumn();

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
            
           
            dgvcarrito.DataSource = ClsCarrito.clsCarritos;

            GB.Name = "Agregar";
            GB.Text = "Agregar";
            GB.UseColumnTextForButtonValue = true;
            GB.DefaultCellStyle.BackColor = Color.Green;
            dgvcarrito.Columns.Add(GB);

            GB2.Name = "Eliminar";
            GB2.Text = "Eliminar";
            GB2.UseColumnTextForButtonValue = true;
            GB2.DefaultCellStyle.BackColor = Color.Red;
            dgvcarrito.Columns.Add(GB2);


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
