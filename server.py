import UdpComms as U
import time
import numpy as np
from mediapipe2unity import Mediapipe_to_Unity
from rotation import Unity_Rotation

# Create UDP socket to use for sending (and receiving)
sock = U.UdpComms(udpIP="127.0.0.1", portTX=8000, portRX=8001, enableRX=True, suppressWarnings=True)

# read pickle skeleton data                    
pickle_path = 'D:\\pose_estimation-main\\pose_estimation-main\\Other\\demo1207_workout.pkl'
txt_path = 'D:\\MediapipeSkeleton2Unity\\demo1207_workout.txt'
hip_path = 'D:\\MediapipeSkeleton2Unity\\demo1207_workout_hip_pos.pickle'
hip_txt = 'D:\\MediapipeSkeleton2Unity\\demo1207_workout_hip_pos.txt'
angle_path = 'D:\\human3.6_dataset_train\\d_act_1_ca_01_ang.pkl'
angle_txt = "D:\\MediapipeSkeleton2Unity\\demo1207_ang.txt"
m2u = Mediapipe_to_Unity()
ur = Unity_Rotation()
world_positions_list = m2u.Data_loader(pickle_path)
hip_pos_list = m2u.Pos_loader(hip_path)
ang_list = m2u.Angle_loader(angle_path)
m2u.write_to_txtfile(world_positions_list, txt_path)
m2u.write_to_txtfile(hip_pos_list, hip_txt)
m2u.write_to_txtfile(ang_list, angle_txt)
world_positions_dict = m2u.world_position_to_dict(world_positions_list[10])
# print(hip_pos_list)
# l_arm_rotation_list = m2u.spine_to_Lhand(world_positions_dict['spine'], world_positions_dict['l_upperarm'], world_positions_dict['l_lowerarm'], world_positions_dict['l_hand'])
# r_arm_rotation_list = m2u.spine_to_Rhand(world_positions_dict['spine'], world_positions_dict['r_upperarm'], world_positions_dict['r_lowerarm'], world_positions_dict['r_hand'])
# print(f"left rotation: shoulder(y,z): {(l_arm_rotation_list[1], l_arm_rotation_list[0])}")
# print(f"left rotation: elbow(y,z): {(l_arm_rotation_list[3], l_arm_rotation_list[2])}")
# print("-----------")
# print(f"right rotation: shoulder(y,z): {(r_arm_rotation_list[1], r_arm_rotation_list[0])}")
# print(f"right rotation: elbow(y,z): {(r_arm_rotation_list[3], r_arm_rotation_list[2])}")

# z, y = m2u.Rotation_calc((-0.7196951, 1.536232, -0.01788038),(-0.4613218, 1.536232, -0.01788041),(-0.5732007, 1.471638, 0.2058774))
# z, y ,v = m2u.Rotation_calc((0, 1, 1),(0, 0, 0),(1, 0, 1))
# print(f"z rotation:{z}\ny rotation:{y}")
# z, y = m2u.Rotation_calc()

# elbow = (-0.4613218, 1.536232, -0.01788041)
# sequence_hand = [(-0.7196951, 1.536232, -0.01788038), (-0.5732007, 1.471638, 0.2058774), (-0.2773551, 1.717031, -0.03286932),
#                 (-0.4370993, 1.791282, 0.01557553), (-0.2708064, 1.674106, 0.08913073), (-0.3065101, 1.585744, 0.1829644)]
# sequence_hand = [(-0.7196951, 1.536232, -0.01788038), (-0.6715853, 1.407045, 0.05864918), (-0.4679296, 1.336422, -0.1815545),
#                 (-0.6064113, 1.327746, -0.06520325), (-0.3711532, 1.301943, 0.0432348), (-0.3505069, 1.341337, 0.1105436)]
# sequence_hand = [(-0.7196951, 1.536232, -0.01788038), (-0.6715854, 1.612761, 0.1113063)]          
# for i in range(5):
#     ur.hand_process(elbow, sequence_hand[i], sequence_hand[i+1])

count = 0

while True:
    # send pose coordinates to unity
    if count < len(world_positions_list):
        sock.SendData(str(world_positions_list[count]))
    count += 1

    data = sock.ReadReceivedData() # read data

    if data != None: # if NEW data has been received since last ReadReceivedData function call
        print(data) # print new received data

    time.sleep(0.05)

    