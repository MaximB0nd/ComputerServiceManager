namespace ComputerService.Models;

public struct SparePartModel
{
    public string id; 
    public string name;
    public string function;
    public string price;

    public SparePartModel(string id, string name, string function, string price)
    {
        this.id = id;
        this.name = name;
        this.function = function;
        this.price = price;
    }
}