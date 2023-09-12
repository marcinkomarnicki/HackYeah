using HackYeah.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;

namespace HackYeah.DAL
{
    public class HackYeahDbConnection : IDbConnection, IDisposable
    {
        private readonly IDbConnection _actualDbConnection;

        public HackYeahDbConnection(IOptions<ConnectionStringsSection> connectionStringsOptions)
        {
            _actualDbConnection = new NpgsqlConnection(connectionStringsOptions.Value.HackYeah);
            _actualDbConnection.Open();
        }

        public string ConnectionString { get => _actualDbConnection.ConnectionString; set => _actualDbConnection.ConnectionString = value; }

        public int ConnectionTimeout => _actualDbConnection.ConnectionTimeout;

        public string Database => _actualDbConnection.Database;

        public ConnectionState State => _actualDbConnection.State;

        public IDbTransaction BeginTransaction()
        {
            return _actualDbConnection.BeginTransaction();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return _actualDbConnection.BeginTransaction(il);
        }

        public void ChangeDatabase(string databaseName)
        {
            _actualDbConnection.ChangeDatabase(databaseName);
        }

        public void Close()
        {
            _actualDbConnection.Close();
        }

        public IDbCommand CreateCommand()
        {
            return _actualDbConnection.CreateCommand();
        }

        public void Dispose()
        {
            _actualDbConnection.Dispose();
        }

        public void Open()
        {
            _actualDbConnection.Open();
        }
    }
}
