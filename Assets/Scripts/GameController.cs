using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject exitDoor;
    public GameObject closedDoor;
    public GameObject switchOff;
    public GameObject switchOn;


    // Start is called before the first frame update
    void Start()
    {
        closedDoor.SetActive(true);
        closedDoor.SetActive(true);
        closedDoor.SetActive(true);
        closedDoor.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
