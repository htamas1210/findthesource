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
        //1-es mez�
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 1)
        {
            //�gyn�kcsapat �l�s b�rhol t�lt�ny n�lk�l
        }
        //2-es mez�
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 1)
        {
            canUpgrade = true;
            //1 fejleszt�s ingyen
        }
        //3-es mez�
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 1)
        {
            //behuzni a boxcollidereket es kattint�sra �tv�ltani a j�t�kos hely�t
        }
        //4-es mez�
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 2)
        {
            //kapsz egy t�rgyat
        }
        //5-es mez�
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
        //6-es mez�
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 2)
        {
            //+1 akci�
        }
        //7-es mez�
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 3)
        {
            canUpgrade = true;
            //1 fejleszt�s ingyen
        }
        //8-es mez�
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 3)
        {
            dice.setLocked(false);
            /*dob k�t kock�val
             az egyik +X akci�
             a m�sik -X energia*/
        }
        //9-es mez�
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 3)
        {
            //kapsz egy t�rgyat
        }
        //10-es mez�
        if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 4)
        {
            //+4 t�lt�ny
        }
        //11-es mez�
        if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 4)
        {
            //Dobj! Megkapod a t�rgyat.
        }
        //12-es mez�
        if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 4)
        {
            //+1 �let
        }
    }
}
