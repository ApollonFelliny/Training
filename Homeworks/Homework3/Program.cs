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
}
class Program
{
    static void Main(string[] args)
    {
        double[] coeffs = { 1.0, 0.0, 2.0 };
        Polynomial p = new Polynomial(coeffs); // 1 + 2x^2

        Console.WriteLine(p);
    }
}
