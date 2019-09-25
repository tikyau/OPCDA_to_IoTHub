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
using System.Configuration;

namespace simulated_device
{
    class SimulatedDevice
    {
        private static DeviceClient s_deviceClient;

        // The device connection string to authenticate the device with your IoT hub.
        private readonly static string s_connectionString = ConfigurationManager.AppSettings["IOTHubConnectionString"];

        // Async method to send tags telemetry
        private static async void SendDeviceToCloudMessagesAsync()
        {
            var opcDAServerUrl = ConfigurationManager.AppSettings["OPCDAServerUrl"];
            OPCServer srv = new OPCServer(opcDAServerUrl);
            Console.WriteLine(srv.ErrorMessage);
            Console.WriteLine("Connected to OPCDA Server:" + srv.IsConnected);

            OPCServerClient opcClient = new OPCServerClient(srv);
            
            while (true)
            {
                // Create JSON message
                var results = opcClient.ReadTagVal(ConfigurationManager.AppSettings["TagFileNamePath"]);
                // Console.WriteLine("Number of tags data:" + results.Length);
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
                await Task.Delay(Convert.ToInt32(ConfigurationManager.AppSettings["StreamInterval"]));
            }
        }
        private static void Main(string[] args)
        {
            Console.WriteLine("Sending OPCDA server data to iothub. Ctrl-C to exit.\n");

            // Connect to the IoT hub using the MQTT protocol
            s_deviceClient = DeviceClient.CreateFromConnectionString(s_connectionString, TransportType.Mqtt);
            SendDeviceToCloudMessagesAsync();
            Console.ReadLine();
        }
    }
}


