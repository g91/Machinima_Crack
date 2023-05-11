using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace server_emu
{
    class Program
    {
        static void Main(string[] args)
        {
            var listener = new TcpListener(IPAddress.Any, 80);
            listener.Start();
            Console.WriteLine("Listening on port 80...");

            while (true)
            {
                var client = listener.AcceptTcpClient();
                Console.WriteLine("Client connected...");

                var stream = client.GetStream();
                var buffer = new byte[1024];
                var bytesRead = stream.Read(buffer, 0, buffer.Length);
                var request = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Request received:");
                Console.WriteLine(request);

                var response = "";
                if (request.Contains("GET /premium/activation.asp"))
                {
                    response = "HTTP/1.1 200 OK\r\nContent-Type: text/html\r\n\r\nactivated:25555";
                }
                else if (request.Contains("GET /premium/check.asp"))
                {
                    response = "HTTP/1.1 200 OK\r\nContent-Type: text/html\r\n\r\npremium";
                }
                else
                {
                    response = "HTTP/1.1 404 Not Found\r\nContent-Type: text/html\r\n\r\n";
                }

                var bytes = Encoding.ASCII.GetBytes(response);
                stream.Write(bytes, 0, bytes.Length);
                client.Close();
                Console.WriteLine("Response sent:");
                Console.WriteLine(response);
            }
        }
    }
}