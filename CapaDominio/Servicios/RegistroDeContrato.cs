using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio.Entidades;

namespace CapaDominio.Servicios
{
    public class RegistroDeContrato
    {
        public void validarEmpleado(Empleado empleado)
        {
            if (empleado == null)
            {
                throw new Exception("No existe el empleado");
            }
        }


        public void validarContrato(Contrato contrato, Empleado empleado, AFP afp, Contrato contratoAnterior)
        {
            if (contrato != null)
            {
                contrato.Empleado = empleado;
                contrato.AFP = afp;

                if (contrato.eslaFechaInicioValida(contrato.FechaFin) != true)
                {
                    throw new Exception("No se puede crear el contrato, La fecha del contrato anterior es superior a la fecha de inicio de este contrato");
                }
                if (contrato.esValidoLasHorasALaSemana() != true)
                {
                    throw new Exception("No se puede crear el contrato, Las horas a la semana no esta en el rango previsto ");
                }
                if (contrato.sonValidasLasFechas() != true)
                {
                    throw new Exception("No se puede crear el contrato, Las fechas no cumplen con el intrvalo previsto");
                }
                if (contrato.esValorPorHoraValido() != true)
                {
                    throw new Exception("No se puede crear el contrato, El valor por hora no cumple con lo privisto segun el cargo");
                }
                contrato.EstadoContrato = true;//HABILIATDO PARA CREAR
            }

        }

     
        public void tieneContratoVigente(Contrato contrato)
        {
            if (contrato == null)
            {
                throw new Exception("El empleado no tiene un contrato vigente");

            }
        }

    }
}
