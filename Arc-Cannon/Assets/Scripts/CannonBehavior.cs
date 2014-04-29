using UnityEngine;

public class CannonBehavior : MonoBehaviour
{
    public GameObject arrowPrefab;

    // Movement variables
    public bool enableMovement;
    public float speed;
    public float lowestPoint;       // How far down the cannon can go
    public float highestPoint;      // How far up the cannon can go

    // Keep track of velocity for when we fire the projectile
    private float velocity;

    void Update()
    {
        if (enableMovement)
        {
            Move();
        }
    }

    /// <summary>
    /// Adjusts cannon's rotation based on angle
    /// </summary>
    /// <param name="angle">float angle of cannon</param>
    public void SetAngle(float angle)
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, angle);
    }

    /// <summary>
    /// Set velocity of projectile to be fired from the cannon
    /// </summary>
    /// <param name="velocity">float velocity of projectile</param>
    public void SetVelocity(float velocity)
    {
        this.velocity = velocity;
    }

    /// <summary>
    /// Fires projectile
    /// </summary>
    public void Fire()
    {
        // The starting conditions (the position and angle of the 'gun' object)
        Vector3 startPos = transform.position;
        Quaternion shotAngle = transform.rotation;

        // Create the arrow
        GameObject arrow = (GameObject)GameObject.Instantiate(arrowPrefab, startPos + transform.right * 2.0f, shotAngle);

        // Add a force to the arrow
        arrow.rigidbody2D.velocity = arrow.transform.right * velocity;

        // If the cannons angle is > 45deg, log a lob
        if (transform.localEulerAngles.z > 45.1f && transform.localEulerAngles.z < 135.0f)
        {
            Debug.Log("lob!!");
            StaticGameVars.lobCount += 1;
        }
    }

    /// <summary>
    /// Movement method for cannon. If a CannonTrack is present in the scene, this method is called.
    /// </summary>
    void Move()
    {
        /*if (Input.GetAxis("Vertical") > 0)
        {
            transform.Translate(new Vector3(0.0f, speed, 0.0f));
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            transform.Translate(new Vector3(0.0f, -speed, 0.0f));
        }*/
        //Debug.Log(transform.position.y);
        /*if (transform.position.y > lowestPoint && transform.position.y < highestPoint)
        {
            transform.Translate(new Vector3(0.0f, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0.0f), Space.World);
        }
        else
        {
            Debug.Log("firing");
        }*/

        if (Input.GetAxis("Vertical") > 0 && transform.position.y < highestPoint)
        {
            transform.Translate(new Vector3(0.0f, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0.0f), Space.World);
        }
        else if (Input.GetAxis("Vertical") < 0 && transform.position.y > lowestPoint)
        {
            transform.Translate(new Vector3(0.0f, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0.0f), Space.World);
        }
    }
}
