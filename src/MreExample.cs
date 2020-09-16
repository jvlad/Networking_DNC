// private static ManualResetEvent mre = new ManualResetEvent(false);

    //     static void Main()
    //     {
    //         SayToConsole("Start 3 named threads that block on a ManualResetEvent:");

    //         for(int i = 0; i <= 2; i++)
    //         {
    //             Thread t = new Thread(ExecutableTask);
    //             t.Name = $"T{i}";
                
    //             mre.Set();
    //             Console.WriteLine("\nCalling mre.Reset");
    //             mre.Reset();
    //             t.Start();
    //         }

    //         Console.WriteLine("\nWhen all three threads have started, press Enter to call Set()" +
    //                       "\nto release all the threads.\n");
    //         Console.ReadLine();

    //         mre.Set();
    //         SayGoodbye();
    //     }

    //     private static void ExecutableTask()
    //     {
    //         string name = Thread.CurrentThread.Name;
    //         Console.WriteLine(name + " starts");
    //         if (name.Equals("T1")) {
    //             mre.WaitOne();
    //         }
    //         Console.WriteLine(name + " ends.");
    //     }

    //     private static void SayGoodbye()
    //     {
    //         Console.WriteLine(Thread.CurrentThread.Name + "Goodbye!");
    //     }

    //     private static void SayToConsole(string v)
    //     {
    //         Console.WriteLine($"\n{v}\n");
    //     }
    // }