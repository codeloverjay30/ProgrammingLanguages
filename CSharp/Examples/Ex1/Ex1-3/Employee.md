```csharp
[Atomicable]
public class Employee
{
    private string _name;
    public string Name { get {return _name;} set { value = _name;}}
    private atomic int _workingHours;
    public int WorkingHours { get {return _workingHours;} set { value = _workingHours;}}

    public Employee(string name,int workingHours){
        _name = name;
        _workingHours = workingHours; // atomic
    }
    public void Work(int hours){
        _workingHours += hours; // atomic
    }
    public int GetSalary()
    {
        return _workingHours * 200; // atomic
    }
}
```