using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    public float speed = 10.0f;
    private float horizontalBoundary = 20.0f;
    private float verticalBoundary = 10.0f;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ValidateAndFixPlayerHorizontalPosition();
        ValidateAndFixPlayerVerticalPosition();
        ControlPlayer();
        FireFood();
    }

    private void ControlPlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
    }

    private void FireFood()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var foodStartPosition = transform.position;
            foodStartPosition.z += 2;

            Instantiate(projectilePrefab, foodStartPosition, projectilePrefab.transform.rotation);
        }
    }

    private void ValidateAndFixPlayerHorizontalPosition()
    {
        if (transform.position.x < -horizontalBoundary)
        {
            transform.position = new Vector3(-horizontalBoundary, transform.position.y, transform.position.z);
        }

        if (transform.position.x > horizontalBoundary)
        {
            transform.position = new Vector3(horizontalBoundary, transform.position.y, transform.position.z);
        }
    }

    private void ValidateAndFixPlayerVerticalPosition()
    {
        if (transform.position.z < -verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -verticalBoundary);
        }

        if (transform.position.z > verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, verticalBoundary);
        }
    }
}
