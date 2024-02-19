using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float horizontalMovement;
    private float verticalMovement;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private float standingHeight;
    private CapsuleCollider coll;
    private PlayerCamera cam;

    public float movementSpeed;
    public float crouchHeight;
    public int gems;
    public TextMeshProUGUI gemsText;
    public TextMeshProUGUI caughtText;
    public GameObject restartButton;
    public GameObject quitButton;
    public TextMeshProUGUI finalGemsText;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<CapsuleCollider>();
        standingHeight = coll.height;
        cam = FindObjectOfType<PlayerCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            coll.height = crouchHeight;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            coll.height = standingHeight;
        }

        gemsText.text = ("Gems: " + gems);
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDirection.normalized * movementSpeed, ForceMode.Acceleration);
    }

    public void PlayerCaught()
    {
        cam.canLook = false;
        Destroy(gemsText);
        restartButton.SetActive(true);
        quitButton.SetActive(true);
        caughtText.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    public void FoundLargeGem()
    {
        cam.canLook = false;
        gems++;
        Destroy(gemsText);
        finalGemsText.text = ("You collected " + gems + " gems.");
        finalGemsText.gameObject.SetActive(true);
        restartButton.SetActive(true);
        quitButton.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
}
