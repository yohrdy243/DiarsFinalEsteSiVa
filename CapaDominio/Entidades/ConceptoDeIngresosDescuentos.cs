using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.Entidades
{
     public class ConceptoDeIngresosDescuentos
    {
        private float montoDeOtrosDescuentos;
        public float MontoDeOtrosDescuentos
        {
            get { return montoDeOtrosDescuentos; }
            set { montoDeOtrosDescuentos = value; }
        }
        private float montoDeOtrosIngresos;

        public float MontoDeOtrosIngresos
        {
            get { return montoDeOtrosIngresos; }
            set { montoDeOtrosIngresos = value; }
        }
        private float montoPorAdelantos;

        public float MontoPorAdelantos
        {
            get { return montoPorAdelantos; }
            set { montoPorAdelantos = value; }
        }

        private float montoPorHorasAusentes;

        public float MontoPorHorasAusentes
        {
            get { return montoPorHorasAusentes; }
            set { montoPorHorasAusentes = value; }
        }
        private float montoPorHorasExtras;

        public float MontoPorHorasExtras
        {
            get { return montoPorHorasExtras; }
            set { montoPorHorasExtras = value; }
        }
        private float montoPorReintegros;

        public float MontoPorReintegros
        {
            get { return montoPorReintegros; }
            set { montoPorReintegros = value; }
        }

        //RELACIONES
        private Contrato contrato;
        public Contrato Contrato
        {
            get { return contrato; }
            set { contrato = value; }
        }

        private PeriodoDePago periodoDePago;
        public PeriodoDePago PeriodoDePago
        {
            get { return periodoDePago; }
            set { periodoDePago = value; }
        }

        public double calcularConceptosDeIngresos()
        {
            return montoPorHorasExtras + montoPorReintegros + montoDeOtrosIngresos;
        }

        public double calularConceptoDeDescuentos()
        {
            return montoPorHorasAusentes + montoPorAdelantos + montoDeOtrosDescuentos;
        }
    }
}
