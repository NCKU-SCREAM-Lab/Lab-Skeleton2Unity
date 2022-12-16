using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Bones_controller;
using static lab_skeleton;
using static Rotation_controller;
// using static Transform__init__;

public class unity_humanbones : MonoBehaviour
{

    // Bones_controller bones_controller = new Bones_controller();
    lab_skeleton Lab_skeleton = new lab_skeleton();
    Rotation_controller rotation_controller = new Rotation_controller();
    // Transform__init__ initial_bones = new Transform__init__();

    Animator animation;

    // torso
    public static Transform Head;
    public static Transform Neck;
    public static Transform Spine;
	public static Transform Hip;

    // Left hand
    public static Transform L_Shoulder;
    public static Transform L_Elbow;
    public static Transform L_Hand;
    public static Transform L_Toe;
    public static Transform L_Ring;
    public static Transform L_Index;

    // Left leg
    public static Transform L_Hip;
    public static Transform L_Knee;
    public static Transform L_Foot;

    // Right hand
    public static Transform R_Shoulder;
    public static Transform R_Elbow;
    public static Transform R_Hand;
    public static Transform R_Toe;
    public static Transform R_Ring;
    public static Transform R_Index;

    // Right leg
    public static Transform R_Hip;
    public static Transform R_Knee;
    public static Transform R_Foot;
    
    int count = 0;
    int delay = 0;

    [HideInInspector] public bool isTxStarted = false;

    [SerializeField] string IP = "127.0.0.1"; // local host
    [SerializeField] int rxPort = 8000; // port to receive data from Python on
    [SerializeField] int txPort = 8001; // port to send data to Python on

    // Create necessary UdpClient objects
    UdpClient client;
    IPEndPoint remoteEndPoint;
    Thread receiveThread; // Receiving Thread
        
    public void SendData(string message) // Use to send data to Python
    {
        try
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            client.Send(data, data.Length, remoteEndPoint);
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }
    void Awake()
    {
        // Create remote endpoint (to Matlab) 
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), txPort);

        // Create local client
        client = new UdpClient(rxPort);

        // local endpoint define (where messages are received)
        // Create a new thread for reception of incoming messages
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();

        // Initialize (seen in comments window)
        print("UDP Comms Initialised");
    }

    // Receive data, update packets received
    private void ReceiveData()
    {
        while (true)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref anyIP);
                string text = Encoding.UTF8.GetString(data);
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

    private void ProcessInput(string input)
    {
        // PROCESS INPUT RECEIVED STRING HERE

        if (!isTxStarted) // First data arrived so tx started
        {
            isTxStarted = true;
        }
    }

    //Prevent crashes - close clients and threads properly!
    void OnDisable()
    {
        if (receiveThread != null)
            receiveThread.Abort();

        client.Close();
    }

    // Start is called before the first frame update
    void Start()
    {
        // initial_bones.Bones_initialize();
        animation = GetComponent<Animator>();

        Head = animation.GetBoneTransform(HumanBodyBones.Head);
        Neck = animation.GetBoneTransform(HumanBodyBones.Neck);
        Spine = animation.GetBoneTransform(HumanBodyBones.Spine);
		Hip = animation.GetBoneTransform(HumanBodyBones.Hips);

        L_Shoulder = animation.GetBoneTransform(HumanBodyBones.LeftUpperArm);
        L_Elbow = animation.GetBoneTransform(HumanBodyBones.LeftLowerArm);
        L_Hand = animation.GetBoneTransform(HumanBodyBones.LeftHand);
        L_Toe = animation.GetBoneTransform(HumanBodyBones.LeftToes);
        L_Ring = animation.GetBoneTransform(HumanBodyBones.LeftRingProximal);
        L_Index = animation.GetBoneTransform(HumanBodyBones.LeftIndexProximal);

        L_Hip = animation.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
        L_Knee = animation.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
        L_Foot = animation.GetBoneTransform(HumanBodyBones.LeftFoot);

        R_Shoulder = animation.GetBoneTransform(HumanBodyBones.RightUpperArm);
        R_Elbow = animation.GetBoneTransform(HumanBodyBones.RightLowerArm);
        R_Hand = animation.GetBoneTransform(HumanBodyBones.RightHand);
        R_Toe = animation.GetBoneTransform(HumanBodyBones.RightToes);
        R_Ring = animation.GetBoneTransform(HumanBodyBones.RightRingProximal);
        R_Index = animation.GetBoneTransform(HumanBodyBones.RightIndexProximal);

        R_Hip = animation.GetBoneTransform(HumanBodyBones.RightUpperLeg);
        R_Knee = animation.GetBoneTransform(HumanBodyBones.RightLowerLeg);
        R_Foot = animation.GetBoneTransform(HumanBodyBones.RightFoot);

        Lab_skeleton.txt_reader();
    }
    // Update is called once per frame
    void Update()
    {
        print(Hip.position);
        if (count < lab_skeleton.coordinate_list.Length && delay % 10 == 0)
        {
            rotation_controller.Lab_Rotation(count);
        }

        // delay time
        if (delay % 10 == 0){
            count += 1;
        }
        delay += 1;
    }
    
}
