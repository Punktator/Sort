// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

namespace Sort;

class Program
{
    static internal void Main()
    {
        TimeSpan t1, t2;
        Stopwatch czasomierz = new();
        Console.WriteLine("Podaj rozmiar tablicy");
        uint rozmiar = Convert.ToUInt32(Console.ReadLine());
        var test = new InterfejsSortowniczy(rozmiar);

        Console.WriteLine(test);

        Console.WriteLine();

        czasomierz.Start();
        test.Bombluj1();
        czasomierz.Stop();
        t1 = czasomierz.Elapsed;
        Console.WriteLine(test);
        Console.WriteLine();
        Console.Write("t1 = ");
        Console.WriteLine(t1);
        Console.WriteLine(test.CzyPosortowaneNiemalejonco());

        Console.WriteLine();

        test.WypelnijLosowo();
        czasomierz.Restart();
        test.Bombluj2();
        czasomierz.Stop();
        t2 = czasomierz.Elapsed;
        Console.WriteLine(test);
        Console.WriteLine();
        Console.Write("t2 = ");
        Console.WriteLine(t2);
    }
}

internal abstract class InterfejsTablic
{
    protected int [] tab;
    protected Random RNG = new();

    internal void WypelnijLosowo()
    {
        for (uint i = 0; i < this.tab.Length; i++) 
        {
            this.tab[i] = RNG.Next(1000*this.tab.Length);
        }
    }

    public override string ToString()
    {
        return String.Join("\n", this.tab);
    }
}

internal class InterfejsSortowniczy : InterfejsTablic
{
    private bool flaga;

    public InterfejsSortowniczy(uint rozmiar) 
    {
        this.tab = new int[rozmiar];
        WypelnijLosowo();
    }

    internal void Bombluj1()
    {
        do
        {
            flaga = false;
            for (uint i = 0; i < this.tab.Length - 1; i++)
            {
                ZamienJesliWieksze(i);
            } 
        } while (flaga);
    }

    internal void Bombluj2()
    {
        do
        {
            flaga = false;
            for (uint i = 0; i  <= this.tab.Length - 1; i++)
            {
                ZamienJesliWieksze(i);
            }
            for (uint i = Convert.ToUInt32(this.tab.Length - 1); i > 0; i--)
            {
                ZamienJesliWieksze(i);
            }
        } while (flaga);
    }

    internal bool CzyPosortowaneNiemalejonco()
    {
        for (uint i = 0; i < this.tab.Length-1; i++)
        {
            if (this.tab[i] > this.tab[i + 1])
                return false;
        }

        return true;
    }

    private void ZamienJesliWieksze(uint i)
    {
        if (this.tab[i] > this.tab[i + 1])
        {
            (this.tab[i], this.tab[i + 1]) = (this.tab[i + 1], this.tab[i]);
            flaga = true;
        }
    }
}