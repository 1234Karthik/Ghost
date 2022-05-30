using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    BoxCollider2D boxCollider;
    
    Vector3 startingPos;
    [SerializeField] Vector3 movementVector;

    [SerializeField] float period = 2f;
    [SerializeField][Range(0, 1)] float movementFactor;

    void Start()
    {
        startingPos = transform.position;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;

        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);
        movementFactor = (rawSinWave + 1f) / 2f;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            boxCollider.enabled = false;
            Invoke("Destroy", 5f);
            gameObject.GetComponent<Enemy>().enabled = false;
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
