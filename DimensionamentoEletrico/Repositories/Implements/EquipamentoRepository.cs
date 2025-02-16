using DimensionamentoEletrico.Models;
using DimensionamentoEletrico.Repositories.Interfaces;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Windows;

namespace DimensionamentoEletrico.Repositories.Implements;

class EquipamentoRepository : IRepository<Equipamento>
{
    private readonly IDbConnection _connection;
    public EquipamentoRepository()
    {

        _connection = new SqlConnection("Server=ANDRE-SILVA366\\SQLEXPRESS;Database=DimensionamentoEletrico;Trusted_Connection=True;TrustServerCertificate=True");

    }
    public void Add(Equipamento equipamento)
    {
        try
        {
            string query = "INSERT INTO Equipamento (Nome, Tensao, Potencia, DataCriacao) VALUES (@Nome, @Tensao, @Potencia, @DataCriacao)";
            _connection.Open();

            var parameters = new
            {
                equipamento.Nome,
                equipamento.Tensao,
                equipamento.Potencia,
                equipamento.DataCriacao
            };

            _connection.Execute(query, parameters);
            
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ocorreu um erro: {ex.Message}", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        finally
        {

            _connection.Close();
        }
    }

    public void Delete(Equipamento entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Equipamento> GetAll()
    {
        throw new NotImplementedException();
    }

    public Equipamento GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }

    public void Update(Equipamento entity)
    {
        throw new NotImplementedException();
    }
}
