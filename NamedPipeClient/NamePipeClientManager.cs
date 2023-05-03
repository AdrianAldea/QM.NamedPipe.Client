using System;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

namespace NamedPipeClient
{
    public class NamePipeClientManager
    {
        private NamedPipeClientStream _namedPipeClientStream = null;
        const int BUFFERSIZE = 256;
        private byte[] rcvBuffer;

        public NamePipeClientManager()
        {
            rcvBuffer = new byte[BUFFERSIZE];

            _namedPipeClientStream = new NamedPipeClientStream(".", "testpipe", PipeDirection.InOut, PipeOptions.Asynchronous);
            _namedPipeClientStream.Connect();

            Console.WriteLine("Before Factory");
            Task.Factory.StartNew(() => Recv());
            Console.WriteLine("After Factory");
        }

        public void Send(string message)
        {
            byte[] _buffer = Encoding.UTF8.GetBytes(message);
            _namedPipeClientStream.Write(_buffer, 0, _buffer.Length);
        }

        private void Recv()
        {
            while (true)
            {
                Console.WriteLine("Before Read");
                int result = _namedPipeClientStream.Read(rcvBuffer, 0, BUFFERSIZE);
                string line = Encoding.UTF8.GetString(rcvBuffer, 0, result);
                Console.WriteLine("Received bytes: " + result + " Response: " + line);
                Console.WriteLine("After Read");
            }

        }
    }


}
