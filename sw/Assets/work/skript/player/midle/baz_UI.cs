using UnityEngine;
using TMPro;

public class baz_UI : MonoBehaviour
{
    [SerializeField] private pl_move pl_move;

    [SerializeField] private TMP_Text Xp_text;
    [SerializeField] private TMP_Text detal_text;
    
    private bool razr_menu;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void info_player(int xp,int detal)
    {
        Xp_text.text = xp.ToString();
        detal_text.text = detal.ToString();
    }

    public void menuoff()
    {
        razr_menu = false;
    }
    public void menuon()
    {
        razr_menu = true;
    }
    public void use_panel(GameObject panel,bool panel_razr)
    {
        pl_move.pl_control(!panel_razr);
        panel.SetActive(panel_razr);
    }
}
