namespace DimensionamentoEletrico.Models;

class Equipamento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public int Tensao { get; set; }
    public double Potencia { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
}
