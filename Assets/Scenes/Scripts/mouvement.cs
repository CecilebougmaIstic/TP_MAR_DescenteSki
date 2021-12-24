
using UnityEngine;
using UnityEngine.UI;


public class mouvement : MonoBehaviour
{
     public Vector3 jump;

    public float timer;
    private bool _isStarted = false;

    public Text TimerDisplay;

    public Text SpacePressed;


    public float Speed = 2;

    public float jumpForce = 2.0f;

    public Rigidbody t;

    void Start(){
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void Update()
    {
        playerMovement();

        if(_isStarted){
            timer += Time.deltaTime;
            TimerDisplay.text = "Temps : " + timer.ToString("0:00");
        }
    }

    void playerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);


       
         if (Input.GetKeyDown(KeyCode.Space))
        {
            t.AddForce(jump * jumpForce, ForceMode.Impulse);
        }

       
        //freinage
        if (Input.GetKey(KeyCode.S))
        {
            if(t.transform.forward.z >0){
                t.AddForce(-2, 0, 0);
            }
        }
    }

     public void OnTriggerExit(Collider other)
     {
        if (other.tag == "startPoint"){
            _isStarted = true;
            timer = 0;
            Debug.Log("game started!");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "endPoint")
        {
            _isStarted = false;
            Debug.Log("game ended!");

        }
    }
}
