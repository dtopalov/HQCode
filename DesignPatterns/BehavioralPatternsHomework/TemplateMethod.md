# Behavioral Patterns

## Template Method/Шаблонен Метод

 * Дефинира основата на даден алгоритъм, като оставя част от конкретната на имплементация на някои от методите на наследниците
 * Дава възможност на наследниците да предефинират имплементацията на част от методите, разчитайки на наследствеността, но не позволява да бъде променяна структурата на алгоритъма

Шаблонният метод позволява разделянето на имплементацията на алгоритъм на 2 нива. Логиката на алгоритъма е реализирана в базов родителски клас, а поведението на обектите в стъпките, специфични за конкретните наследници, е оставено за имплементация в самите тях.

## Клас диаграма:

![Factory method](http://www.oodesign.com/images/design_patterns/behavioral/template_method_implementation_-_uml_class_diagram.gif)

Компоненти:

 * *__AbstractClass:__* Този клас съдържа основно два типа методи. Първият са отделните  стъпки на алгоритъма, а вторият - самият шаблонен метод, който използва останалите отделни методи и предоставя скелет за изпълнение на цялостния алгоритъм.
 * *__ConcreteClass:__* Този клас съдържа специфичната имплементация на методите - стъпки от алгоритъма, декларирани като абстрактни в базовия *AbstractClass*. 

Примерен код:

```
public class Trip {
        public void performTrip(){
                 travelToDestination();
                 doDayOneActivities();
                 doDayTwoActivities();
                 doDayThreeActivities();
                 travelBack();
        }
        public abstract void travelToDestination();
        public abstract void doDayOneActivities();
        public abstract void doDayTwoActivities();
        public abstract void doDayThreeActivities();
        public abstract void travelBack();
}

public class PackageA : Trip {
        public override void travelToDestination() {
                 Console.WriteLine("The tourists are travelling by plane ...");
        }
        public override void doDayOneActivities() {
                 Console.WriteLine("The tourists are visiting the aquarium ...");
        }
        public override void doDayTwoActivities() {
                 Console.WriteLine("The tourists are going to the beach ...");
        }
        public override void doDayThreeActivities() {
                 Console.WriteLine("The tourists are going to the mountains ...");
        }
        public override void travelBack() {
                 Console.WriteLine("The tourists are travelling back home by plane ...");
        }
}
public class PackageB : Trip {
        public override void travelToDestination() {
                 Console.WriteLine("The tourists are travelling by train ...");
        }
        public override void doDayOneActivities() {
                 Console.WriteLine("The tourists are visiting the museum ...");
        }
        public override void doDayTwoActivities() {
                 Console.WriteLine("The tourists are visiting the medieval castle ...");
        }
        public override void doDayThreeActivities() {
                 Console.WriteLine("The tourists are going to the zoo ...");
        }
        public override void travelBack() {
                 Console.WriteLine("The tourists are travelling home by train ...");
        }
}
```
This is [on GitHub](https://github.com/dtopalov/HQCode/blob/master/DesignPatterns/BehavioralPatternsHomework/TemplateMethod.md).