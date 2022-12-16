using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bones_controller;
using static Transform__init__;
using static lab_skeleton;
using static unity_humanbones;

public class Left_hand_controller
{
    Bone_controller Controller = new Bone_controller();
    // Transform__init__ bones = new Transform__init__();

    // public void Left_hand_Rotation_controller()
    // {
    //     // Left Shoulder Rotation
    //     L_Shoulder.Rotate(Controller.L_Shoulder_rotation(v_l_upperarm, v_l_lowerarm, L_Elbow, L_Shoulder).eulerAngles, Space.World);

    //     // Left Elbow Rotation
    //     L_Elbow.Rotate(Controller.L_Elbow_rotation(v_l_lowerarm, v_l_hand, L_Hand, L_Elbow).eulerAngles, Space.World);

    //     // Left Hand Rotation
    //     L_Hand.Rotate(Controller.L_Hand_rotation(v_l_hand, v_l_index, v_l_pinky, L_Ring, L_Hand, L_Index).eulerAngles, Space.World);
    // }

    public void Lab_Left_hand_Rotation_controller(int frame)
    {
        // Left Shoulder Rotation
        unity_humanbones.L_Shoulder.Rotate(Controller.L_Shoulder_rotation(lab_skeleton.coordinate_list[frame, 5], lab_skeleton.coordinate_list[frame, 6], unity_humanbones.L_Elbow, unity_humanbones.L_Shoulder).eulerAngles, Space.World);

        // Left Elbow Rotation
        unity_humanbones.L_Elbow.Rotate(Controller.L_Elbow_rotation(lab_skeleton.coordinate_list[frame, 6], lab_skeleton.coordinate_list[frame, 7], unity_humanbones.L_Hand, unity_humanbones.L_Elbow).eulerAngles, Space.World);
    }
}