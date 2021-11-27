using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private int score = 0;
    private int losingScoreCondition = 0;
    private float fillSpeed = 3f;
    public bool playerLost = false;
    [SerializeField] private Image coinsBarImage;
    [SerializeField] GameObject loseUI;


    private void OnTriggerEnter(Collider other)
    {
        CollectedItem(other);
        LoseCondition();
    }

    private void CollectedItem(Collider other)
    {
        if (other.gameObject.GetComponent<Collectable>() == null)
        {
            return; 
        }

        Collectable collected = other.GetComponent<Collectable>();
        score += collected.GetPoints();
        coinsBarImage.fillAmount += collected.GetPoints() * fillSpeed * Time.deltaTime;
        Destroy(other.gameObject);
    }

    private void LoseCondition()
    {
        if(score < losingScoreCondition)
        {
            playerLost = true;
            loseUI.SetActive(true);
        }
    }
}