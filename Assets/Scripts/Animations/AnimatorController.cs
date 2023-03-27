using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    [SerializeField]InputReader inputReader = default;
    [SerializeField] private StatsSO stats;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        animator.SetFloat("Speed", stats.MovementSpeed);
    }

}
