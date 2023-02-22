using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class Ugynok : MonoBehaviour
{
    private Akciok akciok;
    private Upgrade upgrade;
    private jatekmanager jatekmanager;
    private movement movement;

    public TMP_Text[] oneone;
    //public BoxCollider2D[] oneoneCollider;
    public TMP_Text[] twoone;
    //public BoxCollider2D[] twooneCollider;
    public TMP_Text[] threeone;
    //public BoxCollider2D[] threeoneCollider;
    public TMP_Text[] onetwo;
    //public BoxCollider2D[] onetwoCollider;
    public TMP_Text[] twotwo;
    //public BoxCollider2D[] twotwoCollider;
    public TMP_Text[] threetwo;
    //public BoxCollider2D[] threetwoCollider;
    public TMP_Text[] onethree;
    //public BoxCollider2D[] onethreeCollider;
    public TMP_Text[] twothree;
    //public BoxCollider2D[] twothreeCollider;
    public TMP_Text[] threethree;
    //public BoxCollider2D[] threethreeCollider;
    public TMP_Text[] onefour;
    //public BoxCollider2D[] onefourCollider;
    public TMP_Text[] twofour;
    //public BoxCollider2D[] twofourCollider;
    public TMP_Text[] threefour;
    //public BoxCollider2D[] threefourCollider;

    public bool droidagyuAktivalva = false;

    public bool canKill = false;
    public bool canShoot = false; //harchoz bool
    public void setCanKillTrue(){ canKill = true; }
    public Camera maincamera;

    private void Awake() {
        akciok = FindObjectOfType<Akciok>();
        upgrade = FindObjectOfType<Upgrade>();
        jatekmanager = FindObjectOfType<jatekmanager>();
        movement = FindObjectOfType<movement>();
    }

    private void Start()
    {
        for (int i = 0; i < oneone.Length; i++)
        {
            oneone[i].text = "";
        }
        for (int i = 0; i < onetwo.Length; i++)
        {
            onetwo[i].text = "";
        }
        for (int i = 0; i < onethree.Length; i++)
        {
            onethree[i].text = "";
        }
        for (int i = 0; i < onefour.Length; i++)
        {
            onefour[i].text = "";
        }

        for (int i = 0; i < twoone.Length; i++)
        {
            twoone[i].text = "";
        }
        for (int i = 0; i < twotwo.Length; i++)
        {
            twotwo[i].text = "";
        }
        for (int i = 0; i < twothree.Length; i++)
        {
            twothree[i].text = "";
        }
        for (int i = 0; i < twofour.Length; i++)
        {
            twofour[i].text = "";
        }

        for (int i = 0; i < threeone.Length; i++)
        {
            threeone[i].text = "";
        }
        for (int i = 0; i < threetwo.Length; i++)
        {
            threetwo[i].text = "";
        }
        for (int i = 0; i < threethree.Length; i++)
        {
            threethree[i].text = "";
        }
        for (int i = 0; i < threefour.Length; i++)
        {
            threefour[i].text = "";
        }

    }

    public void UgynokSorsolas(int x, int y)
    {
        if (x == 1 && y == 1)
        {
            if (oneone[0].text.Equals(""))
            {
                oneone[0].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (oneone[1].text.Equals(""))
            {
                oneone[1].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (oneone[2].text.Equals(""))
            {
                oneone[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        }
        else if (x == 1 && y == 2)
        {
            if (onetwo[0].text.Equals(""))
            {
                onetwo[0].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (onetwo[1].text.Equals(""))
            {
                onetwo[1].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (onetwo[2].text.Equals(""))
            {
                onetwo[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        }
        else if (x == 1 && y == 3)
        {
            if (onethree[0].text.Equals(""))
            {
                onethree[0].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (onethree[1].text.Equals(""))
            {
                onethree[1].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (onethree[2].text.Equals(""))
            {
                onethree[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        }
        else if (x == 1 && y == 4)
        {
            if (onefour[0].text.Equals(""))
            {
                onefour[0].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (onefour[1].text.Equals(""))
            {
                onefour[1].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (onefour[2].text.Equals(""))
            {
                onefour[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        }
        else if (x == 2 && y == 1)
        {
            if (twoone[0].text.Equals(""))
            {
                twoone[0].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (twoone[1].text.Equals(""))
            {
                twoone[1].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (twoone[2].text.Equals(""))
            {
                twoone[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        }
        else if (x == 2 && y == 2)
        {
            if (twotwo[0].text.Equals(""))
            {
                twotwo[0].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (twotwo[1].text.Equals(""))
            {
                twotwo[1].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (twotwo[2].text.Equals(""))
            {
                twotwo[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        }
        else if (x == 2 && y == 3)
        {
            if (twothree[0].text.Equals(""))
            {
                twothree[0].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (twothree[1].text.Equals(""))
            {
                twothree[1].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (twothree[2].text.Equals(""))
            {
                twothree[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        }
        else if (x == 2 && y == 4)
        {
            if (twofour[0].text.Equals(""))
            {
                twofour[0].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (twofour[1].text.Equals(""))
            {
                twofour[1].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (twofour[2].text.Equals(""))
            {
                twofour[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        }
        else if (x == 3 && y == 1)
        {
            if (threeone[0].text.Equals(""))
            {
                threeone[0].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (threeone[1].text.Equals(""))
            {
                threeone[1].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (threeone[2].text.Equals(""))
            {
                threeone[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        }
        else if (x == 3 && y == 2)
        {
            if (threetwo[0].text.Equals(""))
            {
                threetwo[0].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (threetwo[1].text.Equals(""))
            {
                threetwo[1].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (threetwo[2].text.Equals(""))
            {
                threetwo[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        }
        else if (x == 3 && y == 3)
        {
            if (threethree[0].text.Equals(""))
            {
                threethree[0].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (threethree[1].text.Equals(""))
            {
                threethree[1].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (threethree[2].text.Equals(""))
            {
                threethree[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        }
        else if (x == 3 && y == 4)
        {
            if (threefour[0].text.Equals(""))
            {
                threefour[0].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (threefour[1].text.Equals(""))
            {
                threefour[1].text = UnityEngine.Random.Range(1, 7).ToString();
            }
            else if (threefour[2].text.Equals(""))
            {
                threefour[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        }
    }


    public void ugynokOles(TMP_Text ugynokText){       
        //string tmp = ugynokText.gameObject.name;
        int x = (int)Char.GetNumericValue(ugynokText.gameObject.name[7]);
        int y = (int)Char.GetNumericValue(ugynokText.gameObject.name[8]);
        Debug.Log("ugynok x: " + x + " y: "+y);
        Debug.Log("movement x: " + movement.jelenlegi_x +  " y: " + movement.jelenlegi_y);
        
        if(ugynokText.text.Equals("")){ //ha nincs ott ugynok csapat ne csinaljon semmit
            Debug.Log("itt nincs ugynok csapat!!");
            return;
        }

        if(!droidagyuAktivalva){ //toltenyek levonasa
            //nincs aktivalva a targy csak azon a helyen olhet ahol van (x, y)
            if(x != movement.jelenlegi_x && y != movement.jelenlegi_y){
                Debug.Log("nem vagy azon a helyen es nincs aktivalva a targy!");
                return;
            }

            int ugynokcsapatletszama = int.Parse(ugynokText.text);
            if(ugynokcsapatletszama > akciok.betarazott_tolteny / upgrade.harc[upgrade.getHarcIndex()]){ //ha nincs eleg tolteny
                Debug.Log("nincs eleg tolteny");
                return;
            }
            akciok.Loves(ugynokcsapatletszama / upgrade.harc[upgrade.getHarcIndex()]);
            Debug.Log("tolteny szama:" + ugynokcsapatletszama / upgrade.harc[upgrade.getHarcIndex()]);
        }

        ugynokText.text = "X"; //ugynok csapat megolve

        //minden vissza kapcsolasa 
        jatekmanager.ugynokDeaktivalas(true);
        droidagyuAktivalva = false;
    }





      /*  private void Update()
    {
        if(canShoot){
            if(oneone[0].text.Equals("")){
                
            }
        }

        if (canKill)
        {
            //check for collider onclick then x out tmp text then set canKill false
            //check if text field is empty
            //oneone
            if (Input.GetKeyDown(KeyCode.Mouse0) && oneoneCollider[0].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!oneone[0].text.Equals(""))
                {
                    oneone[0].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && oneoneCollider[1].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!oneone[1].text.Equals(""))
                {
                    oneone[1].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && oneoneCollider[2].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!oneone[2].text.Equals(""))
                {
                    oneone[2].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            //onetwo
            if (Input.GetKeyDown(KeyCode.Mouse0) && onetwoCollider[0].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!onetwo[0].text.Equals(""))
                {
                    onetwo[0].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && onetwoCollider[1].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!onetwo[1].text.Equals(""))
                {
                    onetwo[1].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && onetwoCollider[2].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!onetwo[2].text.Equals(""))
                {
                    onetwo[2].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            //onethree
            if (Input.GetKeyDown(KeyCode.Mouse0) && onethreeCollider[0].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!onethree[0].text.Equals(""))
                {
                    onethree[0].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && onethreeCollider[1].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!onethree[1].text.Equals(""))
                {
                    onethree[1].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && onethreeCollider[2].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!onethree[2].text.Equals(""))
                {
                    onethree[2].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            //onefour
            if (Input.GetKeyDown(KeyCode.Mouse0) && onefourCollider[0].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!onefour[0].text.Equals(""))
                {
                    onefour[0].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && onefourCollider[1].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!onefour[1].text.Equals(""))
                {
                    onefour[1].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && onefourCollider[2].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!onefour[2].text.Equals(""))
                {
                    onefour[2].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            //twoone
            if (Input.GetKeyDown(KeyCode.Mouse0) && twooneCollider[0].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!twoone[0].text.Equals(""))
                {
                    twoone[0].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && twooneCollider[1].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!twoone[1].text.Equals(""))
                {
                    twoone[1].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && twooneCollider[2].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!twoone[2].text.Equals(""))
                {
                    twoone[2].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            //twotwo
            if (Input.GetKeyDown(KeyCode.Mouse0) && twotwoCollider[0].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!twotwo[0].text.Equals(""))
                {
                    twotwo[0].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && twotwoCollider[1].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!twotwo[1].text.Equals(""))
                {
                    twotwo[1].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && twotwoCollider[2].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!twotwo[2].text.Equals(""))
                {
                    twotwo[2].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            //twothree
            if (Input.GetKeyDown(KeyCode.Mouse0) && twothreeCollider[0].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!twothree[0].text.Equals(""))
                {
                    twothree[0].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && twothreeCollider[1].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!twothree[1].text.Equals(""))
                {
                    twothree[1].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && twothreeCollider[2].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!twothree[2].text.Equals(""))
                {
                    twothree[2].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            //twofour
            if (Input.GetKeyDown(KeyCode.Mouse0) && twofourCollider[0].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!twofour[0].text.Equals(""))
                {
                    twofour[0].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && twofourCollider[1].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!twofour[1].text.Equals(""))
                {
                    twofour[1].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && twofourCollider[2].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!twofour[2].text.Equals(""))
                {
                    twofour[2].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            //threeone
            if (Input.GetKeyDown(KeyCode.Mouse0) && threeoneCollider[0].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!threeone[0].text.Equals(""))
                {
                    threeone[0].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && threeoneCollider[1].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!threeone[1].text.Equals(""))
                {
                    threeone[1].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && threeoneCollider[2].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!threeone[2].text.Equals(""))
                {
                    threeone[2].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            //threetwo
            if (Input.GetKeyDown(KeyCode.Mouse0) && threetwoCollider[0].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!threetwo[0].text.Equals(""))
                {
                    threetwo[0].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && threetwoCollider[1].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!threetwo[1].text.Equals(""))
                {
                    threetwo[1].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && threetwoCollider[2].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!threetwo[2].text.Equals(""))
                {
                    threetwo[2].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            //threethree
            if (Input.GetKeyDown(KeyCode.Mouse0) && threethreeCollider[0].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!threethree[0].text.Equals(""))
                {
                    threethree[0].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && threethreeCollider[1].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!threethree[1].text.Equals(""))
                {
                    threethree[1].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && threethreeCollider[2].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!threethree[2].text.Equals(""))
                {
                    threethree[2].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            //threefour
            if (Input.GetKeyDown(KeyCode.Mouse0) && threefourCollider[0].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!threefour[0].text.Equals(""))
                {
                    threefour[0].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && threefourCollider[1].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!threefour[1].text.Equals(""))
                {
                    threefour[1].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && threefourCollider[2].OverlapPoint(maincamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (!threefour[2].text.Equals(""))
                {
                    threefour[2].text = "X";
                    canKill = false;
                }
                else
                {
                    Debug.Log("itt nincs ugynok csapat!!!");
                }
            }
        }
    }
*/
}