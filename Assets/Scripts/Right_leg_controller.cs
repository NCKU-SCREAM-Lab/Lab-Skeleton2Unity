using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bones_controller;
using static lab_skeleton;
using static unity_humanbones;

public class Right_leg_controller
{
    Bone_controller Controller = new Bone_controller();

    public void Lab_Right_leg_Rotation_controller(int frame, lab_skeleton labSkeleton, HumanBodyTransform humanbodytransform)
    {
        // Right Hip Rotation
        humanbodytransform.R_Hip.Rotate(Controller.R_UpperLeg_rotation(
            labSkeleton.coordinate_list[frame, 9], 
            labSkeleton.coordinate_list[frame, 10], 
            humanbodytransform.R_Knee, 
            humanbodytransform.R_Hip
            ).eulerAngles, Space.World);

        // Right Knee Rotation
        humanbodytransform.R_Knee.Rotate(Controller.R_Knee_rotation(
            labSkeleton.coordinate_list[frame, 10], 
            labSkeleton.coordinate_list[frame, 11], 
            humanbodytransform.R_Foot, 
            humanbodytransform.R_Knee
            ).eulerAngles, Space.World);
    }
}