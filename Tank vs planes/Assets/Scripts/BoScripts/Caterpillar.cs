using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caterpillar : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private List<Animator> animators = new List<Animator>();
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetAnimation(int x)
    {

        animator.SetInteger("direction",x);
        SetAnimationsCircless(x);

    }
    private void SetAnimationsCircless(int x)
    {
        for (int i = 0; i < animators.Count; i++)
        {
            animators[i].SetInteger("direction", x);
        }
    }

}
