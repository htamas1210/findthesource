using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helyszinaktivalas : MonoBehaviour
{
    private Dice dice;
    public Upgrade upgrade;
    private Akciopont akciopont;
    public movement movement;
    //int movement.jelenlegi_x;
    //int movement.movement.jelenlegi_y;
    bool canUpgrade = false;

    // Start is called before the first frame update
    void Start()
    {
        dice = FindObjectOfType<Dice>();
        akciopont = FindObjectOfType<Akciopont>();
        movement = FindObjectOfType<movement>();
        upgrade = FindObjectOfType<Upgrade>();
    }

    // Update is called once per frame
    /*void Update()
    {
        movement.jelenlegi_x = movement.jelenlegi_x;
        movement.jelenlegi_y = movement.jelenlegi_y;
        canUpgrade = false;
    }*/

    public void HelyszinAktivalas()
    {
        //1-es mezõ
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 1)
        {
            //ügynökcsapat ölés bárhol töltény nélkül
        }
        //2-es mezõ
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 1)
        {
            canUpgrade = true;
            //1 fejlesztés ingyen
        }
        //3-es mezõ
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 1)
        {
            //behuzni a boxcollidereket es kattintásra átváltani a játékos helyét
        }
        //4-es mezõ
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 2)
        {
            //kapsz egy tárgyat
        }
        //5-es mezõ
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 2)
        {
            dice.setLocked(false);
            /*if (dobas % 2 == 0)
            {
            akciopont = akciopont + 3
            }
            else
            {
            energia - 1
            }
             */
        }
        //6-es mezõ
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 2)
        {
            //+1 akció
        }
        //7-es mezõ
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 3)
        {
            canUpgrade = true;
            //1 fejlesztés ingyen
        }
        //8-es mezõ
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 3)
        {
            dice.setLocked(false);
            /*dob két kockával
             az egyik +X akció
             a másik -X energia*/
        }
        //9-es mezõ
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 3)
        {
            //kapsz egy tárgyat
        }
        //10-es mezõ
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 4)
        {
            //+4 töltény
        }
        //11-es mezõ
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 4)
        {
            //Dobj! Megkapod a tárgyat.
        }
        //12-es mezõ
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 4)
        {
            //+1 élet
        }
    }
}
