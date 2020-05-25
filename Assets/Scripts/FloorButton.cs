using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour
{

    public GameObject DoorGameObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("box"))
        {
            DoorGameObject.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        DoorGameObject.SetActive(true);
    }
}
