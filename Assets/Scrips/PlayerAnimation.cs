using UnityEngine;

namespace Scrips
{
    public class PlayerAnimation : MonoBehaviour
    {
        private Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void StepRight()
        {
            animator.SetTrigger("RightStep");
        }

        public void StepLeft()
        {
            animator.SetTrigger("LeftStep");
        }

        public void Jump()
        {
            animator.SetTrigger("DoJump");
        }
    }
}