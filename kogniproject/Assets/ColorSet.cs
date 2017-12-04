using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSet{

    public static List<TileColor> colors = new List<TileColor>()
    {
        {new TileColor(new Color(237, 45, 0), 'r') },
        {new TileColor(new Color(0, 112, 237), 'b') },
        {new TileColor(new Color(81, 210, 3), 'g') },
        {new TileColor(new Color(250, 218, 0), 'l') },
        {new TileColor(new Color(191, 117, 0), 'w') },
        {new TileColor(new Color(174, 174, 174), 'y') },
        {new TileColor(new Color(210, 0, 203), 'p') }
    };
}
