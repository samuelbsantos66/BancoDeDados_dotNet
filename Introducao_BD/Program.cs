

using Microsoft.Data.SqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
        SqlConnection conexao;
        conexao = new("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyUniversidadeDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        conexao.Open();
        Console.WriteLine("Conexão OK");
        Console.WriteLine(" == Salvando no banco de dados ==");
        var insertCmd = conexao.CreateCommand();
        insertCmd.CommandText = "INSERT INTO Cursos (nome, categoria, periodo) VALUES (@nome, @categoria, @periodo)";

        var paramNome = new SqlParameter("@nome","POO");
        insertCmd.Parameters.Add(paramNome);

        var paramCategoria = new SqlParameter("@categoria", "Maneiro");
        insertCmd.Parameters.Add(paramCategoria);

        var paramPeriodo = new SqlParameter("@periodo", 4);
        insertCmd.Parameters.Add(paramPeriodo);

        insertCmd.ExecuteNonQuery();

        conexao.Close();
    }
}