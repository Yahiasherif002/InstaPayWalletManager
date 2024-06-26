using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_
{
    public class InstaPay
    {
        private readonly WalletService _walletService;

        public InstaPay(WalletService walletService)
        {
            _walletService = walletService;
        }

        public void Start()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. View All Wallets");
                Console.WriteLine("2. View Wallet by ID");
                Console.WriteLine("3. Add Wallet");
                Console.WriteLine("4. Update Wallet");
                Console.WriteLine("5. Delete Wallet");
                Console.WriteLine("6. TransferMoney");
                Console.WriteLine("7. Exit");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ViewAllWallets();
                        break;
                    case "2":
                        ViewWalletById();
                        break;
                    case "3":
                        AddWallet();
                        break;
                    case "4":
                        UpdateWallet();
                        break;
                    case "5":
                        DeleteWallet();
                        break;
                    case "6":
                        MakeTransaction();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        break;
                }
                Console.ReadKey();
            }
        }

        private void ViewAllWallets()
        {
            Console.ForegroundColor= ConsoleColor.DarkGray;
            var wallets = _walletService.GetWallets();
            foreach (var wallet in wallets)
            {
                Console.WriteLine($"ID: {wallet.Id} |  Holder: {wallet.Holder} |  Balance: {wallet.Balance}");
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;

        }

        private void ViewWalletById()
        {
            Console.ForegroundColor=ConsoleColor.DarkYellow;
            Console.WriteLine( "Enter Wallet ID : ");
            int id;
            while(!int.TryParse( Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. \nEnter Wallet ID :");
            }
            var wallet = _walletService.GetWallet(id);

            if (wallet != null)
            {
                Console.WriteLine($"ID: {wallet.Id} |  Holder: {wallet.Holder} |  Balance: {wallet.Balance}");
            }
            else
            {
                Console.WriteLine("Wallet Not Found ! ");
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }

        private void AddWallet()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Enter holder name : ");
            string holder = Console.ReadLine();

            Console.WriteLine("Enter Balance : ");
            decimal balance;
            while(!decimal.TryParse(Console.ReadLine(), out balance)){
                Console.WriteLine("Invalid input . \nEnter Balance : ");
            }

            var wallet = new Wallet { Holder = holder, Balance = balance };
            _walletService.AddWallet(wallet);
            Console.WriteLine("Wallet Added Successfully. ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }

        private void UpdateWallet()
        {
            Console.ForegroundColor= ConsoleColor.DarkMagenta;
            Console.Write("Enter wallet ID to update: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Invalid input. \nEnter wallet ID: ");
            }

            Console.WriteLine("Enter new holder name : ");
            string holder = Console.ReadLine();

            Console.WriteLine("Enter new  Balance : ");
            decimal balance;
            while (!decimal.TryParse(Console.ReadLine(), out balance))
            {
                Console.WriteLine("Invalid input . \nEnter Balance : ");
            }
            var wallet = new Wallet { Id = id, Holder = holder, Balance = balance };
            _walletService.UpdateWallet(wallet);

            Console.WriteLine("Wallet updated successfully");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }

        private void DeleteWallet()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Enter wallet ID to delete: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Invalid input. \nEnter wallet ID: ");
            }
            _walletService.RemoveWallet(id);
            Console.WriteLine("Wallet deleted Successfully");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }

        private void MakeTransaction()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter source wallet ID: ");
            int sourceId;
            while (!int.TryParse(Console.ReadLine(), out sourceId))
            {
                Console.Write("Invalid input. \nEnter source wallet ID: ");
            }

            Console.Write("Enter destination wallet ID: ");
            int destId;
            while (!int.TryParse(Console.ReadLine(), out destId))
            {
                Console.Write("Invalid input. \nEnter destination wallet ID: ");
            }

            Console.Write("Enter amount to transfer: ");
            decimal amount;
            while (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.Write("Invalid input. \nEnter amount: ");
            }

            _walletService.TransferBalance(sourceId, destId, amount);
            Console.WriteLine("Transaction completed successfully.");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }
    }

 }
