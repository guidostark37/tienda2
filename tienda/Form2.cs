using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tienda
{
    public partial class Form2 : Form
    {
        public DataGridViewButtonColumn GB = new DataGridViewButtonColumn();
        public DataGridViewButtonColumn GB2 = new DataGridViewButtonColumn();
        List<ClsCarrito> remplazo = new List<ClsCarrito>();

        public Form2()
        {
            InitializeComponent();
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
            cargarcarrito();
        }

        int id;
        private void dgvcarrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClsCarrito cls = new ClsCarrito();
            cls.id = 0;
            cls.nombre = "";
            cls.precio = 0;
            cls.cantidad = 0;
            cls.total = 0;
            remplazo.Add(cls);
            int indice=0;
          
            if (e.ColumnIndex == dgvcarrito.Columns.IndexOf(GB))
            {
                id = int.Parse(dgvcarrito.CurrentRow.Cells["id"].Value.ToString());
                for(int i = 0; i < ClsCarrito.clsCarritos.Count; i++)
                {
                    if (id == ClsCarrito.clsCarritos[i].id)
                    {
                        indice = i;
                    }
                }
                if (indice > -1)
                {
                    ClsCarrito.clsCarritos[indice].cantidad = ClsCarrito.clsCarritos[indice].cantidad + 1;
                    ClsCarrito.clsCarritos[indice].total = ClsCarrito.clsCarritos[indice].cantidad * ClsCarrito.clsCarritos[indice].precio;
                }
                dgvcarrito.DataSource = ClsCarrito.clsCarritos;
                dgvcarrito.Refresh();
            }

            if (e.ColumnIndex == dgvcarrito.Columns.IndexOf(GB2))
            {
                id = int.Parse(dgvcarrito.CurrentRow.Cells["id"].Value.ToString());

                for (int i = 0; i < ClsCarrito.clsCarritos.Count; i++)
                {
                    if (id == ClsCarrito.clsCarritos[i].id)
                    {
                        indice = i;
                    }
                }

                if (indice > -1 && ClsCarrito.clsCarritos[indice].cantidad > 1)
                {
                    ClsCarrito.clsCarritos[indice].cantidad = ClsCarrito.clsCarritos[indice].cantidad - 1;
                    ClsCarrito.clsCarritos[indice].total = ClsCarrito.clsCarritos[indice].cantidad * ClsCarrito.clsCarritos[indice].precio;
                    dgvcarrito.DataSource = ClsCarrito.clsCarritos;
                    dgvcarrito.Refresh();
                }
                else if (ClsCarrito.clsCarritos[indice].cantidad == 1)
                {
                    dgvcarrito.DataSource = remplazo;
                    ClsCarrito.clsCarritos.Remove(ClsCarrito.clsCarritos[indice]);
                    dgvcarrito.DataSource = ClsCarrito.clsCarritos;
                    dgvcarrito.Refresh();
                }

            }

        }
    }
}
