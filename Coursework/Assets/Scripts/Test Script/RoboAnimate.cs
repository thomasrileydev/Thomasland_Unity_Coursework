using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class RoboAnimate : MonoBehaviour {
    public AnimationClip idle;
    public AnimationClip walking;
    public AnimationClip attack;
    public Animation Animation;
    public void Start()
    {
        StartCoroutine(AnimationUpdate());

    }
    IEnumerator AnimationUpdate()

    {
        Rigidbody RB = GetComponent<Rigidbody>();
        if (RB.velocity.x != 0||RB.velocity.z!=0)
        {
            Animation.clip = walking;
            
            yield return new WaitForSeconds(1);
            StartCoroutine(AnimationUpdate());
        }
        else
        {
            Animation.clip = idle;
           
            yield return new WaitForSeconds(1);
            StartCoroutine(AnimationUpdate());

        }

        

    }
        
}
