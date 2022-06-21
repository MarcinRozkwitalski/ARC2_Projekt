using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimation : MonoBehaviour
{
    public BattleHandler battleHandler;
    public BattleCardInfo battleCardInfo;
    public BattleCardHandler battleCardHandler;

    public Vector2 startObjectPos;
    public Vector2 targetPos;
    public Vector2 endPos;
    public Vector2 startObjectScale;
    public Vector2 endLocalScale;

    public bool lockPos = false;

    public GameObject target;
    public float lerpDurationOne = 1;
    public float lerpDurationHalf = 0.5f;

    private void Start() 
    {
        battleHandler = GameObject.Find("BattleHandler").GetComponent<BattleHandler>();
        battleCardInfo = this.gameObject.GetComponent<BattleCardInfo>();
        battleCardHandler = GameObject.Find("NetworkManager").GetComponent<BattleCardHandler>();
        startObjectPos = transform.position;
        targetPos = target.transform.position;
        startObjectScale = transform.localScale;
    }

    private void Update() 
    {
        if(battleHandler.moveCardsToUsedCardsAnimation == true && battleCardInfo.allow_to_animate == true)
        {
            endPos = targetPos + new Vector2(960 + 10, 540 + 3);
            endLocalScale = new Vector2(0.63f, 0.53f);
            StartCoroutine(AnimateMovingCardsToUsedCards());
        }

        if(battleHandler.moveCardsToPlayerCardsPanelAnimation == true && battleCardInfo.allow_to_animate == true)
        {
            endPos = targetPos + new Vector2(1561, 118);
            endLocalScale = new Vector2(1f, 0.88f);
            StartCoroutine(AnimateMovingCardsToPlayerCardsPanel());
        }

        if(battleHandler.moveCardsSidewaysInPlayerCardsPanelAnimation == true && battleCardInfo.allow_to_animate == true)
        {
            endLocalScale = new Vector2(0f, 0f);
            StartCoroutine(AnimateMovingCardsSidewaysInPlayerCardsPanel());
        }

        if(battleHandler.moveCardsSidewaysInPlayerCardsPanelAnimation2 == true && battleCardInfo.allow_to_animate == true)
        {
            endLocalScale = new Vector2(1f, 0.88f);
            StartCoroutine(AnimateMovingCardsSidewaysInPlayerCardsPanel2());
        }

        if(battleHandler.moveCardsFromUsedCardsToDeckCardsAnimation == true && battleCardInfo.allow_to_animate == true)
        {
            endPos = new Vector2(152, 710);
            endLocalScale = new Vector2(0.4272f, 0.370f);
            StartCoroutine(AnimateMovingCardsFromUsedCardsToDeckCardsToPick());
        }
    }

    IEnumerator AnimateMovingCardsToUsedCards()
    {
        if (lockPos == false)
        {
            startObjectPos = transform.position;
            startObjectScale = transform.localScale;
            lockPos = true;
        }

        float timeElapsed = 0;
        while(timeElapsed < lerpDurationOne)
        {
            timeElapsed += Time.deltaTime;
            float percentageComplete = timeElapsed / lerpDurationOne;

            transform.position = Vector2.Lerp(startObjectPos, endPos, percentageComplete);
            transform.localScale = Vector2.Lerp(startObjectScale, endLocalScale, percentageComplete);

            yield return null;
        }
        transform.position = endPos;
        transform.localScale = endLocalScale;
        battleCardInfo.allow_to_animate = false;
        battleHandler.moveCardsToUsedCardsAnimation = false;
        lockPos = false;

        StopAllCoroutines();
    }

    IEnumerator AnimateMovingCardsToPlayerCardsPanel()
    {
        if (lockPos == false)
        {
            startObjectPos = transform.position;
            startObjectScale = transform.localScale;
            lockPos = true;
        }

        float timeElapsed = 0;
        while(timeElapsed < lerpDurationOne)
        {
            timeElapsed += Time.deltaTime;
            float percentageComplete = timeElapsed / lerpDurationOne;

            transform.position = Vector2.Lerp(startObjectPos, endPos, percentageComplete);
            transform.localScale = Vector2.Lerp(startObjectScale, endLocalScale, percentageComplete);

            yield return null;
        }
        battleCardInfo.TurnOnButton();
        transform.position = endPos;
        transform.localScale = endLocalScale;
        battleHandler.moveCardsToPlayerCardsPanelAnimation = false;
        lockPos = false;

        StopAllCoroutines();
    }

    IEnumerator AnimateMovingCardsSidewaysInPlayerCardsPanel()
    {
        if (lockPos == false)
        {
            startObjectScale = transform.localScale;
            lockPos = true;
        }
        float timeElapsed = 0;
        while(timeElapsed < lerpDurationHalf)
        {
            timeElapsed += Time.deltaTime;
            float percentageComplete = timeElapsed / lerpDurationHalf;

            transform.localScale = Vector2.Lerp(startObjectScale, endLocalScale, percentageComplete);

            yield return null;
        }
        lockPos = false;
        battleHandler.moveCardsSidewaysInPlayerCardsPanelAnimation = false;

        StopAllCoroutines();

        battleHandler.moveCardsSidewaysInPlayerCardsPanelAnimation2 = true;
    }

    IEnumerator AnimateMovingCardsSidewaysInPlayerCardsPanel2()
    {
        battleCardInfo.AssignCardImage();

        if (lockPos == false)
        {
            startObjectScale = transform.localScale;
            lockPos = true;
        }
        float timeElapsed = 0;
        while(timeElapsed < lerpDurationHalf)
        {
            timeElapsed += Time.deltaTime;
            float percentageComplete = timeElapsed / lerpDurationHalf;

            transform.localScale = Vector2.Lerp(startObjectScale, endLocalScale, percentageComplete);

            yield return null;
        }
        transform.localScale = endLocalScale;
        battleHandler.moveCardsSidewaysInPlayerCardsPanelAnimation2 = false;
        lockPos = false;

        StopAllCoroutines();
    }

    IEnumerator AnimateMovingCardsFromUsedCardsToDeckCardsToPick()
    {
        if (lockPos == false)
        {
            startObjectPos = transform.position;
            startObjectScale = transform.localScale;
            lockPos = true;
        }

        float timeElapsed = 0;
        while(timeElapsed < lerpDurationOne)
        {
            timeElapsed += Time.deltaTime;
            float percentageComplete = timeElapsed / lerpDurationOne;

            transform.position = Vector2.Lerp(startObjectPos, endPos, percentageComplete);
            transform.localScale = Vector2.Lerp(startObjectScale, endLocalScale, percentageComplete);

            yield return null;
        }
        transform.position = endPos;
        transform.localScale = endLocalScale;
        battleHandler.moveCardsFromUsedCardsToDeckCardsAnimation = false;
        lockPos = false;

        StopAllCoroutines();
    }
}