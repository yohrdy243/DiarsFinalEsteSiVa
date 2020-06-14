using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio.Entidades;
namespace CapaDominio.Servicios
{
    public class RegistroDePago
    {
        public void existePeriodoDePago(PeriodoDePago periodoDePago)
        {
            //PASO 4 PROCESAR PAGO
            if (periodoDePago.sePuedeProcesar() == false)
            {
                //PASO 1.1 FLUJO ALTERNATIVO
                throw new Exception("El periodo de pago no esta activo");
            }
            else { 
            
            }
           
        }

        public void procesaronPagos()
        {
            //TODO LOS PAGOS SE MOSTRARAN DESPUES DE MOSTRAR LA PLANTILLA PASO 10
                throw new Exception("Se procesaron los pagos de todo los empleados");
            
        }

    }
}
