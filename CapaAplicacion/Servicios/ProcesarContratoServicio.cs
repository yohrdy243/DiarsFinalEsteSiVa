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
    public class ProcesarContratoServicio
    {
        private GestorSQL gestorDatos;
        private ContratoDAO contratoDAO;
        private EmpleadoDAO empleadoDAO;

        public Empleado buscarEmpleado(String Dni)
        {
            gestorDatos.abrirConexion();
            Empleado aux = empleadoDAO.buscarPorDni(Dni);
            gestorDatos.cerrarConexion();
            return aux;
        }


        public Contrato buscarUltimoContratoActivo(String Dni)
        {
            Contrato aux = new Contrato();
            DateTime fech = new DateTime(1990, 8, 1, 0, 0, 0);
            aux.FechaFin=fech;
            gestorDatos.abrirConexion();
            List<Contrato> contratos = contratoDAO.listarcontratos(); //select * from Contrato
            gestorDatos.cerrarConexion();

            foreach (Contrato contrato in contratos)
            {
                Empleado emp = contrato.Empleado;
                if (emp.Dni == Dni)
                {
                    int resultado = DateTime.Compare(aux.FechaFin, contrato.FechaFin);
                    if (resultado < 0)
                    {
                        aux = contrato;
                    }
                }
            }
            return aux;
        }


        public Contrato buscarUltimoContrato(String Dni, Contrato contratoActual)
        {
            Contrato aux = new Contrato();
            DateTime fech = new DateTime(1990, 8, 1, 0, 0, 0);
            aux.FechaFin=fech;
            gestorDatos.abrirConexion();
            List<Contrato> contratos = contratoDAO.listarcontratos(); //select * from Contrato
            gestorDatos.cerrarConexion();

            foreach (Contrato contrato in contratos)
            {
                Empleado emp = contrato.Empleado;
                if (emp.Dni == Dni)
                {
                    int resultado = DateTime.Compare(aux.FechaFin, contrato.FechaFin);
                    if (resultado < 0 && contrato.Equals(contratoActual) != false)
                    {
                        aux = contrato;
                    }
                }
            }
            return aux;
        }

        //CREAR UN CONTRATO
        public void guardarContrato(Contrato contrato)
        {
            RegistroDeContrato registroDeContrato = new RegistroDeContrato();
            registroDeContrato.validarContrato(contrato, contrato.Empleado, contrato.AFP, buscarUltimoContratoActivo(contrato.Empleado.Dni));
            gestorDatos.abrirConexion();//crear Transaccion
            contratoDAO.crearContrato(contrato);
            gestorDatos.cerrarConexion();//cerrar Transaccion

        }

        public List<Contrato> listarTodoLosContratos()
        {
            gestorDatos.abrirConexion();
            List<Contrato> listaDeContratos = contratoDAO.listarcontratos();
            gestorDatos.cerrarConexion();
            return listaDeContratos;
        }
    }
}
