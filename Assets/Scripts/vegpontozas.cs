using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class vegpontozas : MonoBehaviour
{
    private Energia energia;
    private Upgrade FejlesztesPont;
    public bool foundsource;

    int osszpont = 0;
    int elet = 5;
    int elhasznaltelet = 0;
    int tolteny = 0;
    int megszerzetttargyak = 0;
    // Start is called before the first frame update
    void Start()
    {
        energia = FindObjectOfType<Energia>();
        energia = FindObjectOfType<Energia>();
        FejlesztesPont = FindObjectOfType<Upgrade>();
        
        foundsource = false;

        int energiapont = Convert.ToInt32(energia.energiasav_text) - energia.getEnergiasavIndex();
        int fejlesztespont = FejlesztesPont.fejlesztes_szamlalo/3;
    }

    // Update is called once per frame
    void Update()
    {
        //osszpont = /*energiapont +*/ ((elet - elhasznaltelet) * 2) + FejlesztesPont + tolteny + megszerzetttargyak;
    }
}
