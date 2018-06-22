# 说明

Timer 有2个

1. System.Threading.Timer

    `new Timer (obj => Console.Write ("hello"), new Object(), 0, 1000);`

    0毫秒后启动,间隔1000毫秒运行 obj => Console.Write ("hello") , 其中obj 由第2个参数 new Object() 控制，通过 Dispose 可停止实例。

    适用于一次性的任务

1. System.Timers.Timer

    ```csharp
    Timer timer = new Timer(1000);
    timer.Elapsed += (o, e) => Console.WriteLine("hello");
    timer.Start ();
    ```

    实例化Timer的时候指定定时时间，Elapsed 指的Timer执行的方法。只有手动调用Start 才会开始。通过 timer.Stop 可暂停实例。

    适用于反复暂停和启动的任务