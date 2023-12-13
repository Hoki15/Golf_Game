using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrow : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform spawn;
    public float force = 0f;
    public float hight = 5f;
    public float actionSpeed= 1f;

    public LineRenderer lineRenderer;
    public int linePoints = 5;
    public const float timeIntervalInPoints = 0.05f;

    public float click = 0;

    public static BallThrow instance;

    public bool isMoving = true;

    public bool inAir = false;


    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            value();
        }
        if (lineRenderer != null)
        {
            if (Input.GetMouseButton(0) && click == 0)
            {
                DrawTrajectory();
                lineRenderer.enabled = true;
            }
            else
                lineRenderer.enabled = false;
        }

        if (Input.GetMouseButtonUp(0) && click == 0)
        {
            rb.velocity = new Vector3(force, hight, 0);
            click++;
        }

        IsInAir();
        checkIfMoving();


        if (force >= 14 && click == 0)
        {
            force = 13f;
            hight = 18f;
            rb.velocity = new Vector3(force, hight, 0);
            click++;
            Debug.Log(click);
        }
    }


    public void value()
    {
        force += actionSpeed * Time.deltaTime;
        hight += actionSpeed * Time.deltaTime;
    }


    public void checkIfMoving()
    {
        if (rb.velocity.x < 0.5 && rb.velocity.y < 0.5 && click == 1)
        {
            isMoving = false;
        }
        else
            isMoving = true;
    }

    public void IsInAir()
    {
        if (rb.position.y > -2.5)
            inAir = true;
        else
            inAir = false;
    }


    public void ResetBall()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
        rb.position = spawn.position;
        force = 0;
        hight = 5f;
        click = 0;
        rb.rotation = 0f;
        actionSpeed += 0.5f;
    }


    void DrawTrajectory()
    {
        Vector3 origin = spawn.position;
        Vector3 startVelocity = new Vector3(force * 0.5f, hight * 0.6f, 0);
        lineRenderer.positionCount = linePoints;
        float time = 0;
        for (int i = 0; i < linePoints; i++)
        {
            // s = u*t + 1/2*g*t*t
            var x = (startVelocity.x * time) + (Physics.gravity.x / 2 * time * time);
            var y = (startVelocity.y * time) + (Physics.gravity.y / 2 * time * time);
            Vector3 point = new Vector3(x, y, 0);
            lineRenderer.SetPosition(i, origin + point);
            time += timeIntervalInPoints;
        }
    }

}

