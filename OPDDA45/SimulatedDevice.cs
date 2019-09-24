// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// This application uses the Azure IoT Hub device SDK for .NET
// For samples see: https://github.com/Azure/azure-iot-sdk-csharp/tree/master/iothub/device/samples

using System;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using OPDDA45;

namespace simulated_device
{
    class SimulatedDevice
    {
        private static DeviceClient s_deviceClient;

        // The device connection string to authenticate the device with your IoT hub.
        // Using the Azure CLI:
        // az iot hub device-identity show-connection-string --hub-name {YourIoTHubName} --device-id MyDotnetDevice --output table
        private readonly static string s_connectionString = "HostName=OPCDADemo.azure-devices.cn;DeviceId=MyFirstDevice;SharedAccessKey=6GbkPIGV/LBYh7aeb4HtOsS95jaYAdOYw2GDYaloCOM=";

        // Async method to send simulated telemetry
        private static async void SendDeviceToCloudMessagesAsync()
        {
            OPCServer srv = new OPCServer("Philips.EMOpcDaServer.1");
            Console.WriteLine(srv.ErrorMessage);
            Console.WriteLine("Connected to OPCDA Server:" + srv.IsConnected);

            OPCServerClient opcClient = new OPCServerClient(srv);
            
            while (true)
            {
                // Create JSON message
                var results = opcClient.ReadTagVal();
                foreach(var item in results)
                {
                    var telemetryDataPoint = new
                    {
                        itemname = item.ItemName,
                        value = Convert.ToDouble(item.Value),
                        quality = item.Quality.ToString(),
                        timestamp = item.Timestamp
                    };
                    var messageString = JsonConvert.SerializeObject(telemetryDataPoint);
                    var message = new Message(Encoding.ASCII.GetBytes(messageString));

                    // Add a custom application property to the message.
                    // An IoT hub can filter on these properties without access to the message body.
                    // message.Properties.Add("temperatureAlert", (currentTemperature > 30) ? "true" : "false");

                    // Send the telemetry message
                    await s_deviceClient.SendEventAsync(message);
                    Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, messageString);
                }
                await Task.Delay(10000);
            }
        }
        private static void Main(string[] args)
        {
            Console.WriteLine("IoT Hub Quickstarts #1 - Simulated device. Ctrl-C to exit.\n");

            // Connect to the IoT hub using the MQTT protocol
            s_deviceClient = DeviceClient.CreateFromConnectionString(s_connectionString, TransportType.Mqtt);
            SendDeviceToCloudMessagesAsync();
            Console.ReadLine();
        }
    }
}
