using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int Health;
    public GameObject PowerPrefab;
    public GameObject BallDropObj;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BrickDestroyManagement();
        PowerDropper();
    }
    public void BrickDestroyManagement()
    {
        if (Health > 0)
        {
            Health--;
            this.transform.localScale = new Vector3(0.75f, 1, 1);
            if (Health == 0)
            {
                BallManager.Instance.BrickCounter();
                Destroy(this.gameObject);
            }
        }
        else
        {
            BallManager.Instance.BrickCounter();
            Destroy(this.gameObject);
        }
    }
    public void PowerDropper()
    {
        if (PowerPrefab != null)
        {
            GameObject Power = Instantiate(PowerPrefab, transform.position, Quaternion.identity);
        }
        if (BallDropObj != null)
        {
            GameObject Power = Instantiate(BallDropObj, transform.position, Quaternion.identity);
        }
    }
}