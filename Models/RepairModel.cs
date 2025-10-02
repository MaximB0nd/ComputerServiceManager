namespace ComputerService.Models;

public class RepairModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Producer { get; set; }
    public string Properties { get; set; }
    public string Features { get; set; }

    public RepairModel(string id, string name, string type, string producer, string properties, string features)
    {
        Id = id;
        Name = name;
        Type = type;
        Producer = producer;
        Properties = properties;
        Features = features;
    }
}