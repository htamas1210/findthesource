using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class movement : MonoBehaviour
{
    public Collider2D oneone_Collider;
    public Camera THE_Camera;

    public GameObject oneone;
    public GameObject twoone;
    public GameObject threeone;
    public GameObject onetwo;
    public GameObject twotwo;
    public GameObject threetwo;
    public GameObject onethree;
    public GameObject twothree;
    public GameObject threethree;
    public GameObject onefour;
    public GameObject twofour;
    public GameObject threefour;
    public GameObject player;
    
    string[,] arr2d = new string[4, 3]
    {
        {"oneone", "twoone", "threeone" },
        {"onetwo", "twotwo", "threetwo" },
        {"onethree", "twothree", "threethree" },
        {"onefour", "twofour", "threefour" }    
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        //new WaitForSeconds(2);
        //player.transform.position = oneone.transform.position;

        if (Input.GetKeyDown(KeyCode.Mouse0) && oneone_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            Debug.Log("Player clicked on the collider: " + oneone_Collider.gameObject.name);
        }
    }



}
