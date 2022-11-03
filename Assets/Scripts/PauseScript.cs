using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseCanvas;

    private bool paused;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseAndUnpause();
        }
    }

    public void PauseAndUnpause()
    {
        if (!paused)
        {
            paused = true;
            pauseCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pauseCanvas.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
