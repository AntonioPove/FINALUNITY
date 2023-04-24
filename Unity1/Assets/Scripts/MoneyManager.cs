using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.GlobalIllumination;

public class MoneyManager : MonoBehaviour
{
    [SerializeField]
    float timeToPolice;
    [SerializeField]
    float vel = 0.1f;
    [SerializeField]
    Slider slider;
    [SerializeField]
    TextMeshProUGUI textMoney, textPolice;
    [SerializeField]
    Light lightEnd;

    int maxMoney, currentMoney = 0;

    public static MoneyManager instance;

    float valueSlider;


    bool end = false;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        textMoney.text = "0$";

        Invoke("ToPrison", timeToPolice);
        InvokeRepeating("ActualiceTimeText", 0, 1);
    }


    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            lightEnd.intensity += 3 * Time.fixedDeltaTime;
        }
        if (valueSlider > slider.value)
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

    void ActualiceTimeText()
    {
        int s = (int)timeToPolice - (int)Time.timeSinceLevelLoad;

        if (s < 0)
            return;

        if (s > 10)
            textPolice.text = "LA POLICIA LLEGA EN 0" + s / 60 + ":" + s % 60;
        else
            textPolice.text = "LA POLICIA LLEGA EN 0" + s / 60 + ":0" + s % 60;
    }

    void ToPrison()
    {
        end = true;
        AudioManager.instance.Police();
        Invoke("LoadPrison", 5);
    }

    void LoadPrison()
    {
        CancelInvoke();
        SceneManager.LoadScene(1);
    }

}
