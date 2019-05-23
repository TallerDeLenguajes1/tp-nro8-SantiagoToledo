using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP8
{
    class Empleado
    {
        private string nombre;
        private string apellido;
        private DateTime fnac;
        private EstadoCivil estadoCivilEmp;
        private Genero generoEmp;
        private DateTime fing;
        private double sueldoBasico;
        private Cargo cargoEmp;

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public DateTime Fnac
        {
            get
            {
                return fnac;
            }

            set
            {
                fnac = value;
            }
        }

        public EstadoCivil EstadoCivilEmp
        {
            get
            {
                return estadoCivilEmp;
            }

            set
            {
                estadoCivilEmp = value;
            }
        }

        public Genero GeneroEmp
        {
            get
            {
                return generoEmp;
            }

            set
            {
                generoEmp = value;
            }
        }

        public DateTime Fing
        {
            get
            {
                return fing;
            }

            set
            {
                fing = value;
            }
        }

        public double SueldoBasico
        {
            get
            {
                return sueldoBasico;
            }

            set
            {
                sueldoBasico = value;
            }
        }

        public Cargo CargoEmp
        {
            get
            {
                return cargoEmp;
            }

            set
            {
                cargoEmp = value;
            }
        }

        public int Antiguedad()
        {
            return (DateTime.Today.Year - Fing.Year);
        }

        public int Edad()
        {
            int edad = DateTime.Today.Year - Fnac.Date.Year;
            if (Fnac.Date > DateTime.Today.AddYears(-edad))
            {
                edad--;
            }

            return edad;
        }

        public int Jubilacion()
        {
            int jub;

            if (GeneroEmp == Genero.Masculino)
            {
                jub = 65 - Edad();
            }
            else
            {
                jub = 60 - Edad();
            }

            return jub > 0 ? jub : 0;
        }

        public double Salario()
        {
            double adicional;
            if (Antiguedad() < 20)
            {
                adicional = SueldoBasico * 0.02 * Antiguedad();
            }
            else
            {
                adicional = SueldoBasico * 0.25;
            }

            if (CargoEmp == Cargo.Ingeniero || CargoEmp == Cargo.Especialista)
            {
                adicional *= 1.5;
            }
            if (EstadoCivilEmp == EstadoCivil.Casado)
            {
                adicional += 5000;
            }
            return SueldoBasico + adicional;
        }


    }
}
