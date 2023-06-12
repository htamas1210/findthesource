using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Kezdohelyszin : MonoBehaviour
{
    public SpriteRenderer dice1;
    public SpriteRenderer dice2;
    public TMP_Text eredmenyText;
    public Button nextButton;

    private int random;
    public static bool kesz = false;

    private Dice dice;

    private void Awake() {
        dice = FindObjectOfType<Dice>();
        nextButton.interactable = false;
    }

    public void KezdoHelyszinSorsolas(int x, int y, string helynev){
        eredmenyText.text = "";
        nextButton.interactable = false;

        StartCoroutine(waitForDiceAnimation(helynev));

        dice.callAnimateDice(dice1, x);
        dice.callAnimateDice(dice2, y);
    }

    private IEnumerator waitForDiceAnimation(string helynev){
        yield return new WaitUntil(() => kesz);
        
        eredmenyText.text = "A kezdőhelyszíned: " + helynev;
        nextButton.interactable = true; 
        kesz = false;    
    }
}
