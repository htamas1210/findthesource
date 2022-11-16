using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class vegpontozas : MonoBehaviour
{
    private Energia energia;
    private Upgrade FejlesztesPont;
    private Targyak targyak;
    private Akciok akciok;
    public bool foundsource;
    private Elet elet;

    int osszpont = 0;
    int elhasznaltelet = 0;
    int tolteny = 0;
    int megszerzetttargyak = 0;
    int fejlesztespont;
    int energiapont;
    int megmaradtelet;
    // Start is called before the first frame update
    void Start()
    {
        energia = FindObjectOfType<Energia>();
        energia = FindObjectOfType<Energia>();
        FejlesztesPont = FindObjectOfType<Upgrade>();
        targyak = FindObjectOfType<Targyak>();
        akciok = FindObjectOfType<Akciok>();
        elet = FindObjectOfType<Elet>();
        foundsource = false;
    }

    // Update is called once per frame
    void Update()
    {
        tolteny = akciok.betarazott_tolteny;
        megszerzetttargyak = targyak.targy_szamlalo;
        energiapont = Convert.ToInt32(energia.energiasav_text) - energia.getEnergiasavIndex();
        fejlesztespont = FejlesztesPont.fejlesztes_szamlalo;
        megmaradtelet = elet.elet;

        osszpont = (energiapont * 2) + (megmaradtelet * 2) + (fejlesztespont / 3) + (tolteny / 2) + megszerzetttargyak;
    }
}
