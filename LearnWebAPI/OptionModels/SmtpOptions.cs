using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnWebAPI.OptionModels
{
    public class SmtpOptions
    {
        public string Server { get; set; } = String.Empty;
        public string Port { get; set; } = String.Empty;
        public string FromAddress { get; set; } = String.Empty;
    }
}
