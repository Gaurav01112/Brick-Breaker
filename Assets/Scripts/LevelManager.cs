using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject LevelButtonPrefab;
    public Transform ButtonParent;
    public int LevelButtonCount;
    public GameObject HomePanel, LevelPanel;    

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Level") == false)
        {
            PlayerPrefs.SetInt("Level", 1);
        }
        else
        {
            PlayerPrefs.GetInt("Level");
        }        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (DDOL.Instance.isLevelPlayed == true)
        {
            HomePanel.SetActive(false);
            LevelPanel.SetActive(true);
            LevelBtnGenerate();
        }
        else
        {
            HomePanel.SetActive(true);
            LevelPanel.SetActive(false);
        }
    }
    public void PlayBtn()
    {
        HomePanel.gameObject.SetActive(false);
        LevelPanel.gameObject.SetActive(true);
        LevelBtnGenerate();
    }
    public void LevelBtnGenerate()
    {
        for (int i = 1; i <= LevelButtonCount; i++)
        {
            GameObject G = Instantiate(LevelButtonPrefab);
            G.transform.SetParent(ButtonParent);
            G.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = i.ToString();
            G.name = i.ToString();
            if (i <= PlayerPrefs.GetInt("Level"))
            {
                G.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                G.transform.GetChild(1).gameObject.SetActive(true);
                G.transform.GetComponent<Button>().interactable = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
