using UnityEngine;

public class PlayerMaterialSwitch : MonoBehaviour
{
    public Material material1;
    public Material material2;

    private Renderer rend;
    private int currentMaterialIndex = 0;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = material1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentMaterialIndex = (currentMaterialIndex + 1) % 2;

            if (currentMaterialIndex == 0)
            {
                rend.material = material1;
            }
            else
            {
                rend.material = material2;
            }
        }
    }
}
