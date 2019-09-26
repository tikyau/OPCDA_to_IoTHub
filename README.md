# Streaming data from OPCDA Server to Azure IoT Hub

This repo contain the full source code in C# that allows you to 
1. Remotely connect to your OPCDA Server.
3. Extract the relevant data at a regular predefined time interval from your OPCDA server by providing the tag names concerned .
4. Stream the data into your IoT Hub on Azure.

****Prerequisites***
Before you start this tutorial, you should have obtained all your tag names from an OPC Client. You can easily export all the tag names of your OPC server with an OPC Explorer as shown below:
![66d71a321004 1](https://user-images.githubusercontent.com/17831550/65606541-ac1f2700-dfdd-11e9-981f-e2a27a689ac8.gif)

# Installation and Deployment

1. Build and run the full solution (OPDDA45.sln) with Visual Studio 2017 is recommended. 

2. Fill in your OPCDA Server info (Host Name and Server Name), IoT Hub Connection String and define your stream interval in the app.config file.
   ![Capture2](https://user-images.githubusercontent.com/17831550/65575809-3dbd7300-dfa3-11e9-8145-3561c2f2c7f6.PNG)

3. Update the tag names in the Tags.txt file:
   ![tag](https://user-images.githubusercontent.com/17831550/65658916-37d79880-e05c-11e9-9cfb-53eb9bc68716.png)
   
4. Update the schema of your IoT Hub Message as desired in SimulatedDevice.cs as shown below:
   ![Capture4](https://user-images.githubusercontent.com/17831550/65575755-1e264a80-dfa3-11e9-86fa-c647cd6f90cf.PNG)

5. The repo contains all the DLLs that are required to establish the connection and extracting the tag data from your OPCDA Server:

   ![Capture1](https://user-images.githubusercontent.com/17831550/65575841-5168d980-dfa3-11e9-99a3-83da87348f23.PNG)

6. Successful console output:
   ![Screenshot (10)](https://user-images.githubusercontent.com/17831550/65575696-077ff380-dfa3-11e9-875c-072f0ae4a4bc.png)

