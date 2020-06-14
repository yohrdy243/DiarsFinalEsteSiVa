using CapaDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPersistencia.ADO_SQLServer
{
    public class ContratoDAO
    {
        private GestorSQL gestorSQL;
        private EmpleadoDAO empleadoDAO;
        private AfpDAO afpDAO;
        public ContratoDAO(GestorSQL gestorSQL)
        {
            this.gestorSQL = gestorSQL;
        }

        public void crearContrato(Contrato contrato)
        {
            string crearContrato = "insert into contrato(idcontrato,cargo,estadocontrato,fechafin,fechainicio,tieneasignacionfamiliar,valorhora,idempleado,idafp)" +
                "values(@idcontrato, @cargo, @estadocontrato, @fechafin, @fechainicio, @tieneasignacionfamiliar, @valorhora, @idempleado, @idafp)";
            try
            {
                SqlCommand comando;

                comando = gestorSQL.obtenerComandoSQL(crearContrato);
                comando.Parameters.AddWithValue("@idcontrato",contrato.IdContrato);
                comando.Parameters.AddWithValue("@cargo", contrato.Cargo);
                comando.Parameters.AddWithValue("@estadocontrato", contrato.EstadoContrato);
                comando.Parameters.AddWithValue("@fechafin", contrato.FechaFin);
                comando.Parameters.AddWithValue("@fechainicio", contrato.FechaInicio);
                comando.Parameters.AddWithValue("@tieneasignacionfamiliar", contrato.TieneAsignacionFamiliar);
                comando.Parameters.AddWithValue("@valorhora", contrato.ValorHora);
                comando.Parameters.AddWithValue("@idempleado", contrato.Empleado.IdEmpleado);
                comando.Parameters.AddWithValue("@idafp", contrato.AFP.CodigoAFP);
                comando.ExecuteNonQuery();
            }
            catch(Exception err)
            {
                throw err;
            }
        }

        public List<Contrato> listarcontratos()
        {
            List<Contrato> listaDeContratos = new List<Contrato>();
            Contrato aux;
            string listarContratos = "select idcontrato,cargo,estadocontrato,fechafin,fechainicio,tieneasignacionfamiliar,valorhora,idempleado,idafp from contratos;";
            try
            {
                SqlDataReader resultadoSQL = gestorSQL.ejecutarConsulta(listarContratos);
                while (resultadoSQL.Read())
                {
                    aux = obtenerContrato(resultadoSQL);
                    listaDeContratos.Add(aux);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return listaDeContratos;
        }


        private Contrato obtenerContrato(SqlDataReader resultadoSQL)
        {
            Contrato contrato = new Contrato();
            contrato.IdContrato = resultadoSQL.GetString(0);
            contrato.Cargo = resultadoSQL.GetString(1);
            contrato.EstadoContrato = resultadoSQL.GetBoolean(2);
            contrato.FechaFin = DateTime.Parse(resultadoSQL.GetString(3));
            contrato.FechaInicio = DateTime.Parse(resultadoSQL.GetString(4));
            contrato.TieneAsignacionFamiliar = resultadoSQL.GetBoolean(5);
            contrato.ValorHora = double.Parse(resultadoSQL.GetString(6));
            contrato.Empleado = empleadoDAO.buscarPorDni(resultadoSQL.GetString(7));
            contrato.AFP = afpDAO.buscarPorCod(resultadoSQL.GetString(8));

            return contrato;

        }
        public Contrato buscarContrato(String idContrato)
        {
            Contrato contrato;
            String consultaSQL = "select * from contrato where contrato.idcontrato = '" + idContrato + "';";
            try
            {
                SqlDataReader resultadoSQL = gestorSQL.ejecutarConsulta(consultaSQL);
                if (resultadoSQL.Read())
                {
                    contrato = obtenerContrato(resultadoSQL);
                }
                else
                {
                    throw new Exception("No existe el Contrato");
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return contrato;
        }
    }
}
