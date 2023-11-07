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
   
    public partial class Tienda : Form
      
    {
        
        public Tienda()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargardatos();

        }

        private void btncarrito_Click(object sender, EventArgs e)
        {
            Carrito form2 = new Carrito();
            this.Hide();
            form2.Show();
          
        }

        public void cargardatos()
        {
            using (tiendaEntities2 db = new tiendaEntities2())
            {
                var query = (from productos in db.Productos select productos).ToList();
                flowLayoutPanel1.Controls.Clear();
                foreach (var item in query)
                {
                    flowLayoutPanel1.Controls.Add(new UserControl1(item));
                   
                }
                
            }
        }



        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login form3 = new Login();
            this.Hide();
            form3.Show();
        }

        
    }
}
