using UnityEngine;
using System.Collections;

public class TargetCollision : MonoBehaviour 
{

    public GameObject explodingBallPrefab;

	void Start () 
    {
	    
	}
	
	void Update () 
    {
	    //add movement logic here if desired
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            GameObject.Instantiate(explodingBallPrefab, transform.position, transform.rotation);
            Debug.Log("Player hit a sphere");
            //award points or something...
            gameObject.SetActive(false);
        }
    }
}
