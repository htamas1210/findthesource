using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class Ugynok : MonoBehaviour
{
    private Akciok akciok;
    private Akciopont ap;
    private Upgrade upgrade;
    private jatekmanager jatekmanager;
    private Elet elet;
    private movement movement;

    public TMP_Text[] oneone;
    public TMP_Text[] twoone;
    public TMP_Text[] threeone;
    public TMP_Text[] onetwo;
    public TMP_Text[] twotwo;
    public TMP_Text[] threetwo;
    public TMP_Text[] onethree;
    public TMP_Text[] twothree;
    public TMP_Text[] threethree;
    public TMP_Text[] onefour;
    public TMP_Text[] twofour;
    public TMP_Text[] threefour;

    public bool droidagyuAktivalva = false;
    public bool canKill = false;
    public bool canShoot = false; //harchoz bool
    private string[] previus_ugynok_csapatok;
    private int elozo_x;
    private int elozo_y ;
    public void setCanKillTrue(){ canKill = true; }

    private void Awake() {
        akciok = FindObjectOfType<Akciok>();
        upgrade = FindObjectOfType<Upgrade>();
        jatekmanager = FindObjectOfType<jatekmanager>();
        movement = FindObjectOfType<movement>();
        elet = FindObjectOfType<Elet>();
        ap = FindObjectOfType<Akciopont>();

        previus_ugynok_csapatok = new string[3];

        //ugynok csapat mezo szoveg kiurites
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

    public void UgynokSorsolas(int x, int y, int ugynokSzam = 0){
        int random;
        if(ugynokSzam == 0){
            random = UnityEngine.Random.Range(1,7);
        }else{
            random = ugynokSzam;
        }

        if (x == 1 && y == 1)
        {
            if (oneone[0].text.Equals(""))
            {
                oneone[0].text = random.ToString();
            }
            else if (oneone[1].text.Equals(""))
            {
                oneone[1].text = random.ToString();
            }
            else if (oneone[2].text.Equals(""))
            {
                oneone[2].text = random.ToString();
            }
        }
        else if (x == 1 && y == 2)
        {
            if (onetwo[0].text.Equals(""))
            {
                onetwo[0].text = random.ToString();
            }
            else if (onetwo[1].text.Equals(""))
            {
                onetwo[1].text = random.ToString();
            }
            else if (onetwo[2].text.Equals(""))
            {
                onetwo[2].text = random.ToString();
            }
        }
        else if (x == 1 && y == 3)
        {
            if (onethree[0].text.Equals(""))
            {
                onethree[0].text = random.ToString();
            }
            else if (onethree[1].text.Equals(""))
            {
                onethree[1].text = random.ToString();
            }
            else if (onethree[2].text.Equals(""))
            {
                onethree[2].text = random.ToString();
            }
        }
        else if (x == 1 && y == 4)
        {
            if (onefour[0].text.Equals(""))
            {
                onefour[0].text = random.ToString();
            }
            else if (onefour[1].text.Equals(""))
            {
                onefour[1].text = random.ToString();
            }
            else if (onefour[2].text.Equals(""))
            {
                onefour[2].text = random.ToString();
            }
        }
        else if (x == 2 && y == 1)
        {
            if (twoone[0].text.Equals(""))
            {
                twoone[0].text = random.ToString();
            }
            else if (twoone[1].text.Equals(""))
            {
                twoone[1].text = random.ToString();
            }
            else if (twoone[2].text.Equals(""))
            {
                twoone[2].text = random.ToString();
            }
        }
        else if (x == 2 && y == 2)
        {
            if (twotwo[0].text.Equals(""))
            {
                twotwo[0].text = random.ToString();
            }
            else if (twotwo[1].text.Equals(""))
            {
                twotwo[1].text = random.ToString();
            }
            else if (twotwo[2].text.Equals(""))
            {
                twotwo[2].text = random.ToString();
            }
        }
        else if (x == 2 && y == 3)
        {
            if (twothree[0].text.Equals(""))
            {
                twothree[0].text = random.ToString();
            }
            else if (twothree[1].text.Equals(""))
            {
                twothree[1].text = random.ToString();
            }
            else if (twothree[2].text.Equals(""))
            {
                twothree[2].text = random.ToString();
            }
        }
        else if (x == 2 && y == 4)
        {
            if (twofour[0].text.Equals(""))
            {
                twofour[0].text = random.ToString();
            }
            else if (twofour[1].text.Equals(""))
            {
                twofour[1].text = random.ToString();
            }
            else if (twofour[2].text.Equals(""))
            {
                twofour[2].text = random.ToString();
            }
        }
        else if (x == 3 && y == 1)
        {
            if (threeone[0].text.Equals(""))
            {
                threeone[0].text = random.ToString();
            }
            else if (threeone[1].text.Equals(""))
            {
                threeone[1].text = random.ToString();
            }
            else if (threeone[2].text.Equals(""))
            {
                threeone[2].text = random.ToString();
            }
        }
        else if (x == 3 && y == 2)
        {
            if (threetwo[0].text.Equals(""))
            {
                threetwo[0].text = random.ToString();
            }
            else if (threetwo[1].text.Equals(""))
            {
                threetwo[1].text = random.ToString();
            }
            else if (threetwo[2].text.Equals(""))
            {
                threetwo[2].text = random.ToString();
            }
        }
        else if (x == 3 && y == 3)
        {
            if (threethree[0].text.Equals(""))
            {
                threethree[0].text = random.ToString();
            }
            else if (threethree[1].text.Equals(""))
            {
                threethree[1].text = random.ToString();
            }
            else if (threethree[2].text.Equals(""))
            {
                threethree[2].text = random.ToString();
            }
        }
        else if (x == 3 && y == 4)
        {
            if (threefour[0].text.Equals(""))
            {
                threefour[0].text = random.ToString();
            }
            else if (threefour[1].text.Equals(""))
            {
                threefour[1].text = random.ToString();
            }
            else if (threefour[2].text.Equals(""))
            {
                threefour[2].text = random.ToString();
            }
        }
    }


    public void ugynokOles(TMP_Text ugynokText){       
        //string tmp = ugynokText.gameObject.name;
        string s = ugynokText.gameObject.name;
        //Debug.Log("gomb name: " + s);
        string sx = Char.ToString(s[7]);
        string sy = Char.ToString(s[8]);
        //char cx = sx[7];
        //char cy = sx[8];
        int x = int.Parse(sx);
        int y = int.Parse(sy);
        Debug.Log("ugynok x: " + x + " y: "+y);
        Debug.Log("movement x: " + movement.jelenlegi_x +  " y: " + movement.jelenlegi_y);

        if(x != movement.jelenlegi_x || y != movement.jelenlegi_y){
            Debug.Log("nem egyenlo a ketto");
        }else{
            Debug.Log("egyenlo");
        }
        
        if(ugynokText.text.Equals("")){ //ha nincs ott ugynok csapat ne csinaljon semmit
            Debug.Log("itt nincs ugynok csapat!!");
            return;
        }

        if(!droidagyuAktivalva){ //toltenyek levonasa
            //nincs aktivalva a targy csak azon a helyen olhet ahol van (x, y)
            if(x != movement.jelenlegi_x || y != movement.jelenlegi_y){
                Debug.Log("nem vagy azon a helyen es nincs aktivalva a targy!");
                return;
            }

            int ugynokcsapatletszama = int.Parse(ugynokText.text);
            if(ugynokcsapatletszama > akciok.betarazott_tolteny / upgrade.harc[upgrade.getHarcIndex()]){ //ha nincs eleg tolteny
                Debug.Log("nincs eleg tolteny");
                return;
            }

            if(ap.akciopont < 2){
                Debug.Log("nincs eleg ap az oleshez");
                return;
            }else{
                ap.UpdateAkciopont(-2); //harc koltseg
            }

            akciok.Loves(ugynokcsapatletszama / upgrade.harc[upgrade.getHarcIndex()]);
            Debug.Log("tolteny szama:" + ugynokcsapatletszama / upgrade.harc[upgrade.getHarcIndex()]);
        }

        ugynokText.text = "X"; //ugynok csapat megolve

        jatekmanager.JatekosNyert();

        //minden vissza kapcsolasa 
        //jatekmanager.ugynokDeaktivalas(true);
        
        jatekmanager.UpdateGameState(jatekmanager.GameState.Akcio); //miutan vegzett menjen az akcio state-re
        droidagyuAktivalva = false;
    }


    public void ugynokMegolveElozoHelyen(){     
        if(elozo_x != movement.jelenlegi_x || elozo_y != movement.jelenlegi_y){
            foreach(var item in previus_ugynok_csapatok){
                if(!item.Equals("")){
                    //ha nem ures a text vagyis volt atirva szamra nezze meg hogy X-e
                    if(!item.Equals("x") ||!item.Equals("X")){
                        //vonjon le egy eletet
                        elet.Eletvesztes();
                        break;
                    }
                }
            }
        }
        
        if(elozo_x == 1 && elozo_y == 1){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = oneone[i].text;
            }
        }else if(elozo_x == 1 && elozo_y == 2){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = onetwo[i].text;
            }
        }else if(elozo_x == 1 && elozo_y == 3){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = onethree[i].text;
            }
        }else if(elozo_x == 1 && elozo_y == 4){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = onefour[i].text;
            }
        }else if(elozo_x == 2 && elozo_y == 1){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = twoone[i].text;
            }
        }else if(elozo_x == 2 && elozo_y == 2){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = twotwo[i].text;
            }
        }else if(elozo_x == 2 && elozo_y == 3){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = twothree[i].text;
            }
        }else if(elozo_x == 2 && elozo_y == 4){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = twofour[i].text;
            }
        }else if(elozo_x == 3 && elozo_y == 1){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = threeone[i].text;
            }
        }else if(elozo_x == 3 && elozo_y == 2){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = threetwo[i].text;
            }
        }else if(elozo_x == 3 && elozo_y == 3){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = threethree[i].text;
            }
        }else if(elozo_x == 3 && elozo_y == 4){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = threefour[i].text;
            }
        }

        elozo_x = movement.jelenlegi_x;
        elozo_y = movement.jelenlegi_y;
    }

    public void setElozoHelyszin(int x, int y){
        elozo_x = x;
        elozo_y = y;

        if(elozo_x == 1 && elozo_y == 1){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = oneone[i].text;
            }
        }else if(elozo_x == 1 && elozo_y == 2){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = onetwo[i].text;
            }
        }else if(elozo_x == 1 && elozo_y == 3){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = onethree[i].text;
            }
        }else if(elozo_x == 1 && elozo_y == 4){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = onefour[i].text;
            }
        }else if(elozo_x == 2 && elozo_y == 1){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = twoone[i].text;
            }
        }else if(elozo_x == 2 && elozo_y == 2){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = twotwo[i].text;
            }
        }else if(elozo_x == 2 && elozo_y == 3){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = twothree[i].text;
            }
        }else if(elozo_x == 2 && elozo_y == 4){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = twofour[i].text;
            }
        }else if(elozo_x == 3 && elozo_y == 1){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = threeone[i].text;
            }
        }else if(elozo_x == 3 && elozo_y == 2){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = threetwo[i].text;
            }
        }else if(elozo_x == 3 && elozo_y == 3){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = threethree[i].text;
            }
        }else if(elozo_x == 3 && elozo_y == 4){
            for (int i = 0; i < 3; i++)
            {
                previus_ugynok_csapatok[i] = threefour[i].text;
            }
        }
    }
}