using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimation : MonoBehaviour
{
    public BattleHandler battleHandler;

    public Vector2 startObjectPos;
    public Vector2 targetPos;
    public Vector2 endPos;
    public Vector2 startObjectScale;
    public Vector2 endLocalScale;

    public bool lockPos = false;

    public GameObject target;
    public float lerpDuration = 3;

    private void Start() 
    {
        battleHandler = GameObject.Find("BattleHandler").GetComponent<BattleHandler>();
        startObjectPos = transform.position;
        targetPos = target.transform.position;
        startObjectScale = transform.localScale;
        
    }

    private void Update() {
        if(battleHandler.moveCardsToUsedCardsAnimation == true)
        {
            endPos = targetPos + new Vector2(960 + 10, 540 + 3);
            endLocalScale = new Vector2(0.63f, 0.53f);
            StartCoroutine(AnimateMovingCardsToUsedCards());
        }

        if(battleHandler.moveCardsToPlayerCardsPanelAnimation == true)
        {
            endPos = targetPos + new Vector2(960 + 10, 540 + 3);
            endLocalScale = new Vector2(0.63f, 0.53f);
            StartCoroutine(AnimateMovingCardsToPlayerCardsPanel());
        }
    }

    IEnumerator AnimateMovingCardsToPlayerCardsPanel()
    {
        if (lockPos == false)
        {
            startObjectPos = transform.position;
            lockPos = true;
        }

        float timeElapsed = 0;
        while(timeElapsed < lerpDuration)
        {
            timeElapsed += Time.deltaTime;
            float percentageComplete = timeElapsed / lerpDuration;

            transform.position = Vector2.Lerp(startObjectPos, endPos, percentageComplete);
            transform.localScale = Vector2.Lerp(startObjectScale, endLocalScale, percentageComplete);

            yield return null;
        }
        transform.position = endPos;
        transform.localScale = endLocalScale;
        battleHandler.moveCardsToPlayerCardsPanelAnimation = false;
        lockPos = false;
    }

    IEnumerator AnimateMovingCardsToUsedCards()
    {
        if (lockPos == false)
        {
            startObjectPos = transform.position;
            lockPos = true;
        }

        float timeElapsed = 0;
        while(timeElapsed < lerpDuration)
        {
            timeElapsed += Time.deltaTime;
            float percentageComplete = timeElapsed / lerpDuration;

            transform.position = Vector2.Lerp(startObjectPos, endPos, percentageComplete);
            transform.localScale = Vector2.Lerp(startObjectScale, endLocalScale, percentageComplete);

            yield return null;
        }
        transform.position = endPos;
        transform.localScale = endLocalScale;
        battleHandler.moveCardsToUsedCardsAnimation = false;
        lockPos = false;
    }
}