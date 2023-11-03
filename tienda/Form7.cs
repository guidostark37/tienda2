using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tienda
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }


        public Form7(int pid)
        {
            InitializeComponent();
            //buscar(pid);
        }
        private void label1_Click(object sender, EventArgs e)
        {
           
        }
        public void editar(int pid) { 
            
        }
        public void buscar(int pid)
        {
            try
            {
                using (tiendaEntities2 db = new tiendaEntities2()) {

                    var query = db.Productos.Where(p => p.id == pid).ToList();

                    if (query.Count > 0)
                    {
                        foreach (Productos producto in query)
                        {
                            txtnombre.Text = producto.name;
                            txtprecio.Text = producto.precio_unidad.ToString();
                            txtstock.Text = producto.stock.ToString();
                            MemoryStream ms = new MemoryStream(producto.imagen);
                            Bitmap bitmap = new Bitmap(ms);
                            pictureBox2.Image = bitmap;
                        }
                    }
                }            
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);          
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Productos producto = new Productos();


        public void editar(Productos producto)
        {
            try
            {
                using (tiendaEntities2 db = new tiendaEntities2())
                {

                    db.Entry(producto).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

            } 
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void cargardatos()
        {
                byte[] file = null;
                Stream stream = openFileDialog1.OpenFile();

                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    file = ms.ToArray();
                }  
                    producto.name = txtnombre.Text;
                    producto.precio_unidad = int.Parse(txtprecio.Text);
                    producto.stock = int.Parse(txtstock.Text);
                    producto.imagen = file;   
        }

        

        private void btnarchivo_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Archivos jpg(*.jpg)|*.jpg|Archivos png(*.png)|*.png";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtruta.Text = openFileDialog1.FileName;
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            
            cargardatos();
            editar(producto);

            Form4 form4 = new Form4();
            form4.Show();
            this.Close();
        }
    }
}
