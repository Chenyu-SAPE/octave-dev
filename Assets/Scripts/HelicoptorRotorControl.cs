using UnityEngine;
using System.Collections;

public class HelicoptorRotorControl : MonoBehaviour 
{
    public float rotationSpeed;

	void Start ()
    {
	
	}
	
	void Update () 
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
	}
}
