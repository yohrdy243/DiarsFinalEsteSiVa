using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.Entidades
{
    public class Contrato
    {
        private String idContrato;
        public String IdContrato
        {
            get { return idContrato; }
            set { idContrato = value; }
        }

        private String cargo;
        public String Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        private Boolean estadoContrato;
        public Boolean EstadoContrato
        {
            get { return estadoContrato; }
            set { estadoContrato = value; }
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

        private Boolean tieneAsignacionFamiliar;
        public Boolean TieneAsignacionFamiliar
        {
            get { return tieneAsignacionFamiliar; }
            set { tieneAsignacionFamiliar = value; }
        }

        private int horasPorSemana;
        public int HorasPorSemana
        {
            get { return horasPorSemana; }
            set { horasPorSemana = value; }
        }

        private Double valorHora;
        public Double ValorHora
        {
            get { return valorHora; }
            set { valorHora = value; }
        }

        //RELACIONES
        private Empleado empleado;
        public Empleado Empleado
        {
            get { return empleado; }
            set { empleado = value; }
        }

        private AFP afp;
        public AFP AFP
        {
            get { return afp; }
            set { afp = value; }
        }
    


        //REGLAS DE NEGOCIO

        public Boolean esValidoLasHorasALaSemana()
        {
            if (horasPorSemana >= 8 && horasPorSemana <= 40)
            {
                return true;
            }
            return false;
        }


        public Boolean sonValidasLasFechas()
        {
            TimeSpan resultado = fechaFin - fechaInicio;
            int dias = resultado.Days;

            if (dias >= 90 && dias <= 365)
            {
                return true;
            }
            return false;
            //Contraro.Last().fechafin-> localizar la fecha fin del ultimo contrato
        }


        public Boolean esValorPorHoraValido()
        {
            switch (empleado.GradoAcademico)//EN GRADOACADEMICO YA ESTA EL SET Y GET
            {
                case "Primaria":
                    {
                        if (valorHora >= 5 && valorHora <= 10)
                        {
                            return true;
                        }
                        return false;
                    }
                case "Secundaria":
                    {
                        if (valorHora >= 5 && valorHora <= 10)
                        {
                            return true;
                        }
                        return false;
                    }
                case "Bachiller":
                    {
                        if (valorHora >= 11 && valorHora <= 20)
                        {
                            return true;
                        }
                        return false;
                    }
                case "Profesional":
                    {
                        if (valorHora >= 21 && valorHora <= 30)
                        {
                            return true;
                        }
                        return false;
                    }
                case "Magister":
                    {
                        if (valorHora >= 31 && valorHora <= 40)
                        {
                            return true;
                        }
                        return false;
                    }
                case "Doctor":
                    {
                        if (valorHora >= 41 && valorHora <= 60)
                        {
                            return true;
                        }
                        return false;
                    }
            }
            return false;
        }


        public Boolean eslaFechaInicioValida(DateTime fechaFinal)
        {
            int resultado = DateTime.Compare(fechaFinal, fechaInicio);
            if (resultado < 0)
            {
                return true;
            }
            return false;
        }


        public Boolean esVigente()
        {
            DateTime fechaActual = DateTime.Now;
            int resultado = DateTime.Compare(fechaActual, fechaFin);
            if (resultado >= 0 && estadoContrato == true)
            {
                return true;
            }
            return false;
        }
    }
}
