using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GameController : MonoBehaviour
{
    public GameObject exitDoor;
    public GameObject closedDoor;
    public GameObject switchOff;
    public GameObject switchOn;

    [SerializeField] private HealthBar healthBar;

    void Start()
    {
        float health = 1f;

        FunctionPeriodic.Create(() => {
            if (health > 0)
            {
                health -= .001f;
                healthBar.SetSize(health);

                if (health < .65f) {
                    //Under 30%
                    if (health * 100f % 5 == 0)
                    {
                        healthBar.SetColor(Color.white);
                    }
                    else {
                        healthBar.SetColor(Color.yellow);
                    }
                }
                
                if (health < .3f)
                {
                    //Under 30%
                    if (health * 100f % 5 == 0)
                    {
                        healthBar.SetColor(Color.white);
                    }
                    else
                    {
                        healthBar.SetColor(Color.red);
                    }
                }
            }

        }, .03f);


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
