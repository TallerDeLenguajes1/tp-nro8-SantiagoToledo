using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TP8
{
    public enum EstadoCivil { Soltero, Casado }
    public enum Genero { Masculino, Femenino }
    public enum Cargo { Auxiliar, Administrativo, Ingeniero, Especialista, Investigador }


    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int cant = 5;
            string rutaCsv = @"C:\Prueba\Registro.csv";
            string datos = "";
            

            Empleado prueba = new Empleado();
            List<Empleado> Empleados = new List<Empleado>();

            for (int i = 0; i < cant; i++)
            {
                Empleados.Add(CargarEmpleado(rnd));
            }
            Console.WriteLine("\nCantidad de Empleados: {0}\nSalario total: {1}", Empleados.Count, SalarioTotal(Empleados));

            //Mostrar(Empleados.ElementAt(rnd.Next(0, cant)));

            prueba = Empleados.ElementAt(rnd.Next(0, cant));

            PropertyInfo[] properties = prueba.GetType().GetProperties();


            foreach (var p in properties)
            {
                datos += p.GetValue(prueba).ToString() + ";";
            }
            Console.WriteLine("{0}", datos);

            string[] datospCargar = datos.Split(';');

            


        }



        public static Empleado CargarEmpleado(Random rnd)
        {
            Empleado emp = new Empleado();
            string[] Nombres = { "Santiago", "Pedro", "Juan", "Luciano", "Martin", "Maria", "Carla", "Luciana", "Cristina", "Alejandra" };
            string[] Apellidos = { "González", "Rodríguez", "Gómez", "Fernández", "López", "Díaz", "Martínez", "Pérez", "Romero", "Sánchez" };

            emp.GeneroEmp = (Genero)rnd.Next(0, 2);

            if (emp.GeneroEmp == Genero.Masculino)
            {
                emp.Nombre = Nombres[rnd.Next(0, 5)];
            }
            else
            {
                emp.Nombre = Nombres[rnd.Next(5, 10)];
            }

            emp.Apellido = Apellidos[rnd.Next(0, 10)];

            DateTime start = new DateTime(1940, 1, 1);

            int rangedate = (DateTime.Today.AddYears(-18) - start).Days;
            emp.Fnac = start.AddDays(rnd.Next(rangedate));

            rangedate = (DateTime.Today - emp.Fnac.AddYears(18)).Days;
            emp.Fing = emp.Fnac.AddYears(18).AddDays(rnd.Next(rangedate));

            emp.SueldoBasico = 15000;
            emp.CargoEmp = (Cargo)rnd.Next(0, 5);
            emp.EstadoCivilEmp = (EstadoCivil)rnd.Next(0, 2);
            return emp;
        }

        public static void Mostrar(Empleado emp)
        {
            Console.WriteLine("\nNombre y apellido: {0}\nGenero: {1}\nEstado civil: {2}\nFecha de Nacimiendo: {3:dd/MM/yyyy}\nFecha de Ingreso: {4:dd/MM/yyyy}\nCargo: {5}\nSueldo basico: {6}\nSalario: {7}\nEdad: {8}\nAntiguedad: {9}\nJubilacion: {10}",
                emp.Nombre + " " + emp.Apellido,
                emp.GeneroEmp,
                emp.EstadoCivilEmp,
                emp.Fnac.Date,
                emp.Fing.Date,
                emp.CargoEmp,
                emp.SueldoBasico,
                emp.Salario(),
                emp.Edad(),
                emp.Antiguedad(),
                emp.Jubilacion());

        }
        public static double SalarioTotal(List<Empleado> empleados)
        {
            double total = 0;
            foreach (Empleado emp in empleados)
            {
                total += emp.Salario();
            }
            return total;
        }

    }



}
