using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToNight : MonoBehaviour
{
    public string nightScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public void ChangetoNight()
    {
        SceneManager.LoadScene(nightScene);
    }
}
