using System;
using System.Text.Json;
using static Modul9_103022400021.Transfer;

namespace Modul9_103022400021
{
    public class BankTransferConfig
    {
        public string lang { get; set; }
        public Transfer transfer { get; set; }
        public List<string> methods { get; set; }
        public Confirmation confirmation { get; set; }

        public BankTransferConfig()
        {
            lang = "en";
            transfer = new Transfer
            {
                treeshold = 25000000,
                low_fee = 6500,
                high_fee = 15000
            };
            methods = new List<string> { "RTO (real-time)", "SKN", "RTGS", "BI FAST", };
            confirmation = new Confirmation
            {
                en = "yes",
                id = "ya"
            };
        }
    }

    public class Transfer
    {
        public double treeshold { get; set; }
        public double low_fee { get; set; }
        public double high_fee
        {
            get; set;
        }

        public class Confirmation
        {
            public string en { get; set; }
            public string id { get; set; }
        }

        public class ConfigProcessor
        {
            private const string FilePath = "bank_transfer_config.json";


            public void ReadConfig()
            {
                string jsonString = File.ReadAllText(FilePath);
                JsonSerializer.Deserialize<BankTransferConfig>(jsonString);
            }
        }
    }
}