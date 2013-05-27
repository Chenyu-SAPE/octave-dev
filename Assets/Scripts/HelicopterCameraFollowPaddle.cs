/*Note: We'll use this if we decide to make a smoother camera in the future.
 *
*/

using UnityEngine;
using System.Collections;

public class HelicopterCameraFollowPaddle : MonoBehaviour 
{
    public GameObject target;
	void Start () 
    {
	
	}
	
	void LateUpdate () 
    {
        if (!target)
        {
            return;
        }

        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, target.transform.position.z + 23), 3 * Time.deltaTime);
	}
}
