using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// CountDownTimer class that defines the oxygen time
/// </summary>
public class CountDownTimer : MonoBehaviour
{
    /// <summary>
    /// StartTime
    /// </summary>
    [SerializeField] float startTime = 5f;

    /// <summary>
    /// UI Slider
    /// </summary>
    [SerializeField] Slider slider;

    /// <summary>
    /// TimerText
    /// </summary>
    [SerializeField] TextMeshProUGUI timerText;


    /// <summary>
    /// audioTimer to handle the audiosource
    /// </summary>
    [SerializeField] AudioSource audioTimer;

    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    /// <summary>
    /// Timer couritne to define the countdown 
    /// </summary>
    /// <returns></returns>
    private IEnumerator Timer()
    {
        timer = startTime;

        do
        {
            timer -= Time.deltaTime;
            slider.value = timer / startTime;
            FormatText();
            if(slider.value == 0.4f)
                audioTimer.Play();
            yield return null;
        }
        while (timer > 0);
        if (slider.value == 0)
            SceneManager.LoadScene(0);
    }

    private void FormatText()
    {

        int seconds = (int)(timer);
        timerText.text = "";
        if (seconds > 0)
            timerText.text += seconds;
        if (seconds == (int)(startTime) / 2)
        {
            Color32 col = new Color(1.0f, 0.92f, 0.016f, 1.0f);
            timerText.color = col;
        }
        else if (seconds == (int)(startTime) / 4)
        {
            timerText.color = new Color32(222, 41, 22, 255);
        }
    }
}
