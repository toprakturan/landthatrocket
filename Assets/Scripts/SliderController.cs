using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public float fuel;
    public Slider slider;
    private int CurrentLevel;
    public static SliderController Current;
    public float _upSpeed;


    private void Start()
    {
        Current = this;
        
        
    }
    private void Update()
    {

        CurrentLevel = CollisionController.Current.getCurrentLevelIndex;
        _upSpeed = PlayerController.Current.upSpeed;
        if (CurrentLevel == 1)
        {
            UpdateFuel(5f);
        }
        else if(CurrentLevel == 2)
        {
            UpdateFuel(0.8f);
        }
        else if (CurrentLevel == 3)
        {
            UpdateFuel(1f);
        }
        else if (CurrentLevel == 4)
        {
            UpdateFuel(1.3f);
        }
        else if (CurrentLevel == 5)
        {
            UpdateFuel(1.5f);
        }
        else
        {
            return;
        }


    }
    public void UpdateFuel(float fuelIncreaseValue)
    {
        slider.value -= fuelIncreaseValue;
        fuel = slider.value;
    }

   
}
