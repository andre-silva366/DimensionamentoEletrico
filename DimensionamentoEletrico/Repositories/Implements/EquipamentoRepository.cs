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

        _connection = new SqlConnection("Server=ANDRE-SILVA366\\SQLEXPRESS;Database=DimensionamentoEletrico;Trusted_Connection=True");

    }
    public void Add(Equipamento equipamento)
    {
        try
        {
            string query = "INSERT INTO Equipamento (Nome, Quantidade, Tensao, Potencia, DataCriacao) VALUES (@Nome, @Quantidade, @Tensao, @Potencia, @DataCriacao)";
            _connection.Open();

            var parameters = new
            {
                equipamento.Nome,
                equipamento.Quantidade,
                equipamento.Tensao,
                equipamento.Potencia,
                equipamento.DataCriacao
            };

            var row = _connection.Execute(query, parameters);
            if (row > 0)
            {
                MessageBox.Show("Equipamento cadastrado com sucesso!", "SUCESSO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
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
