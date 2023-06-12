using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bones_controller;
// using static Transform__init__;
using static lab_skeleton;
using static unity_humanbones;

public class Right_hand_controller
{
    Bone_controller Controller = new Bone_controller();
    
    public void Lab_Right_hand_Rotation_controller(int frame, lab_skeleton labSkeleton, HumanBodyTransform humanbodytransform)
    {
        // Right Shoulder Rotation
        humanbodytransform.R_Shoulder.Rotate(Controller.R_Shoulder_rotation(
            labSkeleton.coordinate_list[frame, 2], 
            labSkeleton.coordinate_list[frame, 3], 
            humanbodytransform.R_Elbow, 
            humanbodytransform.R_Shoulder
            ).eulerAngles, Space.World);

        // Right Elbow Rotation
        humanbodytransform.R_Elbow.Rotate(Controller.R_Elbow_rotation(
            labSkeleton.coordinate_list[frame, 3], 
            labSkeleton.coordinate_list[frame, 4], 
            humanbodytransform.R_Hand, 
            humanbodytransform.R_Elbow
            ).eulerAngles, Space.World);
    }
}