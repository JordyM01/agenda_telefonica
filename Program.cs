using System;

public class Program
{
    public static void Main()
    {
        Dictionary<string, string> listaDeContactos = new Dictionary<string, string>();
        int opcion = 0;

        do
        {
            opcion = Menu();

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("escogio Agregar un contacto");
                    AgregarContacto(listaDeContactos);
                    break;
                case 2:
                    Console.WriteLine("escogio Buscar un contacto");
                    BuscarContacto(listaDeContactos);
                    break;
                case 3:
                    Console.WriteLine("escogio Eliminar un contacto");
                    EliminarContacto(listaDeContactos);
                    break;
                case 4:
                    Console.WriteLine("escogio Mostrar todos los contactos");
                    MostrarTodosLosContactos(listaDeContactos);
                    break;
                case 5:
                    Console.WriteLine("escogio salir");
                    return;
                default:
                    Console.WriteLine("Por favor seleccione una opcion valida");
                    break;
            }
            Console.WriteLine("\nPresiona una tecla para continuar");
            Console.ReadKey();

        } while (true);
    }

    public static int Menu()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("|      Agenda Telefonica       |");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("1. Agregar un contacto");
        Console.WriteLine("2. Buscar un contacto");
        Console.WriteLine("3. Eliminar un contacto");
        Console.WriteLine("4. Mostrar todos los contactos");
        Console.WriteLine("5. Salir");
        Console.Write("\nPor favor escoja una opcion: ");

        string entradaUsuario = Console.ReadLine() ?? "";

        if (int.TryParse(entradaUsuario, out int opcion))
        {
            Console.WriteLine(opcion);
        }
        else
        {
            Console.WriteLine("Por favor ingrese un numero del 1 - 5");
        }

        return opcion;
    }

    public static void AgregarContacto(Dictionary<string, string> listaDeContactos)
    {
        string nombreContacto = ValidarExistencia(listaDeContactos, "Por favor ingrese el nombre del nuevo contacto: ");

        Console.WriteLine("Por favor ingrese el numero del nuevo contacto: ");
        string numeroContacto = Console.ReadLine() ?? "";

        listaDeContactos.Add(nombreContacto, numeroContacto);

        Console.WriteLine("Contacto agregado con exito");
    }

    public static void BuscarContacto(Dictionary<string, string> listaDeContactos)
    {
        Console.WriteLine("Ingrese el nombre del contacto a buscar");
        string contactoBuscado = Console.ReadLine() ?? string.Empty;
        string numero = string.Empty;

        if (listaDeContactos.TryGetValue(contactoBuscado, out numero!))
        {
            // El contacto existe en nuestra lista de contactos
            Console.WriteLine($"El numero de {contactoBuscado} es: {numero}"); // Imprimirá "El numero"
        }
        else
        {
            // El contacto no existe dentro de nuestra lista de contactos
            Console.WriteLine($"El contacto {contactoBuscado}, no fue encontrado.");
        }
    }

    public static void MostrarTodosLosContactos(Dictionary<string, string> listaDeContactos)
    {
        int contador = 0;

        foreach (KeyValuePair<string, string> kvp in listaDeContactos)
        {
            contador++;
            Console.WriteLine("[{0}] Nombre: {1}, Numero: {2}",
                contador, kvp.Key, kvp.Value);
        }
    }

    public static void EliminarContacto(Dictionary<string, string> listaDeContactos)
    {
        // Use the Remove method to remove a key/value pair.
        Console.WriteLine("Ingrese el nombre del contacto a eliminar");
        string nombreContacto = Console.ReadLine() ?? string.Empty;

        if (!listaDeContactos.ContainsKey(nombreContacto))
        {
            Console.WriteLine($"El contacto {nombreContacto} no existe");
        }
        else
        {
            listaDeContactos.Remove(nombreContacto);
            Console.WriteLine("Contacto eliminado con exito");
        }
    }

    static public string ValidarExistencia(Dictionary<string, string> listaDeContactos, string mensaje)
    {
        string contactoBuscado = string.Empty;

        do
        {
            Console.WriteLine(mensaje);
            contactoBuscado = Console.ReadLine() ?? string.Empty;

            if (listaDeContactos.ContainsKey(contactoBuscado))
            {
                Console.WriteLine($"El contacto {contactoBuscado} ya existe, por favor intente nuevamente");
            }
            else
            {
                return contactoBuscado;
            }
        } while (true);
    }
}
