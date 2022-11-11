using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class movement : MonoBehaviour {

    public Camera THE_Camera;

    public GameObject oneone;
    public Collider2D oneone_Collider;
    public GameObject eromulepes1;
    public GameObject eromulepes2;

    public GameObject twoone;
    public Collider2D twoone_Collider;
    public GameObject feketepiaclepes1;
    public GameObject feketepiaclepes2;

    public GameObject threeone;
    public Collider2D threeone_Collider;
    public GameObject metrolepes1;
    public GameObject metrolepes2;

    public GameObject onetwo;
    public Collider2D onetwo_Collider;
    public GameObject szervereklepes1;
    public GameObject szervereklepes2;

    public GameObject twotwo;
    public Collider2D twotwo_Collider;
    public GameObject kingcasinolepes1;
    public GameObject kingcasinolepes2;

    public GameObject threetwo;
    public Collider2D threetwo_Collider;
    public GameObject feltoltolepes1;
    public GameObject feltoltolepes2;

    public GameObject onethree;
    public Collider2D onethree_Collider;
    public GameObject kutatolaborlepes1;
    public GameObject kutatolaborlepes2;

    public GameObject twothree;
    public Collider2D twothree_Collider;
    public GameObject kriptoklublepes1;
    public GameObject kriptoklublepes2;

    public GameObject threethree;
    public Collider2D threethree_Collider;
    public GameObject cyberplazalepes1;
    public GameObject cyberplazalepes2;

    public GameObject onefour;
    public Collider2D onefour_Collider;
    public GameObject hadiuzemlepes1;
    public GameObject hadiuzemlepes2;

    public GameObject twofour;
    public Collider2D twofour_Collider;
    public GameObject konyvtarlepes1;
    public GameObject konyvtarlepes2;

    public GameObject threefour;
    public Collider2D threefour_Collider;
    public GameObject korhazlepes1;
    public GameObject korhazlepes2;

    public GameObject player;


    int oneonecount = 0;
    int twoonecount = 0;
    int threeonecount = 0;
    int onetwocount = 0;
    int twotwocount = 0;
    int threetwocount = 0;
    int onethreecount = 0;
    int twothreecount = 0;
    int threethreecount = 0;
    int onefourcount = 0;
    int twofourcount = 0;
    int threefourcount = 0;

    int w = 3; //ennyi oszlop van a mapon
    int h = 4; //ennyi sor van a mapon

    string[,] helyek =
    {
        {"oneone", "twoone", "threeone", "" },
        {"onetwo", "twotwo", "threetwo", "" },
        {"onethree", "twothree", "threethree", "" },
        {"onefour", "twofour", "threefour", "" },
        {"", "", "", "" }
    };

    
    int jelenlegi_x = 1;
    int jelenlegi_y = 1;
    int akciopont = 20;
    int tavolsag = 0;

    // Start is called before the first frame update
    void Start() {
        player.transform.position = oneone.transform.position;

        eromulepes1.SetActive(false);
        eromulepes2.SetActive(false);

        feketepiaclepes1.SetActive(false);
        feketepiaclepes2.SetActive(false);

        metrolepes1.SetActive(false);
        metrolepes2.SetActive(false);

        szervereklepes1.SetActive(false);
        szervereklepes2.SetActive(false);

        kingcasinolepes1.SetActive(false);
        kingcasinolepes2.SetActive(false);

        feltoltolepes1.SetActive(false);
        feltoltolepes2.SetActive(false);

        kutatolaborlepes1.SetActive(false);
        kutatolaborlepes2.SetActive(false);

        kriptoklublepes1.SetActive(false);
        kriptoklublepes2.SetActive(false);

        cyberplazalepes1.SetActive(false);
        cyberplazalepes2.SetActive(false);

        hadiuzemlepes1.SetActive(false);
        hadiuzemlepes2.SetActive(false);

        konyvtarlepes1.SetActive(false);
        konyvtarlepes2.SetActive(false);

        korhazlepes1.SetActive(false);
        korhazlepes2.SetActive(false);
    }

    private void kezdoHelyMeghatarzoas() {
        
    }

    // Update is called once per frame
    public void Update() {

        tavolsag = math.abs(tavolsag);

        // player mozgatása és konzolra iratás
        if (Input.GetKeyDown(KeyCode.Mouse0) && oneone_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("oneone")) {
                        Debug.Log("Player clicked on the collider: " + oneone_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));
                        if (eromulepes1.activeSelf == true & eromulepes2.activeSelf == true) {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && akciopont != 0)
                            {
                                    player.transform.position = oneone.transform.position;
                                    jelenlegi_x = 1;
                                    jelenlegi_y = 1;
                                    akciopont = akciopont - 1;
                                    oneonecount = oneonecount + 1;
                                    Debug.Log(akciopont);
                                if (eromulepes1.activeSelf == true)
                                {
                                    eromulepes2.SetActive(true);
                                }
                                else
                                {
                                    eromulepes1.SetActive(true);
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mez?n belül akarsz lépni");
                            }
                        }
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && twoone_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("twoone")) {
                        Debug.Log("Player clicked on the collider: " + twoone_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));
                        if (feketepiaclepes1.activeSelf == true & feketepiaclepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && akciopont != 0)
                            {
                                if (twoonecount < 2)
                                {
                                    player.transform.position = twoone.transform.position;
                                    jelenlegi_x = 2;
                                    jelenlegi_y = 1;
                                    akciopont = akciopont - 1;
                                    twoonecount = twoonecount + 1;
                                    Debug.Log(akciopont);
                                    if (feketepiaclepes1.activeSelf == true)
                                    {
                                        feketepiaclepes2.SetActive(true);
                                    }
                                    else
                                    {
                                        feketepiaclepes1.SetActive(true);
                                    }
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mez?re");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mez?n belül akarsz lépni");
                            }
                        }
                        
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && threeone_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("threeone")) {
                        Debug.Log("Player clicked on the collider: " + threeone_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));
                        if (metrolepes1.activeSelf == true & metrolepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && akciopont != 0)
                            {
                                if (threeonecount < 2)
                                {
                                    player.transform.position = threeone.transform.position;
                                    jelenlegi_x = 3;
                                    jelenlegi_y = 1;
                                    akciopont = akciopont - 1;
                                    threeonecount++;
                                    Debug.Log(akciopont);
                                    if (metrolepes1.activeSelf == true)
                                    {
                                        metrolepes2.SetActive(true);
                                    }
                                    else
                                    {
                                        metrolepes1.SetActive(true);
                                    }
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mezõre");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mez?n belül akarsz lépni");
                            }
                        }
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && onetwo_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("onetwo")) {
                        Debug.Log("Player clicked on the collider: " + onetwo_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));

                        if (szervereklepes1.activeSelf == true & szervereklepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && akciopont != 0)
                            {
                                if (onetwocount < 2)
                                {
                                    player.transform.position = onetwo.transform.position;
                                    jelenlegi_x = 1;
                                    jelenlegi_y = 2;
                                    akciopont = akciopont - 1;
                                    onetwocount++;
                                    Debug.Log(akciopont);
                                    if (szervereklepes1.activeSelf == true)
                                    {
                                        szervereklepes2.SetActive(true);
                                    }
                                    else
                                    {
                                        szervereklepes1.SetActive(true);
                                    }
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mezõre");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mezõn belül akarsz lépni");
                            }
                        }
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && twotwo_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("twotwo")) {
                        Debug.Log("Player clicked on the collider: " + twotwo_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));

                        if (kingcasinolepes1.activeSelf == true & kingcasinolepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else {
                            if (tavolsag == 1 && akciopont != 0)
                            {
                                if (twotwocount < 2)
                                {
                                    player.transform.position = twotwo.transform.position;
                                    jelenlegi_x = 2;
                                    jelenlegi_y = 2;
                                    akciopont = akciopont - 1;
                                    Debug.Log(akciopont);
                                    twotwocount++;
                                    if (kingcasinolepes1.activeSelf == true)
                                    {
                                        kingcasinolepes2.SetActive(true);
                                    }
                                    else
                                    {
                                        kingcasinolepes1.SetActive(true);
                                    }
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mezõre");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mezõn belül akarsz lépni");
                            }
                        }
                        
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && threetwo_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("threetwo")) {
                        Debug.Log("Player clicked on the collider: " + threetwo_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));

                        if (feltoltolepes1.activeSelf == true & feltoltolepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && akciopont != 0)
                            {
                                if (threetwocount < 2)
                                {
                                    player.transform.position = threetwo.transform.position;
                                    jelenlegi_x = 3;
                                    jelenlegi_y = 2;
                                    akciopont = akciopont - 1;
                                    Debug.Log(akciopont);
                                    threetwocount++;
                                    if (feltoltolepes1.activeSelf == true)
                                    {
                                        feltoltolepes2.SetActive(true);
                                    }
                                    else
                                    {
                                        feltoltolepes1.SetActive(true);
                                    }
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mez?re");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mez?n belül akarsz lépni");
                            }
                        }

                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && onethree_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("onethree")) {
                        Debug.Log("Player clicked on the collider: " + onethree_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));

                        if (kutatolaborlepes1.activeSelf == true & kutatolaborlepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && akciopont != 0)
                            {
                                if (onethreecount < 2)
                                {
                                    player.transform.position = onethree.transform.position;
                                    jelenlegi_x = 1;
                                    jelenlegi_y = 3;
                                    akciopont = akciopont - 1;
                                    Debug.Log(akciopont);
                                    onethreecount++;
                                    if (kutatolaborlepes1.activeSelf == true)
                                    {
                                        kutatolaborlepes2.SetActive(true);
                                    }
                                    else
                                    {
                                        kutatolaborlepes1.SetActive(true);
                                    }
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mez?re");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mez?n belül akarsz lépni");
                            }
                        }

                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && twothree_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("twothree")) {
                        Debug.Log("Player clicked on the collider: " + twothree_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));

                        if (kriptoklublepes1.activeSelf == true & kriptoklublepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && akciopont != 0)
                            {
                                if (twothreecount < 2)
                                {
                                    player.transform.position = twothree.transform.position;
                                    jelenlegi_x = 2;
                                    jelenlegi_y = 3;
                                    akciopont = akciopont - 1;
                                    Debug.Log(akciopont);
                                    twothreecount++;
                                    if (kriptoklublepes1.activeSelf == true)
                                    {
                                        kriptoklublepes2.SetActive(true);
                                    }
                                    else
                                    {
                                        kriptoklublepes1.SetActive(true);
                                    }
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mez?re");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mez?n belül akarsz lépni");
                            }
                        }


                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && threethree_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[x, y].Equals("threethree")) {
                        Debug.Log("Player clicked on the collider: " + threethree_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));

                        if (cyberplazalepes1.activeSelf == true & cyberplazalepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && akciopont != 0)
                            {
                                if (threethreecount < 2)
                                {
                                    player.transform.position = threethree.transform.position;
                                    jelenlegi_x = 3;
                                    jelenlegi_y = 3;
                                    akciopont = akciopont - 1;
                                    Debug.Log(akciopont);
                                    threethreecount++;
                                    if (cyberplazalepes1.activeSelf == true)
                                    {
                                        cyberplazalepes2.SetActive(true);
                                    }
                                    else
                                    {
                                        cyberplazalepes1.SetActive(true);
                                    }
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mezõre");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mez?n belül akarsz lépni");
                            }
                        }

                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && onefour_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("onefour")) {
                        Debug.Log("Player clicked on the collider: " + onefour_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));

                        if (hadiuzemlepes1.activeSelf == true & hadiuzemlepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && akciopont != 0)
                            {
                                if (onefourcount < 2)
                                {
                                    player.transform.position = onefour.transform.position;
                                    jelenlegi_x = 1;
                                    jelenlegi_y = 4;
                                    akciopont = akciopont - 1;
                                    Debug.Log(akciopont);
                                    onefourcount++;
                                    if (hadiuzemlepes1.activeSelf == true)
                                    {
                                        hadiuzemlepes2.SetActive(true);
                                    }
                                    else
                                    {
                                        hadiuzemlepes1.SetActive(true);
                                    }
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mez?re");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mez?n belül akarsz lépni");
                            }
                        }

                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && twofour_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("twofour")) {
                        Debug.Log("Player clicked on the collider: " + twofour_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));

                        if (konyvtarlepes1.activeSelf == true & konyvtarlepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && akciopont != 0)
                            {
                                if (twofourcount < 2)
                                {
                                    player.transform.position = twofour.transform.position;
                                    jelenlegi_x = 2;
                                    jelenlegi_y = 4;
                                    akciopont = akciopont - 1;
                                    Debug.Log(akciopont);
                                    twofourcount++;
                                    if (konyvtarlepes1.activeSelf == true)
                                    {
                                        konyvtarlepes2.SetActive(true);
                                    }
                                    else
                                    {
                                        konyvtarlepes1.SetActive(true);
                                    }
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mez?re");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mez?n belül akarsz lépni");
                            }
                        }

                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && threefour_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition))) {
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    if (helyek[y, x].Equals("threefour")) {
                        Debug.Log("Player clicked on the collider: " + threefour_Collider.gameObject.name);
                        tavolsag = math.abs((jelenlegi_x + jelenlegi_y) - ((x + 1) + (y + 1)));

                        if (korhazlepes1.activeSelf == true & korhazlepes2.activeSelf == true)
                        {
                            Debug.Log("Maximum kétszer léphetsz egy mezõre");
                        }
                        else
                        {
                            if (tavolsag == 1 && akciopont != 0)
                            {
                                if (threefourcount < 2)
                                {
                                    player.transform.position = threefour.transform.position;
                                    jelenlegi_x = 3;
                                    jelenlegi_y = 4;
                                    akciopont = akciopont - 1;
                                    Debug.Log(akciopont);
                                    threefourcount++;
                                    if (korhazlepes1.activeSelf == true)
                                    {
                                        korhazlepes2.SetActive(true);
                                    }
                                    else
                                    {
                                        korhazlepes1.SetActive(true);
                                    }
                                }
                                else
                                {
                                    Debug.Log("Maximum kétszer léphetsz egy mez?re");
                                }
                            }
                            else
                            {
                                Debug.Log("Nincs elég akciópontod vagy nem 1 mez?n belül akarsz lépni");
                            }
                        }

                    }
                }
            }
        }

    }
}