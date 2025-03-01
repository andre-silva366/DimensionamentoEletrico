using Dapper;
using DimensionamentoEletrico.Models;
using DimensionamentoEletrico.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows;

namespace DimensionamentoEletrico.Repositories.Implements;

class ProjetoRepository : IRepository<Projeto>
{
    private readonly IDbConnection _connection;
    public ProjetoRepository()
    {
        _connection = new SqlConnection("Server=ANDRE-SILVA366\\SQLEXPRESS;Database=DimensionamentoEletrico;Trusted_Connection=True;TrustServerCertificate=True"); ;
    }
    public void Add(Projeto projeto)
    {
        try
        {
            var query = "INSERT INTO Projeto (Nome, IdAmbiente) VALUES (@Nome, @IdAmbiente)";
            _connection.Open();
            var parameters = new
            {
                projeto.Nome,
                projeto.IdAmbiente
            };
            var row = _connection.Execute(query, parameters);
            if(row == 1)
            {
                MessageBox.Show("Projeto cadastrado com sucesso!", "SUCESSO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar projeto!", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
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

    public void Delete(string name)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Projeto> GetAll()
    {
        throw new NotImplementedException();
    }

    public Projeto GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Projeto GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public void Update(Projeto entity, string name)
    {
        throw new NotImplementedException();
    }
}
