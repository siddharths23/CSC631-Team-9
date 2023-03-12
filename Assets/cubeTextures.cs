
using UnityEngine;

public class cubeTextures : MonoBehaviour
{
    public Material[] materials;

    private int currentMaterialIndex = 0;

    void Start()
    {
        // Apply the first material in the list
        GetComponent<Renderer>().material = materials[currentMaterialIndex];
    }

    void Update()
    {
        // Check if the user pressed the "Change Material" button (in this example, "Q" key)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentMaterialIndex++;
            if (currentMaterialIndex >= materials.Length)
            {
                currentMaterialIndex = 0;
            }
            // Apply the new material
            GetComponent<Renderer>().material = materials[currentMaterialIndex];
        }
    }
}