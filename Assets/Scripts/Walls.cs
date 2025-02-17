using UnityEngine;

public class Walls : MonoBehaviour
{
    public GameObject RightSide, LeftSide, TopSide, BottomSide;
    Vector3 CameraPos;
    Vector3 BoxSize;
    public static Walls Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        CameraPos = new Vector3(Screen.width, Screen.height, 0);
        BoxSize = Camera.main.ScreenToWorldPoint(CameraPos);
        WallsSetup();
        //Debug.Log(BoxSize);
    }
    public void WallsSetup()
    {
        float BoundX = RightSide.transform.GetComponent<SpriteRenderer>().bounds.size.x;
        float BoundY = RightSide.transform.GetComponent<SpriteRenderer>().bounds.size.y;

        Vector3 RightSidePosition = new Vector3(BoxSize.x + 0.5f, 0, 0);
        RightSide.transform.position = RightSidePosition;
        RightSide.GetComponent<BoxCollider2D>().size = new Vector2(BoundX, BoxSize.y * 2);

        Vector3 LeftSidePosition = new Vector3(-BoxSize.x - 0.5f, 0, 0);
        LeftSide.transform.position = LeftSidePosition;
        LeftSide.transform.GetComponent<BoxCollider2D>().size = new Vector2(BoundX, BoxSize.y * 2);

        Vector3 TopSidePosition = new Vector3(0, BoxSize.y + 0.5f, 0);
        TopSide.transform.position = TopSidePosition;
        TopSide.transform.GetComponent<BoxCollider2D>().size = new Vector2(BoxSize.x * 2, BoundY);

        Vector3 BottomSidePosition = new Vector3(0, -BoxSize.y - 0.5f, 0);
        BottomSide.transform.position = BottomSidePosition;
        BottomSide.transform.GetComponent<BoxCollider2D>().size = new Vector2(BoxSize.x * 2, BoundY);
    }
}