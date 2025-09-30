using UnityEngine;

public class PicUp : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private float distance = 15f;
    private GameObject currentWeapon;
    [SerializeField] private Transform Pic_vexctor;
    private bool canPickUp;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) Pic();
        if (Input.GetKeyDown(KeyCode.Q)) Drop();
    }

    void Pic()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "UP")
            {
                if (canPickUp) Drop();

                currentWeapon = hit.transform.gameObject;
                currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
                currentWeapon.transform.parent = transform;
                currentWeapon.transform.localPosition = Pic_vexctor.localPosition;
                currentWeapon.transform.localEulerAngles = new Vector3(50f, 180f, 83f);
                canPickUp = true;

            }
        }

    }

    void Drop()
    {
        currentWeapon.transform.parent = null;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        canPickUp = false;
        currentWeapon = null;
    }
}
