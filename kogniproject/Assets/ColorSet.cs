using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSet{

    public static List<TileColor> colors = new List<TileColor>()
    {
        {new TileColor(new Color32(255, 0, 0, 255), 'r') },
        {new TileColor(new Color32(0, 112, 237, 255), 'b') },
        {new TileColor(new Color32(81, 210, 3, 255), 'g') },
        {new TileColor(new Color32(250, 218, 0, 255), 'l') },
        {new TileColor(new Color32(191, 117, 0, 255), 'w') },
        {new TileColor(new Color32(174, 174, 174, 255), 'y') },
        {new TileColor(new Color32(210, 0, 203, 255), 'p') }
    };
}
