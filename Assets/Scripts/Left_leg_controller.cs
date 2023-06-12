using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bones_controller;
using static lab_skeleton;
using static unity_humanbones;

public class Left_leg_controller
{
    Bone_controller Controller = new Bone_controller();
    
    public void Lab_Left_leg_Rotation_controller(int frame, lab_skeleton labSkeleton, HumanBodyTransform humanbodytransform)
    {
        // Left Hip Rotation
        humanbodytransform.L_Hip.Rotate(Controller.L_UpperLeg_rotation(
            labSkeleton.coordinate_list[frame, 12], 
            labSkeleton.coordinate_list[frame, 13], 
            humanbodytransform.L_Knee, 
            humanbodytransform.L_Hip
            ).eulerAngles, Space.World);

        // Left Knee Rotation
        humanbodytransform.L_Knee.Rotate(Controller.L_Knee_rotation(
            labSkeleton.coordinate_list[frame, 13], 
            labSkeleton.coordinate_list[frame, 14], 
            humanbodytransform.L_Knee, 
            humanbodytransform.L_Foot
            ).eulerAngles, Space.World);
    }
}