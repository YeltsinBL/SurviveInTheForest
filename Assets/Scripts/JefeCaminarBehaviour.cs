using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeCaminarBehaviour : StateMachineBehaviour
{
    private EnemigoJefe jefe;
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float velocidadMovimiento;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       jefe = animator.GetComponent<EnemigoJefe>();
       rigidbody2D = jefe.rigidbody2D;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       jefe.MirarJugador();
        Debug.Log("animator.transform.right" + animator.transform.right);
       rigidbody2D.velocity = new Vector2(velocidadMovimiento, rigidbody2D.velocity.y) * -animator.transform.right;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
