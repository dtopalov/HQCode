# Creational Patterns

## Factory method/Метод фабрика

 * Дефинира интерфейс за създаването на обект, но оставя на подкласовете да решат кой клас да инстанцират.
 * Позволява добавянето на нови фабрики и класове, без да се нарушава Open/Closed принципа.

Фабриката служи за инстанцирането на различни обекти, чиито типове не са предефинирани. Обектите се създават динамично в зависимост от подадените на фабриката параметри. 

Класът-фабрика съдържа метод, който позволява определянето на създавания тип по време на изпълнение на програмата.

По принцип фабриките са единствени в дадена програма, затова за създаването им често се използва шаблонът Сек (Singleton).

## Клас диаграма:

![Factory method](http://www.codeproject.com/KB/architecture/430590/Factory_Method.jpg)

Компоненти:

 * *__FactoryBase:__* Това е абстрактен клас за конкретните класове-фабрики, които ще връщат нови обекти. В някои случаи може да е прост интерфейс, съдържащ сигнатурата на метода-фабрика. Този клас съдържа метод-фабрика (*FactoryMethod*), който връща обект *ProductBase*.
 * *__ConcreteFactory:__* Конкретната имплементация на фабриката. Обикновено този клас оувъррайдва *FactoryMethod*-а и връща обект *ConcreteProduct*.
 * *__ProductBase:__* Базов клас за всички продукти, създавани от конкретни фабрики. В някои случай може да е прост интерфейс.
 * *__ConcreteProduct:__* Конкретна имплементация на *ProductBase*, която може да съдържа специфична функционаност. Тези обекти се създават от методи фабрика.

Примерен код:

```
public interface ICarFactory
{
    Car CreateCar();
}

public abstract class Car
{
    public string Model { get; set; }
    public string Engine { get; set; }
    public string Transmission { get; set; }
    public int Doors { get; set; }
    public List<string> Accessories = new List<string>();
    
    public abstract void ShowInfo();
}

public class MercedesFactory:ICarFactory
{
    public Car CreateCar()
    {
        return new Mercedes("Some model", "Engine type", "Transmission type", 4);
    }
}

public class BMWFactory:ICarFactory
{
    public Car CreateCar()
    {
        return new BMW("Some model", "Engine type", "Transmission type", 4);
    }
}

public class Mercedes:Car
{
    public Mercedes(string model, string engine, string transmission, int doors)
    {
        Model = model;
        Engine = engine;
        Transmission = transmission;
        Doors = doors;
        Accessories.Add("Leather Look Seat Covers");
        Accessories.Add("Chequered Plate Racing Floor");
        Accessories.Add("Car Cover");
        Accessories.Add("Sun Shade");
    }

    public override void ShowInfo()
    {
        Console.WriteLine("Model: {0}", Model);
        Console.WriteLine("Engine: {0}", Engine);
        Console.WriteLine("Doors: {0}", Doors);
        Console.WriteLine("Transmission: {0}", Transmission);
        Console.WriteLine("Accessories:");
        foreach (var accessory in Accessories)
        {
            Console.WriteLine("\t{0}", accessory);
        }
    }
}

public class BMW:Car
{
    public BMW(string model, string engine, string transmission, string body, int doors)
    {
        Model = model;
        Engine = engine;
        Transmission = transmission;
        Doors = doors;
        Accessories.Add("Leather Look Seat Covers");
        Accessories.Add("Chequered Plate Racing Floor");
        Accessories.Add("4x 200 Watt Coaxial Speekers");
        Accessories.Add("500 Watt Bass Subwoofer");
    }

    public override void ShowInfo()
    {
        Console.WriteLine("Model: {0}", Model);
        Console.WriteLine("Engine: {0}", Engine);
        Console.WriteLine("Doors: {0}", Doors);
        Console.WriteLine("Transmission: {0}", Transmission);
        Console.WriteLine("Accessories:");
        foreach (var accessory in Accessories)
        {
            Console.WriteLine("\t{0}", accessory);
        }
    }
}
```
This is [on GitHub](https://github.com/dtopalov/HQCode/blob/master/DesignPatterns/CreationalPatterns/factory-method.md).