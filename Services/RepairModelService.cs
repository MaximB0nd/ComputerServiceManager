using System.Collections.ObjectModel;
using ComputerService.Models;
using Microsoft.Data.Sqlite;

namespace ComputerService.Services;

public class RepairModelService
{
    public static RepairModelService Shared = new RepairModelService();
    
    private string _dbName;
    private SqliteConnection _connection;
    private RepairModelService() 
    {
        _dbName = "ServiceDatabase.db";
        _connection = new SqliteConnection("Data Source=" + _dbName);
        OpenConnection();
    }

    ~RepairModelService()
    {
        _connection.Close();
    }
    
    private void OpenConnection()
    {
        _connection.Open();
        var command = _connection.CreateCommand();
        command.CommandText = @"
        CREATE TABLE IF NOT EXISTS RepairModels(
            id TEXT PRIMARY KEY CHECK (id != ''),
            name TEXT NOT NULL,
            type TEXT NOT NULL,
            producer TEXT NOT NULL,
            properties TEXT,
            features TEXT
        )";
        command.ExecuteNonQuery();
    }

    public void AddRepairModel(RepairModel repairModel)
    {
        var command = _connection.CreateCommand();
        command.CommandText = @"INSERT INTO RepairModels VALUES(@id, @name, @type, @producer, @properties, @features)";
        command.Parameters.AddWithValue("@id", repairModel.Id);
        command.Parameters.AddWithValue("@name", repairModel.Name);
        command.Parameters.AddWithValue("@type", repairModel.Type);
        command.Parameters.AddWithValue("@producer", repairModel.Producer);
        command.Parameters.AddWithValue("@properties", repairModel.Properties);
        command.Parameters.AddWithValue("@features", repairModel.Features);
        command.ExecuteNonQuery();
    }

    public void DeleteRepairModel(RepairModel repairModel)
    {
        var command = _connection.CreateCommand();
        command.CommandText = @"DELETE FROM RepairModels WHERE id = @id";
        command.Parameters.AddWithValue("$id", repairModel.Id);
        command.ExecuteNonQuery();
    }

    public ObservableCollection<RepairModel> ReadRepairModels()
    {
        var command = _connection.CreateCommand();
        command.CommandText = "SELECT * FROM RepairModels";
        var list = new ObservableCollection<RepairModel>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new RepairModel(
                reader.GetString(reader.GetOrdinal("id")),
                reader.GetString(reader.GetOrdinal("name")),
                reader.GetString(reader.GetOrdinal("type")),
                reader.GetString(reader.GetOrdinal("producer")),
                reader.GetString(reader.GetOrdinal("properties")),
                reader.GetString(reader.GetOrdinal("features"))
            ));

        }
        return list;
    }
}