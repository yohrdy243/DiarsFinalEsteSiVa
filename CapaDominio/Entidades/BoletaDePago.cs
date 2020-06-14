using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.Entidades
{
    public class BoletaDePago
    {
        private String idBoleta;
        public String IdBoleta
        {
            get { return idBoleta; }
            set { idBoleta = value; }
        }
        private double asignacionFamiliar;
        public double AsignacionFamiliar
        {
            get { return asignacionFamiliar; }
            set { asignacionFamiliar = value; }
        }

        private double descuentoPorAFP;

        public double DescuentoPorAFP
        {
            get { return descuentoPorAFP; }
            set { descuentoPorAFP = value; }
        }

        private double sueldoBasico;

        public double SueldoBasico
        {
            get { return sueldoBasico; }
            set { sueldoBasico = value; }
        }

        private double sueldoNeto;

        public double SueldoNeto
        {
            get { return sueldoNeto; }
            set { sueldoNeto = value; }
        }

        private double totalDeHoras;
        public double TotalDeHoras
        {
            get { return totalDeHoras; }
            set { totalDeHoras = value; }
        }

        private double totalDescuentos;

        public double TotalDescuentos
        {
            get { return totalDescuentos; }
            set { totalDescuentos = value; }
        }

        private double totalIngresos;

        public double TotalIngresos
        {
            get { return totalIngresos; }
            set { totalIngresos = value; }
        }

        //RELACIONES
        private Contrato contrato;
        public Contrato Contrato
        {
            get { return contrato; }
            set { contrato = value; }
        }

        private ConceptoDeIngresosDescuentos conceptoDeIngresosDescuentos;
        public ConceptoDeIngresosDescuentos ConceptoDeIngresosDescuentos
        {
            get { return conceptoDeIngresosDescuentos; }
            set { conceptoDeIngresosDescuentos = value; }
        }

        private PeriodoDePago periodoDePago;
        public PeriodoDePago PeriodoDePago
        {
            get { return periodoDePago; }
            set { periodoDePago = value; }
        }

        //REGLAS DE NEGOCIO

        public void calcularAsignacionFamiliar()
        {
            if (contrato.TieneAsignacionFamiliar == true)
            {
                asignacionFamiliar = 930 * 0.1;
            }
            else
            {
                asignacionFamiliar = 0;
            }
        }

        //DUDA: SE IMPLEMENTARA EN ESTRATEGIAS PROXIMAMENTE
        public void calcularTotalDeHoras()
        {
            totalDeHoras = periodoDePago.SemanasDePeriodo * contrato.HorasPorSemana;
        } 


        public void calcularSueldoBasico()
        {
            sueldoBasico = totalDeHoras * contrato.ValorHora;
        }


        public void calcularDescuentoAFP()
        {
            descuentoPorAFP = sueldoBasico * contrato.AFP.PorcentajeDescuentoAFP;
        }


        public void calcularTotalDeIngreso()
        {
            totalIngresos = sueldoBasico + asignacionFamiliar + conceptoDeIngresosDescuentos.calcularConceptosDeIngresos();
        }


        public void calcularTotalDeDescuento()
        {
            totalDescuentos = descuentoPorAFP + conceptoDeIngresosDescuentos.calularConceptoDeDescuentos();
        }


        public void calcularSueldoNeto()
        {
            sueldoNeto = totalIngresos - totalDescuentos;
        }
    }


}
