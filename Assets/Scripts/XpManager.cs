using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class XpManager : MonoBehaviour
{
    private int progress = 0;
    [SerializeField]
    private Slider slider;

    private void Start()
    {
        
    }
    private void Update()
    {
        slider.value = progress;
        CheckIfMaxProgress();
    }
    public void UpdateProgress()
    {
        progress++;
    }

    private void CheckIfMaxProgress()
    {
        if (progress >= slider.maxValue)
        {
            LevelUpScript.levelup.LevelUp();
            progress = 0;
            slider.maxValue += 5;
        }
    }


}
