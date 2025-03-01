using DimensionamentoEletrico.Models;
using DimensionamentoEletrico.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows;

namespace DimensionamentoEletrico.Repositories.Implements;

class DimensionamentoRepository : IRepository<Dimensionamento>
{
    private readonly IDbConnection _connection;
    public DimensionamentoRepository()
    {
        _connection = new SqlConnection("Server=ANDRE-SILVA366\\SQLEXPRESS;Database=DimensionamentoEletrico;Trusted_Connection=True;TrustServerCertificate=True");
    }
    public void Add(Dimensionamento dimensionamento)
    {
        try
        {
            var query = "INSERT INTO Dimensionamento (IdProjeto, IdComodo , IdEquipamento, Potencia, Tensao, Circuito) VALUES (@IdProjeto, @IdComodo , @IdEquipamento, @Potencia, @Tensao, @Circuito);";
            _connection.Open();
            var parameters = new
            {
                dimensionamento.IdProjeto,
                dimensionamento.IdComodo,
                dimensionamento.IdEquipamento,
                dimensionamento.Potencia,
                dimensionamento.Tensao,
                dimensionamento.Circuito
            };

        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro: {ex.Message}", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        finally
        {

        }
    }

    public void Delete(string name)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Dimensionamento> GetAll()
    {
        throw new NotImplementedException();
    }

    public Dimensionamento GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Dimensionamento GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public void Update(Dimensionamento entity, string name)
    {
        throw new NotImplementedException();
    }
}
