using UnityEngine;
using System.Collections;

public class GUIOverlay : MonoBehaviour
{
    //------- PUBLICS -----------
    // Reference to Cannon Script
    public CannonBehavior cannon;

    public GUIStyle style;

    //------- PRIVATES -----------
    // Holds the initial velocity variable the user inputs
    private float initialVelocity = 0f;
    private string initialVelocityString = "";

    // Holds the angle variable the user inputs
    private float angle = 0f;
    private string angleString = "";

    // Is help menu enabled (GUI)
    private bool helpMenu = false;

    void OnGUI()
    {
        //------------------ Cannon Settings GUI --------------------------------------------------
        if (StaticGameVars.guiSettingsEnabled)
        {
            // Make a GUILayout area at the bottom left
            GUILayout.BeginArea(new Rect(10.0f, Screen.height - 90.0f, 175.0f, 100.0f));

            // The vertical consists of the two textfields
            GUILayout.BeginVertical("box");

            // Begin Angle textfield
            GUILayout.BeginHorizontal();
            GUILayout.Label("Angle", style);

            // Parse float input in angle textfield
            angleString = GUILayout.TextField(angleString, GUILayout.MaxWidth(75));
            float angleOut;
            if (float.TryParse(angleString, out angleOut))
            {
                angle = angleOut;
            }
            else if (angleString == "")
            {
                angle = 0f;
            }

            // End angle textfield
            GUILayout.EndHorizontal();

            // Begin initial velocity textfield
            GUILayout.BeginHorizontal();
            GUILayout.Label("Initial Velocity", style);

            // Parse float input in Initial Velocity textfield
            initialVelocityString = GUILayout.TextField(initialVelocityString, GUILayout.MaxWidth(75));
            float initialVelocityOut;
            if (float.TryParse(initialVelocityString, out initialVelocityOut))
            {
                initialVelocity = initialVelocityOut;
            }
            else if (initialVelocityString == "")
            {
                initialVelocity = 0f;
            }

            // End initial velocity textfield
            GUILayout.EndHorizontal();

            // End the vertical
            GUILayout.EndVertical();

            // Start button starts the simulation
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Start"))
            {
                StaticGameVars.guiSettingsEnabled = false;
                cannon.Fire();
            }
            GUILayout.EndHorizontal();

            // End Area
            GUILayout.EndArea();

            if (GUI.changed)
            {
                cannon.SetAngle(angle);
                cannon.SetVelocity(initialVelocity);
            }
        }
        //---------------- End of Cannon Settings GUI ---------------------------------------------


        //-------------------- Info GUI ---------------------------------------------------
        // Create a new GUI area at the top left
        GUILayout.BeginArea(new Rect(10.0f, 10.0f, 175.0f, 100.0f));

        GUILayout.BeginVertical("box");

        // Includes the score (i.e. how many times projectile hit the target)
        GUILayout.BeginHorizontal();
        GUILayout.Label("Score", style);
        GUILayout.Label(StaticGameVars.score.ToString(), style);
        GUILayout.EndHorizontal();

        // How many shots remaining before restart
        GUILayout.BeginHorizontal();
        GUILayout.Label("Shots", style);
        GUILayout.Label(StaticGameVars.shots.ToString(), style);
        GUILayout.EndHorizontal();

        GUILayout.EndVertical();

        // Help button. Toggles the help menu (see below)
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Help"))
        {
            helpMenu = !helpMenu;
        }
        GUILayout.EndHorizontal();

        // End info area
        GUILayout.EndArea();
        //------------------ End of Info GUI -----------------------------------------------------


        //--------------------- Help Menu ---------------------------------------------------------
        if (helpMenu)
        {
            // Create new GUI area in the center of screen (should disable elements in background)
            GUILayout.BeginArea(new Rect(Screen.width * 0.5f - 375.0f, Screen.height * 0.5f - 250.0f, 750.0f, 500.0f));

            GUI.skin.settings.cursorFlashSpeed = 0;

            GUILayout.TextArea("Arc-Cannon is a conceptual, projectile motion game meant to teach the relationships between initial velocity, angle, " +
                               "distance, and height.\n" +
                               "Set the angle of the cannon to your desired angle (something that seems appropriate given the problem), " +
                               "then set the initial velocity. A projectile will fire and leave a trail to mark it's path. If you hit the target, " +
                               "the trail goes away and the next problem will be presented.\n" +
                               "You start out with three shots. If you use all your shots, it's game over. Every shot you don't use gets added to your score. " +
                               "Also, 3 more shots get added at the end of each scenario.");

            GUILayout.EndArea();
        }
        //------------------ End of Help Menu -----------------------------------------------------
    }
}
