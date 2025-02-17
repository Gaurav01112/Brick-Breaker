using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleIncrease : MonoBehaviour
{
    public GameObject PaddleStart, PaddleMiddle, PaddleEnd;
    // Start is called before the first frame update
    void Start()
    {
        float PaddleStartPartPosition = PaddleMiddle.transform.GetComponent<SpriteRenderer>().bounds.size.x + 0.1f;
        Debug.Log(PaddleStartPartPosition);
        PaddleStart.transform.position = new Vector3(-PaddleStartPartPosition, 0, 0);
        PaddleEnd.transform.position = new Vector3(PaddleStartPartPosition, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
