using UnityEngine;
//using UnityEngine.Windows;

public class pl_player : MonoBehaviour
{
    [SerializeField] private Transform camer;
    [SerializeField] private float distanse_Hit;
    [SerializeField] private PicUp pic;
    public string raycast_tag;

    private bool Input_E;
    private bool Interakt;

    private int metal_ditals = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKeyUp(KeyCode.E)) Input_E = true;
        else Input_E = false;

        RaycastHit hit;
        if (Physics.Raycast(camer.position, camer.forward, out hit, distanse_Hit))
        {
            raycast_tag = hit.transform.tag;
            switch (raycast_tag)
            {
                case "bad":
                    Interakt = true;
                    if (Input_E)hit.transform.GetComponent<sleap>().sleap_bed();
                    break;
                case "dital":
                    Interakt = true;
                    if (Input_E)
                    {
                        Destroy(hit.transform.gameObject);
                        metal_ditals++;
                    }

                    break;
                case "term":
                    Interakt = true;
                    //print("f");
                    if (pic.currentWeapon != null)
                    {
                        if (Input_E && metal_ditals > 0 && pic.currentWeapon.transform.name == "ремонтный набор")
                        {
                            hit.transform.GetComponent<terminal>().regen_term();
                            metal_ditals--;
                        }
                    }
                    break;
            }

        }
    }
}
