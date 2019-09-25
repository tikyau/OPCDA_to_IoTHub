# Streaming data from OPCDA Server to Azure IoT Hub

This repo contain the full source code in C# that allows you to 
1. Remotely connect to your OPCDA Server.
3. Extracting the relevant data from your OPCDA server by providing the tag names concerned at a regular time interval.
4. Stream the data to your IoT Hub on Azure.


# Installation and Deployment

1. Run the full solution (OPDDA45.sln) with Visual Studio 2017 is recommended. 

2. Fill in your OPCDA Server info (Host Name and Server Name) and IoT Hub Connection String in the app.config file.
   ![Capture2](https://user-images.githubusercontent.com/17831550/65575809-3dbd7300-dfa3-11e9-8145-3561c2f2c7f6.PNG)

3. Update the tag names in the Tags.txt file:
   ![Capture3](https://user-images.githubusercontent.com/17831550/65575778-2bdbd000-dfa3-11e9-9b1d-d863997e841c.PNG)
   
4. Update the schema of your IoT Hub Message in SimulatedDevice.cs
   ![Capture4](https://user-images.githubusercontent.com/17831550/65575755-1e264a80-dfa3-11e9-86fa-c647cd6f90cf.PNG)

5. The repo contains all the DLLs that are required to establish the connection and extracting the tag data from your OPCDA Server

   ![Capture1](https://user-images.githubusercontent.com/17831550/65575841-5168d980-dfa3-11e9-99a3-83da87348f23.PNG)

6. Successful console output:
   ![Screenshot (10)](https://user-images.githubusercontent.com/17831550/65575696-077ff380-dfa3-11e9-875c-072f0ae4a4bc.png)

