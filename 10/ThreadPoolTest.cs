using System;
using System.IO;
using System.Threading;


class Test {
  static void Main() {
    Console.WriteLine("CPU count:" + Environment.ProcessorCount);
    ThreadPool.SetMaxThreads(2, 2); // 大于等于CPU核数, 2个工作线程、2个异步I/O线程
    ThreadPool.GetMaxThreads(out int workerThreads, out int ioThreads);
    Console.WriteLine($"workerThreads：{workerThreads},ioThreads：{ioThreads}");

    for (int i = 1; i < 20; i++) {
      ThreadPool.QueueUserWorkItem(new WaitCallback(Fun), i);
    }
    Console.ReadKey();
  }

  static void Fun(object obj) {
    int n = (int)obj;
    Console.WriteLine(
          $"当前值为：{n}," +
          $"线程ID={Thread.CurrentThread.ManagedThreadId}");
    Thread.Sleep(200);
  }



}
