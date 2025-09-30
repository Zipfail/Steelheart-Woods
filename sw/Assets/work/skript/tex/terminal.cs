using UnityEngine;

public class terminal : MonoBehaviour
{
    [SerializeField]private float xp_term;
    [SerializeField]private float xp_def;
    public bool life_term = true;
    private float xp_max;
    void Start()
    {
        xp_max = xp_term;
    }

    // Update is called once per frame
    void Update()
    {
        xp_term -= xp_def;
        life_term = true;
        if(xp_term <= 0)
        {
            life_term=false;
        }
    }

    public void regen_term()
    {
        xp_term = xp_max;
    }
}
