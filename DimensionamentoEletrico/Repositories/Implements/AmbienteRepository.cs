using Dapper;
using DimensionamentoEletrico.Models;
using DimensionamentoEletrico.Repositories.Interfaces;
using DimensionamentoEletrico.Views.Insert;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows;

namespace DimensionamentoEletrico.Repositories.Implements;

class AmbienteRepository : IRepository<Ambiente>
{
    private readonly IDbConnection _connection;
    public AmbienteRepository()
    {
        _connection = new SqlConnection("Server=ANDRE-SILVA366\\SQLEXPRESS;Database=DimensionamentoEletrico;Trusted_Connection=True;TrustServerCertificate=True");
    }
    public void Add(Ambiente ambiente)
    {
        try
        {
            var query = "INSERT INTO Ambiente (Nome) VALUES (@Nome)";
            _connection.Open();
            var parameter = new { ambiente.Nome };
            var row = _connection.Execute(query, parameter);
            if (row == 1)
            {
                MessageBox.Show("Ambiente cadastrado com sucesso!", "SUCESSO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar ambiente!", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro: {ex.Message}","ERRO",MessageBoxButton.OK,MessageBoxImage.Error);
        }
        finally
        {
            _connection.Close();
        }
    }

    public void Delete(Ambiente entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Ambiente> GetAll()
    {
        throw new NotImplementedException();
    }

    public Ambiente GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Ambiente entity)
    {
        throw new NotImplementedException();
    }
}
