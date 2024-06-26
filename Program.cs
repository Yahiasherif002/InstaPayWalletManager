using Dapper_;
using Microsoft.Extensions.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {

       var configService= new Configrationservice();
       var costr = configService.GetConnectionString("DefaultConnection");

        using(var dbService = new DatabaseService(costr))
        {
            var walletservice =new  WalletService(dbService.GetConnection());
            var instapay = new InstaPay(walletservice);

            instapay.Start();
        }



            
    }


}