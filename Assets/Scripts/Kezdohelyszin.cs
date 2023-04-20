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

    private float time;
    private int random;

    private Dice dice;

    private void Awake() {
        dice = FindObjectOfType<Dice>();
        nextButton.interactable = false;

        #if !UNITY_EDITOR
            time = 4f;
        #else
            time = 5f;
        #endif
    }

    public void KezdoHelyszinSorsolas(int x, int y, string helynev){
        StartCoroutine(waitForDiceAnimation(helynev));

        dice.callAnimateDice(dice1, x);
        dice.callAnimateDice(dice2, y);
    }

    private IEnumerator waitForDiceAnimation(string helynev){
        yield return new WaitForSeconds(time);

        eredmenyText.text = "A kezdőhelyszíned: " + helynev;
        nextButton.interactable = true;
    }

    public void Debugl(){
        Debug.Log("clicked");
    }

}
