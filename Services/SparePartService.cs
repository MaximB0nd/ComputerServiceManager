using System;
using System.Collections.ObjectModel;
using ComputerService.Models;
using Microsoft.Data.Sqlite;

namespace ComputerService.Services;

public class SparePartService
{
    public static SparePartService Shared = new SparePartService();
    
    private string _dbName;
    private SqliteConnection _connection;
    private SparePartService()
    {
        _dbName = "ServiceDatabase.db";
        _connection = new SqliteConnection("Data Source=" + _dbName);
        OpenConnection();
    }
    
    ~SparePartService()
    {
        _connection.Close();
    }

    private void OpenConnection()
    {
        _connection.Open();
        var command = _connection.CreateCommand();
        command.CommandText = @"
        CREATE TABLE IF NOT EXISTS SpaceParts(
            id TEXT PRIMARY KEY,
            name TEXT NOT NULL,
            price REAL NOT NULL CHECK(price > 0),
            functions TEXT NOT NULL
        )";
        command.ExecuteNonQuery();
    }

    public void AddSparePart(SparePartModel sparePart)
    {
        var command = _connection.CreateCommand();
        command.CommandText = "INSERT INTO SpaceParts values ($id, $name, $price, $functions)";
        command.Parameters.AddWithValue("$id", sparePart.Id);
        command.Parameters.AddWithValue("$name", sparePart.Name);
        command.Parameters.AddWithValue("$price", sparePart.Price);
        command.Parameters.AddWithValue("$functions", sparePart.Functions);
        command.ExecuteNonQuery();
        ReadSpaceParts();
    }

    public void DeleteSparePart(SparePartModel sparePart)
    {
        var command = _connection.CreateCommand();
        command.CommandText = "DELETE FROM SpaceParts WHERE id = $id";
        command.Parameters.AddWithValue("$id", sparePart.Id);
        command.ExecuteNonQuery();
        ReadSpaceParts();
    }

    public ObservableCollection<SparePartModel> ReadSpaceParts()
    {
        var command = _connection.CreateCommand();
        command.CommandText = "SELECT * FROM SpaceParts";
        var list = new ObservableCollection<SparePartModel>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new SparePartModel(
                reader.GetString(reader.GetOrdinal("id")),
                reader.GetString(reader.GetOrdinal("name")),
                reader.GetString(reader.GetOrdinal("functions")),
                reader.GetString(reader.GetOrdinal("price"))
                ));
        }
        return list;
    }
}