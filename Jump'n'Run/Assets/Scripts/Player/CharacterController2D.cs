using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class CharacterController2D : MonoBehaviour
{
    // Move player in 2D space
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    public float maxCameraXLeft;
    public float maxCameraXRight;
    public float backgroundScrollingSpeed;
    public float backgroundY;
    public float backgroundZ;
    public bool disableInput;
    public Camera mainCamera;
    public GameObject background;
    public Vector3 cameraRespawnPoint;
    public Animator animator;
    public Sprite jumpSprite;
    
    bool facingRight = true;
    float moveDirection = 0;
    public bool isGrounded = false;
    private Vector3 respawnPoint;
    Vector3 cameraPos;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;

    // Use this for initialization
    void Start()
    {
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;
        respawnPoint = transform.position;

        if (mainCamera)
        {
            cameraPos = mainCamera.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!disableInput)
        {
            // Movement controls
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) &&
                (isGrounded || Mathf.Abs(r2d.velocity.x) > 0.01f))
            {
                moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
            }
            else
            {
                if (isGrounded || r2d.velocity.magnitude < 0.01f)
                {
                    moveDirection = 0;
                }
            }

            // Change facing direction
            if (moveDirection != 0)
            {
                if (moveDirection > 0 && !facingRight)
                {
                    facingRight = true;
                    t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
                }

                if (moveDirection < 0 && facingRight)
                {
                    facingRight = false;
                    t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
                }
            }

            // Jumping
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
            }

            // Camera follow
            if (mainCamera)
            {
                if (r2d.position.x > maxCameraXLeft && r2d.position.x < maxCameraXRight)
                    mainCamera.transform.position = new Vector3(t.position.x, cameraPos.y, cameraPos.z);
            }

            if (isGrounded)
            {
                animator.SetBool("IsJumping", false);
            }
            else
            {
                animator.SetBool("IsJumping", true);
            }
        }
    }

    void FixedUpdate()
    {
        r2d.isKinematic = false;
        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);

        isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider)
                {
                    isGrounded = true;
                    break;
                }
            }
        }

        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(r2d.velocity.x));
        if (r2d.position.x > maxCameraXLeft && r2d.position.x < maxCameraXRight)
        {
            var position = transform.position;
            background.transform.position = new Vector3(position.x * backgroundScrollingSpeed, backgroundY, backgroundZ);
        }

        if (transform.position.y < -8)
        {
            r2d.isKinematic = true;
            transform.position = respawnPoint;
            mainCamera.transform.position = cameraRespawnPoint;
        }
        
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderRadius, 0), isGrounded ? Color.green : Color.red);
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderRadius, 0, 0), isGrounded ? Color.green : Color.red);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Platform"))
        {
            transform.SetParent(other.collider.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Platform"))
        {
            transform.SetParent(null);
        }
    }
}