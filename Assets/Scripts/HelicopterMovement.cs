using UnityEngine;
using System.Collections;

public class HelicopterMovement : MonoBehaviour 
{
    public float movementSpeed = 1f;

    public static float distanceTraveled;

    public ProceduralTargets ballManager;

    private Vector3 targetPosition;

    private bool keyDownPressed;

    public static int currentStaffPosition;
	void Start () 
    {
        //make units per second
        movementSpeed = movementSpeed * Time.deltaTime;

        currentStaffPosition = 0;
	}
	
	void Update ()
    {
        transform.Translate(Vector3.forward * movementSpeed);

        //used by the procedural manager scripts.
        distanceTraveled = transform.localPosition.z;

        targetPosition = new Vector3(transform.position.x, ballManager.yLocations[currentStaffPosition], transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, 1 * Time.deltaTime);

        //temporary keyboard movement controls
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!keyDownPressed)
            {
                //move up a note. can only be done every .1 seconds
                if (currentStaffPosition + 1 <= 7)
                {
                    currentStaffPosition++;
                    keyDownPressed = true;
                    StartCoroutine(Wait(0.1f));
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!keyDownPressed)
            {
                //move down a bar. can only be done every .1 seconds
                if (currentStaffPosition - 1 >= 0)
                {
                    currentStaffPosition--;
                    keyDownPressed = true;
                    StartCoroutine(Wait(0.1f));

                }
            }
        }
	}
    IEnumerator Wait(float time)
    {
        keyDownPressed = true;
        yield return new WaitForSeconds(time);
        keyDownPressed = false;
    }
}
