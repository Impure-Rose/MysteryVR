using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : MonoBehaviour
{
    [SerializeField] private LayerMask lay;
    [SerializeField] private bool leftHand = true;
    Collider[] detectHitR;
    Collider[] detectHitL;
    public bool isHolding = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (leftHand == false)
        {
            if (Input.GetButton("Fire1"))
            {
                Debug.Log("Fire1");
                detectHitR = Physics.OverlapSphere(transform.position, .5f, lay, QueryTriggerInteraction.UseGlobal);
                if (detectHitR.Length > 0)
                {
                    detectHitR[0].transform.SetParent(transform.transform);
                    isHolding = true;
                }
            }
            if (Input.GetButtonUp("Fire1"))
            {
                transform.DetachChildren();
                isHolding = false;
            }
        }
        if (leftHand == true)
        {
            if (Input.GetButton("Fire2"))
            {
                Debug.Log("Fire2");
                detectHitL = Physics.OverlapSphere(transform.position, .5f, lay, QueryTriggerInteraction.UseGlobal);
                if (detectHitL.Length > 0)
                {
                    detectHitL[0].transform.SetParent(transform.transform);
                    isHolding = true;
                }
            }
            if (Input.GetButtonUp("Fire2"))
            {
                transform.DetachChildren();
                isHolding = false; 
            }
        }

    }
}