using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] public float upSpeed; //Up speed' i sýfýrla
    [SerializeField] private float rotateSpeed;
    [SerializeField] AudioClip mainEngine;
    public float Fuel;
    public Slider slider;
    private int CurrentLevel;
    public static PlayerController Current;
    AudioSource audioSource;
    private bool _isfuelCollided;

    [SerializeField] ParticleSystem mainEngineParticle;
    

    void Start()
    {
        Fuel = 10000f;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        Current = this;
    }

    
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        //Debug.Log(slider.value.ToString());
       

        CurrentLevel = CollisionController.Current.getCurrentLevelIndex;
        _isfuelCollided = CollisionController.Current.fuelCollision;
        


    }

    public void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * upSpeed * Time.deltaTime);

            //Level check to update fuel consumption
            if (CurrentLevel == 1)
            {
                UpdateFuel(2f);
                
            }
            else if (CurrentLevel == 2)
            {
                UpdateFuel(3f);
            }
            else if (CurrentLevel == 3)
            {
                UpdateFuel(4f);
            }
            else if (CurrentLevel == 4)
            {
                UpdateFuel(5f);
            }
            else if (CurrentLevel == 5)       
            {
                UpdateFuel(5f);
            }
            else
            {
                
            }

            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
                mainEngineParticle.Play();
            }
            }
            else
            {
            audioSource.Stop();
            mainEngineParticle.Stop();
            }
    }

    public void UpdateFuel(float fuelIncreaseValue)
    {
        slider.value -= fuelIncreaseValue;
        Fuel = slider.value;
    }

    public void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(-rotateSpeed);
        }
    }

    public void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freeze rotation
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing back to normal
    }

    //public void fillFuel(float fillValue)
    //{
    //    if(_isfuelCollided == true)
    //    {
    //        slider.value += fillValue;
           
    //    }
    //}
}
