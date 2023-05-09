using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;
            
    [SerializeField] private float waitTime = 1f;

    private float currentTimeScale;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject.transform.root.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentTimeScale = Time.timeScale;
    }

    public void PauseTimeScale()
    {
        Time.timeScale = 0;
    }

    public void StartTimeScale()
    {

        Time.timeScale = currentTimeScale;
    }

    public void ReturnStartPosition()
    {
        StartCoroutine(nameof(ReloadScene));        
    }

    private IEnumerator ReloadScene()
    {
        PauseTimeScale();
        yield return new WaitForSecondsRealtime(waitTime); 
        
        SceneManager.LoadScene(0);
        StartTimeScale();
    }
}
