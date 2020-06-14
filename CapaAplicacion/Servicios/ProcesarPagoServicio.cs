using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaPersistencia.ADO_SQLServer;
using CapaDominio.Entidades;
using CapaDominio.Servicios;

namespace CapaAplicacion.Servicios
{
    class ProcesarPagoServicio
    {
        private GestorSQL gestorDatos;
        private ContratoDAO contratoDAO;
        private Contrato contrato;
        private BoletaDAO boletaDAO;
        private ConceptoDeIngresoDescuentoDAO conceptoDAO;
        private PeriodoDePagoDAO periodoDePagoDAO;
        private RegistroDePago registroDePago;
        public List<Contrato> buscarContratosActivos()
        {
            List<Contrato> aux = new List<Contrato>();
            gestorDatos.abrirConexion();
            List<Contrato> contratos = contratoDAO.listarcontratos(); //select * from Contrato
            gestorDatos.cerrarConexion();

            foreach (Contrato contrato in contratos)
            {

                if (contrato.EstadoContrato == true)
                {
                    aux.Add(contrato);
                }
            }
            return aux;
        }


        public BoletaDePago generarBoleta(Contrato contrato, ConceptoDeIngresosDescuentos concepto)
        {
            BoletaDePago boleta = new BoletaDePago();
            boleta.Contrato = contrato;
            boleta.ConceptoDeIngresosDescuentos = concepto;
            boleta.calcularAsignacionFamiliar();
            boleta.calcularTotalDeHoras();
            boleta.calcularSueldoBasico();
            boleta.calcularDescuentoAFP();
            boleta.calcularTotalDeIngreso();
            boleta.calcularTotalDeDescuento();
            boleta.calcularSueldoNeto();
            return boleta;  
        }
        public ConceptoDeIngresosDescuentos buscarConcepto(Contrato contrato,PeriodoDePago periodoDePago,List<ConceptoDeIngresosDescuentos> conceptos)
        {
            foreach (ConceptoDeIngresosDescuentos concep in conceptos)
            {
                if(concep.Contrato.Equals(contrato) == true && concep.PeriodoDePago.Equals(periodoDePago))
                {
                    return concep;
                }
            }
            return null;
        }
        public void generarBoletas(List<Contrato> contratosVigentes, PeriodoDePago periodoDePago)
        {
            ConceptoDeIngresosDescuentos aux = new ConceptoDeIngresosDescuentos();
            gestorDatos.abrirConexion();
            List<ConceptoDeIngresosDescuentos> conceptos = conceptoDAO.listarConceptosDeIngresosDescuento();
            foreach (Contrato contrato in contratosVigentes)
            {
                aux = buscarConcepto(contrato, periodoDePago, conceptos); 
                boletaDAO.guardar(generarBoleta(contrato, aux));
            } 
            periodoDePagoDAO.actualizarPeriodo(periodoDePago);
            gestorDatos.cerrarConexion();
        }
        //PASO 9 LISTAR PLANILLA
        public List<BoletaDePago> listarTodaLaPlanilla()
        {
            gestorDatos.abrirConexion();
            List<BoletaDePago> listaDePlanilla = boletaDAO.listarPlanilla();
            //EL SISTEMA MUESTRA MENSAJE DE PROCESO DE PAGOS
            registroDePago.procesaronPagos();
            gestorDatos.cerrarConexion();
            return listaDePlanilla;
        }

    }
}
