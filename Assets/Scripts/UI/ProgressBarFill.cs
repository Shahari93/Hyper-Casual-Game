using UnityEngine;
using UnityEngine.UI;

public class ProgressBarFill : MonoBehaviour
{
    [SerializeField] private GameObject endLevelGO;
    [SerializeField] private GameObject player;
    [SerializeField] private Image progressBarImage;
    private float totalDistance;

    private void Start()
    {
        totalDistance = Mathf.Abs(endLevelGO.transform.position.z - player.transform.position.z);
    }

    public void CalcProgressBarValue()
    {
        float dist = Vector3.Distance(endLevelGO.transform.position, player.transform.position);
        progressBarImage.fillAmount = (dist / totalDistance);
        progressBarImage.fillAmount = 1 - progressBarImage.fillAmount;
    }
}