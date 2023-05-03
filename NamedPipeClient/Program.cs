using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

namespace NamedPipeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            NamePipeClientManager clientManager = new NamePipeClientManager();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "bye")
                    break;
                Console.WriteLine("Before send");
                clientManager.Send(line);
                Console.WriteLine("After send");
            }
        }

    }
}
