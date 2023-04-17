using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    [SerializeField]
    float vel = 0.1f;
    [SerializeField]
    Slider slider;
    [SerializeField]
    TextMeshProUGUI textMoney;

    int maxMoney, currentMoney = 0;

    public static MoneyManager instance;

    float valueSlider;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        textMoney.text = "0$";
    }


    // Update is called once per frame
    void Update()
    {
        if(valueSlider > slider.value)
        {

            slider.value += vel * Time.deltaTime;

            textMoney.text = ((int)(slider.value * maxMoney)).ToString() + "$";
            if (slider.value > valueSlider)
            {
                textMoney.text = (currentMoney).ToString() + "$";
                slider.value = slider.value;
            }
               
        }
    }

    public void AddObject(int m)
    {
        maxMoney += m;
    }

    public void AddMoney(int m)
    {
        currentMoney += m;

        valueSlider = (float)currentMoney / maxMoney;
    }

}
