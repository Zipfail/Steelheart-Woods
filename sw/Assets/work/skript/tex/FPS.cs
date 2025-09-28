using UnityEngine;

public class FPS : MonoBehaviour
{
    public int max_FPS;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = max_FPS;
    }
}
