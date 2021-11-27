using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class DotTweenScript : MonoBehaviour
{
     public Canvas tutorialCanvas;
    PlayerMovement playerMovementScript;
    public Ease animEase;
    public float animDuration;

    public RectTransform leftBorder;
    public RectTransform rightBorder;
    public RectTransform hand;
    // Start is called before the first frame update
    void Start()
    {
        hand.position = leftBorder.position;
        playerMovementScript = FindObjectOfType<PlayerMovement>();
        gameObject.transform.DOMoveX(rightBorder.position.x, animDuration).SetEase(animEase).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovementScript.keyHasPressed)
        {
            tutorialCanvas.enabled = false;
        }
    }
}