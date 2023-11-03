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
    public partial class UserControl1 : UserControl
    {
       
        List<ClsCarrito> CarritoList = new List<ClsCarrito>();
        public UserControl1()
        {
            InitializeComponent();
        }
        public UserControl1(Productos productos)
        {
            InitializeComponent();
            cargardatos(productos);

        }

        public Image mostrar(byte[]data) {
            using (MemoryStream ms = new MemoryStream(data)) { 

                return Image.FromStream(ms);
            }
        }

        public void cargardatos(Productos productos)
        {
            pictureBox1.Image = mostrar(productos.imagen);
            label1.Text = productos.name;
            label2.Text= productos.precio_unidad.ToString();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           

        }

        private void UserControl1_MouseClick(object sender, MouseEventArgs e)
        {
            var dif = e.X;
            if (dif != 0) {
                

            }
        }
    }
}
