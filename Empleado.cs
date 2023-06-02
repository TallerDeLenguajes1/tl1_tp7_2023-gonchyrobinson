using System.Collections.Generic;
namespace EspacioEmpleados
{
    public class Empleado
    {
         private static List<Empleado> objetosCreados = new List<Empleado>();
        private string? nombre;
        private string? apellido;
        private DateTime fechaNacimiento;
        private char estadoCivil;
        private char genero;
        private DateTime fechaIngreso;
        private double sueldoBasico;
        private Cargos cargo;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public char EstadoCivil { get => estadoCivil; set => estadoCivil = value; }
        public char Genero { get => genero; set => genero = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public double SueldoBasico { get => sueldoBasico; set => sueldoBasico = value; }

        public int Antiguedad(){
            DateTime fechaHoy= DateTime.Now.Date;
            int antiguedad = fechaHoy.Year-this.fechaIngreso.Year;
            return(antiguedad);
        }

        public int Edad(){
            DateTime fechaDeHoy=DateTime.Now.Date;
            int edad;
            edad=fechaDeHoy.Year-this.fechaNacimiento.Year;
            return(edad);
        }
        public int FaltanJubilarse(){
            int aniosRestantes;
            if (this.genero=='m')
            {
                aniosRestantes=65-this.Edad();
            }else
            {
                aniosRestantes=60-this.Edad();
            }
            if (aniosRestantes<0)
            {
                aniosRestantes=0;
            }
            return(aniosRestantes);
        }
        public double salario(){
            double Adicional=0;
            if (this.Antiguedad()<20)
            {
                Adicional+=0.01*this.Antiguedad()*this.sueldoBasico;
            }else
            {
                Adicional+=0.25*this.sueldoBasico;
            }
            if (this.cargo==Cargos.Ingeniero || this.cargo==Cargos.Especialista )
            {
                Adicional+=0.50*this.sueldoBasico;
            }
            if (this.estadoCivil=='c')
            {
                Adicional+=15000;
            }
            return(this.sueldoBasico+Adicional);
        }
        public Empleado(){

        }
        public Empleado(string Nombre, string Apellido, DateTime FechaDeNacimiento, char EstadoCivil, char Genero, DateTime FechaDeIngreso, double SueldoBasico, Cargos Cargo){
            nombre=Nombre;
            apellido=Apellido;
            fechaNacimiento=FechaDeNacimiento;
            estadoCivil=EstadoCivil;
            genero=Genero;
            fechaIngreso=FechaDeIngreso;
            sueldoBasico=SueldoBasico;
            cargo=Cargo;
            objetosCreados.Add(this);
        }
         public static double montoTotal(){
            double suma=0;
            foreach (Empleado item in objetosCreados)
            {
                suma+=item.salario();
            }
            return(suma);
         }

         public static Empleado? ProximoAJubilarse(){
            Empleado? masProximo=null;
            int jubilarse=999;
            foreach (Empleado item in objetosCreados)
            {
                if (item.FaltanJubilarse()<jubilarse)
                {
                    masProximo=item;
                    jubilarse=item.FaltanJubilarse();
                }
            }
            return(masProximo);
         }
         public string Mostrar(){
            int edad=this.Edad();
            int antiguedad=this.Antiguedad();
            return("\n-------------------------\n\n\tNombre: "+this.nombre+"\n\tApellido: "+ this.apellido +"\n\tFecha de nacimiento: "+this.FechaNacimiento.ToShortDateString()+"\n\tEstado Civil: "+ this.estadoCivil+ "\n\tGenero: "+ this.genero + "\n\tFecha de ingreso en la empresa: "+ this.fechaIngreso.ToShortDateString()+"\n\tSuedlo Basico: "+this.sueldoBasico + "\n\tCargo: "+this.cargo+"\n\tAntiguedad: "+antiguedad+ "\n\tEdad: "+edad+"\n\tCantidad de anios que faltan para jubilarse: "+this.FaltanJubilarse()+"\n\tSalario: "+this.salario());
         }
    }
    public enum Cargos
        {
            Auxiliar=1,
            Administrativo=2,
            Ingeniero=3,
            Especialista=4,
            Investigador=5
        }
}