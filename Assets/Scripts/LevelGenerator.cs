using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    void Start()
    {
        GameObject G = Resources.Load<GameObject>("Level" + DDOL.Instance.LevelNumber);
        Instantiate(G);
    }
}
