using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : MonoBehaviour
{
    public bool isNyitva = false;
    public int oszlop = -1;
    public List<int> sor;

    private movement movement;
    public GameObject sourceSprite;
    private Ugynok ugynok;
    private jatekmanager jatekmanager;
    

    private bool oneTime = false;

    private void Awake() {
        movement = FindObjectOfType<movement>();
        ugynok = FindObjectOfType<Ugynok>();
    }

    private void Start() {
        sor = new List<int>();
        for (int i = 1; i < 5; i++) {
            sor.Add(i);
        }
    }

    private void Update() {
        if(isNyitva && oszlop != -1 && sor.Count == 1) {
            sourceRender(oszlop, sor[0]);
            
            if (!oneTime) {
                for (int i = 0; i < 3; i++)
                {
                    ugynok.UgynokSorsolas(oszlop, sor[0]);
                }
                printSourceLocation();
                oneTime = true;
                jatekmanager.JatekosVesztett();
            }
        }
    }

    public void printSourceLocation() {
        Debug.Log("Source hely: oszlop: "+oszlop+", sor: "+sor[0]);
    }

    public void sourceRender(int x, int y) {
        if (x == 1 && y == 1) {
            sourceSprite.transform.position = movement.oneone.transform.position;
        } else if (x == 1 && y == 2) {
            sourceSprite.transform.position = movement.onetwo.transform.position;
        } else if (x == 1 && y == 3) {
            sourceSprite.transform.position = movement.onethree.transform.position;
        } else if (x == 1 && y == 4) {
            sourceSprite.transform.position = movement.onefour.transform.position;
        } else if (x == 2 && y == 1) {
            sourceSprite.transform.position = movement.twoone.transform.position;
        } else if (x == 2 && y == 2) {
            sourceSprite.transform.position = movement.twotwo.transform.position;
        } else if (x == 2 && y == 3) {
            sourceSprite.transform.position = movement.twothree.transform.position;
        } else if (x == 2 && y == 4) {
            sourceSprite.transform.position = movement.twofour.transform.position;
        } else if (x == 3 && y == 1) {
            sourceSprite.transform.position = movement.threeone.transform.position;
        } else if (x == 3 && y == 2) {
            sourceSprite.transform.position = movement.threetwo.transform.position;
        } else if (x == 3 && y == 3) {
            sourceSprite.transform.position = movement.threethree.transform.position;
        } else if (x == 3 && y == 4) {
            sourceSprite.transform.position = movement.threefour.transform.position;
        }
    }
}
