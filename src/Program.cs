using System;
using System.Threading;
using System.Threading.Tasks;


Application.Run();

static class Application
{
    public static void Run()
    {
        var target = nameof(TestOne);
        Log($"Begin {target}");
        TestOne();
        Log($"End {target}");

        target = nameof(TestTwo);
        Log($"Begin {target}");
        TestTwo();
        Log($"End {target}");
    }

    static void TestOne()
    {
        Outer(() =>
        {
            Thread.Sleep(3_000);
        });
    }

    static void TestTwo()
    {
        Outer(async () =>
        {
            await Task.Delay(3_000);
        });
    }

    static void Outer(Action? action = null) => action?.Invoke();
    
    static void Log(params object[] objs)
    {
        var info = ThreadingInfo();

        Console.WriteLine($"{Now()} [{info.ThreadId}-{info.TaskId}]: {string.Join(" | ", objs)}");

        static string Now() => $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}";

        static (int ThreadId, int TaskId) ThreadingInfo()
        {
            return (Thread.CurrentThread.ManagedThreadId, Task.CurrentId ?? 0);
        }
    }
}




