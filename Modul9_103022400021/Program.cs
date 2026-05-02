using Modul9_103022400021;
using System;
using static Transfer;

class Program
{
    static void Main(string[] args)
    {
        BankTransferConfig config = ConfigProcessor.ReadConfig();

        if (config.lang == "en")
        {
            Console.Write("Please insert  the amount of money to transfer: ");
        }
        else
        {
            Console.Write("Masukkan jumlah uang yang akan ditransfer: ");
        }

        double inputAmount = double.Parse(Console.ReadLine());

        double transferFee = (inputAmount <= config.transfer.treeshold) ? config.transfer.low_fee : config.transfer.high_fee;

        double totalAmount = inputAmount + transferFee;

        if (config.lang == "en")
        {
            Console.WriteLine($"Transfer Fee = {transferFee}");
            Console.WriteLine($"Total Amount = {totalAmount}");
        }
        else
        {
            Console.WriteLine($"Biaya Transfer = {transferFee}");
            Console.WriteLine($"Total Biaya = {totalAmount}");
        }

        if (config.lang == "en")
        {
            Console.WriteLine($"Select transfer method:");
        }
        else
        {
            Console.WriteLine($"Pilih metode transfer:");
        }

        for (int i = 0; i < config.methods.Count; i++)
        {
            Console.WriteLine($"{i + 1} : {config.methods[i]}");
        }

        Console.Write("Choose: ");
        int methodChoise = int.Parse(Console.ReadLine());
        string selectMethod = config.methods[methodChoise - 1];

        string confirmationToken = (config.lang == "en") ? config.confirmation.en : config.confirmation.id;

        if(config.lang == "en")
        {
            Console.WriteLine($"Please type \"{confirmationToken}\" to confirm the transaction: ");
        } 
        else
        {
            Console.WriteLine($"Ketik \"{confirmationToken}\" untuk mengkonfirmasi transaksi: ");
        }


        string inputConfirm = Console.ReadLine();

        if(inputConfirm == confirmationToken)
        {
            if (config.lang == "en")
            {
                Console.WriteLine($"The transfer is completed using \"{confirmationToken}");
            }
            else
            {
                Console.WriteLine($"Proses transfer berhasil menggunakan \n\"{confirmationToken}");
            }
        } 
        else
        {
            if (config.lang == "en")
            {
                Console.WriteLine($"Transfer is cancelled");
            }
            else
            {
                Console.WriteLine($"Transfer dibatalkan");
            }
        }
    }
}

