using System;
class Polynomial
{
    private int degree;
    private double[] coefs;
    public Polynomial()
    {
        this.degree = 0;
        this.coefs = new double[] { 0 };
    }
    public Polynomial(double[] new_coefs)
    {
        this.degree = new_coefs.Length - 1;
        this.coefs = (double[])new_coefs.Clone();
    }
    public int Degree
    {
        get { return degree; }
    }
    public double[] Coefs
    {
        get { return (double[])this.coefs.Clone(); }
    }
    public override string ToString()
    {
        string result = "";
        for (int i = 0; i < coefs.Length; i++)
        {
            double coef = coefs[i];
            if (coef == 0) continue;

            if (result != "" && coef > 0) result += " + ";
            if (result != "" && coef < 0) result += " - ";
            if (result == "" && coef < 0) result += "-";

            double absCoef = Math.Abs(coef);
            if (i == 0)
            {
                result += absCoef;
            }
            else if (i == 1)
            {
                if (absCoef == 1) result += "x";
                else result += absCoef + "x";
            }
            else
            {
                if (absCoef == 1) result += "x^" + i;
                else result += absCoef + "x^" + i;
            }
        }
        if (result == "") return "0";
        return result;
    }
    public static Polynomial operator +(Polynomial p1, Polynomial p2)
    {
        int maxlen = Math.Max(p1.coefs.Length, p2.coefs.Length);
        double[] result = new double[maxlen];

        for (int i = 0; i < maxlen; i++)
        {
            double coef1 = (i < p1.coefs.Length) ? p1.coefs[i] : 0;
            double coef2 = (i < p2.coefs.Length) ? p2.coefs[i] : 0;
            result[i] = coef1 + coef2;
        }
        return new Polynomial(result);
    }
    public static Polynomial operator *(Polynomial p, double k)
    {
        double[] results = new double[p.coefs.Length];
        for(int i =0; i < p.coefs.Length; i++)
        {
            results[i] = p.coefs[i] * k;
        }
        return new Polynomial(results);
    }
}
class Program
{
    static void Main(string[] args)
    {
        double k = Convert.ToDouble(Console.ReadLine());
        double[] coeffs = { 1.0, 1.0, 2.0 };
        Polynomial p1 = new Polynomial(coeffs); // 1 + x + 2x^2

        double[] coeffs1 = { 3.0, 1.0, 1.0 };
        Polynomial p2 = new Polynomial(coeffs1); // 3 + x + x^2
        Console.WriteLine(p1);
        Console.WriteLine();
        Console.WriteLine(p1 * k);
        Console.WriteLine();
        Console.WriteLine(p2);
        Console.WriteLine();
        Console.WriteLine(p2 * k);
        Console.WriteLine();
        Console.WriteLine(p1+p2);
    }
}