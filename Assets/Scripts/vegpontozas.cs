using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class vegpontozas : MonoBehaviour
{
    private Energia energia;
    private Upgrade FejlesztesPont;
    private Targyak targyak;
    private Akciok akciok;
    private Elet elet;
    public bool foundsource;

    int osszpont = 0;
    int tolteny;
    int megszerzetttargyak;
    int fejlesztespont;
    int energiapont;
    int megmaradtelet;

    void Start()
    {
        energia = FindObjectOfType<Energia>();
        FejlesztesPont = FindObjectOfType<Upgrade>();
        targyak = FindObjectOfType<Targyak>();
        akciok = FindObjectOfType<Akciok>();
        elet = FindObjectOfType<Elet>();
        foundsource = false;
    }

    public int OsszpontSzamalas()
    {
        energiapont = energia.energiasav_text.Length - (energia.getEnergiasavIndex() + 1);
        megmaradtelet = elet.elet;
        tolteny = akciok.betarazott_tolteny;
        megszerzetttargyak = targyak.targy_szamlalo;
        fejlesztespont = FejlesztesPont.fejlesztes_szamlalo;

        osszpont = (energiapont * 2) + (megmaradtelet * 2) + (fejlesztespont / 3) + (tolteny / 2) + megszerzetttargyak;
        return osszpont;
    }
}
