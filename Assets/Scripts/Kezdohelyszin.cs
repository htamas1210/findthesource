using System.Collections;
using System.Collections.Generic;
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

    private Dice dice;

    private void Awake() {
        dice = FindObjectOfType<Dice>();
        nextButton.interactable = false;
    }

    public void KezdoHelyszinSorsolas(int x, int y, string helynev){
        StartCoroutine(waitForDiceAnimation(helynev));

        dice.callAnimateDice(dice1, x);
        dice.callAnimateDice(dice2, y);
    }

    private IEnumerator waitForDiceAnimation(string helynev){
        yield return new WaitForSeconds(5f);

        eredmenyText.text = "A kezdőhelyszíned: " + helynev;
        nextButton.interactable = true;
    }

    public void Debugl(){
        Debug.Log("clicked");
    }

}
