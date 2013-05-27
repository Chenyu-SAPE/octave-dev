//attempt to use this script to use the event listener script to bounce the camera over to the right page.

using UnityEngine;
using System.Collections;

public class UIButtonControls : MonoBehaviour
{

    public GameObject cameraGameObject;
    public string iTweenEventName;

    void OnClick()
    {
        if (!string.IsNullOrEmpty(iTweenEventName))
        {
            iTweenEvent.GetEvent(cameraGameObject, iTweenEventName).Play();
        }
    }

}
