using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BoomController : MonoBehaviour
{
    public Vector3 target;
    public float moveSpeed = 5;
    private float DestroyTime = 2;
    public GameObject Explode;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((target - transform.position) * moveSpeed * Time.deltaTime);
    }

    void OnDestroy()
    {
        GameObject explosion = Instantiate(Explode, transform.position, Quaternion.identity) as GameObject;
        Destroy(explosion, 0.5f);
    }
}
