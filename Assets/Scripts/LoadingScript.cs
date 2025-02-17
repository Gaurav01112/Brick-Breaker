using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    public GameObject LoadingPanel;
    public Slider slider;
    public TextMeshProUGUI LoadingTxt;

    private void Start()
    {
        StartCoroutine(AsyncLoading());
    }
    IEnumerator AsyncLoading()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        while (asyncLoad.isDone == false)
        {
            LoadingPanel.SetActive(true);
            slider.value += 1;
            LoadingTxt.text = "Loading... " + slider.value.ToString() + "%";
            yield return null;
        }
    }
}
