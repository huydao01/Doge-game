using UnityEngine;

public class WolfController : MonoBehaviour
{
    public GameObject Boom;
    public float minBoomTime = 3;
    public float maxBoomTime = 6;
    private float BoomTime = 0;
    private float lastBoomTime = 0;
    private GameObject Sheep;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        UpdateBoomTime();
        Sheep = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isBoom", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastBoomTime + BoomTime - 0.5f)
        {
            anim.SetBool("isBoom", true);
        }
        if (Time.time >= lastBoomTime + BoomTime)
        {
            ThrowBoom();
        }
    }
    
    void UpdateBoomTime()
    {
        lastBoomTime = Time.time;
        BoomTime = Random.Range(minBoomTime, maxBoomTime + 1);
    }

    void ThrowBoom()
    {
        GameObject bom = Instantiate(Boom, transform.position, Quaternion.identity) as GameObject;
        bom.GetComponent<BoomController>().target = Sheep.transform.position;
        UpdateBoomTime();
        anim.SetBool("isBoom", false);
    }
}
