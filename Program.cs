using EspacioEmpleados;
internal class Program
{
    private static void Main(string[] args)
    {
       DateTime fechaNacimiento;
       DateTime fechaIngreso;
       string? fechaNacimientoSTR; 
       string? fechaIngresoSTR; 
       string? nombre;
       string? apellido;
       char estadoCivil;
       string? estadoCivilSTR;
       char genero;
       string? generoSTR;
       double salarioBasico;
       Cargos cargo;
       string? cargoSTR;
       string? salarioBasicoSTR;
       for (int i =0 ; i <3 ; i++)
       {
            Console.WriteLine("\n-Apellido:  ");
            apellido=Console.ReadLine();
            Console.WriteLine("\n-Nombre:  ");
            nombre=Console.ReadLine();
            Console.WriteLine("\n-Cargo (1=Auxiliar, 2=Administrativo, 3=Ingeniero, 4=especialista, 5=Investigador):  ");
            cargoSTR=Console.ReadLine();
            Console.WriteLine("\n-Sueldo Basico:  ");
            salarioBasicoSTR=Console.ReadLine();
            Console.WriteLine("\n-Genero(m = masculino, f=femenino):  ");
            generoSTR=Console.ReadLine();
            Console.WriteLine("\n-Estado Civil(s=soltero, c=casado):  ");
            estadoCivilSTR =Console.ReadLine();
            Console.WriteLine("\n-Fecha de nacimiento (aaaa-mm-dd):  ");
            fechaNacimientoSTR=Console.ReadLine();
            Console.WriteLine("\n-Fecha de Ingrso (aaaa-mm-dd):  ");
            fechaIngresoSTR=Console.ReadLine();
            if (nombre!=null && apellido!=null && DateTime.TryParse(fechaNacimientoSTR, out fechaNacimiento) && DateTime.TryParse(fechaIngresoSTR, out fechaIngreso) && char.TryParse(estadoCivilSTR,out estadoCivil) && char.TryParse(generoSTR, out genero) && double.TryParse(salarioBasicoSTR, out salarioBasico) && Enum.TryParse(cargoSTR, out cargo))
            {
                var objeto = new Empleado(nombre,apellido,fechaNacimiento,estadoCivil,genero,fechaIngreso,salarioBasico,cargo); 
                Console.WriteLine("\n"+objeto.Mostrar());
            }
       }
            Console.WriteLine("\n========================\n");
            Console.WriteLine("\n\tMonto total:  "+Empleado.montoTotal());
            Console.WriteLine("\n\tDATOS DEL EMPLEADO QUE ESTA MAS PROXIMO A JUBILARSE:  ");
            Console.WriteLine(Empleado.ProximoAJubilarse().Mostrar());
    
}
}