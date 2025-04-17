using UnityEngine;

public class BookManager : MonoBehaviour
{
    public static BookManager Instance { get; private set;}
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject closedBook;

    public GameObject openBook;

    public bool bookState;

    public Vector2 xOff = new Vector2(-0.234f, 0);

    public Vector2 yOff = new Vector2(0.247f, 0);
    public Vector2 zOff = new Vector2(0.354f, 0.4f);

    public Vector2 xScale = new Vector2(0.43f, 1.1f);

    public Vector2 yScale = new Vector2(0.43f, 0.7f);

    public Vector2 zScale = new Vector2(0.43f, 1.1f);


    public Vector3 goalPos;

    public Vector3 goalScale;

    public float moveSpeed = 0.05f;

    public float scaleSpeed = 0.05f;

    private bool movingSwitch;
    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        closedBook = transform.GetChild(1).gameObject;
        openBook = transform.GetChild(0).gameObject;
        closedBook.transform.localPosition = new Vector3(xOff.x,yOff.x, zOff.x);
        openBook.transform.localPosition = new Vector3(xOff.x,yOff.x, zOff.x);
    }

    // Update is called once per frame
    void Update()
    {
        //Testing
        if(Input.GetKeyDown(KeyCode.K)) {
            activate();
        }
        if(movingSwitch) {
            Vector3 dist = (goalPos - openBook.transform.localPosition);
            Vector3 scaleDist = (goalScale - openBook.transform.localScale);
            if(dist.magnitude < 0.01f && scaleDist.magnitude < 0.01f) {
                openBook.transform.localPosition = goalPos;
                openBook.transform.localScale = goalScale;
                movingSwitch = false;
                if(!bookState) {
                    openBook.SetActive(false);
                    closedBook.SetActive(true);
                }
            } else { 
                Vector3 toScale = Vector3.ClampMagnitude(scaleSpeed * scaleDist.normalized * Time.deltaTime, scaleDist.magnitude);
                Vector3 toMove = Vector3.ClampMagnitude(moveSpeed * dist.normalized * Time.deltaTime, dist.magnitude);
                openBook.transform.localPosition += toMove;
                openBook.transform.localScale += toScale;
            }
        } 
        closedBook.transform.localPosition = new Vector3(xOff.x,yOff.x, zOff.x);
    }

    public void activate() {
        bookState = !bookState;
        if(bookState) {
            //Replace closed with open. Scale open book up while moving to center of screen.
            openBook.SetActive(true);
            closedBook.SetActive(false);
            goalPos = new Vector3(xOff.y, yOff.y, zOff.y);
            goalScale = new Vector3(xScale.y, yScale.y, zScale.y);
            movingSwitch = true;

        } else {
            goalPos = new Vector3(xOff.x, yOff.x, zOff.x);
            goalScale = new Vector3(xScale.x, yScale.x, zScale.x);
            movingSwitch = true;
        }
    }
}
