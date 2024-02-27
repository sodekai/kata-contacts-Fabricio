using Microsoft.Data.Sqlite;

namespace Contacts;

public class Database : IDisposable
{
  private readonly SqliteConnection _connection;

  public Database(String path)
  {
    String dataSource = $"Data Source={path}";
    _connection = new SqliteConnection(dataSource);
    _connection.Open();
  }

  public void Dispose()
  {
    _connection.Dispose();
    GC.SuppressFinalize(this);
  }

  public void InsertContacts(IEnumerable<Contact> contacts)
  {
    // TODO
  }

  public string LookupContact(string email)
  {
    var command = _connection.CreateCommand();
    command.CommandText = "SELECT name FROM contacts WHERE email = $email";
    command.Parameters.AddWithValue("$email", email);
    using (var reader = command.ExecuteReader())
    {
      var ok = reader.Read();
      if (!ok)
      {
        throw new Exception($"Could not find contact with email '{email}'");
      }
      return reader.GetString(0);
    }

  }

  internal void Migrate()
  {
    Console.WriteLine("Migrating DB");
    var command = _connection.CreateCommand();
    string statement = """
      CREATE TABLE contacts(
        id INTEGER PRIMARY KEY,
        name TEXT NOT NULL,
        email TEXT NOT NULL
      );
      """;
    command.CommandText = statement;
    command.ExecuteNonQuery();
  }

}
