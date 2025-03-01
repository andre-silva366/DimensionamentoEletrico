namespace DimensionamentoEletrico.Models;

class Dimensionamento
{
    public int Id { get; set; }
    public string Nome { get; set; } = "Sem nome";
    public int Potencia { get; set; }
    public int Corrente { get; set; }
    public int Tensao { get; set; }
    public string Circuito { get; set; } = "Sem identificação";
    public int IdProjeto { get; set; }
    public int IdComodo { get; set; }
    public int IdEquipamento { get; set; }
}
