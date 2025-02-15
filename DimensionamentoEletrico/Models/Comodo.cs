namespace DimensionamentoEletrico.Models;

class Comodo
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public List<Equipamento> equipamentos { get; set; } = [];
}
