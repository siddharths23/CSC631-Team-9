using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public void LoadScene2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene2");
    }

    void Update()
    {
        if (Input.GetButtonDown("LoadScene2"))
        {
            LoadScene2();
        }
    }
}

