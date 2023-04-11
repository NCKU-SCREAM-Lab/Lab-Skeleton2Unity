using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bones_controller;
using static lab_skeleton;
using static unity_humanbones;

public class Torso_controller
{
    Bone_controller Controller = new Bone_controller();
    
    public void Lab_Torso_Rotation_controller(int frame)
    {
        // Spine Rotation
        unity_humanbones.Spine.Rotate(Controller.Spine_rotation(
            lab_skeleton.coordinate_list[frame, 12], 
            lab_skeleton.coordinate_list[frame, 9], 
            lab_skeleton.coordinate_list[frame, 5], 
            lab_skeleton.coordinate_list[frame, 2], 
            unity_humanbones.L_Shoulder, 
            unity_humanbones.R_Shoulder, 
            unity_humanbones.L_Hip, 
            unity_humanbones.R_Hip
            ).eulerAngles, Space.World);
    }
}