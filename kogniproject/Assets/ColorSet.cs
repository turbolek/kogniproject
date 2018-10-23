using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSet{

    public static List<TileColor> colors = new List<TileColor>()
    {
        {new TileColor(new Color32(179, 57, 57, 255), 'r') },
        {new TileColor(new Color32(52, 66, 112, 255), 'b') },
        {new TileColor(new Color32(98, 155, 35, 255), 'g') },
        {new TileColor(new Color32(255, 201, 14, 255), 'l') },
        {new TileColor(new Color32(109, 70, 30, 255), 'w') },
        {new TileColor(new Color32(174, 174, 174, 255), 'y') },
        {new TileColor(new Color32(157, 81, 152, 255), 'p') }
    };
}
