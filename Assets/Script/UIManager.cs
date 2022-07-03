using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public int maxValue = 1;
    public int currentValue = 0;
    public GameObject TTPPanel;
    public CharacterMove chaMove;
    public Animator tylerAnim;
    public Animator jackAnim;

    private void Start()
    {
    }

    void Update()
    {
        healthBar.maxValue = maxValue;
        healthBar.value = currentValue;
    }

    public void TTPBtn()
    {
        TTPPanel.SetActive(false);
        chaMove.isRunning = true;
        tylerAnim.SetBool("isRunning", true);
        jackAnim.SetBool("isRunning", true);
        
    }

}
