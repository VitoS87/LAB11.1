using System.Reflection.Emit;
using System.Runtime.CompilerServices;

Console.Write("Введите наименование товара:");
string name = Console.ReadLine()!;
Console.Write("Введите цену товара:");
double price = double.Parse(Console.ReadLine()!);
Console.Write("Введите количество товара:");
double count = double.Parse(Console.ReadLine()!);
Product product1 = new Product(name, price, count);
Console.WriteLine(product1);
Console.WriteLine("Введите год выпуска: ");
double year = double.Parse(Console.ReadLine()!);
double cyear = DateTime.Now.Year;
SuperProduct product2 = new SuperProduct(name, price, count, year, cyear);
Console.WriteLine(product2);
class Product
{
    private string? name;
    private double price;
    private double count;
    public Product(string? _name, double _price, double _count)
    {
        this.name = _name;
        this.price = _price;
        this.count = _count;
    }
    public string? Name
    {
        get { return name; }
        set { name = value; }
    }
    public double Price
    {
        get { return price; }
        set { price = value; }
    }
    public double Count
    {
        get { return count; }
        set { count = value; }
    }
    public virtual double Quality()
    {
        return price / count;
    }
    public override string? ToString()
    {
        return $"Товар с наименованием {name}, c ценой в {price}" +
            $" и количеством {count} - имеет качество: {Quality():F2}";
    }
}
class SuperProduct : Product
{
    public double year;
    public double cyear;
    public SuperProduct(string? _name, double _price, double _count, double _year, double _cyear) : base(_name, _price, _count)
    {
        year = _year;
        cyear = _cyear;
    }
    public double Year
    {
        get { return year; }
        set { year = value; }
    }
    public double Cyear
    {
        get { return cyear; }
        set { cyear = value; }
    }
    public override double Quality()
    {
        return base.Quality() + 0.5*(Cyear-Year);
    }
    public override string? ToString()
    {
        return $"Товар с наименованием {Name}, c ценой в {Price}" +
            $", количеством в {Count} и годом выпуска {year} - "+ 
            $"имеет качество:{Quality():F2}";
    }
}   