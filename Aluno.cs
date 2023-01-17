using System.Data;
using System.Data.SqlClient;
namespace console_desafio21dias_api
{
  class Aluno
  {
    #region Propriedades
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Matricula { get; set; }
    private List<double> notas;
    public List<double> Notas
    {
      get
      {
        if (this.notas == null) this.notas = new List<double>();
        return this.notas;
      }
      set
      {
        this.notas = value;
      }
    }
    #endregion

    #region  Métodos de instância
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
    #endregion

    #region Métodos de classe ou estáticos
    private static string connectionString()
    {
      return "Data Source=localhost\\SQLEXPRESS;Database=desafio21diasapi;Integrated Security=SSPI";
    }

    public static void Incluir(Aluno aluno)
    {
      SqlConnection sqlConn = new SqlConnection(connectionString());

      sqlConn.Open();

      SqlCommand sqlCommand = new SqlCommand($"insert into alunos (nome, matricula, notas) values (@nome, @matricula, @notas)", sqlConn);
      sqlCommand.Parameters.Add("@nome", SqlDbType.VarChar);
      sqlCommand.Parameters["@nome"].Value = aluno.Nome;

      sqlCommand.Parameters.AddWithValue("@matricula", aluno.Matricula);
      sqlCommand.Parameters.AddWithValue("@notas", string.Join(",", aluno.Notas.ToArray()));

      sqlCommand.ExecuteNonQuery();

      sqlConn.Close();
      sqlConn.Dispose();
    }

    public void Salvar()
    {
      if (this.Id > 0)
      {
        Aluno.Atualizar(this);
      }
      else
      {
        Aluno.Incluir(this);
      }
    }

    public static void Atualizar(Aluno aluno)
    {
      SqlConnection sqlConn = new SqlConnection(connectionString());

      sqlConn.Open();

      SqlCommand sqlCommand = new SqlCommand($"update alunos set nome = @nome, matricula = @matricula, notas = @notas where id = @id", sqlConn);
      sqlCommand.Parameters.Add("@nome", SqlDbType.VarChar);
      sqlCommand.Parameters["@nome"].Value = aluno.Nome;

      sqlCommand.Parameters.AddWithValue("@id", aluno.Id);
      sqlCommand.Parameters.AddWithValue("@matricula", aluno.Matricula);
      sqlCommand.Parameters.AddWithValue("@notas", string.Join(",", aluno.Notas.ToArray()));

      sqlCommand.ExecuteNonQuery();

      sqlConn.Close();
      sqlConn.Dispose();
    }

    public void Apagar()
    {
      Aluno.ApagarPorId(this.Id);
    }

    public static void ApagarPorId(int id)
    {
      SqlConnection sqlConn = new SqlConnection(connectionString());

      sqlConn.Open();

      SqlCommand sqlCommand = new SqlCommand($"delete from alunos where id = {id}", sqlConn);
      sqlCommand.ExecuteNonQuery();

      sqlConn.Close();
      sqlConn.Dispose();
    }

    public static List<Aluno> Todos()
    {
      var alunos = new List<Aluno>();

      SqlConnection sqlConn = new SqlConnection(connectionString());

      sqlConn.Open();

      SqlCommand sqlCommand = new SqlCommand("select * from alunos", sqlConn);
      var reader = sqlCommand.ExecuteReader();

      while (reader.Read())
      {
        var notas = new List<double>();
        string strNotas = reader["notas"].ToString();
        foreach (var nota in strNotas.Split(','))
        {
          notas.Add(Convert.ToDouble(nota));
        }

        var aluno = new Aluno()
        {
          Id = Convert.ToInt32(reader["id"]),
          Nome = reader["nome"].ToString(),
          Matricula = reader["matricula"].ToString(),
          Notas = notas,
        };

        alunos.Add(aluno);
      }

      sqlConn.Close();
      sqlConn.Dispose();

      return alunos;
    }
    #endregion
  }
}