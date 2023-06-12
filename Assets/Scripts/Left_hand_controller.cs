using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bones_controller;
using static lab_skeleton;
using static unity_humanbones;

public class Left_hand_controller
{
    Bone_controller Controller = new Bone_controller();

    public void Lab_Left_hand_Rotation_controller(int frame, lab_skeleton labSkeleton, HumanBodyTransform humanbodytransform)
    {
        // Left Shoulder Rotation
        humanbodytransform.L_Shoulder.Rotate(Controller.L_Shoulder_rotation(
            labSkeleton.coordinate_list[frame, 5], 
            labSkeleton.coordinate_list[frame, 6], 
            humanbodytransform.L_Elbow, 
            humanbodytransform.L_Shoulder
            ).eulerAngles, Space.World);

        // Left Elbow Rotation
        humanbodytransform.L_Elbow.Rotate(Controller.L_Elbow_rotation(
            labSkeleton.coordinate_list[frame, 6], 
            labSkeleton.coordinate_list[frame, 7], 
            humanbodytransform.L_Hand, 
            humanbodytransform.L_Elbow
            ).eulerAngles, Space.World);
    }
}