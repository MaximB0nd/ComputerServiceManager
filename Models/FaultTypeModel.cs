using CommunityToolkit.Mvvm.ComponentModel;

namespace ComputerService.Models;

public class FaultTypeModel
{
    public string Id { get; set; }
    public string ModelId { get; set; }
    public string Description { get; set; }
    public string Symptoms { get; set; }
    public string RepairMethods { get; set; }

    public FaultTypeModel(string id, string modelId, string description, string symptoms, string repairMethods)
    {
        Id = id;
        ModelId = modelId;
        Description = description;
        Symptoms = symptoms;
        RepairMethods = repairMethods;
    }
}