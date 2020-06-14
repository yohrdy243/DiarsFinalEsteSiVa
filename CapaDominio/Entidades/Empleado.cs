using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.Entidades
{
     public class Empleado
    {
        
        private String idEmpleado;
        public String IdEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }

        private String direccion;
        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        private String dni;
        public String Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        private DateTime fechaDeNacimiento;
        public DateTime FechaDeNacimiento
        {
            get { return fechaDeNacimiento; }
            set { fechaDeNacimiento = value; }
        }


        private String gradoAcademico;
        public String GradoAcademico
        {
            get { return gradoAcademico; }
            set { gradoAcademico = value; }
        }

        private String nombre;
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        private String telefono;
        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }


        private String estadoCivil;
        public String EstadoCivil
        {
            get { return estadoCivil; }
            set { estadoCivil = value; }
        }

        //REGLAS DE NEGOCIO
        //------

    }
}
