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
    public GameObject HomePanel, LevelPanel, SettingPanel;

    [SerializeField] private Toggle musicToggle;
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
        bool isMusicOn = PlayerPrefs.GetInt("MusicToggle", 1) == 1;
        musicToggle.isOn = isMusicOn;
        MusicManager.instance.musicSource.mute = !isMusicOn;

        // Add listener to toggle change
        musicToggle.onValueChanged.AddListener(OnMusicToggleClick);

        if (DDOL.Instance.isLevelPlayed == true)
        {
            HomePanel.SetActive(false);
            LevelPanel.SetActive(true);
            SettingPanel.SetActive(false);
            LevelBtnGenerate();
        }
        else
        {
            HomePanel.SetActive(true);
            LevelPanel.SetActive(false);
            SettingPanel.SetActive(false);
        }
    }
    public void PlayBtn()
    {
        HomePanel.gameObject.SetActive(false);
        LevelPanel.gameObject.SetActive(true);
        LevelBtnGenerate();
    }
    public void SettingBtn()
    {
        HomePanel.SetActive(false);
        LevelPanel.SetActive(false);
        SettingPanel.SetActive(true);
    }
    public void CloseSetting()
    {

        HomePanel.SetActive(true);
        LevelPanel.SetActive(false);
        SettingPanel.SetActive(false);
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
    private void OnMusicToggleClick(bool isOn)
    {
        MusicManager.instance.musicSource.mute = !isOn;

        // Save state in PlayerPrefs
        PlayerPrefs.SetInt("MusicToggle", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
