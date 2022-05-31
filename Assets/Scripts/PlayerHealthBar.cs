using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;

    public HealthBar healthBar;

    BoxCollider2D boxCollider;
    Rigidbody2D rb2d;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        boxCollider = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        TakeDamage(0.01f);

        if (currentHealth > 100)
            currentHealth = 100;

        if (Input.GetKeyDown(KeyCode.Space))
            TakeDamage(1f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(10f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pill")
            Heal(20f);

        if (other.gameObject.tag == "Lava")
            TakeDamage(100f);
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void Heal(float heal)
    {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);
    }
}
