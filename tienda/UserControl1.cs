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
        int id = 0;
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
           
            id = productos.id;
            pictureBox1.Image = mostrar(productos.imagen);
            label1.Text = productos.name;
            label2.Text= productos.precio_unidad.ToString();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var confirma = "";
            var indice = 0;
            ClsCarrito cls = new ClsCarrito();
            cls.id = id;
            cls.nombre = label1.Text;
            cls.precio = float.Parse(label2.Text);
            cls.cantidad = 1;
            cls.total = cls.precio*cls.cantidad;

            for (int i = 0; i < ClsCarrito.clsCarritos.Count; i++)
            {
                if (ClsCarrito.clsCarritos[i].nombre == cls.nombre)
                {
                    confirma = "si";
                    indice= i;
                }
            }

            if (confirma == "si")
            {
                MessageBox.Show("si esta");
                cls.cantidad = ClsCarrito.clsCarritos[indice].cantidad + 1;
                cls.total = cls.precio * cls.cantidad;
                ClsCarrito.clsCarritos[indice] = cls;
            }
            else {
                ClsCarrito.clsCarritos.Add(cls);
            }
            
           

        }

        private void UserControl1_MouseClick(object sender, MouseEventArgs e)
        {
          
                

            
        }
    }
}
