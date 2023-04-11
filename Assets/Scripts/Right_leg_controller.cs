using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bones_controller;
using static lab_skeleton;
using static unity_humanbones;

public class Right_leg_controller
{
    Bone_controller Controller = new Bone_controller();

    public void Lab_Right_leg_Rotation_controller(int frame)
    {
        // Right Hip Rotation
        unity_humanbones.R_Hip.Rotate(Controller.R_UpperLeg_rotation(
            lab_skeleton.coordinate_list[frame, 9], 
            lab_skeleton.coordinate_list[frame, 10], 
            unity_humanbones.R_Knee, 
            unity_humanbones.R_Hip
            ).eulerAngles, Space.World);

        // Right Knee Rotation
        unity_humanbones.R_Knee.Rotate(Controller.R_Knee_rotation(
            lab_skeleton.coordinate_list[frame, 10], 
            lab_skeleton.coordinate_list[frame, 11], 
            unity_humanbones.R_Foot, 
            unity_humanbones.R_Knee
            ).eulerAngles, Space.World);
        
        // Right Foot Rotation
        unity_humanbones.R_Foot.Rotate(Controller.R_Foot_rotation(
            lab_skeleton.coordinate_list[frame, 10], 
            lab_skeleton.coordinate_list[frame, 11], 
            lab_skeleton.coordinate_list[frame, 20], 
            unity_humanbones.R_Toe, 
            unity_humanbones.R_Foot, 
            unity_humanbones.R_Knee
            ).eulerAngles, Space.World);
    }
}