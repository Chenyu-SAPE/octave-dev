using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ProceduralLevelManager : MonoBehaviour 
{
    public int numberOfObjects;

    public Transform player;

    public Transform levelPrefab; //placed by generator

    private Vector3 nextPosition;
    private Queue<Transform> objectQueue;

    public float recycleOffset = 1000f; //distance player needs to run past object before it's "recycled"

	void Start () 
    {
        objectQueue = new Queue<Transform>(numberOfObjects);
        for (int i = 0; i < numberOfObjects; i++)
        {
            objectQueue.Enqueue((Transform)Instantiate(levelPrefab));
        }
        
        nextPosition = transform.localPosition;
        
        for (int i = 0; i < numberOfObjects; i++)
        {
            Recycle();
        }
        
       
	}

    void Update() 
    {
        if (objectQueue.Peek().localPosition.z + recycleOffset < HelicopterMovement.distanceTraveled)
        {
            Recycle();
        }
	}

    void Recycle()
    {
        Transform piece = objectQueue.Dequeue();
        piece.localPosition = nextPosition;
        nextPosition.z += 250f;
        objectQueue.Enqueue(piece);
    }
}
