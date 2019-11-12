using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEmail : MonoBehaviour
{
    [SerializeField] GameObject email;
    [SerializeField] bool isVisable=false;
    // Start is called before the first frame update
    void Start()
    {
        email.SetActive(isVisable);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
       if (isVisable == false)
       {
            isVisable = true;
            email.SetActive(true);
       }
       else
       {
           isVisable = false;
           email.SetActive(false);
       }

    }
}
