using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject handL;
    [SerializeField] GameObject handR;
    [SerializeField] bool menuVisable = false;

    //[Header("selection tools")]
    [SerializeField] LayerMask laymask;
    private Vector3 aimDirection;

    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(menuVisable);
        aimDirection = new Vector3(0, 0f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("menu"))
        {
            menuVisable = true;
            Time.timeScale = 0f;
            handL.GetComponent<Grabable>().enabled = false;
            handR.GetComponent<Grabable>().enabled = false;
            Menu.SetActive(menuVisable);

        }
        if (menuVisable == true)
        {
            MenuSelect();
        }

    }

    public void MenuSelect()
    {
        RaycastHit hit;
        if(Physics.Raycast(handR.transform.position, handR.transform.TransformDirection(Vector3.forward)*15000, out hit, Mathf.Infinity, laymask))
        {
            if(hit.collider != null)
            {
               if(hit.collider.gameObject.name == "PlayButton")
                {
                    if (Input.GetButton("Submit"))
                    {
                        menuVisable = false;
                        Menu.SetActive(menuVisable);
                        Time.timeScale = 1f;
                        handL.GetComponent<Grabable>().enabled = true;
                        handR.GetComponent<Grabable>().enabled = true;
                    }

                }
                if (hit.collider.gameObject.name == "QuitButton")
                {
                    if (Input.GetButton("Submit"))
                    {
                        Debug.Log("Quit");
                        Application.Quit();
                    }
                }
            }
        }
    }
}