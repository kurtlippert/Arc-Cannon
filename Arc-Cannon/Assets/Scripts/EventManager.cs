using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    /// <summary>
    /// Call this method upon the arrow colliding into something
    /// </summary>
    /// <param name="arrow">The arrow object</param>
    /// <param name="collision">The 2D collision information</param>
    public static void ArrowCollision(GameObject arrow, Collision2D collision)
    {
        // First we want to get rid of the arrow trail
        Destroy(arrow.GetComponent<ProjectileTrail>());

        // Then, lets re-enable the gui settings
        StaticGameVars.guiSettingsEnabled = true;

        // If the arrow hits the target, increment the player's score based on the remaining shots, 
        // then proceed to the next level and reset shots. Otherwise, decrement the player's shots
        if (collision.gameObject.name.Equals("Target"))
        {
            StaticGameVars.score += StaticGameVars.shots;
            StaticGameVars.levelIndex += 1;
            Application.LoadLevel(StaticGameVars.levelIndex);
            StaticGameVars.shots += 2;
        }
        else
        {
            StaticGameVars.shots -= 1;
        }

        // If the player runs out of shots, reset the game (go back to level 1) and all the static game vars
        if (StaticGameVars.shots == 0)
        {
            Application.LoadLevel("Level_1");
            StaticGameVars.score = 0;
            StaticGameVars.shots = 3;
            StaticGameVars.levelIndex = 0;
            StaticGameVars.lobCount = 0;
        }
    }
}
