using UnityEngine;

public class pl_move : MonoBehaviour
{

    [SerializeField] private baz_UI baz_UI;


    [SerializeField] private float jumpPower = 3.0f;
    [SerializeField] private float _speedRun;
    [SerializeField] private float _speedWalk;
    [SerializeField] private float mouseSens = 100.0f;
    private float xRotation = 0f;
    [SerializeField] private Transform camer;
    

    //private float gravity = 9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;

    private float speed;

    private Vector3 _velositi;

    private CharacterController controler;

    private bool walk_bool = true;

    void Start()
    {
        controler = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        speed = _speedWalk;
    }


    void Update()
    {
        if (walk_bool)
        {
            camera_move();
            player_move();
            Gravity();
            if (Input.GetKey(KeyCode.Space)) Jump(controler.isGrounded);
            Run(Input.GetKey(KeyCode.LeftShift));
            sit(Input.GetKey(KeyCode.LeftControl));
        }

    }

    private void camera_move()//отвечает за камеру
    {
        float mousX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mousY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mousY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        camer.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mousX);
    }

    private void player_move()//отвечает за движение игрока
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        controler.Move(moveDirection * Time.deltaTime);
    }

    private void Gravity()
    {
        _velositi.y -=  gravityMultiplier;
        controler.Move(_velositi * Time.deltaTime);
    }

    private void Jump(bool canJump)
    {
        if (canJump)
        {
            _velositi.y += jumpPower;
            //controler.Move(_velositi * Time.deltaTime);
        }

    }
    private void Run(bool canRun)
    {
        speed = canRun ? _speedRun : _speedWalk;
    }

    private void sit(bool canSit)
    {
        controler.height = canSit ? 1f : 2f;
    }

    
    public void pl_control(bool sost)
    {
        if (sost)
        {
            walk_on();
            cursoroff();
            baz_UI.menuon();
        }
        else {
            walk_off();
            cursoron();
            baz_UI.menuoff();
        }
    }
    
    
    private void walk_off()
    {
        walk_bool = false;
    }
    private void walk_on()
    {
        walk_bool = true;
    }
    private void cursoroff()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void cursoron()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
