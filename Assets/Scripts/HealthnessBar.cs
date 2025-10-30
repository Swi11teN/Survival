using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthnessBar : MonoBehaviour
{
    public Slider waterBar;
    private float waterValue = 3f;

    public Slider foodBar;
    private float foodValue = 1f;

    public Slider healthBar;

    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseWater();
        DecreaseFood();
        CheckCriticalCondition();
    }

    void DecreaseWater()
    {
        waterBar.value -= waterValue * Time.deltaTime;
    }

    void IncreaseWater()
    {
        waterBar.value += 15;
    }

    void DecreaseFood()
    {
        foodBar.value -= foodValue * Time.deltaTime;
    }

    void IncreaseFood()
    {
        foodBar.value += 20;
    }

    private void TakeDamage(float damage)
    {
        healthBar.value -= damage;
        if (healthBar.value <= 0)
        {
            healthBar.value = 0;
            gm.GameOver();
            Debug.Log("Game over");
        }
    }

    private void CheckCriticalCondition()
    {
        if (waterBar.value <= 0 || foodBar.value <= 0)
        {
            TakeDamage(0.05f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(15);
        }

        if (collision.gameObject.CompareTag("Water"))
        {
            Destroy(collision.gameObject);
            IncreaseWater();
        }

        if (collision.gameObject.CompareTag("Food"))
        {
            Destroy(collision.gameObject);
            IncreaseFood();
        }
    }
}
