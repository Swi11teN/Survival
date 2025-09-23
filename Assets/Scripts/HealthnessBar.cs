using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthnessBar : MonoBehaviour
{
    public Slider waterBar;
    private float waterValue = 1f;

    public Slider foodBar;
    private float foodValue = 1f;

    public Slider healthBar;
    private float healthValue = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseWater();
        DecreaseFood();
    }

    void DecreaseWater()
    {
        waterBar.value -= waterValue * Time.deltaTime;
    }

    void DecreaseFood()
    {
        foodBar.value -= foodValue * Time.deltaTime;
    }

    public void TakeDamage()
    {
        healthBar.value -= healthValue;
    }
}
