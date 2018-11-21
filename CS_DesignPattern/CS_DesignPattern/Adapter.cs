using System;

namespace CS_DesignPattern
{
    internal class Adapter
    {
        public Adapter()
        {
        }

        public void Main()
        {
            Print p = new PrintBanner("Hello");
            p.PrintWeak();
            // => (Hello)
            p.PrintStrong();
            // => *Hello*

            // 実行が一瞬で終わって確認できないので、キーの入力を待ちます
            Console.ReadLine();
        }
    }

    // このクラスは既に提供されているものとします
    // Adaptee
    public class Banner
    {
        private string str;
        public Banner(string str)
        {
            this.str = str;
        }
        public void ShowWithPattern()
        {
            Console.WriteLine($"({str})");
        }
        public void ShowWithAster()
        {
            Console.WriteLine($"*{str}*");
        }
    }

    // Target
    public interface Print
    {
        void PrintWeak();
        void PrintStrong();
    }

    // Adapter
    public class PrintBanner : Banner, Print
    {
        public PrintBanner(string str) : base(str) { }
        public void PrintWeak()
        {
            ShowWithPattern();
        }
        public void PrintStrong()
        {
            ShowWithAster();
        }
    }

}