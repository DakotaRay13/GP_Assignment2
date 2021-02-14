using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameManager gm;

    private Rigidbody rb;

    private int count;

    private float movementX;
    private float movementY;

    public float speed = 0f;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        GetComponent<MeshRenderer>().material.color = gm.GetBallColor();
        speed = gm.GetBallSpeed() * 10f;

        if (gm.IsBallOversized())
        {
            transform.localScale = new Vector3(5, 5, 5);
            transform.position = new Vector3(0, 2.5f, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.position = new Vector3(0, 0.5f, 0);
        }

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if(count >= 12)
        {
            StartCoroutine(WinGame());
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        if(transform.position.y < -5)
        {
            transform.position = transform.position = new Vector3(0, 2.5f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    public IEnumerator WinGame()
    {
        winTextObject.SetActive(true);

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("EndMenu");
    }
}
