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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        

        private void Form3_Load(object sender, EventArgs e)
        {

        }


        private void btnregistrar_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            this.Hide();
            form6.Show();
        }

        private void btniniciar_Click(object sender, EventArgs e)
        {
            using (tiendaEntities2 db = new tiendaEntities2())
            {

                Usuario usuario = new Usuario();

                if (txtnombre.Text == "" || txtdocumento.Text == "")
                {
                    MessageBox.Show("Campos requeridos");
                    return;
                }
                else
                {
                    var num = int.Parse(txtdocumento.Text);
                    var query = (from user in db.Usuario where txtnombre.Text == user.nombre && num == user.documento && user.id_rol == 1
                                select
                                user).ToList();

                    if (query.Count() > 0) {
                       
                        Form4 form4 = new Form4();
                        this.Hide();
                        form4.Show();

                    }
                    else
                    {
                        Form1 form1 = new Form1();
                        this.Hide();
                        
                        form1.Show();
                        

                    }


                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
    }
}
