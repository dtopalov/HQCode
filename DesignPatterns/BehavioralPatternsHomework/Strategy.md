# Behavioral Patterns

## Strategy/Стратегия

 * Енкапсулира група свързани алгоритми, позволявайки на алгоритъма да варира, независимо от класа, който го използва
 * Използва се в случаи, в които в кода има switch или if-else конструкции, както и когато добавянето на нова операция би довело до модификация на класа
 * Позволява лесната замяна на даден алгоритъм с друг, като всички алгоритми работят с едни и същи данни, а клиентът може да си избере с кой алгоритъм да работи

Целта на шаблона е да се дефинират алгоритми, които решават един и същ проблем, но по различни начини. Тези алгоритми се правят взаимно заменяеми, за да може да се променя поведението на класа, който ги използва по време на изпълнение на програмата, в зависимост от желания резултат.

## Клас диаграма:

![Factory method](http://www.dofactory.com/images/diagrams/net/strategy.gif)

Компоненти:

 * *__Strategy:__*
   * декларира общ за всички поддържани алгоритми интерфейс. *Context* използва този интерфейс, за да извиква алгоритъма, дефиниран от *ConcreteStrategy*
 * *__ConcreteStrategy:__*
   * имплементира алгоритъма, използвайки интерфейса *Strategy*
 * *__Context:__*
   * конфигуриран е с *ConcreteStrategy* обект
   * Поддържа референция към *Strategy* обект
   * може да дефинира интерфейс, който позволява на *Strategy* да достъпва данните му

Примерен код:

```
class Program
{
   static void Main()
   {
      ISortingStrategy sortingStrategy = null;

      //Sorting the countyResidents
      List<string> countyResidents = new List<string>{ "ad","ac", "ax", "zw" };
      sortingStrategy = GetSortingOption(ObjectToSort.CountyResidents);
      sortingStrategy.Sort(countyResidents);

      //Sorting student numbers

      List<int> studentNumbers = new List<int>{ 123,678,543,  189};
      sortingStrategy = GetSortingOption(ObjectToSort.StudentNumber);
      sortingStrategy.Sort(studentNumbers);
      
      
      //Sorting railway passengers      
      List<string> railwayPassengers = new List<string> { "A21", "Z2", "F3", "G43" };
      sortingStrategy = GetSortingOption(ObjectToSort.RailwayPassengers);
      sortingStrategy.Sort(railwayPassengers);

    }

   private static ISortingStrategy GetSortingOption(ObjectToSort objectToSort)
   {
      ISortingStrategy sortingStrategy = null;

      switch (objectToSort)
      {
         case ObjectToSort.StudentNumber:
              sortingStrategy = new MergeSort();              
              break;
         case ObjectToSort.RailwayPassengers:
              sortingStrategy = new HeapSort();
              break;
         case ObjectToSort.CountyResidents:
              sortingStrategy = new QuickSort();
              break;
         default:
                    break;
      }
      return sortingStrategy;
   }
}
// Enum for different types of sortings.

Hide   Copy Code
public enum ObjectToSort
{
   StudentNumber,
   RailwayPassengers,
   CountyResidents
}
// Interface for the sorting strategy.

Hide   Copy Code
public interface ISortingStrategy 
{
   void Sort<T>(List<T> dataToBeSorted);
}
// Algorithm-Quicksort.

Hide   Copy Code
public class QuickSort : ISortingStrategy
{
   #region ISortingStrategy Members
      public void Sort<T>(List<T> dataToBeSorted)
      {
        //Logic for quick sort
      }
   #endregion
}
// Algorithm-Mergesort.

Hide   Copy Code
public class MergeSort : ISortingStrategy
{
   #region ISortingStrategy Members
      public void Sort<T>(List<T> dataToBeSorted)
      {
         //Logic for Merge sort
      }
   #endregion
}
// Algorithm-Heapsort.

Hide   Copy Code
public class HeapSort : ISortingStrategy
{
   #region ISortingStrategy Members
      public void Sort<T>(List<T> dataToBeSorted)
      {
         //Logic for Heap sort
      }
   #endregion
}
```
This is [on GitHub](https://github.com/dtopalov/HQCode/blob/master/DesignPatterns/BehavioralPatternsHomework/Strategy.md).