using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda
{
   public class ClsCarrito
    {
        public int id { get; set; }
        public string nombre{ get; set; }
        public float precio { get; set;}
        public int cantidad { get; set;}
        public float total { get; set; }
       
       public  static List<ClsCarrito> clsCarritos = new List<ClsCarrito>();
    }
   

}
