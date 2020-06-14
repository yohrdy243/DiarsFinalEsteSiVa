using CapaDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPersistencia.ADO_SQLServer
{
    public class ConceptoDeIngresoDescuentoDAO

    {
        private PeriodoDePagoDAO periodoDePagoDAO;
        private ContratoDAO contratoDAO;
        private GestorSQL gestorSQL;

        public List<ConceptoDeIngresosDescuentos> listarConceptosDeIngresosDescuento()
        {
            List<ConceptoDeIngresosDescuentos> listaDeConceptosIngresosDescuentos = new List<ConceptoDeIngresosDescuentos>();
            ConceptoDeIngresosDescuentos aux;
            string listaDeConceptos = "select idconcepto,montodeotrosdescuentos,montodeotrosingresos,montoporadelantos,montoporhorasausentes," +
                "montoporhorasextras,montoporreintegros from conceptoDeIngresosDescuentos;";
            try
            {
                SqlDataReader resultadoSQL = gestorSQL.ejecutarConsulta(listaDeConceptos);
                while (resultadoSQL.Read())
                {
                    aux = obtenerConceptos(resultadoSQL);
                    listaDeConceptosIngresosDescuentos.Add(aux);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return listaDeConceptosIngresosDescuentos;

        }

        private ConceptoDeIngresosDescuentos obtenerConceptos(SqlDataReader resultadoSQL)
        {
            ConceptoDeIngresosDescuentos conceptoDeIngresosDescuentos = new ConceptoDeIngresosDescuentos();
            conceptoDeIngresosDescuentos.MontoDeOtrosIngresos = float.Parse(resultadoSQL.GetString(0));
            conceptoDeIngresosDescuentos.MontoDeOtrosDescuentos = float.Parse(resultadoSQL.GetString(1));
            conceptoDeIngresosDescuentos.MontoPorAdelantos = float.Parse(resultadoSQL.GetString(2));
            conceptoDeIngresosDescuentos.MontoPorHorasExtras= float.Parse(resultadoSQL.GetString(3));
            conceptoDeIngresosDescuentos.MontoPorReintegros = float.Parse(resultadoSQL.GetString(4));
            conceptoDeIngresosDescuentos.PeriodoDePago = periodoDePagoDAO.buscarPeriodo(resultadoSQL.GetString(5));//falta buscar
            conceptoDeIngresosDescuentos.Contrato = contratoDAO.buscarContrato(resultadoSQL.GetString(6));//falta buscar
            return conceptoDeIngresosDescuentos;

        }
        public ConceptoDeIngresosDescuentos BuscarConcepto(String id)
        {
            ConceptoDeIngresosDescuentos concepto;
            String consultaSQL = "select * from conceptodeingresosdescuentos  where conceptodeingresosdescuentos.idconcepto = '" + id + "';";
            try
            {
                SqlDataReader resultadoSQL = gestorSQL.ejecutarConsulta(consultaSQL);
                if (resultadoSQL.Read())
                {
                    concepto = obtenerConceptos(resultadoSQL);
                }
                else
                {
                    throw new Exception("No existe el Empleado");
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return concepto;
        }
    }
}
