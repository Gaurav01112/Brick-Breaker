using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PaddleManager : MonoBehaviour
{
    Vector3 ScreenSize;
    Vector3 StartPos, EndPos;
    Vector3 Difference;
    public bool isBallReleased = false;
    public static PaddleManager Instance;
    public float time = 10;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        ScreenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }
    private void Update()
    {
        if (isBallReleased == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //StartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.GetMouseButton(0))
            {
                EndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Difference = EndPos - StartPos;
                //Debug.Log(Difference.x);
                //Debug.Log(transform.GetComponent<SpriteRenderer>().bounds.size);
                float YofPaddle = -ScreenSize.x + transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
                float ZofPaddle = ScreenSize.x - transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
                //Debug.Log("Difference.x  ::  " + Difference.x);
                Difference.x = Mathf.Clamp(Difference.x, YofPaddle, ZofPaddle);
                //Debug.Log("YofPaddle  ::  " + YofPaddle);
                //Debug.Log("ZofPaddle  ::  " + ZofPaddle);
                this.gameObject.transform.position = new Vector3(Difference.x, -4f, 0);
            }
            if (Input.GetMouseButtonUp(0))
            {
                EndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Power")
        {
            Destroy(collision.gameObject);
            StartCoroutine(PaddleSizeIncrease());
        }
        if (collision.gameObject.tag == "BallPower")
        {
            BallManager.Instance.SecondBall = Instantiate(BallManager.Instance.BallPrefab);
            BallManager.Instance.SecondBall.transform.position = BallManager.Instance.FirstBall.transform.position;
            BallManager.Instance.SecondBall.GetComponent<Rigidbody2D>().velocity = BallManager.Instance.FirstBall.GetComponent<Rigidbody2D>().velocity + new Vector2(-1, 1); ;
            Destroy(collision.gameObject);
        }
    }
    IEnumerator PaddleSizeIncrease()
    {
        for (int i = 0; i < 3; i++)
        {
            transform.localScale = new Vector3(1.25f, 1, 1);
            new WaitForSeconds(0.5f);
        }
        yield return null;
    }
}