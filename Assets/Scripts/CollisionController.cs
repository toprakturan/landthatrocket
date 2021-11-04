using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{

    [SerializeField] float levelLoadDeleay = 2f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;
    public static CollisionController Current;
    public int getCurrentLevelIndex;
    private float _getFuel;
    public bool isFuelEmpty = false;
    public Canvas outOfGasCanvas, crashCanvas;
    public bool fuelCollision = false;
    private Slider _slider;



    AudioSource audioSource;

    bool isTransitioning = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Current = this;
        outOfGasCanvas.GetComponent<Canvas>().enabled = false;
        crashCanvas.GetComponent<Canvas>().enabled = false;
    }

    private void Update()
    {
        getCurrentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        _getFuel = PlayerController.Current.Fuel;
        _slider = PlayerController.Current.slider;

        //StartCrashSequence();
        //StartSuccessSequence();

        //Check fuel is empty
        if (_getFuel == 0 && isFuelEmpty == false)
        {
            StartOutOfGasSequence();
            isFuelEmpty = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning)
        {
            return;
        }
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("this is friend");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            case "fuel":
               // Debug.Log("collision fuel");
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    //To control fuel collision
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "fuel")
        {
            Debug.Log("fuelCollision");
            fuelCollision = true;
            checkSceneToFillFuel();
            Destroy(other.gameObject);
            fuelCollision = false;
        }
    }

    public void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        Debug.Log("deneme");
        GetComponent<PlayerController>().enabled = false; //Stop player movement
        Invoke("LoadNextLevel", 3f);
    }

    public void StartCrashSequence()
    {
        isTransitioning = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        crashParticles.Play();
        GetComponent<PlayerController>().enabled = false; //Stop player movement
        crashCanvas.GetComponent<Canvas>().enabled = true;
        //Invoke("ReloadLevel", 3f);
    }

    public void StartOutOfGasSequence()
    {
        isTransitioning = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        crashParticles.Play();
        GetComponent<PlayerController>().enabled = false; //Stop player movement
        outOfGasCanvas.GetComponent<Canvas>().enabled = true;
        //Invoke("ReloadLevel", 3f);
    }

    void ReloadLevel()
    {
        int currenSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currenSceneIndex);
    }

    void LoadNextLevel()
    {
        int currenSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currenSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    //Fill the fuel
    public void FillFuel(float fillValue)
    {
        _slider.value += fillValue;
    }

    //Level check for the amount of gas to be added
    public void checkSceneToFillFuel()
    {
        if (getCurrentLevelIndex == 1)
        {
            FillFuel(5000f);

        }
        else if (getCurrentLevelIndex == 2)
        {
            FillFuel(3000f);
        }
        else if (getCurrentLevelIndex == 3)
        {
            FillFuel(2500f);
        }
        else if (getCurrentLevelIndex == 4)
        {
            FillFuel(2000f);
        }
        else if (getCurrentLevelIndex == 5)
        {
            FillFuel(1500f);
        }
        else
        {

        }
    }
}
