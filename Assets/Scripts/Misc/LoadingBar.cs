using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingBar : MonoBehaviour
{
    [SerializeField] private Image loadingProgressImage = null;
    private float progress = 0f;

    private IEnumerator Start()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);

        //don't let the Scene activate when finish loading
        asyncOperation.allowSceneActivation = false;

        while (progress < 0.9f)
        {
            progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            yield return null;
            if (progress >= 1)
            {
                // move to next scene if the value is 1
                asyncOperation.allowSceneActivation = true;
                AdsManager.adsManagerInstace.ShowInterAd();
            }
            yield return null;
        }
    }

    private void Update()
    {
        // adding the progress to the fill amount of the image
        loadingProgressImage.fillAmount += progress;
    }
}
