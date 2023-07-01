using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Helyszin
{
    [SerializeField] private string helyszinNev;
    [Range(1,2)] [SerializeField] private int helyszinAktivalasDb;
    [SerializeField] private TMP_Text[] lepesSzamlalo;
    [SerializeField] private TMP_Text[] nyomozasJelolo;
    [SerializeField] private TMP_Text[] ugynokCsapatSzamlalo;
    [Range(0,2)] [SerializeField] private int energiaKoltseg;
    [Range(0,2)] [SerializeField] private int akciopontKoltseg;
    [SerializeField] private string szektor; //alpha | omega
    [SerializeField] private string alszektor; //nap vagy hold
    [Range(0,2)][SerializeField] private int x;
    [Range(0,3)] [SerializeField] private int y;

    public int X { get{ return x;}}
    public int Y { get{ return y; }}
    public int EnergiaKoltseg { get{ return energiaKoltseg; }}
    public int AkciopontKoltseg{ get{ return akciopontKoltseg; }}
    public TMP_Text[] LepesSzamlalo { get{ return lepesSzamlalo; } set { lepesSzamlalo = value;}}
}