using UnityEngine;
using System.Collections;

public class StaticGameVars : MonoBehaviour
{
    /// <summary>
    /// The game's score
    /// </summary>
    public static int score = 0;

    /// <summary>
    /// Cannon's shots remaining
    /// </summary>
    public static int shots = 3;

    /// <summary>
    /// Holds the index for the current level
    /// </summary>
    public static int levelIndex = 0;

    /// <summary>
    /// The number of lobs the player fires (angle > 45deg)
    /// </summary>
    public static int lobCount = 0;

    /// <summary>
    /// Are the gui cannon settings locked to the player or not
    /// </summary>
    public static bool guiSettingsEnabled = true;
}
