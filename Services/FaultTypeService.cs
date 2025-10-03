using System.Collections.ObjectModel;
using ComputerService.Models;
using Microsoft.Data.Sqlite;

namespace ComputerService.Services;

public class FaultTypeService
{
    public static FaultTypeService Shared = new  FaultTypeService();

    private string _dbName;
    private SqliteConnection _connection;
    private FaultTypeService()
    {
        _dbName = "ServiceDatabase.db";
        _connection = new SqliteConnection("Data Source=" + _dbName);
        OpenConnection();
    }
    
    ~FaultTypeService() {
        _connection.Close();
    }

    private void OpenConnection()
    {
        _connection.Open();
        var command = _connection.CreateCommand();
        command.CommandText = @"
        CREATE TABLE IF NOT EXISTS FaultTypes (
            id TEXT PRIMARY KEY CHECK (id != ''),
            modelId TEXT NOT NULL CHECK (modelId != ''),
            description TEXT,
            symptoms TEXT,
            repairMethods TEXT,
            FOREIGN KEY (id) REFERENCES RepairModels(id) ON DELETE CASCADE
        )";
        command.ExecuteNonQuery();
    }

    public void AddFaultType(FaultTypeModel faultType)
    {
        var command = _connection.CreateCommand();
        command.CommandText = @"INSERT INTO FaultTypes VALUES($id, $modelId, $description, $symptoms, $repairMethods)";
        command.Parameters.AddWithValue("$id", faultType.Id);
        command.Parameters.AddWithValue("$modelId", faultType.ModelId);
        command.Parameters.AddWithValue("$description", faultType.Description);
        command.Parameters.AddWithValue("$symptoms", faultType.Symptoms);
        command.Parameters.AddWithValue("$repairMethods", faultType.RepairMethods);
        command.ExecuteNonQuery();
    }

    public void DeleteFaultType(FaultTypeModel faultType)
    {
        var command = _connection.CreateCommand();
        command.CommandText = @"DELETE FROM FaultTypes WHERE id = $id";
        command.Parameters.AddWithValue("$id", faultType.Id);
        command.ExecuteNonQuery();
    }

    public ObservableCollection<FaultTypeModel> ReadFaultTypes()
    {
        var command = _connection.CreateCommand();
        command.CommandText = "SELECT * FROM FaultTypes";
        var list = new ObservableCollection<FaultTypeModel>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new FaultTypeModel(
                reader.GetString(reader.GetOrdinal("id")),
                reader.GetString(reader.GetOrdinal("modelId")),
                reader.GetString(reader.GetOrdinal("description")),
                reader.GetString(reader.GetOrdinal("symptoms")),
                reader.GetString(reader.GetOrdinal("repairMethods"))
                ));
        }
        return list;
    }
    
}