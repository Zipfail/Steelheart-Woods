using UnityEngine;

public class sleap : MonoBehaviour
{
    [SerializeField] private time _time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sleap_bed()
    {
        _time.time_set(0);
        _time.day++;
    }
}
