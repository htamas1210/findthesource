using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;

public class vegpontozas : MonoBehaviour
{
    private Energia energia;
    private Upgrade FejlesztesPont;
    private Targyak targyak;
    private Akciok akciok;
    private Elet elet;
    
    public TMP_Text szoveg;

    public int osszpont = 0;
    int tolteny;
    int megszerzetttargyak;
    int fejlesztespont;
    int energiapont;
    int megmaradtelet;

    void Awake()
    {
        energia = FindObjectOfType<Energia>();
        FejlesztesPont = FindObjectOfType<Upgrade>();
        targyak = FindObjectOfType<Targyak>();
        akciok = FindObjectOfType<Akciok>();
        elet = FindObjectOfType<Elet>();

        if(SceneManager.GetActiveScene().name.Equals("JatekosNyert") || SceneManager.GetActiveScene().name.Equals("JatekosVesztett")){
            szoveg.text = "Pontszam: " + pontbeolvas();
        }
    }

    public int OsszpontSzamalas()
    {
        energiapont = energia.energiasav_text.Length - (energia.getEnergiasavIndex() + 1);
        megmaradtelet = elet.elet;
        tolteny = akciok.betarazott_tolteny;
        megszerzetttargyak = targyak.targy_szamlalo;
        fejlesztespont = FejlesztesPont.fejlesztes_szamlalo;

        osszpont = (energiapont * 2) + (megmaradtelet * 2) + (fejlesztespont / 3) + (tolteny / 2) + megszerzetttargyak;
        //textMesh.text = "Összesen ennyi pontot szereztél:" + osszpont;
        return osszpont;
    }

    public void pontkiiras(){
        StreamWriter writer = new StreamWriter(""+Application.persistentDataPath + "/pontszam.txt", false, Encoding.Default);

        writer.Write(osszpont);
        writer.Close();

        Debug.Log("fajl kiirva");
    }

    public string pontbeolvas(){
        StreamReader reader = new StreamReader(Application.persistentDataPath + "/pontszam.txt");
        string pontszam = reader.ReadLine();
        reader.Close();

        return pontszam;        
    }
}
