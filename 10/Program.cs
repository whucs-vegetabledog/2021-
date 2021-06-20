using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerTest {

  class TimerState {
    public int count = 0;
  }

  class App {
    public static void Main() {
      TimerState s = new TimerState();
      Timer timer = new Timer(Tick, s, 1000, 500);
      Console.ReadKey();
      timer.Dispose();
      Console.WriteLine("counter=" + s.count);
      Console.ReadKey();
    }

    //定时调用的方法
    static void Tick(object state) {
      TimerState s = state as TimerState;
      if (s != null) {
        s.count++;
      }
      Console.WriteLine($"{DateTime.Now}: count={s.count}");
    }
  }
}
