using CommunityToolkit.Mvvm.ComponentModel;

namespace ComputerService.Models;

public class SparePartModel: ObservableObject
{
    public string Id {get; set;}
    public string Name {get; set;}
    public string Functions {get; set;}
    public string Price {get; set;}

    public SparePartModel(string id, string name, string function, string price)
    {
        this.Id = id;
        this.Name = name;
        this.Functions = function;
        this.Price = price;
    }
}