using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ProceduralTargets : MonoBehaviour
{
    public int numberOfObjects;
    public float[] yLocations;
    public Transform player;

    public Transform ballPrefab; //placed by generator

    private Vector3 nextPosition;
    private Queue<Transform> objectQueue;

    public float recycleOffset = 150f; //distance player needs to run past object before it's "recycled"
    public float objectiveSpacing = 50f;
    void Start()
    {
        objectQueue = new Queue<Transform>(numberOfObjects);
        for (int i = 0; i < numberOfObjects; i++)
        {
            objectQueue.Enqueue((Transform)Instantiate(ballPrefab));
        }

        nextPosition = transform.localPosition;

        for (int i = 0; i < numberOfObjects; i++)
        {
            Recycle();
        }


    }

    void Update()
    {
        if (objectQueue.Peek())
        {
            if (objectQueue.Peek().localPosition.z + recycleOffset < HelicopterMovement.distanceTraveled)
            {
                Recycle();
            }
        }
        //if (objectQueue.Peek())
        //{
        //    Debug.Log("yes");
        //}
        //else
        //    Debug.Log("no");
    }

    void Recycle()
    {
        Transform piece = objectQueue.Dequeue();
        piece.localPosition = nextPosition;
        nextPosition = new Vector3(0, yLocations[Random.Range(0, yLocations.Length)],nextPosition.z += objectiveSpacing);
        if (piece.gameObject.activeSelf == false)
        {
            piece.gameObject.SetActive(true);
        }
        objectQueue.Enqueue(piece);
    }
}
