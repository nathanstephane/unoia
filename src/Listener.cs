using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;


namespace unoia.src
{
    internal class Listener
    {
        private HttpListener httpListener;
        string[]? prefixes;
        bool isSystemSupported;
        public bool islistening;
        private static Listener instance;
        
        private Listener()
        {
            httpListener = new HttpListener();
        }

        public static Listener createListener()
        {
            if (instance == null)
            {
                instance = new Listener();
            }
            return instance;
        }
        public void listenTo(string[] prefixes)
        {
            
            foreach (string s in prefixes)
            {
                Console.WriteLine($"Adding {s}");
                instance.httpListener.Prefixes.Add(s);
            }
        }

        public void start()
        {
            if(instance.httpListener.Prefixes.Count>0)
            {
                instance.httpListener.Start();
                islistening = instance.httpListener.IsListening;
                Logger.setInfoMessage($"started listening for incoming requests");
               
            }
            else
            {
                Logger.setWarningMessage("Please provide an URI");
            }
        }

        public HttpListenerContext  getContext()
        {
            return instance.httpListener.GetContext();
        }
        public void typesInfo(HttpListenerRequest request)
        {
            string[]? _types = request.AcceptTypes;

            if (_types != null)
            {
                Console.WriteLine("The client accepts the following types:");
                foreach (var s in _types)
                {
                    Console.WriteLine(s);
                }
            }
            else { Logger.setWarningMessage("no types or types might be null"); }

        }
        public void displayRequestInfo()
        {

            HttpListenerRequest request = getContext().Request;
            Console.WriteLine("=======MIME TYPES INFO=======");

            typesInfo(request);            
            
            Console.WriteLine("=======CERTIFICATE AUTHENTICATION=======");
            var clientCertificate = request.GetClientCertificate()?.FriendlyName;

            Console.WriteLine($"is client authenticated ?: {request.IsAuthenticated}");

            if (clientCertificate != null)
            {
                Console.WriteLine(clientCertificate);
            }
            else
            {
                Logger.setWarningMessage("Invalid certificate or not found.");
            }

        }   

        

    }
}
