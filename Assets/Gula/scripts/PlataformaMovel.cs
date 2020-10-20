using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovel : MonoBehaviour
{
    // Start is called before the first frame update
    public SliderJoint2D slider;
    public JointMotor2D aux;
   public void Start()
    {
        aux = slider.motor;
    }

    // Update is called once per frame
   public void Update()
    {
        if(slider.limitState == JointLimitState2D.LowerLimit)
        {
            aux.motorSpeed = 1;
            slider.motor = aux;
        }
        if(slider.limitState == JointLimitState2D.UpperLimit)
        {
            aux.motorSpeed = -1;
            slider.motor = aux;
        }
    }
}
