using UnityEngine;
using UnityEngine.UI;

public class ResetButtonAnimation : MonoBehaviour
{
    private Button button;
    private Animator animator;

    private void Awake()
    {
        button = GetComponent<Button>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        button = GetComponent<Button>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        animator.Play("Normal");
    }
}