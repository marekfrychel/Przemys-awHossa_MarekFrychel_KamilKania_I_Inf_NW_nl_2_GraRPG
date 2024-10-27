using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    public float moveSpeed;

//    private bool isMoving;

//    private Vector2 input;

//    private Animator animator;

//    private void Awake()
//    {
//        animator = GetComponent<Animator>();
//        Debug.Log("Animator:" + animator);
//    }

//    private void Update()
//    {
//        if (!isMoving)
//        {
//            input.x = Input.GetAxisRaw("Horizontal");
//            input.y = Input.GetAxisRaw("Vertical");

//            if (input.x != 0) input.y = 0;

//            if (input != Vector2.zero)
//            {
//                animator.SetFloat("moveX", input.x);
//                animator.SetFloat("moveY", input.y);

//                var targetPos = transform.position;
//                targetPos.x += input.x;
//                targetPos.y += input.y;

//                StartCoroutine(Move(targetPos));
//            }
//        }

//        animator.SetBool("isMoving", isMoving);


//    }
//    IEnumerator Move(Vector3 targetPos)
//    {
//        isMoving = true;

//        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
//        {
//            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
//            yield return null;
//        }

//        transform.position = targetPos;
//        isMoving = false;
//    }
//}


public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving;

    private Vector2 input;

    private Animator animator;

    public LayerMask solidObjectsLayer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        Debug.Log("Animator: " + animator);
    }

    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");


            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {

                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                Debug.Log("This is input.x" + input.x);


                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));


                StartCoroutine(Move(targetPos));
            }
        }

        animator.SetBool("isMoving", isMoving);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) != null)
        {
            return false;
        }
        return true;
    }

}

