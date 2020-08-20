using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwayProximityScript : MonoBehaviour
{
    [SerializeField]
    private bool isPlayerByExit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerByExit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerByExit = false;
        }
    }

    public bool GetStatus()
    {
        return isPlayerByExit;
    }
}
