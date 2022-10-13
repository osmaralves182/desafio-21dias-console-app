namespace console_desafio21dias_api
{
  class Aluno
  {
    // Propriedades
    public string Nome { get; set; }
    public string Matricula { get; set; }
    private List<double> notas;
    public List<double> Notas
    {
      get
      {
        if (notas == null) this.notas = new List<double>();
        return this.notas;
      }
      set
      {
        this.notas = value;
      }
    }

    // Métodos
    public double CalcularMedia()
    {
      var somaNotas = 0.0;
      foreach (var nota in this.Notas)
      {
        somaNotas += nota;
      }
      return somaNotas / this.Notas.Count;
    }

    public string Situacao()
    {
      return this.CalcularMedia() >= 7 ? "Aprovado" : "Reprovado";
    }

  }
}