using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.Entidades
{
     public class PeriodoDePago
    {
        private String idPeriodoDePago;
        public String IdPeriodoDePago
        {
            get { return idPeriodoDePago; }
            set { idPeriodoDePago = value; }
        }

        private String estado;
        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private DateTime fechaFin;
        public DateTime FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }

        private DateTime fechaInicio;
        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        private int semanasDePeriodo;
        public int SemanasDePeriodo
        {
            get { return semanasDePeriodo; }
            set { semanasDePeriodo = value; }
        }

        //REGLAS DE NEGOCIO
        public Boolean sePuedeProcesar()
        {
            DateTime fechaActual = DateTime.Now;
            int resultado = DateTime.Compare(fechaActual, fechaFin);// 1 ,0, -1
            if (resultado <= 0) 
            {
                return true;
            }
            return false;
        }

     }
}
