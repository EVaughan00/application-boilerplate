using System.Text;

namespace Application.Config
{    
    public class RabbitMQSettings {
        public string Host { get; set; }
        public string Port { get; set; }
        public string ConnectionString {
            get { 
                if (string.IsNullOrWhiteSpace(Host))
                    Host = "rabbitmq";

                if (string.IsNullOrWhiteSpace(Port))
                    Port = "5672";                
                
                return $"{Host}";
            }
        }
    }  
}
