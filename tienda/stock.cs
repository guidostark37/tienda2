using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace tienda
{
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
            mostrar();
        }
        public DataGridViewButtonColumn GB = new DataGridViewButtonColumn();
        public DataGridViewButtonColumn GB2 = new DataGridViewButtonColumn();
        private void Form4_Load(object sender, EventArgs e)
        {
         
        }

        private void mostrar()
        {
            using (tiendaEntities2 db = new tiendaEntities2()) {

                var query = from producto in db.Productos
                            select new
                            {
                                producto.id,
                                producto.name,
                                producto.precio_unidad,
                                producto.stock
                            };


                dgvProductos.DataSource = query.ToList();
            }
            GB.Name = "editar";
            GB.Text = "Editar";
            GB.UseColumnTextForButtonValue = true;
            GB.DefaultCellStyle.BackColor = Color.Green;
            dgvProductos.Columns.Add(GB);


            GB2.Name = "borrar";
            GB2.Text = "Borrar";
            GB2.DefaultCellStyle.BackColor = Color.Red;

            GB2.UseColumnTextForButtonValue = true;
            dgvProductos.Columns.Add(GB2);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarProducto form5 = new AgregarProducto();
            this.Hide();
            form5.Show();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Tienda form1 = new Tienda();
            this.Hide();
            form1.Show();
        }
        int id;

        private void eliminarProducto(int id)
        {
            try 
            { 
                using(tiendaEntities2 db = new tiendaEntities2())
                {
                    db.Productos.Remove(db.Productos.Single(p=>p.id==id));
                    db.SaveChanges();
                }                    
            } 
            catch (Exception ex){
                MessageBox.Show(ex.Message);           
            }
        
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProductos.Columns.IndexOf(GB))
            {
                id =int.Parse(dgvProductos.CurrentRow.Cells["id"].Value.ToString());
              
                Editar F7 = new Editar(id);    
                F7.Show();
                this.Hide();
               
            }
            if (e.ColumnIndex == dgvProductos.Columns.IndexOf(GB2))
            {
                id = int.Parse(dgvProductos.CurrentRow.Cells["id"].Value.ToString());

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                    
                result = MessageBox.Show("¿Desea Eliminar el producto?","se eliminará permanentemente", buttons);
              

                if (result == DialogResult.Yes)
                {
                    eliminarProducto(id);
                    llenar();

                }

            }
        }

        public void llenar()
        {
            using (tiendaEntities2 db = new tiendaEntities2())
            {

                var query = from producto in db.Productos
                            select new
                            {
                                producto.id,
                                producto.name,
                                producto.precio_unidad,
                                producto.stock
                            };


                dgvProductos.DataSource = query.ToList();
            }
        }
    }
}
