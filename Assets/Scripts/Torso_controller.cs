using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bones_controller;
// using static Transform__init__;
using static lab_skeleton;
using static unity_humanbones;

public class Torso_controller
{
    public Bone_controller Controller = new Bone_controller();

    public void Lab_Torso_Rotation_controller(int frame, lab_skeleton labSkeleton, HumanBodyTransform humanbodytransform)
    {
        // Spine Rotation
        humanbodytransform.Spine.Rotate(Controller.Spine_rotation(
            labSkeleton.coordinate_list[frame, 12], 
            labSkeleton.coordinate_list[frame, 9], 
            labSkeleton.coordinate_list[frame, 5], 
            labSkeleton.coordinate_list[frame, 2], 
            humanbodytransform.L_Shoulder, 
            humanbodytransform.R_Shoulder, 
            humanbodytransform.L_Hip, 
            humanbodytransform.R_Hip
            ).eulerAngles, Space.World);
    }
}