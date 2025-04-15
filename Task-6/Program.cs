using System;
using System.Threading;

// 1. Define delegate
public delegate void ThresholdReachedEventHandler(object sender, EventArgs e);

public class Counter
{
    private int _threshold;
    private int _count;

   // define event using delegate
    public event ThresholdReachedEventHandler ThresholdReached;
    public Counter(int t)
    {
        _threshold = t;
        _count = 0;
    }

    public void Increment()
    {
        _count++;
        Console.WriteLine($"Current Count:{_count}");
        if (_count >= _threshold)
        {
            OnThresholdReached(EventArgs.Empty);
        }
    }

    //invoke event
    protected virtual void OnThresholdReached(EventArgs e)
    {
        Console.WriteLine($"Threshold reached: {_threshold}");
        ThresholdReached?.Invoke(this, e);
    }

}

public class EventHandlers
{
    public void AlertFunc1(object sender, EventArgs e)
    {
        Console.WriteLine("Alert function 1 invoked, counter reached max value");
    }
    public void AlertFunc2(object sender, EventArgs e)
    {
        Console.WriteLine("Alert function 2 invoked , counter reached max value");
        Environment.Exit(0);
    }
}   

class Program
{
    static void Main(string[] args)
    {
        Counter obj = new Counter(10);
        EventHandlers eObj = new EventHandlers();

        //subscribe multiple handlers to the event
        obj.ThresholdReached += eObj.AlertFunc1;
        obj.ThresholdReached += eObj.AlertFunc2;

        //Console.WriteLine("Press Enter to increment counter.");
        while (true)
        {
            //Console.ReadLine();
            //counter.Increment();
            obj.Increment();
            Thread.Sleep(1000);
        }
    }
}
