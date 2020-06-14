using CapaDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPersistencia.ADO_SQLServer
{
    public class PeriodoDePagoDAO
    {
         private GestorSQL gestorSQL;

        public PeriodoDePagoDAO(GestorSQL gestorSQL)
        {
            this.gestorSQL = gestorSQL;
        }

        public void actualizarPeriodo(PeriodoDePago periodoDePago)
        { 
            String consultaSQL = "update PeriodoDePago set estado = 'Procesado' where PeriodoDePago.id = '" + periodoDePago.IdPeriodoDePago + "';";
            try
            {
                SqlDataReader resultadoSQL = gestorSQL.ejecutarConsulta(consultaSQL);
                if (resultadoSQL.Read())
                {
                    periodoDePago = obtenerPeriodo(resultadoSQL);
                }
                else
                {
                    throw new Exception("No existe el Periodo de Pago");
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public PeriodoDePago obtenerPeriodo(SqlDataReader resultadoSQL)
        {
            PeriodoDePago periodoDePago = new PeriodoDePago();
            periodoDePago.IdPeriodoDePago=resultadoSQL.GetString(0);
            periodoDePago.Estado=resultadoSQL.GetString(1);
            periodoDePago.FechaFin=resultadoSQL.GetDateTime(2);
            periodoDePago.FechaInicio=resultadoSQL.GetDateTime(3);
            periodoDePago.SemanasDePeriodo=resultadoSQL.GetInt32(3);
            return periodoDePago;
        }

        public PeriodoDePago buscarPeriodo(String idperiodoDePago)
        {
            return null;
        }
    }
}
