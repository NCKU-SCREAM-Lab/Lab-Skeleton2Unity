using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bones_controller;
using static Transform__init__;
using static lab_skeleton;
using static unity_humanbones;

public class Right_leg_controller
{
    Bone_controller Controller = new Bone_controller();

    Transform__init__ bones = new Transform__init__();

    // public void Right_leg_Rotation_controller()
    // {
    //     // Right Hip Rotation
    //     R_Hip.Rotate(Controller.R_UpperLeg_rotation(v_l_upperleg, v_l_lowerleg, R_Knee, R_Hip).eulerAngles, Space.World);

    //     // Right Knee Rotation
    //     R_Knee.Rotate(Controller.R_Knee_rotation(v_l_lowerleg, v_l_foot, R_Knee, R_Foot).eulerAngles, Space.World);

    //     // Right Foot Rotation
    //     R_Foot.Rotate(Controller.R_Foot_rotation(v_l_lowerleg, v_l_foot, v_l_toe, R_Toe, R_Foot, R_Knee).eulerAngles, Space.World);
    // }

    public void Lab_Right_leg_Rotation_controller(int frame)
    {
        // Right Hip Rotation
        unity_humanbones.R_Hip.Rotate(Controller.R_UpperLeg_rotation(lab_skeleton.coordinate_list[frame, 9], lab_skeleton.coordinate_list[frame, 10], unity_humanbones.R_Knee, unity_humanbones.R_Hip).eulerAngles, Space.World);

        // Right Knee Rotation
        unity_humanbones.R_Knee.Rotate(Controller.R_Knee_rotation(lab_skeleton.coordinate_list[frame, 10], lab_skeleton.coordinate_list[frame, 11], unity_humanbones.R_Foot, unity_humanbones.R_Knee).eulerAngles, Space.World);
    }
}