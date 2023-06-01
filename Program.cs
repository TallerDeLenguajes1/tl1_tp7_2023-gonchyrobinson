using EspacioCalculadora;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("----------------------MENU----------------------------\n");
        Console.WriteLine("\n\t1-Sumar\n\t2-Restar\n\t3-Multiplicar\n\t4-Dividir\n\t5-Limpiar\n\t0-Salir");
        int opcion;
        string? opcionSTR;
        opcionSTR=Console.ReadLine();
        var calculadora =  new Calculadora();
        double termino;
        string? terminoSTR;
        while (int.TryParse(opcionSTR, out opcion) && opcion!=0)
        {
            switch (opcion)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    Console.WriteLine("Ingrese el tremino con el que desea realizar la operacion:  ");
                    terminoSTR=Console.ReadLine();
                    if (double.TryParse(terminoSTR, out termino))
                    {
                        switch (opcion)
                        {
                            case 1:
                                calculadora.Sumar(termino);
                            break;
                            case 2:
                                calculadora.Restar(termino);
                            break;
                            case 3: 
                                calculadora.Multiplicar(termino);
                            break;
                            case 4: 
                                if (termino!=0)
                                {
                                    calculadora.Dividir(termino);
                                }else
                                {
                                    Console.WriteLine("\nNo se puede dividir en 0");
                                }
                            break;
                            default:
                            break;
                        }
                    }
                break;
                case 5:
                    calculadora.Limpiar();
                break;
                default:
                break;
            }
            Console.WriteLine("\nIngrese una opcion:  ");
            opcionSTR=Console.ReadLine();   
        }
    Console.WriteLine("\n\nRESULTADO= " + calculadora.Resultado);
    }
}