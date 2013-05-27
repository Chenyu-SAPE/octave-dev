using UnityEngine;
using System.Collections;

public class MusicStaffFollowPlayer : MonoBehaviour 
{
    public GameObject player;
	void Start () 
    {
	
	}
	
	void Update () 
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
	}
}
