using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

class ParallelLoopMatrix {

  static Random rnd = new Random();

  static void Main(string[] args) {
    int m = 300, n = 400, t = 1000;
    double[,] matricA = new double[m, n];
    double[,] matricB = new double[n, t];
    double[,] result1 = new double[m, t];
    double[,] result2 = new double[m, t];
    InitMatrix(matricA);
    InitMatrix(matricB);
    InitMatrix(result1);
    InitMatrix(result2);

    Console.WriteLine("����˷�");
    Stopwatch sw = new Stopwatch();
    sw.Start();
    MultiMatrixNormal(matricA, matricB, result1);
    sw.Stop();
    Console.WriteLine("��ͨ������ʱ" + sw.ElapsedMilliseconds);

    sw.Restart();
    MultiMatrixParallel(matricA, matricB, result2);
    sw.Stop();
    Console.WriteLine("���з�����ʱ" + sw.ElapsedMilliseconds);

    bool ok = CompareMatrix(result1, result2);
    Console.WriteLine("����Ƿ���ͬ��" + ok);
  }


  static void InitMatrix(double[,] matric) {
    int m = matric.GetLength(0);
    int n = matric.GetLength(1);
    for (int i = 0; i < m; i++) {
      for (int j = 0; j < n; j++) {
        matric[i, j] = rnd.Next();
      }
    }
  }

  //��ͨ�㷨
  static void MultiMatrixNormal(double[,] 
      matricA,double[,] matricB, double[,] result) {

    int m = matricA.GetLength(0); //����A������
    int n = matricA.GetLength(1); //����A������
    int t = matricB.GetLength(1); //����B������

    for (int i = 0; i < m; i++) {
      for (int j = 0; j < t; j++) {
        double temp = 0;
        for (int k = 0; k < n; k++) {
          temp += matricA[i, k] * matricB[k, j];
        }
        result[i, j] = temp;
      }
    }
  }

  //�����㷨
  static void MultiMatrixParallel(double[,] matricA, 
      double[,] matricB, double[,] result) {

    int m = matricA.GetLength(0);
    int n = matricA.GetLength(1);
    int t = matricB.GetLength(1);

    //����Aÿһ�д���һ������Ȼ����ִ��
    Parallel.For(0, m, i => {
      for (int j = 0; j < t; j++) {
        double temp = 0;
        for (int k = 0; k < n; k++) {
          temp += matricA[i, k] * matricB[k, j];
        }
        result[i, j] = temp;
      }
    });
  }


  static bool CompareMatrix(double[,] matA, double[,] matB) {
    int m = matA.GetLength(0);
    int n = matA.GetLength(1);
    for (int i = 0; i < m; i++) {
      for (int j = 0; j < n; j++) {
        if (Math.Abs(matA[i, j] - matB[i, j]) > 0.1) return false;
      }
    }
    return true;
  }
}