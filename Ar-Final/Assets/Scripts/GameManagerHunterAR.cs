using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerHunterAR : MonoSingleton<GameManagerHunterAR>
{
    [SerializeField] public int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private GameObject balloonPrefab;
    [SerializeField] private List<GameObject> gameObjects;
    public Transform ArOrigin;
    public GameObject balloonParticlePrefab;
    [SerializeField] private Animator panelAnimator;
    [SerializeField] private AudioSource[] sounds;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnTargetWithTime", 0.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    void SpawnTargetWithTime()
    {
        if (gameObjects.Count > 10)
        {
            return;
        }
        float randomZort = Random.value;
        if (randomZort < .5f)
        {
            float randomX = Random.Range(-10, 10);
            float randomY = Random.Range(-5, 5);
            float randomZ = Random.Range(-10, 10);
            GameObject obj = Instantiate(targetPrefab, new Vector3(randomX, randomY, randomZ), Quaternion.identity);
            gameObjects.Add(obj);
        }
        else
        {
            float randomX = Random.Range(-10, 10);
            float randomY = Random.Range(-5, 5);
            float randomZ = Random.Range(-10, 10);
            GameObject obj = Instantiate(balloonPrefab, new Vector3(randomX, randomY, randomZ), Quaternion.identity);
            gameObjects.Add(obj);
        }
    }

    public void RemoveFromList(GameObject ObjectToRemove)
    {
        gameObjects.Remove(ObjectToRemove);
    }

    public void PlaySound(SoundType soundType)
    {
        sounds[(int)soundType].Play();
    }

    public void HomeButton()
    {
        panelAnimator.SetTrigger("Reverse");
        Invoke("MenuReturn", 1.2f);
    }

    void MenuReturn()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PauseGame()
    {

    }
}

public enum SoundType
{
    BOW,
    ARROW,
    BALLOON
}
