using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class jatekmanager : MonoBehaviour
{
    public static jatekmanager Instance;

    //game objectek implementálása
    public GameObject energiafejlesztés;
    public GameObject akciofejlesztés;
    public GameObject harcfejlesztés;
    public GameObject ujradobasfejlesztés;
    public GameObject hackfejlesztés;
    public GameObject kovetkezokor;
    public GameObject betarazas;
    public GameObject nyomozas;
    public GameObject hackeles;
    public GameObject rolldice;
    public GameObject test;


    //script-ek implementalasa
    private Elet elet;
    private Akciok akciok;
    private Targyak targyak;
    private Dice dice;
    private Upgrade upgrade;
    private Akciopont akciopont;
    private movement movement;
    private TurnManager turnManager;
    private Source source;
    private vegpontozas vegpontozas;
    private AudioManager audioManager;

    //ügynökcsapatok implementálása
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

    //nyert es vesztett bool lethrehozas
    public bool jatekosnyert = false;
    public bool jatekosvesztett = false;
    public bool vanertelme = true;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;
    public Button helyszinaktivalasBtn;

    public GameObject pauseMenuUI;
    public static bool GameIsPlaying = true;

    private GameState previousGameState;

    public TMP_Text nev;

    public GameObject mainCanvas;
    public GameObject helyszinCanvas;
    public GameObject helyszinSorsolasCanvas;
    public GameObject palyaSprite;
    public GameObject playerSprite;

    private void Awake()
    {
        Instance = this;   

        mainCanvas.SetActive(false); //helyszin sorsolas animacio miatt
        helyszinCanvas.SetActive(false);
        helyszinSorsolasCanvas.SetActive(true);
        palyaSprite.SetActive(false);
        playerSprite.SetActive(false);
    }

    private void Start()
    {
        elet = FindObjectOfType<Elet>();
        akciok = FindObjectOfType<Akciok>();
        targyak = FindObjectOfType<Targyak>();
        dice = FindObjectOfType<Dice>();
        upgrade = FindObjectOfType<Upgrade>();
        akciopont = FindObjectOfType<Akciopont>();
        movement = FindObjectOfType<movement>();
        turnManager = FindObjectOfType<TurnManager>();
        source = FindObjectOfType<Source>();
        vegpontozas = FindObjectOfType<vegpontozas>();

        //hatterzene lejatszas
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("BackgroundMusic");

        UpdateGameState(GameState.Nev);
        
        #if !UNITY_EDITOR
            test.SetActive(false);
        #endif
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.KorKezdet:
                HandleKorkezdet();
                break;
            case GameState.Akcio:
                HandleAkcio();
                break;
            case GameState.Fejlesztes:
                HandleFejlesztes();
                break;
            case GameState.Ugynok:
                ugynokDeaktivalas(false);
                break;
            case GameState.Vesztette:
                HandleVesztette();
                break;
            case GameState.UgynokValasztas:
                HandleUgynokValasztas();
                break;
            case GameState.Nev:
                HandleUgynokNev();
                break;
            case GameState.Pause:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    public enum GameState
    {
        KorKezdet,
        Akcio,
        Fejlesztes,
        Ugynok,
        Vesztette,
        UgynokValasztas,
        Nev,
        Pause
    }

    //double click

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; //normal ido visszainditasa
        GameIsPlaying = true;
        audioManager.SetMainVolume(0f);
        Instance.UpdateGameState(previousGameState); //elozo statere menjen vissza
    }

    public void Pause(){
        pauseMenuUI.SetActive(true);
        //ido megallitasa hogy megalljon a jatek
        Time.timeScale = 0f;
        GameIsPlaying = false;
        audioManager.SetMainVolume(-80f); //hangerot teljesen levenni a masteren
        previousGameState = State;
        Instance.UpdateGameState(jatekmanager.GameState.Pause);
    }

    public void Quit(){
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator atlatszo(Button gomb)
    {
        while (gomb.GetComponent<CanvasGroup>().alpha > 0.25f)
        {
            gomb.GetComponent<CanvasGroup>().alpha -= 0.5f;
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }

    public IEnumerator megjelen(Button gomb)
    {
        while (gomb.GetComponent<CanvasGroup>().alpha < 1f)
        {
            gomb.GetComponent<CanvasGroup>().alpha += 0.5f;
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }

    private async void HandleKorkezdet()
    {
        rolldice.SetActive(true);

        energiafejlesztés.SetActive(false);
        akciofejlesztés.SetActive(false);
        harcfejlesztés.SetActive(false);
        ujradobasfejlesztés.SetActive(false);
        hackfejlesztés.SetActive(false);
        kovetkezokor.SetActive(false);
        betarazas.SetActive(false);
        nyomozas.SetActive(false);
        hackeles.SetActive(false);
        helyszinaktivalasBtn.gameObject.SetActive(false);
        //test.SetActive(false);

        //ha ugynok state-el vegezne kapcsoljon vissza mindent
        movement.oneone_Collider.gameObject.SetActive(true);
        movement.onetwo_Collider.gameObject.SetActive(true);
        movement.onethree_Collider.gameObject.SetActive(true);
        movement.onefour_Collider.gameObject.SetActive(true);
        movement.twoone_Collider.gameObject.SetActive(true);
        movement.twotwo_Collider.gameObject.SetActive(true);
        movement.twothree_Collider.gameObject.SetActive(true);
        movement.twofour_Collider.gameObject.SetActive(true);
        movement.threeone_Collider.gameObject.SetActive(true);
        movement.threetwo_Collider.gameObject.SetActive(true);
        movement.threethree_Collider.gameObject.SetActive(true);
        movement.threefour_Collider.gameObject.SetActive(true);

        targyak.hackerFelhasznalva.GetComponent<Button>().gameObject.SetActive(true);
        targyak.lathatatlanFelhasznalva.GetComponent<Button>().gameObject.SetActive(true);
        targyak.droidFelhasznalva.GetComponent<Button>().gameObject.SetActive(true);
        targyak.matavFelhasznalva.GetComponent<Button>().gameObject.SetActive(true);
        targyak.alomhozoFelhasznalva.GetComponent<Button>().gameObject.SetActive(true);

        dice.dice1btnBtn.gameObject.SetActive(true);
        dice.dice2btnBtn.gameObject.SetActive(true);


        Debug.Log(dice.dobott + " ; ennyiszer dobtál már a körben");
        Debug.Log((upgrade.getUjradobasIndex() + 1) + " ; ennyi dobásod van összesen");
    }

    private async void HandleUgynokValasztas(){
        //kapcsolja ki addig a mezoket amig nem valasztott ugynokcsapat szamot
        movement.oneone_Collider.gameObject.SetActive(false);
        movement.onetwo_Collider.gameObject.SetActive(false);
        movement.onethree_Collider.gameObject.SetActive(false);
        movement.onefour_Collider.gameObject.SetActive(false);
        movement.twoone_Collider.gameObject.SetActive(false);
        movement.twotwo_Collider.gameObject.SetActive(false);
        movement.twothree_Collider.gameObject.SetActive(false);
        movement.twofour_Collider.gameObject.SetActive(false);
        movement.threeone_Collider.gameObject.SetActive(false);
        movement.threetwo_Collider.gameObject.SetActive(false);
        movement.threethree_Collider.gameObject.SetActive(false);
        movement.threefour_Collider.gameObject.SetActive(false);
    }

    public void NevValasztasUtan(){
        if(!nev.text.Equals("")){
            UpdateGameState(GameState.KorKezdet);
            //dice.CallRenderDice(true);
        }          
    }

    private async void HandleUgynokNev(){
        movement.oneone_Collider.gameObject.SetActive(false);
        movement.onetwo_Collider.gameObject.SetActive(false);
        movement.onethree_Collider.gameObject.SetActive(false);
        movement.onefour_Collider.gameObject.SetActive(false);
        movement.twoone_Collider.gameObject.SetActive(false);
        movement.twotwo_Collider.gameObject.SetActive(false);
        movement.twothree_Collider.gameObject.SetActive(false);
        movement.twofour_Collider.gameObject.SetActive(false);
        movement.threeone_Collider.gameObject.SetActive(false);
        movement.threetwo_Collider.gameObject.SetActive(false);
        movement.threethree_Collider.gameObject.SetActive(false);
        movement.threefour_Collider.gameObject.SetActive(false);

        energiafejlesztés.SetActive(false);
        akciofejlesztés.SetActive(false);
        harcfejlesztés.SetActive(false);
        ujradobasfejlesztés.SetActive(false);
        hackfejlesztés.SetActive(false);
        kovetkezokor.SetActive(false);
        betarazas.SetActive(false);
        nyomozas.SetActive(false);
        hackeles.SetActive(false);
        helyszinaktivalasBtn.gameObject.SetActive(false);
        //test.SetActive(false);
        rolldice.SetActive(false);      
    }


    private async void HandleFejlesztes()
    {
        energiafejlesztés.SetActive(true);
        akciofejlesztés.SetActive(true);
        harcfejlesztés.SetActive(true);
        ujradobasfejlesztés.SetActive(true);
        hackfejlesztés.SetActive(true);
        kovetkezokor.SetActive(false);
        //rolldice.SetActive(false);
        helyszinaktivalasBtn.gameObject.SetActive(false);

        betarazas.SetActive(false);
        nyomozas.SetActive(false);
        hackeles.SetActive(false);
    }

    private async void HandleAkcio()
    {
        //itt a movement bekapcsol
        kovetkezokor.SetActive(true);
        betarazas.SetActive(true);
        nyomozas.SetActive(true);
        hackeles.SetActive(true);
        helyszinaktivalasBtn.gameObject.SetActive(true);
        energiafejlesztés.SetActive(false);
        akciofejlesztés.SetActive(false);
        harcfejlesztés.SetActive(false);
        ujradobasfejlesztés.SetActive(false);
        hackfejlesztés.SetActive(false);

        kovetkezokor.SetActive(true);

        //ha ugynok valasztasbol jon kapcsolaja vissza a collidereket
        movement.oneone_Collider.gameObject.SetActive(true);
        movement.onetwo_Collider.gameObject.SetActive(true);
        movement.onethree_Collider.gameObject.SetActive(true);
        movement.onefour_Collider.gameObject.SetActive(true);
        movement.twoone_Collider.gameObject.SetActive(true);
        movement.twotwo_Collider.gameObject.SetActive(true);
        movement.twothree_Collider.gameObject.SetActive(true);
        movement.twofour_Collider.gameObject.SetActive(true);
        movement.threeone_Collider.gameObject.SetActive(true);
        movement.threetwo_Collider.gameObject.SetActive(true);
        movement.threethree_Collider.gameObject.SetActive(true);
        movement.threefour_Collider.gameObject.SetActive(true);

        rolldice.SetActive(true);
    }

    private async void HandleVesztette()
    {
        //vegpontozas.pontkiiras();
        JatekosNyert();
        JatekosVesztett();
    }

    private void Update() {
        /*if(jatekosvesztett){
            SceneManager.LoadScene("JatekosVesztett");
        }
        if(jatekosnyert){
            SceneManager.LoadScene("JatekosNyert");
        }*/

        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPlaying){
                Pause();
                Debug.Log("Game is paused");
            }else{
                Resume();
                Debug.Log("Game is playing");
            }
        }
    }

    private async void ugynokDeaktivalas(bool bekapcsolas)
    {
        energiafejlesztés.SetActive(bekapcsolas);
        akciofejlesztés.SetActive(bekapcsolas);
        harcfejlesztés.SetActive(bekapcsolas);
        ujradobasfejlesztés.SetActive(bekapcsolas);
        hackfejlesztés.SetActive(bekapcsolas);
        kovetkezokor.SetActive(bekapcsolas);
        betarazas.SetActive(bekapcsolas);
        nyomozas.SetActive(bekapcsolas);
        hackeles.SetActive(bekapcsolas);

        //roll dice gomb
        rolldice.SetActive(bekapcsolas);
        //kovetkezo kor
        kovetkezokor.SetActive(bekapcsolas);
        //helyszinaktivalas
        helyszinaktivalasBtn.gameObject.SetActive(bekapcsolas);


        movement.oneone_Collider.gameObject.SetActive(bekapcsolas);
        movement.onetwo_Collider.gameObject.SetActive(bekapcsolas);
        movement.onethree_Collider.gameObject.SetActive(bekapcsolas);
        movement.onefour_Collider.gameObject.SetActive(bekapcsolas);
        movement.twoone_Collider.gameObject.SetActive(bekapcsolas);
        movement.twotwo_Collider.gameObject.SetActive(bekapcsolas);
        movement.twothree_Collider.gameObject.SetActive(bekapcsolas);
        movement.twofour_Collider.gameObject.SetActive(bekapcsolas);
        movement.threeone_Collider.gameObject.SetActive(bekapcsolas);
        movement.threetwo_Collider.gameObject.SetActive(bekapcsolas);
        movement.threethree_Collider.gameObject.SetActive(bekapcsolas);
        movement.threefour_Collider.gameObject.SetActive(bekapcsolas);

        targyak.hackerFelhasznalva.GetComponent<Button>().gameObject.SetActive(bekapcsolas);
        targyak.lathatatlanFelhasznalva.GetComponent<Button>().gameObject.SetActive(bekapcsolas);
        targyak.droidFelhasznalva.GetComponent<Button>().gameObject.SetActive(bekapcsolas);
        targyak.matavFelhasznalva.GetComponent<Button>().gameObject.SetActive(bekapcsolas);
        targyak.alomhozoFelhasznalva.GetComponent<Button>().gameObject.SetActive(bekapcsolas);

        dice.dice1btnBtn.gameObject.SetActive(bekapcsolas);
        dice.dice2btnBtn.gameObject.SetActive(bekapcsolas);
    }

    public void JatekosNyert()
    {
        Debug.Log("Játékos nyerésének vizsgálata.");
        Debug.Log("A forrás oszlopa:" + source.oszlop);
        Debug.Log("A forrás sora:" + source.sor[0]);
        //Debug.Log("");
        Debug.Log("A te jelenlegi oszlopod:" + movement.jelenlegi_y);
        Debug.Log("A te jelenlegi sorod:" + movement.jelenlegi_x);
        if (source.isNyitva == true && source.oszlop == movement.jelenlegi_x && source.sor[0] == movement.jelenlegi_y) //+ ugynokcsapat oles a helyszinen
        {
            Debug.Log("A forrás ki van nyitva és ott állsz ahol a forrás is van.");
            if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 1)
            {
                if (oneone[0].text.Equals("X") && oneone[1].text.Equals("X") && oneone[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                    
                }
            }
            if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 2)
            {
                if (onetwo[0].text.Equals("X") && onetwo[1].text.Equals("X") && onetwo[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
            if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 3)
            {
                if (onethree[0].text.Equals("X") && onethree[1].text.Equals("X") && onethree[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
            if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 1)
            {
                if (twoone[0].text.Equals("X") && twoone[1].text.Equals("X") && twoone[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
            if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 2)
            {
                if (twotwo[0].text.Equals("X") && twotwo[1].text.Equals("X") && twotwo[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
            if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 3)
            {
                if (twothree[0].text.Equals("X") && twothree[1].text.Equals("X") && twothree[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
            if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 1)
            {
                if (threeone[0].text.Equals("X") && threeone[1].text.Equals("X") && threeone[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
            if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 2)
            {
                if (threetwo[0].text.Equals("X") && threetwo[1].text.Equals("X") && threetwo[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
            if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 3)
            {
                if (threethree[0].text.Equals("X") && threethree[1].text.Equals("X") && threethree[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
            if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 4)
            {
                if (onefour[0].text.Equals("X") && onefour[1].text.Equals("X") && onefour[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
            if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 4)
            {
                if (twofour[0].text.Equals("X") && twofour[1].text.Equals("X") && twofour[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
            if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 4)
            {
                if (threefour[0].text.Equals("X") && threefour[1].text.Equals("X") && threefour[2].text.Equals("X"))
                {
                    jatekosnyert = true;
                }
            }
        }

        if(jatekosnyert){
            vegpontozas.pontkiiras();
            SceneManager.LoadScene("JatekosNyert");
        }
        else
        {
            Debug.Log("Nem nyert a játékos ebben a körben");
        }

    }
     
    public void JatekosVesztett()
    {
        Debug.Log("Játékos vesztésének vizsgálata.");
        //ha kinyilik a forras de mar voltal ott ketszer
        if (source.isNyitva == true)
        {
            if (source.sor[0] == 1 && source.oszlop == 1)
            {
                if (movement.eromulepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 1)
                    {

                    }
                    else
                    {
                        jatekosvesztett = true;
                    }
                }
            }
            if (source.sor[0] == 1 && source.oszlop == 2)
            {
                if (movement.feketepiaclepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 1)
                    {

                    }
                    else
                    {
                        jatekosvesztett = true;
                    }
                }
            }
            if (source.sor[0] == 1 && source.oszlop == 3)
            {
                if (movement.metrolepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 1)
                    {

                    }
                    else
                    {
                        jatekosvesztett = true;
                    }
                }
            }
            if (source.sor[0] == 2 && source.oszlop == 1)
            {
                if (movement.szervereklepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 2)
                    {

                    }
                    else
                    {
                        jatekosvesztett = true;
                    }
                }
            }
            if (source.sor[0] == 2 && source.oszlop == 2)
            {
                if (movement.kingcasinolepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 2)
                    {

                    }
                    else
                    {
                        jatekosvesztett = true;
                    }
                }
            }
            if (source.sor[0] == 2 && source.oszlop == 3)
            {
                if (movement.feltoltolepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 2)
                    {

                    }
                    else
                    {
                        jatekosvesztett = true;
                    }
                }
            }
            if (source.sor[0] == 3 && source.oszlop == 1)
            {
                if (movement.kutatolaborlepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 3)
                    {

                    }
                    else
                    {
                        jatekosvesztett = true;
                    }
                }
            }
            if (source.sor[0] == 3 && source.oszlop == 2)
            {
                if (movement.kriptoklublepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 3)
                    {

                    }
                    else
                    {
                        jatekosvesztett = true;
                    }
                }
            }
            if (source.sor[0] == 3 && source.oszlop == 3)
            {
                if (movement.cyberplazalepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 3)
                    {

                    }
                    else
                    {
                        jatekosvesztett = true;
                    }
                }
            }
            if (source.sor[0] == 4 && source.oszlop == 1)
            {
                if (movement.hadiuzemlepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 1 && movement.jelenlegi_y == 4)
                    {

                    }
                    else
                    {
                        jatekosvesztett = true;
                    }
                }
            }
            if (source.sor[0] == 4 && source.oszlop == 2)
            {
                if (movement.konyvtarlepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 2 && movement.jelenlegi_y == 4)
                    {

                    }
                    else
                    {
                        jatekosvesztett = true;
                    }
                }
            }
            if (source.sor[0] == 4 && source.oszlop == 3)
            {
                if (movement.korhazlepes2.activeSelf == true)
                {
                    if (movement.jelenlegi_x == 3 && movement.jelenlegi_y == 4)
                    {

                    }
                    else
                    {
                        jatekosvesztett = true;
                    }
                }
            }
        }

        //ha elfogy a töltényed mielőtt végzel a source-nál lévő ügynökcsapatokkal

        if (source.isNyitva == true && akciok.toltenyszamlalo >= 24)
        {
            if (source.sor[0] == 1 && source.oszlop == 1)
            {
                if (oneone[0].text.Equals("X") == false || oneone[1].text.Equals("X") == false || oneone[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 2 && source.oszlop == 1)
            {
                if (twoone[0].text.Equals("X") == false || twoone[1].text.Equals("X") == false || twoone[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 3 && source.oszlop == 1)
            {
                if (threeone[0].text.Equals("X") == false || threeone[1].text.Equals("X") == false || threeone[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 1 && source.oszlop == 2)
            {
                if (onetwo[0].text.Equals("X") == false || onetwo[1].text.Equals("X") == false || onetwo[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 2 && source.oszlop == 2)
            {
                if (twotwo[0].text.Equals("X") == false || twotwo[1].text.Equals("X") == false || twotwo[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 3 && source.oszlop == 2)
            {
                if (threetwo[0].text.Equals("X") == false || threetwo[1].text.Equals("X") == false || threetwo[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 1 && source.oszlop == 3)
            {
                if (onethree[0].text.Equals("X") == false || onethree[1].text.Equals("X") == false || onethree[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 2 && source.oszlop == 3)
            {
                if (twothree[0].text.Equals("X") == false || twothree[1].text.Equals("X") == false || twothree[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 3 && source.oszlop == 3)
            {
                if (threethree[0].text.Equals("X") == false || threethree[1].text.Equals("X") == false || threethree[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 1 && source.oszlop == 4)
            {
                if (onefour[0].text.Equals("X") == false || onefour[1].text.Equals("X") == false || onefour[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 2 && source.oszlop == 4)
            {
                if (twofour[0].text.Equals("X") == false || twofour[1].text.Equals("X") == false || twofour[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
            if (source.sor[0] == 3 && source.oszlop == 4)
            {
                if (threefour[0].text.Equals("X") == false || threefour[1].text.Equals("X") == false || threefour[2].text.Equals("X") == false)
                {
                    jatekosvesztett = true;
                }
            }
        }

        if(jatekosvesztett){
            vegpontozas.pontkiiras();
            SceneManager.LoadScene("JatekosVesztett");
        }
        else
        {
            Debug.Log("Jelenleg itt állsz: " + movement.jelenlegi_x + ". sor, " + movement.jelenlegi_y + ". oszlop" );
            Debug.Log("A játékos nem vesztett ebben a körben.");
        }
    } 
}
