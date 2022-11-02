using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private static int w = 3; //ennyi oszlop van a mapon
    private static int h = 4; //ennyi sor van a mapon


    public GameObject[,] helyszinek = new GameObject[h, w];
    public Collider2D[,] colliders = new Collider2D[h, w];


    public Camera THE_Camera;

    public GameObject oneone;
    public Collider2D oneone_Collider;

    public GameObject twoone;
    public Collider2D twoone_Collider;

    public GameObject threeone;
    public Collider2D threeone_Collider;

    public GameObject onetwo;
    public Collider2D onetwo_Collider;

    public GameObject twotwo;
    public Collider2D twotwo_Collider;

    public GameObject threetwo;
    public Collider2D threetwo_Collider;

    public GameObject onethree;
    public Collider2D onethree_Collider;

    public GameObject twothree;
    public Collider2D twothree_Collider;

    public GameObject threethree;
    public Collider2D threethree_Collider;

    public GameObject onefour;
    public Collider2D onefour_Collider;

    public GameObject twofour;
    public Collider2D twofour_Collider;

    public GameObject threefour;
    public Collider2D threefour_Collider;

    public GameObject player;

    private int jelenlegi_x = 1;
    private int jelenlegi_y = 1;
    private int akciopont = 6;
    private int tavolsag = 0;

    private string[,] helyek = new string[4, 3]//kell e meg?
    {
        {"oneone", "twoone", "threeone" },
        {"onetwo", "twotwo", "threetwo" },
        {"onethree", "twothree", "threethree" },
        {"onefour", "twofour", "threefour" }    
    };

    private void Awake() {
        
    }

    public void FixedUpdate()
    {
        // player mozgat�sa es konzolra iratas
        //ha kattint nezze meg a tombbon hogy overlappol valamelyik colliderrel
        if (Input.GetKeyDown(KeyCode.Mouse0) && oneone_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    if (helyek[x,y].Equals("oneone"))
                    {
                        Debug.Log("Player clicked on the collider: " + oneone_Collider.gameObject.name);
                        tavolsag = x + y - jelenlegi_x + jelenlegi_y;
                        if (tavolsag < 1)
                        {
                            tavolsag = -tavolsag;
                            if (tavolsag == 1 && akciopont != 0)
                            {
                                player.transform.position = oneone.transform.position;
                                jelenlegi_x = 1;
                                jelenlegi_y = 1;
                            }
                            else
                            {
                                Debug.Log("Nincs eleg akciopontod vagy nem 1 mezon belul akarsz lepni");
                            }
                        }
                    }
                    //break; ??
                }
            }
        }
        ///////////////////////////
        ///

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            for (int i = 0; i < colliders.GetLength(0); i++) {
                for (int j = 0; j < colliders.GetLength(1); j++) {
                    if (colliders[i, j].OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))){  
                                    Debug.Log("Player clicked on the collider: " + colliders[i,j].gameObject.name);
                                    tavolsag = i + j - jelenlegi_x + jelenlegi_y;
                                    if (tavolsag < 1) {
                                        tavolsag = -tavolsag;
                                        if (tavolsag == 1 && akciopont != 0) {
                                            player.transform.position = oneone.transform.position;
                                            jelenlegi_x = 1;
                                            jelenlegi_y = 1;
                                        } else {
                                            Debug.Log("Nincs eleg akciopontod vagy nem 1 mezon belul akarsz lepni");
                                        }
                                    }                            
                            }
                        }
                    }
                }
            }       
        }

