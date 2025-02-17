using Dapper;
using DimensionamentoEletrico.Models;
using DimensionamentoEletrico.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Windows;

namespace DimensionamentoEletrico.Repositories.Implements;

class ComodoRepository : IRepository<Comodo>
{
    private readonly IDbConnection _connection;

    public ComodoRepository()
    {
        _connection = new SqlConnection("Server=ANDRE-SILVA366\\SQLEXPRESS;Database=DimensionamentoEletrico;Trusted_Connection=True;TrustServerCertificate=True");
    }
    public void Add(Comodo comodo)
    {
        try
        {
            var query = "INSERT INTO Comodo (Nome) VALUES (@Nome)";
            _connection.Open();
            var parameter = new { comodo.Nome };
            var row = _connection.Execute(query, parameter);
            if (row == 1)
            {
                MessageBox.Show("Comodo cadastrado com sucesso!", "SUCESSO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar comodo!", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro: {ex.Message}", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        finally
        {
            _connection.Close();
        }
    }

    public void Delete(Comodo entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Comodo> GetAll()
    {
        throw new NotImplementedException();
    }

    public Comodo GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Comodo entity)
    {
        throw new NotImplementedException();
    }
}
