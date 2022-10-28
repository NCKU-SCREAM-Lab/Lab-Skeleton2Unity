import UdpComms as U
import time
import numpy as np
import pickle

# Create UDP socket to use for sending (and receiving)
sock = U.UdpComms(udpIP="127.0.0.1", portTX=8000, portRX=8001, enableRX=True, suppressWarnings=True)


skeleton_list = ['head', 'spine', 'hip', 
                'l_upperarm', 'l_lowerarm', 'l_hand', 
                'r_upperarm', 'r_lowerarm', 'r_hand', 
                'l_upperleg', 'l_lowerleg', 'l_foot', 
                'r_upperleg', 'r_lowerleg', 'r_foot']
skeleton_position = [[-2.4, 1.7, -1.1], [-2.4, 1.1, -1.1], [-2.4, 0.9, -1.1], 
                    [-2.6, 1.5, -1.1], [-2.8, 1.3, -1.0], [-2.8, 1.6, -0.9],
                    [-2.2, 1.5, -1.2], [-2.3, 1.3, -1.0], [-2.4, 1.4, -0.8],
                    [-2.5, 0.9, -1.1], [-2.5, 0.5, -1.1], [-2.5, 0.1, -1.2],
                    [-2.3, 0.9, -1.1], [-2.2, 0.5, -1.1], [-2.2, 0.1, -1.2]]
# read pickle skeleton data                    
pickle_path = 'D:\\pose_estimation-main\\pose_estimation-main\\Other\\'
dataset = []
with open(pickle_path + "demo0405_media_test.pkl", 'rb')as fpick:
    data = pickle.load(fpick)
    dataset.append(data)
print(dataset)
world_positions_list = []
for frame in dataset[0]:
    temp_str = ""
    for idx, skeletons in enumerate(frame):
        if idx % 3 == 2:
            temp_str += (str(skeletons) + ",")
        else:
            temp_str += (str(skeletons) + " ")
    temp_str = temp_str[:len(temp_str)-1]
    world_positions_list.append(temp_str)
#print(len(world_positions_list))
#print(world_positions_list[0])
count = 0

while True:
    '''
    world_position = ""
    for i in range(len(skeleton_position)):
        temp_str = ""
        for j in skeleton_position[i]:
            temp_str += str(j) + " "
        temp_str = temp_str[:len(temp_str)-1]
        #print(temp_str)
        world_position += (str(temp_str) + ",")
    world_position = world_position[:len(world_position)-1]
    sock.SendData(str(world_position))
    '''
    # send pose coordinates to unity
    
    if count < len(world_positions_list):
        # print(world_positions_list[count])
        sock.SendData(str(world_positions_list[count]))
    count += 1
    
    '''
    for i in range(len(skeleton_position)):
        skeleton_position[i][1] += 0.1
    '''

    data = sock.ReadReceivedData() # read data

    if data != None: # if NEW data has been received since last ReadReceivedData function call
        print(data) # print new received data
        '''
        with open('C:\\Users\\yu_hsien\\Desktop\\mix_fast_01.txt', 'a') as f:
            f.write(data)
        '''

    time.sleep(1/30)

    