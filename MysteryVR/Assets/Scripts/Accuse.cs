using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accuse : MonoBehaviour
{
    [Header("Am I the Killer??")]
    [SerializeField] bool Murderer = false;

    [Header("References")]
    [SerializeField] GameObject playerHandL;
    [SerializeField] GameObject playerHandR;
    [SerializeField] GameObject winUI;
    [SerializeField] GameObject winMessage;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    //Set a bool in Grabbable, and then get it here, and that might fix the issue I was having.  

    // Update is called once per frame
    void Update()
    {
        if (playerHandL.GetComponent<Grabable>().isHolding==true || playerHandR.GetComponent<Grabable>().isHolding==true) {
            Debug.Log("Take a guess");
            //do i need to reference?? I dont know why its deciding everyone is the murderer 
            if (Input.GetButtonDown("Fire3"))
            {
                if (Murderer == false)
                {
                    Debug.Log("Not the murderer");
                }
                if (Murderer == true)
                {
                    Debug.Log("Murderer");
                    winUI.SetActive(true);
                    winMessage.SetActive(true);
                    playerHandL.GetComponent<Grabable>().enabled = false;
                    playerHandR.GetComponent<Grabable>().enabled = false;
                }
            }
            if (playerHandL.GetComponent<Grabable>().enabled == false|| playerHandR.GetComponent<Grabable>().enabled == false)
            {
                player.GetComponent<PlayerMenu>().MenuSelect();
            }
        }
    }
}
