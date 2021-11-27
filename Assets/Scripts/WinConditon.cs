using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditon : MonoBehaviour
{
    [SerializeField] private GameObject winLevelUI;
    public bool playerEndedLevel = false;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BoxCollider>())
        {
            Debug.Log("PLAYERRRR");
            playerEndedLevel = true;
            winLevelUI.SetActive(true);
        }
    }
}
