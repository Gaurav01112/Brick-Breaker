using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] private AudioSource ballHit;
    Rigidbody2D body;
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        ballHit = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PaddleManager.Instance.isBallReleased == true)
        {

            if (collision.gameObject.tag == "Paddle")
            {
                float BallPosition = collision.GetContact(0).point.x;
                float PaddlePosition = PaddleManager.Instance.transform.position.x;
                //Debug.Log("BallPosition "+ BallPosition);
                //Debug.Log("PaddlePosition "+ PaddlePosition);
                float Difference = BallPosition - PaddlePosition;
                //Debug.Log("Difference = BallPostion - PaddlePosition  ::  " + Difference);
                Vector2 Direction = new Vector2(Difference, 1).normalized;
                body.velocity = Direction * body.velocity.magnitude;
                ballHit.PlayOneShot(ballHit.clip);
            }
            if (collision.gameObject.tag == "RightSide")
            {
                Vector2 contactPoint = collision.GetContact(0).normal;
                Vector2 direction = Vector2.Reflect(body.velocity, contactPoint);
                //Debug.Log("Direction  ::  " + direction);
                Vector2 newDirection = new Vector2(-direction.x, direction.y).normalized;
                //Debug.Log("NewDirection  ::  " + newDirection);
                newDirection = Quaternion.Euler(0, 0, Random.Range(-10, 10)) * newDirection;
                body.velocity = newDirection * body.velocity.magnitude;
                ballHit.PlayOneShot(ballHit.clip);
            }
            if (collision.gameObject.tag == "LeftSide")
            {
                Vector2 contactPoint1 = collision.GetContact(0).normal;
                //Debug.Log("ContactPoint  ::  " + contactPoint1);
                Vector2 direction = Vector2.Reflect(body.velocity, contactPoint1);
                //Debug.Log("Body.Vellocity  ::  " + body.velocity);
                //Debug.Log("Direction  ::  " + direction);
                Vector2 newDirection = new Vector2(-direction.x, direction.y).normalized;
                //Debug.Log("NewDirection  ::  " + newDirection);                
                newDirection = Quaternion.Euler(0, 0, Random.Range(-10, 10)) * newDirection;
                body.velocity = newDirection * body.velocity.magnitude;
                ballHit.PlayOneShot(ballHit.clip);
            }
            if (collision.gameObject.tag == "TopSide")
            {
                Vector2 ContactPoint = collision.GetContact(0).normal;
                //Debug.Log(ContactPoint);
                Vector2 direction = Vector2.Reflect(body.velocity, ContactPoint);
                //Debug.Log(direction);
                Vector2 newDirection = new Vector2(direction.x, -direction.y).normalized;
                //Debug.Log(newDirection);
                newDirection = Quaternion.Euler(0, 0, Random.Range(-10, 10)) * newDirection;
                body.velocity = newDirection * body.velocity.magnitude;
                ballHit.PlayOneShot(ballHit.clip);
                //Debug.Log(newDirection);
            }
            if (collision.gameObject.tag == "BottomSide")
            {
                if (BallManager.Instance.FirstBall == null || BallManager.Instance.SecondBall == null)
                {
                    SceneManager.LoadScene("BrickBreaker");
                }
                Destroy(this.gameObject);
            }
        }
    }
}

