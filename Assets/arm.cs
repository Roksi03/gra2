using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arm : MonoBehaviour

{
    [SerializeField] private float velocity = 1.5f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            rb.velocity = Vector2.up * velocity;
        }
    }
}
