using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_
{
    public class WalletService
    {
        private readonly IDbConnection _db;

        public WalletService(IDbConnection db)
        {
            _db=db;
        }

        public IEnumerable<Wallet> GetWallets() {

            var sql = "SELECT * FROM Wallets";
            return _db.Query<Wallet>(sql);
        
        }

        public void AddWallet(Wallet wallet)
        {
            var sql = "INSERT INTO Wallets (Holder,Balance) " +
                     "values(@Holder,@Balance)";
            _db.Execute(sql,wallet);
        }

        public void RemoveWallet(int Id) {

            var sql = " DELETE FROM Wallets WHERE Id = @Id";
            _db.Execute(sql, new {Id=Id});
        }

        public Wallet GetWallet(int Id)
        {
            var sql = "SELECT * FROM Wallets WHERE Id=@Id";
           return _db.QueryFirstOrDefault<Wallet>(sql, new { Id = Id });
        }

        public void UpdateWallet(Wallet wallet)
        {
            var sql = "UPDATE Wallets SET Holder=@Holder , Balance = @Balance WHERE Id=@Id";
            _db.Execute(sql, wallet);
        }
        public void TransferBalance(int sourceId, int destId, decimal amount)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }

                using (var transaction = _db.BeginTransaction())
                {
                    try
                    {
                        var sqlDebit = "UPDATE Wallets SET Balance = Balance - @Amount WHERE Id = @SourceId";
                        var sqlCredit = "UPDATE Wallets SET Balance = Balance + @Amount WHERE Id = @DestId";

                        _db.Execute(sqlDebit, new { Amount = amount, SourceId = sourceId }, transaction);
                        _db.Execute(sqlCredit, new { Amount = amount, DestId = destId }, transaction);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            finally
            {
                if (_db.State == ConnectionState.Open)
                {
                    _db.Close();
                }
            }
        }

    }
}
