using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallManager : MonoBehaviour
{
    Vector3 StartPos, EndPos;
    public GameObject WinPanel, OverPanel;
    public GameObject BallPrefab;
    public GameObject FirstBall;
    public GameObject SecondBall;
    public GameObject DirectionLine;
    public float Speed, Values;
    public bool isAngletaken = false;
    Vector3 ScreenSize;
    float X, Y;
    int BrickCount = 0;
    public static BallManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        BrickCount = FindObjectsOfType<Brick>().Length;
        GameObject.Find("BrickCount").GetComponent<TextMeshProUGUI>().text = BrickCount.ToString();
        ScreenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        FirstBall = Instantiate(BallPrefab, transform.position, Quaternion.identity);
        float GBoundsX = FirstBall.transform.GetComponent<SpriteRenderer>().bounds.size.x;
        float GBoundsY = FirstBall.transform.GetComponent<SpriteRenderer>().bounds.size.y;
        float PaddleBoundsX = PaddleManager.Instance.transform.GetComponent<SpriteRenderer>().bounds.size.x;
        float PaddleBoundsY = PaddleManager.Instance.transform.GetComponent<SpriteRenderer>().bounds.size.y;
        FirstBall.transform.position = PaddleManager.Instance.transform.position + new Vector3(0, (PaddleBoundsY / 2) + (GBoundsY / 2), 0);
    }
    public void BrickCounter()
    {
        BrickCount--;
        GameObject.Find("BrickCount").GetComponent<TextMeshProUGUI>().text = BrickCount.ToString();
        if (BrickCount == 0)
        {
            Time.timeScale = 0;
            WinPanel.gameObject.SetActive(true);
        }
    }
    public void Nextbutton()
    {
        if (DDOL.Instance.LevelNumber >= PlayerPrefs.GetInt("Level"))
        {
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);            
        }
        SceneManager.LoadScene(1);
    }
    public void RetryBtn()
    {

    }
    public void HomeBtn()
    {
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        if (PaddleManager.Instance.isBallReleased == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                DirectionLine.SetActive(true);
                EndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                X = EndPos.x - StartPos.x;
                Y = EndPos.y - StartPos.y;
                //Debug.Log("X  ::  " + X);
                //Debug.Log("Y  ::  " + Y);
                float Angle = Mathf.Atan2(X, Y) * Mathf.Rad2Deg;
                DirectionLine.transform.rotation = Quaternion.Euler(0, 0, -Angle);
            }
            if (Input.GetMouseButton(0))
            {
                EndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                X = EndPos.x - StartPos.x;
                Y = EndPos.y - StartPos.y;
                //Debug.Log("X  ::  " + X);
                //Debug.Log("Y  ::  " + Y);
                float Angle = Mathf.Atan2(X, Y) * Mathf.Rad2Deg;
                DirectionLine.transform.rotation = Quaternion.Euler(0, 0, -Angle);
                //if(isAngletaken == false)
                //{

                //}
            }
            if (Input.GetMouseButtonUp(0))
            {
                EndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 Difference = EndPos - StartPos;
                X = StartPos.x - EndPos.x;
                Y = StartPos.y - EndPos.y;
                Vector2 temp = new Vector2(X, Y).normalized * Values;
                FirstBall.GetComponent<Rigidbody2D>().velocity = Difference.normalized * Speed * Values;                
                DirectionLine.gameObject.SetActive(false);
                PaddleManager.Instance.isBallReleased = true;                
            }
        }
    }
}