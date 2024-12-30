using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerMove playerMove;
    [SerializeField] Animator animator;
    [SerializeField] Transform tr;
    public float moveSpeed = 6f;
    public float turnSpeed = 120f;
    private readonly string PosX = "PosX";
    private readonly string PosY = "PosY";

    private readonly int hashrun = Animator.StringToHash("IsRun");
    private readonly int hashreload = Animator.StringToHash("Reload");
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        animator = GetComponent<Animator>();
        tr = transform;
    }
    void FixedUpdate()
    {
        playmove();
        sprint();
        Reload();
    }
    private void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger(hashreload);
        }
    }
    private void sprint()
    {
        if (playerMove.sprint == true)
        {
            moveSpeed = 10f;
            animator.SetBool(hashrun, playerMove.sprint);
        }
        else if (playerMove.sprint == false)
        {
            moveSpeed = 6f;
            animator.SetBool(hashrun, playerMove.sprint);
        }
    }

    private void playmove()
    {
        if (animator != null && playerMove != null)
        {
            Vector3 movedir = (playerMove.h * Vector3.right) + (playerMove.v * Vector3.forward);
            tr.Translate(movedir.normalized * moveSpeed * Time.deltaTime);
            tr.Rotate(Vector3.up * playerMove.r * Time.deltaTime * turnSpeed);
            animator.SetFloat("PosX", playerMove.h, 0.01f, Time.deltaTime);
            animator.SetFloat("PosY", playerMove.v, 0.01f, Time.deltaTime);
        }
    }
}
