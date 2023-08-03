using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CompletedScreenScript : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.FindGameObjectWithTag("panel");
        //panel.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnContinueButton()
    {
        panel.SetActive(false);
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
