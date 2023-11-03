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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            guardar();
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
            

        }


        public void guardar() 
        {
            using (tiendaEntities2 db = new tiendaEntities2()) 
            {
                Usuario usuario = new Usuario();
              

                usuario.nombre = txtname.Text;
                usuario.apellido = txtapellido.Text;
                usuario.tipo_documento = txttipodoc.Text;
                usuario.documento = int.Parse(txtnumdocumento.Text);
                usuario.id_rol = 2;

                try 
                { 
                    db.Usuario.Add(usuario);
                    db.SaveChanges();
                    MessageBox.Show("se guardo correctamente");
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                } 
                
            }

        }
    }
}
