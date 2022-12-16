using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bones_controller;
using static Transform__init__;
using static lab_skeleton;
using static unity_humanbones;

public class Torso_controller
{
    public Bone_controller Controller = new Bone_controller();
    // public Transform__init__ t = new Transform__init__();
    // public void Torso_Rotation_controller()
    // {
    //     // head Rotation
    //     Head.Rotate(Controller.Head_rotation(v_l_mouth, v_r_mouth, v_head, v_l_upperarm, v_r_upperarm).eulerAngles, Space.World);

    //     // Hip Rotation
    //     transform.localEulerAngles = new Vector3(0, 0, 0);
    //     transform.Rotate(Controller.Hip_rotation(v_l_upperleg, v_r_upperleg).eulerAngles);

    //     // Spine Rotation
    //     Spine.Rotate(bones_controller.Spine_rotation(v_l_upperleg, v_r_upperleg, v_l_upperarm, v_r_upperarm, L_Shoulder, R_Shoulder, L_Hip, R_Hip).eulerAngles, Space.World);
    // }

    public void Lab_Torso_Rotation_controller(int frame)
    {
        // Hip Rotation
        // unity_humanbones.Hip.localEulerAngles = new Vector3(0, 0, 0);
        // unity_humanbones.Hip.Rotate(Controller.Hip_rotation(lab_skeleton.coordinate_list[frame, 12], lab_skeleton.coordinate_list[frame, 9]).eulerAngles);

        // Spine Rotation
        unity_humanbones.Spine.Rotate(Controller.Spine_rotation(lab_skeleton.coordinate_list[frame, 12], lab_skeleton.coordinate_list[frame, 9], lab_skeleton.coordinate_list[frame, 5], lab_skeleton.coordinate_list[frame, 2], unity_humanbones.L_Shoulder, unity_humanbones.R_Shoulder, unity_humanbones.L_Hip, unity_humanbones.R_Hip).eulerAngles, Space.World);
    }
}