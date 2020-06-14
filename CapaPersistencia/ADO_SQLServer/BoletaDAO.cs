using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio.Entidades;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace CapaPersistencia.ADO_SQLServer
{
    public class BoletaDAO
    {
        private GestorSQL gestorSQL;
        private ContratoDAO contratoDAO;
        private PeriodoDePagoDAO periodoDAO;
        private ConceptoDeIngresoDescuentoDAO conceptoDAO;
        private EmpleadoDAO empleadoDAO;

        public BoletaDAO(GestorSQL gestorSQL)
        {
            this.gestorSQL = gestorSQL;
        }

        public void guardar(BoletaDePago boleta)
        {
            String query = "insert into() ";
        }
        public List<BoletaDePago> listarboleta()
        {
            List<BoletaDePago> listaDeBoletas = new List<BoletaDePago>();
            BoletaDePago aux;
            string listarBoleta = "select idboleta, asignacionfamiliar, descuentoporafp, sueldobasico,sueldoneto ,totaldehoras,totaldescuentos,totalingresos,idperiodo,idconcepto,idcontrato from boleta;";
            try
            {
                SqlDataReader resultadoSQL = gestorSQL.ejecutarConsulta(listarBoleta);
                while (resultadoSQL.Read())
                {
                    aux = obtenerBoleta(resultadoSQL);
                    listaDeBoletas.Add(aux);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return listaDeBoletas;
        }

        public List<BoletaDePago> listarPlanilla()
        {
            List<BoletaDePago> listaDePlanilla = new List<BoletaDePago>();
            BoletaDePago aux;
            string listarPlanillas = "select idEmpleado, nombre, dni, totalDeHoras,valorHora ,sueldoBasico,totalIngresos,totalDescuentos,SueldoNeto from boleta,contrato,empleado ;";
            try
            {
                SqlDataReader resultadoSQL = gestorSQL.ejecutarConsulta(listarPlanillas);
                while (resultadoSQL.Read())
                {
                    aux = obtenerPlanilla(resultadoSQL);
                    listaDePlanilla.Add(aux);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return listaDePlanilla;
        }

        private BoletaDePago obtenerPlanilla(SqlDataReader resultadoSQL)
        {
            BoletaDePago planilla = new BoletaDePago();
            planilla.Contrato.Empleado.IdEmpleado = resultadoSQL.GetString(0);
            planilla.Contrato.Empleado.Nombre = resultadoSQL.GetString(1);
            planilla.Contrato.Empleado.Dni = resultadoSQL.GetString(2);
            planilla.TotalDeHoras = double.Parse(resultadoSQL.GetString(3));
            planilla.Contrato.ValorHora = double.Parse(resultadoSQL.GetString(4));
            planilla.SueldoBasico = double.Parse(resultadoSQL.GetString(5));
            planilla.TotalIngresos = double.Parse(resultadoSQL.GetString(6));
            planilla.TotalDescuentos = double.Parse(resultadoSQL.GetString(7));
            planilla.SueldoNeto = double.Parse(resultadoSQL.GetString(8));

            return planilla;

        }

        private BoletaDePago obtenerBoleta(SqlDataReader resultadoSQL)
        {
            Empleado emp = new Empleado();
            Contrato cont = new Contrato();
            //emp = empleadoDAO.buscarPorDni(resultadoSQL.GetString(9));
            
            cont = contratoDAO.buscarContrato(resultadoSQL.GetString(8));
            BoletaDePago boleta = new BoletaDePago();
            boleta.IdBoleta = resultadoSQL.GetString(0);
            boleta.AsignacionFamiliar = double.Parse(resultadoSQL.GetString(1));
            boleta.DescuentoPorAFP = double.Parse(resultadoSQL.GetString(2));
            boleta.SueldoBasico = double.Parse(resultadoSQL.GetString(3));
            boleta.SueldoNeto = double.Parse(resultadoSQL.GetString(4));
            boleta.TotalDeHoras = double.Parse(resultadoSQL.GetString(5));
            boleta.TotalIngresos = double.Parse(resultadoSQL.GetString(6));
            boleta.TotalDescuentos = double.Parse(resultadoSQL.GetString(7));
            boleta.Contrato = cont;
            boleta.PeriodoDePago = periodoDAO.buscarPeriodo(resultadoSQL.GetString(9));
            boleta.ConceptoDeIngresosDescuentos = conceptoDAO.BuscarConcepto(resultadoSQL.GetString(10));

            return boleta;

        }
    }
}
