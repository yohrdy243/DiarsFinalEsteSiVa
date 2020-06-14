using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.Entidades
{
    public class Planilla
    {
        private String idPlanilla;
        public String IdPlanilla
        {
            get { return idPlanilla; }
            set { idPlanilla = value; }
        }

        private DateTime fechaPlanilla;
        public DateTime FechaPlanilla
        {
            get { return fechaPlanilla; }
            set { fechaPlanilla = value; }
        }

        private BoletaDePago boleta;
        public BoletaDePago Boleta
        {
            get { return boleta; }
            set { boleta = value; }
        }

    }
}
