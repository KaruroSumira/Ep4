using System;
using UnityEngine;

public class CVector2
{
    public float a { get; set; }
    public float b { get; set; }

    public CVector2(float a, float b)
    {
        this.a = a;
        this.b = b;
    }

    public static float Magnitud(CVector2 x)
    {
        return Mathf.Sqrt(x.a * x.a + x.b * x.b);
    }

    public static float Distancia(CVector2 a, CVector2 b)
    {
        CVector2 diff = b - a;
        return CVector2.Magnitud(diff);
    }

    public static CVector2 Normaliza(CVector2 a)
    {
        float m = CVector2.Magnitud(a);
        if (m == 0)
        {
            return new CVector2(float.NaN, float.NaN);
        }
        return new CVector2(a.a / m, a.b / m);
    }

    public static CVector2 operator -(CVector2 a, CVector2 b)
    {
        return new CVector2(a.a - b.a, a.b - b.b);
    }

    public override string ToString()
    {
        return $"CVector2(a: {a}, b: {b})";
    }
}
