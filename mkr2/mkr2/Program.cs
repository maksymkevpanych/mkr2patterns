using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//В даному завданні доцільно використати шаблон Спостерігач
//тому, що цей шаблон дозволяє об'єктам  автоматично отримувати сповіщення про
//зміни стану іншого об'єкта  та реагувати на них.
interface IObserver
{
    void Update(string message);
}


class Device : IObserver
{
    private string name;

    public Device(string name)
    {
        this.name = name;
    }

    public void Update(string message)
    {
        if (name.ToLower() == "навушники")
        {
            Console.WriteLine("Навушники отримали звукове повідомлення");
        }
        else
        {
            Console.WriteLine($"{name} отримав повідомлення: {message}");
        }
        Console.WriteLine("\n");
    }
}


class Notification
{
    private List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Notify(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }
}

namespace mkr2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Device smartphone = new Device("Смартфон");
            Device watch = new Device("Годинник");
            Device headphones = new Device("Навушники");

           
            Notification notification = new Notification();

       
            notification.AddObserver(smartphone);
            notification.AddObserver(watch);
            notification.AddObserver(headphones);

           
            notification.Notify("Instagram :користувач user поставив вам лайк");
            notification.Notify("Classroom:нове завдання - МКР2,здати до 11:00");

            Console.ReadLine();
        }
    }
}
