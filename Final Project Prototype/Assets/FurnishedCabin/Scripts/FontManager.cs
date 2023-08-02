using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontManager : MonoBehaviour
{
    public static GUIStyle guiStyle { get; private set; }
    public static GUIStyle yellowStyle { get; private set; }

    static FontManager()
    {
        InitializeStyles();
    }

    static void InitializeStyles()
    {
        guiStyle = new GUIStyle();
        guiStyle.fontSize = 16;
        guiStyle.fontStyle = FontStyle.Bold;
        guiStyle.normal.textColor = Color.white;

        yellowStyle = new GUIStyle();
        yellowStyle.fontSize = 16;
        yellowStyle.fontStyle = FontStyle.Italic;
        yellowStyle.normal.textColor = Color.yellow;
    }
}
