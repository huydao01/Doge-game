using UnityEngine;

public class SheepController : MonoBehaviour
{
    Vector3 mousePos;
    public float moveSpeed = 5;
    public float minX = -5.5f;
    public float maxX = 5.5f;
    public float minY = -3;
    public float maxY = 3;
    private GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        mousePos = transform.position;
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePos = new Vector3(Mathf.Clamp(mousePos.x, minX, maxX), Mathf.Clamp(mousePos.y, minY, maxY), 0);
        }
        transform.position = Vector3.Lerp(transform.position, mousePos, moveSpeed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        gameController.GetComponent<GameController>().EndGame();
    }
}

