using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bones_controller;
using static lab_skeleton;
using static unity_humanbones;

public class Left_leg_controller
{
    Bone_controller Controller = new Bone_controller();
    
    public void Lab_Left_leg_Rotation_controller(int frame)
    {
        // Left Hip Rotation
        unity_humanbones.L_Hip.Rotate(Controller.L_UpperLeg_rotation(
            lab_skeleton.coordinate_list[frame, 12], 
            lab_skeleton.coordinate_list[frame, 13], 
            unity_humanbones.L_Knee, 
            unity_humanbones.L_Hip
            ).eulerAngles, Space.World);

        // Left Knee Rotation
        unity_humanbones.L_Knee.Rotate(Controller.L_Knee_rotation(
            lab_skeleton.coordinate_list[frame, 13], 
            lab_skeleton.coordinate_list[frame, 14], 
            unity_humanbones.L_Knee, 
            unity_humanbones.L_Foot
            ).eulerAngles, Space.World);
    }
}