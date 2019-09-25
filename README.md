# Streaming data from OPCDA Server to Azure IoT Hub

This repo contain the full source code in C# that allows you to 
1. Remotely connect to your OPCDA Server.
3. Extracting the relevant data from your OPCDA server by providing the tag names concerned at a regular time interval.
4. Stream the data to your IoT Hub on Azure.


# Installation and Deployment

1. Run the full solution (OPDDA45.sln) with Visual Studio 2017 is recommended. 

2. Fill in your OPCDA Server info (Host Name and Server Name) and IoT Hub Connection String in the app.config file.
    [https://imgbbb.com/image/LtJyH2](https://imgbbb.com/image/LtJyH2)

3. Update the tag names in the Tags.txt file:
    [https://imgbbb.com/image/LtJOqr](https://imgbbb.com/image/LtJOqr)

4. Update the schema of your IoT Hub Message in SimulatedDevice.cs
    [https://imgbbb.com/image/LtJe9d](https://imgbbb.com/image/LtJe9d)

5. The repo contains all the DLLs that are required to establish the connection and extracting the tag data from your OPCDA Server
![enter image description here](https://imgbbb.com/image/LtJPlD)

6. Successful console output:
    [https://imgbbb.com/image/LtJfHe](https://imgbbb.com/image/LtJfHe)
