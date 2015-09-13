# Creational Patterns

## 1. Prototype/Прототип

 * Шаблонът се използва за създаване на инстанции на даден клас чрез копиране (клониране) на вече съществуващ обект.
 * Определя видовете обекти за създаване чрез прототипна инстанция
 * Създава обекти с клониране на един от няколко предварително съхранени прототипа

Прототипът се използва, когато създаването на нова инстанция от даден клас отнема много време или усилия или за да се избегне сложна йерархия от класове тип Фабрика и съответните ѝ класове-продукти.

Шаблонът е удобен и за случаите, в които класовете за инстанциране се определят по време на изпълнение и състоянията на инстанциите на даден клас могат да са в ограничен и определен брой комбинации.

## Клас диаграма:

![Prototype pattern](http://www.codeproject.com/KB/architecture/430590/Prototype.jpg)

Компоненти:

 * *__Prototype:__* Абстрактен базов клас от обекти, които могат да бъдат клонирани. Класът съдържа единствен виртуален метод Clone(), който връща обект-прототип. .NET включва интерфейс ICloneable, който създава нова инстанция от даден клас със същата стойност като съществуващата инстанция.
 * *__ConcretePrototype:__* Този клас наследява базовия клас *Prototype* и съдържа допълнителна функционалност, като в същото време оувъррайдва метода Clone().

Примерен код: :+1:

```
using System;
using System.Collections.Generic;
 
namespace PrototypePattern
{
  /// <summary>
  /// MainApp startup class 
  /// Prototype Design Pattern.
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Entry point into console application.
    /// </summary>
    static void Main()
    {
      ColorManager colormanager = new ColorManager();
 
      // Initialize with standard colors
      colormanager["red"] = new Color(255, 0, 0);
      colormanager["green"] = new Color(0, 255, 0);
      colormanager["blue"] = new Color(0, 0, 255);
 
      // User adds personalized colors
      colormanager["angry"] = new Color(255, 54, 0);
      colormanager["peace"] = new Color(128, 211, 128);
      colormanager["flame"] = new Color(211, 34, 20);
 
      // User clones selected colors
      Color color1 = colormanager["red"].Clone() as Color;
      Color color2 = colormanager["peace"].Clone() as Color;
      Color color3 = colormanager["flame"].Clone() as Color;
    }
  }
 
  /// <summary>
  /// The 'Prototype' abstract class
  /// </summary>
  abstract class ColorPrototype
  {
    public abstract ColorPrototype Clone();
  }
 
  /// <summary>
  /// The 'ConcretePrototype' class
  /// </summary>
  class Color : ColorPrototype
  {
    private int _red;
    private int _green;
    private int _blue;

    public Color(int red, int green, int blue)
    {
      this._red = red;
      this._green = green;
      this._blue = blue;
    }
 
    // Create a shallow copy
    public override ColorPrototype Clone()
    {
      Console.WriteLine(
        "Cloning color RGB: {0,3},{1,3},{2,3}",
        _red, _green, _blue);
 
      return this.MemberwiseClone() as ColorPrototype;
    }
  }
 
  /// <summary>
  /// Prototype manager
  /// </summary>
  class ColorManager
  {
    private Dictionary<string, ColorPrototype> _colors =
      new Dictionary<string, ColorPrototype>();
 
    // Indexer
    public ColorPrototype this[string key]
    {
      get { return _colors[key]; }
      set { _colors.Add(key, value); }
    }
  }
}
```

This is [on GitHub](https://github.com/jbt/markdown-editor).