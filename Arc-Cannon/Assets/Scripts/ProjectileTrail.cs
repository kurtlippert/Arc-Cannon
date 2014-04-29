using UnityEngine;

/// <summary>
/// Attach this script to the object you want to leave a trail behind
/// </summary>
public class ProjectileTrail : MonoBehaviour
{
    public GameObject[] ticks;
    public float interval;

    private Vector2 lastPos;
    private Vector2 currPos;

    void Update()
    {
        currPos = this.transform.position;
        if (Vector2.Distance(currPos, lastPos) > interval)
        {
            GameObject.Instantiate(ticks[Random.Range(0, ticks.Length)], this.transform.position, this.transform.rotation);
            lastPos = currPos;
        }
    }
}
