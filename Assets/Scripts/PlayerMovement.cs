
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("移动设置")]
    public float moveSpeed = 5f;
    private Vector2 currentDir;
    private Vector2 playerPos;
    private Vector2 boxSize = new Vector2(0.8f,0.8f);
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //位置更新
        Vector2 NewDir = new Vector2(h, v).normalized;
        if (NewDir == currentDir)
        {
            playerPos += NewDir * moveSpeed * Time.deltaTime;
            transform.position = playerPos;
            return;
        }
        currentDir = NewDir;

        //

        //动画更新
        anim.SetFloat("Speed", NewDir.magnitude);
        if (currentDir != Vector2.zero)
        {
            anim.SetFloat("Horizontal", currentDir.x);
            anim.SetFloat("Vertical", currentDir.y);
        }
    }
    private void FixedUpdate()
    {

    }
}
