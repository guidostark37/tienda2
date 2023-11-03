﻿using System;
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
    public partial class Form1 : Form
    {
        tiendaEntities2 db = new tiendaEntities2 ();    
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargardatos();

        }

        private void btncarrito_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
          
        }

        public void cargardatos()
        {
            using (tiendaEntities2 db = new tiendaEntities2())
            {
                var query = (from producto in db.Productos
                            select producto).ToList();
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
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }
    }
}
