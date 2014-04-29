using UnityEngine;
using System.Collections.Generic;

public class ResultsMenu : MonoBehaviour
{
    public GUIStyle style;

    private List<string> achievements;

    void Start()
    {
        achievements = new List<string>();

        // Achievements (based off of data collection stored in StaticGameVars)
        if (StaticGameVars.score == 25)
        {
            achievements.Add("Perfect Game!!");
        }

        if (StaticGameVars.lobCount > 5)
        {
            achievements.Add("Lobbyist");
        }
    }

    void OnGUI()
    {
        // Final Score
        GUI.Label(new Rect(Screen.width * 0.5f, Screen.height * 0.5f - 105.0f, 100.0f, 50.0f), StaticGameVars.score.ToString(), style);

        for (int i = 0; i < achievements.Count; i++)
        {
            GUI.Label(new Rect(Screen.width * 0.5f, Screen.height * 0.48f + (i * 55.0f), 100.0f, 50.0f), achievements[i], style);
        }

        if (GUI.Button(new Rect(Screen.width * 0.20f, Screen.height * 0.85f, 200.0f, 50.0f), "Restart"))
        {
            StaticGameVars.levelIndex = 0;
            Application.LoadLevel(0);
        }

        if (GUI.Button(new Rect(Screen.width * 0.35f, Screen.height * 0.85f, 200.0f, 50.0f), "Quit"))
        {
            Application.Quit();
        }
    }
}
