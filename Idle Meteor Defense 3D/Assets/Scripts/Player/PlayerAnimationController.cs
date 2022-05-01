using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        AssignVariables();
    }

    public void Shoot()
    {
        anim.Play("shoot");
    }

    private void AssignVariables()
    {
        anim = GetComponent<Animator>();
    }
}
