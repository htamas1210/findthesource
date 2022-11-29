using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Akciok : MonoBehaviour
{
    //Betarazashoz
    public TMP_Text[] toltenyek;
    private int tolteny_index = 3;
    private int felhasznalt_tolteny = 0;
    public int betarazott_tolteny = 3;
    private Akciopont ap;
    //

    //Nyomozashoz
    private movement movement;
    public TMP_Text[] nyomozas_x;
    private string[,] nyomozasok =
    {
        {"ures", "ures", "ures", "" },
        {"ures", "ures", "ures", "" },
        {"ures", "ures", "ures", "" },
        {"ures", "ures", "ures", "" },

    };

    
    //

    //Hack
    public TMP_Text elso_sor_text;
    public TMP_Text[] masodik_sor;
    public TMP_Text[] harmadik_sor;
    public TMP_Text[] negyedik_sor;
    private int[] hackelt_sorok;
    private Upgrade upgrade;
    //

    private void Start() {
        ap = FindObjectOfType<Akciopont>();
        movement = FindObjectOfType<movement>();
        upgrade = FindObjectOfType<Upgrade>();

        //kezdesnel karikazza be az elso harom adott toltenyt
        for (int i = 0; i < tolteny_index; i++) {
            toltenyek[i].text = "O";
        }
    }

    public void Betarazas(int betarazas) {
        if (tolteny_index < 24 && ap.akciopont != 0) {
            if(tolteny_index + betarazas > 23) {
                tolteny_index = 23;
            } else {
                tolteny_index += betarazas;
            }
            //felhasznalt toltenytol megy hogy az ott levo x-et ne irja felul
            for (int i = felhasznalt_tolteny; i < tolteny_index; i++) {
                toltenyek[i].text = "O";
            }

            betarazott_tolteny += betarazas;
            //tolteny_index++;
            ap.akciopont--;

            Debug.Log("Tolteny betarazva");
            Debug.Log("Betarazott toltenyek szama: " + betarazott_tolteny);
        }
    }

    public void Loves(int elhasznalt_toltenyek) {
        if (felhasznalt_tolteny < betarazott_tolteny) {
            if (felhasznalt_tolteny + elhasznalt_toltenyek > betarazott_tolteny) {
                Debug.Log("Nincs eleg tolteny betarazva, tul sok lenne egyszerre felhasznalva!");
                return;
            } else {
                felhasznalt_tolteny += elhasznalt_toltenyek;
                for (int i = 0; i < felhasznalt_tolteny; i++) {
                    toltenyek[i].text = "X";
                }
                betarazott_tolteny -= elhasznalt_toltenyek;
            }
        } else {
            Debug.Log("Nincs eleg tolteny");
        }
    }


    //Nyomozas
    public void Nyomozas() {
        if (ap.akciopont <= 0) {
            Debug.Log("nincs eleg akciopont");
            return;
        }
     
        int atirandox = movement.jelenlegi_x - 1;
        int atirandoy = movement.jelenlegi_y - 1;

        if (nyomozasok[atirandox, atirandoy] == "nyomozott") {
            Debug.Log("Itt mar nyomoztal");
            return;
        } else {
            nyomozasok[atirandoy, atirandox] = "nyomozott";
        }

        int counter = 0;
        //egy sorral feljebb megy
        for (int i = 0; i < nyomozasok.GetLength(0); i++) {
            for (int j = 0; j < nyomozasok.GetLength(1); j++) {
                if (nyomozasok[i, j].Equals("nyomozott")) {
                    nyomozas_x[counter].text = "X";
                    counter++;
                }
            }
        }

        /*if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 1) {
            nyomozas_x[0].text = "X";
        } else if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 2) {
            nyomozas_x[1].text = "X";
        } else if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 3) {
            nyomozas_x[2].text = "X";
        } else if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 4) {
            nyomozas_x[3].text = "X";
        } else if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 1) {
            nyomozas_x[4].text = "X";
        } else if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 2) {
            nyomozas_x[5].text = "X";
        } else if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 3) {
            nyomozas_x[6].text = "X";
        } else if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 4) {
            nyomozas_x[7].text = "X";
        } else if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 1) {
            nyomozas_x[8].text = "X";
        } else if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 2) {
            nyomozas_x[9].text = "X";
        } else if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 3) {
            nyomozas_x[10].text = "X";
        } else if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 4) {
            nyomozas_x[11].text = "X";
        }*/

        ap.akciopont--;

        for (int i = 0; i < nyomozasok.GetLength(0); i++) {
            string sor = "";
            for (int j = 0; j < nyomozasok.GetLength(1); j++) {
                sor += nyomozasok[i, j] + " ";
            }
            Debug.Log(sor);
        }
    }


    public void Hack() {
        int count = 0;
        int rand;

        if(ap.akciopont < upgrade.hack[upgrade.getHackIndex()]) { //van e eleg akicopont
            Debug.Log("nincs eleg ap a hackeleshez");
            return;
        }

        //egy sorban lett e ketszer nyomozva
        for (int i = 0; i < 3; i++) {
            Debug.Log("Belep for");
            if (nyomozasok[movement.jelenlegi_y, i] == "nyomozott") {
                count++;
                Debug.Log("count: " + count);
            }
        }

        //forras helyenek bejelolese
        if(count >= 2 && !hackelt_sorok.Contains(movement.jelenlegi_y)){
            Debug.Log("belep");
            if (movement.jelenlegi_y == 1){ 
                elso_sor_text.text = "X";
            }else {
                rand = UnityEngine.Random.Range(1, 7);
                Debug.Log("sorsolt szam: " + rand);
                if(movement.jelenlegi_y == 2) {
                    if(rand < 4) {
                        masodik_sor[0].text = "X";
                    } else {
                        masodik_sor[1].text = "X";
                    }
                }else if(movement.jelenlegi_y == 3) {
                    if (rand < 4) {
                        harmadik_sor[0].text = "X";
                    } else {
                        harmadik_sor[1].text = "X";
                    }
                }else if(movement.jelenlegi_y == 4) {
                    if(rand < 3) {
                        negyedik_sor[0].text = "X";
                    }else if( rand < 5) {
                        negyedik_sor[1].text = "X";
                    } else {
                        negyedik_sor[2].text = "X";
                    }
                }
            }
        }

        ap.akciopont -= upgrade.hack[upgrade.getHackIndex()]; //ap koltseg levonasa
    }
}
