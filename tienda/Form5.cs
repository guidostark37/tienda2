using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tienda
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
        }

 

        private void btnarchivo_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Archivos jpg(*.jpg)|*.jpg|Archivos png(*.png)|*.png";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                txtruta.Text = openFileDialog1.FileName;
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            guardar();
            Form4 form4 = new Form4();
            this.Hide();
            form4.Show();
        }


        public void guardar()
        {
            byte[] file = null;
            Stream stream = openFileDialog1.OpenFile();

            using (MemoryStream ms =new MemoryStream()) 
            {
                stream.CopyTo(ms);
                file = ms.ToArray();
            }

            using (tiendaEntities2 db = new tiendaEntities2())
            {
                Productos productos = new Productos();
                productos.name = txtnombre.Text;
                productos.precio_unidad = int.Parse(txtprecio.Text);
                productos.stock = int.Parse(txtstock.Text);
                productos.imagen = file;
                try
                {
                    db.Productos.Add(productos);
                    db.SaveChanges();
                    MessageBox.Show("se guardo correctamente");
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }

            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            this.Hide();
            form4.Show();
        }
    }
}
