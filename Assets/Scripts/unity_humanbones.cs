using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Threading;
using Bones_controller;
using static lab_skeleton;
using static Rotation_controller;
using static HumanBodyTransform;

public class unity_humanbones : MonoBehaviour
{
    // lab_skeleton Lab_skeleton = new lab_skeleton();
    Rotation_controller rotation_controller = new Rotation_controller();
    Bone_controller Controller = new Bone_controller();

    lab_skeleton Lab_skeleton1 = new lab_skeleton();
    lab_skeleton Lab_skeleton2 = new lab_skeleton();
    lab_skeleton Lab_skeleton3 = new lab_skeleton();

    static public GameObject GT;
    static public GameObject Frag_ori;
    static public GameObject Frag;

    HumanBodyTransform HumanBodyTransform1; 
    HumanBodyTransform HumanBodyTransform2;
    HumanBodyTransform HumanBodyTransform3; 

    int count = 0;

    void Start()
    {
        // Set update fps: 10
        Application.targetFrameRate = 12;

        Lab_skeleton1.txt_reader(@"Assets/Motion Data/s_09_act_02_subact_01_ca_03_ori.txt");
        Lab_skeleton2.txt_reader(@"Assets/Motion Data/s_09_act_02_subact_01_ca_03_frag_ori.txt");
        Lab_skeleton3.txt_reader(@"Assets/Motion Data/s_09_act_02_subact_01_ca_03_frag.txt");

        Frag = GameObject.Find("Frag");
        Frag_ori = GameObject.Find("Frag_ori");
        GT = GameObject.Find("GT");

        HumanBodyTransform1 = new HumanBodyTransform(GT.GetComponent<Animator>());
        HumanBodyTransform2 = new HumanBodyTransform(Frag_ori.GetComponent<Animator>());
        HumanBodyTransform3 = new HumanBodyTransform(Frag.GetComponent<Animator>()); 

    }
    
    void Update()
    {
        // Update the bones for each lab_skeleton instance
        UpdateBones(Lab_skeleton1, HumanBodyTransform1);
        UpdateBones(Lab_skeleton2, HumanBodyTransform2);
        UpdateBones(Lab_skeleton3, HumanBodyTransform3);
        count += 1;
    }

    void UpdateBones(lab_skeleton labSkeleton, HumanBodyTransform humanbodytransform)
    {
        if (count < labSkeleton.coordinate_list.Length)
        {
            // Apply bone transformations based on the coordinate list
            humanbodytransform.Hip.localEulerAngles = new Vector3(0, 0, 0);
            humanbodytransform.Hip.Rotate(Controller.Hip_rotation(labSkeleton.coordinate_list[count, 12], labSkeleton.coordinate_list[count, 9]).eulerAngles, Space.World);
            rotation_controller.Lab_Rotation(count, labSkeleton, humanbodytransform);
        }
    }
    
}

