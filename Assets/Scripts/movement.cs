using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using TMPro;
using UnityEngine.UI;


public class movement : MonoBehaviour
{
    public Camera THE_Camera;
    public GameObject player;

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

    private Akciopont ap;
    private Ugynok ugynok;
    private Targyak targyak;
    private jatekmanager jatekmanager;
    private Dice dice;
    private Kezdohelyszin kezdohelyszin;
    private MessageBox messageBox;

    private int oneonecount = 0;
    private int twoonecount = 0;
    private int threeonecount = 0;
    private int onetwocount = 0;
    private int twotwocount = 0;
    private int threetwocount = 0;
    private int onethreecount = 0;
    private int twothreecount = 0;
    private int threethreecount = 0;
    private int onefourcount = 0;
    private int twofourcount = 0;
    private int threefourcount = 0;

    private int w = 3; //ennyi oszlop van a mapon
    private int h = 4; //ennyi sor van a mapon

    public int jelenlegi_x = 1;
    public int jelenlegi_y = 1;
    //private int tavolsag = 0;
    private int moveCounter = 1;

    //move confirm
    private bool biztosoda = true; //meg nem mukodik addig true
    [SerializeField] private Button confirmMove;
    [SerializeField] private Button cancelMove;
    [SerializeField] private GameObject parentMoveConfirm;

    public void EnableButtons(bool isEnabled)
    {
        parentMoveConfirm.SetActive(isEnabled);
    }

    private void Awake()
    {
        ap = FindObjectOfType<Akciopont>();
        ugynok = FindObjectOfType<Ugynok>();
        targyak = FindObjectOfType<Targyak>();
        jatekmanager = FindObjectOfType<jatekmanager>();
        dice = FindObjectOfType<Dice>();
        kezdohelyszin = FindObjectOfType<Kezdohelyszin>();
        messageBox = FindObjectOfType<MessageBox>();
    }

    private void Start()
    {
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

        kezdoHelyMeghatarzoas();
    }

    private void kezdoHelyMeghatarzoas()
    {
        int random = UnityEngine.Random.Range(1, 12);
        Debug.Log("Random a kezdohelyszinhez: " + random);
        string helynev = "";

        if (random == 1)
        {
            player.transform.position = oneone.transform.position;
            eromulepes1.SetActive(true);
            eromulepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 1;
            jelenlegi_y = 1;
            helynev = "Erőmű";
        }
        else if (random == 2)
        {
            player.transform.position = twoone.transform.position;
            feketepiaclepes1.SetActive(true);
            feketepiaclepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 2;
            jelenlegi_y = 1;
            helynev = "Fekete piac";
        }
        else if (random == 3)
        {
            player.transform.position = threeone.transform.position;
            metrolepes1.SetActive(true);
            metrolepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 3;
            jelenlegi_y = 1;
            helynev = "Metró";
        }
        else if (random == 4)
        {
            player.transform.position = onetwo.transform.position;
            szervereklepes1.SetActive(true);
            szervereklepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 1;
            jelenlegi_y = 2;
            helynev = "Szerverek";
        }
        else if (random == 5)
        {
            player.transform.position = twotwo.transform.position;
            kingcasinolepes1.SetActive(true);
            kingcasinolepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 2;
            jelenlegi_y = 2;
            helynev = "King Kaszinó";
        }
        else if (random == 6)
        {
            player.transform.position = threetwo.transform.position;
            feltoltolepes1.SetActive(true);
            feltoltolepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 3;
            jelenlegi_y = 2;
            helynev = "Feltöltő";
        }
        else if (random == 7)
        {
            player.transform.position = onethree.transform.position;
            kutatolaborlepes1.SetActive(true);
            kutatolaborlepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 1;
            jelenlegi_y = 3;
            helynev = "Kutatólabor";
        }
        else if (random == 8)
        {
            player.transform.position = twothree.transform.position;
            kriptoklublepes1.SetActive(true);
            kriptoklublepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 2;
            jelenlegi_y = 3;
            helynev = "Kripto club";
        }
        else if (random == 9)
        {
            player.transform.position = threethree.transform.position;
            cyberplazalepes1.SetActive(true);
            cyberplazalepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 3;
            jelenlegi_y = 3;
            helynev = "Cyber pláza";
        }
        else if (random == 10)
        {
            player.transform.position = onefour.transform.position;
            hadiuzemlepes1.SetActive(true);
            hadiuzemlepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 1;
            jelenlegi_y = 4;
            helynev = "Hadiüzem";
        }
        else if (random == 11)
        {
            player.transform.position = twofour.transform.position;
            konyvtarlepes1.SetActive(true);
            konyvtarlepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 2;
            jelenlegi_y = 4;
            helynev = "Könyvtár";
        }
        else if (random == 12)
        {
            player.transform.position = threefour.transform.position;
            korhazlepes1.SetActive(true);
            korhazlepes1.GetComponent<TMP_Text>().text = moveCounter.ToString();
            jelenlegi_x = 3;
            jelenlegi_y = 4;
            helynev = "Kórház";
        }

        kezdohelyszin.KezdoHelyszinSorsolas(jelenlegi_x, jelenlegi_y, helynev);
        //ugynok.UgynokSorsolas(jelenlegi_x, jelenlegi_y);
        ugynok.setElozoHelyszin(jelenlegi_x, jelenlegi_y);
    }

    private int Distance(int x, int y)
    {
        //hozza adni az atlos checket
        //TODO

        return math.abs((x) - jelenlegi_x) + math.abs((y) - jelenlegi_y);
    }

    public void setConfirmValue(bool ertek)
    {
        biztosoda = ertek;
    }

    private IEnumerator Confirmation(Transform pos, string helynev, int future_x, int future_y, Collider2D collider)
    {
        //move parent confirm to collider
        parentMoveConfirm.transform.position = pos.position;
        EnableButtons(true);
        int tavolsag = Distance(future_x, future_y);
        messageBox.SendMessageToBox("Biztos ide akarsz mozgoni? (" + helynev + ") Ez " + tavolsag + " ap-ba fog kerülni");



        var waitForButton = new WaitForUIButtons(confirmMove, cancelMove);
        yield return waitForButton.Reset();

        //if(biztosoda) yield break;

        //yield return new WaitUntil(() => biztosoda == true);

        collider.gameObject.SetActive(false);

        if (waitForButton.PressedButton == confirmMove)
        {
            Move(future_x, future_y, collider);
        }
    }

    public void Move(int future_x, int future_y, Collider2D collider)
    {
        Debug.Log("Player clicked on the collider: " + collider.gameObject.name);

        int tavolsag = Distance(future_x, future_y);
        Debug.Log("<color=yellow> tavolsag: " + tavolsag + "</color>");

        GameObject lepesjelzo1;
        GameObject lepesjelzo2;

        //lepesjelzo beallitasa
        if (collider.gameObject.name.Equals("oneone"))
        {
            lepesjelzo1 = eromulepes1;
            lepesjelzo2 = eromulepes2;
        }
        else if (collider.gameObject.name.Equals("twoone"))
        {
            lepesjelzo1 = feketepiaclepes1;
            lepesjelzo2 = feketepiaclepes2;
        }
        else if (collider.gameObject.name.Equals("threeone"))
        {
            lepesjelzo1 = metrolepes1;
            lepesjelzo2 = metrolepes2;
        }
        else if (collider.gameObject.name.Equals("onetwo"))
        {
            lepesjelzo1 = szervereklepes1;
            lepesjelzo2 = szervereklepes2;
        }
        else if (collider.gameObject.name.Equals("twotwo"))
        {
            lepesjelzo1 = kingcasinolepes1;
            lepesjelzo2 = kingcasinolepes2;
        }
        else if (collider.gameObject.name.Equals("threetwo"))
        {
            lepesjelzo1 = feltoltolepes1;
            lepesjelzo2 = feltoltolepes2;
        }
        else if (collider.gameObject.name.Equals("onethree"))
        {
            lepesjelzo1 = kutatolaborlepes1;
            lepesjelzo2 = kutatolaborlepes2;
        }
        else if (collider.gameObject.name.Equals("twothree"))
        {
            lepesjelzo1 = kriptoklublepes1;
            lepesjelzo2 = kriptoklublepes2;
        }
        else if (collider.gameObject.name.Equals("threethree"))
        {
            lepesjelzo1 = cyberplazalepes1;
            lepesjelzo2 = cyberplazalepes2;
        }
        else if (collider.gameObject.name.Equals("onefour"))
        {
            lepesjelzo1 = hadiuzemlepes1;
            lepesjelzo2 = hadiuzemlepes2;
        }
        else if (collider.gameObject.name.Equals("twofour"))
        {
            lepesjelzo1 = konyvtarlepes1;
            lepesjelzo2 = konyvtarlepes2;
        }
        else if (collider.gameObject.name.Equals("threefour"))
        {
            lepesjelzo1 = konyvtarlepes1;
            lepesjelzo2 = konyvtarlepes2;
        }
        else
        {
            Debug.Log("<color=red> Hiba: collider nev: " + collider.gameObject.name + "</color>");
            lepesjelzo1 = new GameObject();
            lepesjelzo2 = new GameObject();
        }

        if (lepesjelzo1.activeSelf && lepesjelzo2.activeSelf)
        {
            Debug.Log("Maximum ketszer lephetsz egy mezore");
        }
        else
        {
            if (tavolsag <= ap.getAkciopont() && tavolsag != 0 && biztosoda)
            {
                player.transform.position = collider.transform.position;
                jelenlegi_x = future_x;
                jelenlegi_y = future_y;

                collider.gameObject.SetActive(true);
                //setConfirmValue(false);

                if (targyak.lathatatlanOltozetAktivalva)
                    targyak.lathatatlanOltozetAktivalva = false;
                else
                    ap.UpdateAkciopont(-tavolsag);


                Debug.Log(ap.getAkciopont());
                Debug.Log("ugynok sorsolas");
                jatekmanager.Instance.UpdateGameState(jatekmanager.GameState.UgynokValasztas); //ne lepjen addig tovabb amig nem valasztott

                dice.CallRenderDice(true);
                ugynok.ugynokMegolveElozoHelyen();

                if (lepesjelzo1.activeSelf == true)
                {
                    lepesjelzo2.SetActive(true);
                    moveCounter++;
                    lepesjelzo2.GetComponent<TMP_Text>().text = moveCounter.ToString();
                }
                else
                {
                    lepesjelzo1.SetActive(true);
                    moveCounter++;
                    lepesjelzo1.GetComponent<TMP_Text>().text = moveCounter.ToString();
                }
                jatekmanager.JatekosVesztett();
            }
            else
            {
                Debug.Log("Nincs eleg akciopontod vagy nem 1 mezon belul akarsz lepni");
            }
        }
    }

    public void Update()
    {
        //tavolsag = math.abs(tavolsag); //mindig abszolut

        ugynok.ugynokMegolveElozoHelyen();

        // player mozgatasa es konzolra iratas
        if (Input.GetKeyDown(KeyCode.Mouse0) && oneone_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            if (ap.getAkciopont() == 0) return;

            // Call Confrimation() if confirm is pressed call Move which has the code down below
            StartCoroutine(Confirmation(oneone.transform, "Erőmű", 1, 1, oneone_Collider));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && twoone_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            if (ap.getAkciopont() == 0) return;
            // Call Confrimation() if confirm is pressed call Move which has the code down below
            StartCoroutine(Confirmation(twoone.transform, "Feketepiac", 2, 1, twoone_Collider));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && threeone_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            if (ap.getAkciopont() == 0) return;
            // Call Confrimation() if confirm is pressed call Move which has the code down below
            StartCoroutine(Confirmation(threeone.transform, "Metró", 3, 1, threeone_Collider));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && onetwo_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            if (ap.getAkciopont() == 0) return;
            // Call Confrimation() if confirm is pressed call Move which has the code down below
            StartCoroutine(Confirmation(onetwo.transform, "Szerverek", 1, 2, onetwo_Collider));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && twotwo_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            if (ap.getAkciopont() == 0) return;
            // Call Confrimation() if confirm is pressed call Move which has the code down below
            StartCoroutine(Confirmation(twotwo.transform, "King Kaszinó", 2, 2, twotwo_Collider));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && threetwo_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            if (ap.getAkciopont() == 0) return;
            // Call Confrimation() if confirm is pressed call Move which has the code down below
            StartCoroutine(Confirmation(threetwo.transform, "Feltöltő", 3, 2, threetwo_Collider));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && onethree_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            if (ap.getAkciopont() == 0) return;
            // Call Confrimation() if confirm is pressed call Move which has the code down below
            StartCoroutine(Confirmation(onethree.transform, "Kutatólabor", 1, 3, onethree_Collider));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && twothree_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            if (ap.getAkciopont() == 0) return;
            // Call Confrimation() if confirm is pressed call Move which has the code down below
            StartCoroutine(Confirmation(twothree.transform, "Kripto Club", 2, 3, twothree_Collider));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && threethree_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            if (ap.getAkciopont() == 0) return;
            // Call Confrimation() if confirm is pressed call Move which has the code down below
            StartCoroutine(Confirmation(threethree.transform, "Cyber Pláza", 3, 3, threethree_Collider));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && onefour_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            if (ap.getAkciopont() == 0) return;
            // Call Confrimation() if confirm is pressed call Move which has the code down below
            StartCoroutine(Confirmation(onefour.transform, "Hadiüzem", 1, 4, onefour_Collider));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && twofour_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            if (ap.getAkciopont() == 0) return;
            // Call Confrimation() if confirm is pressed call Move which has the code down below
            StartCoroutine(Confirmation(twofour.transform, "Könyvtár", 2, 4, twofour_Collider));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && threefour_Collider.OverlapPoint(THE_Camera.ScreenToWorldPoint(Input.mousePosition)))
        {
            if (ap.getAkciopont() == 0) return;
            // Call Confrimation() if confirm is pressed call Move which has the code down below
            StartCoroutine(Confirmation(threefour.transform, "Kórház", 3, 4, threefour_Collider));
        }
    }
}