using UnityEngine;

public class BootManager : MonoBehaviour
{
    void Start()
    {
        SceneLoader.Instance.LoadScene("MainMenu");
    }
}
