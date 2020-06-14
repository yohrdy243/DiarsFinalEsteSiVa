using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.Entidades
{
     public class AFP
    {

        private String codigoAFP;

        public string CodigoAFP
        {
            get { return codigoAFP; }
            set { codigoAFP = value; }
        }

        private String nombreAFP;

        public string NombreAFP
        {
            get { return nombreAFP; }
            set { nombreAFP = value; }
        }

        private float porcentajeDescuentoAFP;

        public float PorcentajeDescuentoAFP
        {
            get { return porcentajeDescuentoAFP; }
            set { porcentajeDescuentoAFP = value; }
        }


    }
}
