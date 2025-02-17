using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectBtn : MonoBehaviour
{
    public void LevelSelection()
    {
        DDOL.Instance.isLevelPlayed = true;
        Time.timeScale = 1;
        DDOL.Instance.LevelNumber = int.Parse(gameObject.name);
        SceneManager.LoadScene(2);
    }
}
