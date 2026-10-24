using UnityEngine;

public static class ColorGenerator 
{
    public static Color GetRandomColor()
    {
        return Random.ColorHSV();
    }
}
