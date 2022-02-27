using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public int maxValue = 1;
    public int currentValue = 0;

    void Update()
    {
        healthBar.maxValue = maxValue;
        healthBar.value = currentValue;
    }
}
