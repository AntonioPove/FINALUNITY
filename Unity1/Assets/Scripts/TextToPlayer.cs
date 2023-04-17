using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextToPlayer : MonoBehaviour
{
    [SerializeField]
    TextMeshPro text;
    // Start is called before the first frame update

    bool updateText = false;
    float currentTime = 0;
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        text.text = "";
    }

    private void Update()
    {
        if (!updateText) return;

        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);

        currentTime -= Time.deltaTime;


        if (currentTime <= 0)
        {
            text.text = "";
            updateText = false;
        }
        else
        {
            if (currentTime >= 10)
                text.text = "00:" + ((int)(currentTime)).ToString();
            else
                text.text = "00:0" + ((int)(currentTime)).ToString();
        }
    }
    public void ActualiceText(float time)
    {
        updateText = true;
        currentTime = time;
    }
}
