using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 targetPosition;
    private Vector3 movementDirection;

    public float moveSpeed = 10f;
    [SerializeField] private float rotateSpeed = 40f;

    Animator playerAnimator;

    public Slider slider;
    public GameObject gameOverUI;

    void Start()
    {
        targetPosition = transform.position;
        playerAnimator = GetComponent<Animator>();
        gameOverUI.SetActive(false);

    }

    void Update()
    {
        if (gameOverUI.activeInHierarchy)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            GetPosition();                                                      //get position of click or touch
        }

        if(targetPosition != transform.position)
        {

            movementDirection = (targetPosition - transform.position).normalized;       //get normalised direction vector for movement

            SpeedFromSlider();

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);       //move to the new position

            Quaternion newRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, rotateSpeed * 10 * Time.deltaTime);      //rotate from initial rotation to the new rotation

        }
    }

    void GetPosition()                                                          //Function to fetch position using a ray from camera to mouse position in worldspace.
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))                    //returns true if raycast output hits a collider
        {
            targetPosition = new Vector3(raycastHit.point.x,                    //set target position to position of hit point
                                         0.5f,
                                         raycastHit.point.z);
        }
    }

    void SpeedFromSlider()
    {
        if (slider.value == 0)
            moveSpeed = 5f;
        else if (slider.value == 1)
            moveSpeed = 10f;
        else if(slider.value == 2)
            moveSpeed = 15f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Killer")
        {
            gameOverUI.SetActive(true);
        }
    }
}
