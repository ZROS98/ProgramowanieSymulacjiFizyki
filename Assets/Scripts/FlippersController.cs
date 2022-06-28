using System;
using UnityEngine;

public class FlippersController : MonoBehaviour
{
    [field: SerializeField]
    public int RestPosition { get; set; }
    [field: SerializeField]
    public int PressedPosition { get; set; }
    [field: SerializeField]
    public int HitStrength { get; set; }
    [field: SerializeField]
    public int FlipperDamper { get; set; }
    
    [field: SerializeField]
    public string InputName { get; set; }
    
    [field: SerializeField]
    private HingeJoint CurrentHingeJoint { get; set; }

    private void Start()
    {
        CurrentHingeJoint.useSpring = true;
    }

    private void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = HitStrength;
        spring.damper = FlipperDamper;
        
        if (Input.GetAxis(InputName) == 1)
        {
            spring.targetPosition = PressedPosition;
        }
        else
        {
            spring.targetPosition = RestPosition;
        }

        CurrentHingeJoint.spring = spring;
        CurrentHingeJoint.useLimits = true;
    }
}
