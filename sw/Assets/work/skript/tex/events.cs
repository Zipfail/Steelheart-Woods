using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class events : MonoBehaviour
{
    [SerializeField] private time _time;
    [SerializeField] private List<GameObject> spavn_pr = new List<GameObject>();
    [SerializeField] private List<GameObject> pr = new List<GameObject>();

    private int last_day = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( _time.day % 2 == 0 && last_day != _time.day)
        {
            last_day = _time.day;
            for (int i = 0; i < spavn_pr.Count; i++)
            {
                Instantiate(pr[Random.Range(0, pr.Count)],spavn_pr[i].transform.position, spavn_pr[i].transform.rotation);
            }
        }
    }
}
