using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolePlacement : MonoBehaviour
{

    public static HolePlacement instance;

    public GameObject objectToPlace;
    private float minX = -5f;
    private float maxX = 5f;
    private float fixedY = -3.187f;

    public GameObject placedObject;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        float randomX = Random.Range(minX, maxX);

        placedObject = Instantiate(objectToPlace, new Vector3(randomX, fixedY, 0f), Quaternion.identity);

    }


    public void PlaceObjectRandomly()
    {

        float randomX = Random.Range(minX, maxX);

        placedObject.transform.position = new Vector3(randomX, fixedY, 0);

    }
}
