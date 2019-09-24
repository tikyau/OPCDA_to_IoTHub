using Opc.Da;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPDDA45
{
    /// <summary>
    /// Read-only OPC client
    /// </summary>
    public class OPCServerClient
    {
        private OPCServer _server;

        public OPCServerClient(OPCServer server)
        {
            if (server == null)
                throw new Exception("Server is null");

            _server = server;
        }

        /// <summary>
        /// Read value from an OPC tag. 
        /// </summary>
        /// <returns>Tag value.</returns>
        public object ReadTagVal(string tagName)
        {
            if (String.IsNullOrEmpty(tagName))
                throw new Exception(String.Format("OPC tag name '{0}' is not valid", tagName));

            object tagValue = String.Empty;

            if (!_server.IsConnected)
                throw new Exception("Not connected to OPC server");

            string[] tags = new string[98]
            {
                "Trend Point.Metered Data.SITE0060B2_EMDX3#022.Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#014.Line 2 - Active Power",
                "Trend Point.Metered Data.SITE0060B2_EMDX3#022.Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#022.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#022.Line 2 - Active Power",
                "Trend Point.Metered Data.SITE0060B2_EMDX3#022.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_CO2#001 #1.CO2","Trend Point.Metered Data.SITE0060B2_CO2#001 #1.humidity","Trend Point.Metered Data.SITE0060B2_CO2#001 #1.temperature","Trend Point.Metered Data.SITE0060B2_CO2#001.CO2","Trend Point.Metered Data.SITE0060B2_CO2#001.humidity","Trend Point.Metered Data.SITE0060B2_CO2#001.temperature","Trend Point.Metered Data.SITE0060B2_EcoMeter#010 #10.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#010 #10.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#010 #10.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#010 #10.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#010 #10.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#010 #10.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#010.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#010.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#010.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#010.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#010.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#010.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#011 #11.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#011 #11.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#011 #11.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#011 #11.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#011 #11.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#011 #11.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#011.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#011.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#011.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#011.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#011.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#011.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#012 #12.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#012 #12.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#012 #12.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#012 #12.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#012 #12.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#012 #12.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#012.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#012.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#012.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#012.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#012.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#012.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#013 #13.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#013 #13.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#013 #13.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#013 #13.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#013 #13.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#013 #13.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#013.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#013.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#013.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#013.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#013.Line 3 - Active Energy",
                "Trend Point.Metered Data.SITE0060B2_EcoMeter#013.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#014 #14.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#014 #14.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#014 #14.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#014 #14.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#014 #14.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#014 #14.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#014.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#014.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#014.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#014.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#014.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#015 #15.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#015 #15.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#015 #15.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#015 #15.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#015 #15.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#015 #15.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#015.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#015.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#015.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#015.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#015.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#015.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#021.Active Energy","Trend Point.Metered Data.SITE0060B2_EMDX3#021.Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#021.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#021.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#021.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#022 #22.Active Energy","Trend Point.Metered Data.SITE0060B2_EMDX3#022 #22.Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#022 #22.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#022 #22.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#022 #22.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#022.Active Energy",
                "Trend Point.Metered Data.SITE0060B2_EMDX3#022.Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#022.Line 1 - Active Power",
                "Trend Point.Metered Data.SITE0060B2_EMDX3#022.Line 2 - Active Power",
                "Trend Point.Metered Data.SITE0060B2_EMDX3#022.Line 3 - Active Power"
            };
            
            Item[] itemCollection = new Item[98];
            for(int index=0;index<tags.Length;index++)
                itemCollection[index] = new Item { ItemName = tags[index], MaxAge = -1 };

            ItemValueResult[] results = _server.Read(itemCollection);

            for (int index = 0; index < results.Length; index++)
                Console.WriteLine("ItemName: "+results[index].ItemName + " Value: "+ results[index].Value + " Quality: "+results[index].Quality +" Timestamp: "+ results[index].Timestamp);
            if (results.Length > 0)
                tagValue = results[0].Value;

            return tagValue;
        }

        /// <summary>
        /// Read tag value. 
        /// </summary>
        /// <returns>Tag value.</returns>
        public ItemValueResult[] ReadTagVal()
        {
            if (!_server.IsConnected)
                throw new Exception("Not connected to OPC server");

            string[] tags = new string[98]
            {
                "Trend Point.Metered Data.SITE0060B2_EMDX3#022.Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#014.Line 2 - Active Power",
                "Trend Point.Metered Data.SITE0060B2_EMDX3#022.Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#022.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#022.Line 2 - Active Power",
                "Trend Point.Metered Data.SITE0060B2_EMDX3#022.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_CO2#001 #1.CO2","Trend Point.Metered Data.SITE0060B2_CO2#001 #1.humidity","Trend Point.Metered Data.SITE0060B2_CO2#001 #1.temperature","Trend Point.Metered Data.SITE0060B2_CO2#001.CO2","Trend Point.Metered Data.SITE0060B2_CO2#001.humidity","Trend Point.Metered Data.SITE0060B2_CO2#001.temperature","Trend Point.Metered Data.SITE0060B2_EcoMeter#010 #10.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#010 #10.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#010 #10.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#010 #10.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#010 #10.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#010 #10.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#010.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#010.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#010.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#010.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#010.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#010.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#011 #11.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#011 #11.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#011 #11.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#011 #11.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#011 #11.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#011 #11.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#011.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#011.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#011.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#011.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#011.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#011.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#012 #12.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#012 #12.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#012 #12.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#012 #12.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#012 #12.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#012 #12.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#012.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#012.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#012.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#012.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#012.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#012.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#013 #13.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#013 #13.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#013 #13.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#013 #13.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#013 #13.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#013 #13.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#013.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#013.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#013.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#013.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#013.Line 3 - Active Energy",
                "Trend Point.Metered Data.SITE0060B2_EcoMeter#013.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#014 #14.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#014 #14.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#014 #14.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#014 #14.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#014 #14.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#014 #14.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#014.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#014.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#014.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#014.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#014.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#015 #15.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#015 #15.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#015 #15.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#015 #15.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#015 #15.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#015 #15.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#015.Line 1 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#015.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#015.Line 2 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#015.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EcoMeter#015.Line 3 - Active Energy","Trend Point.Metered Data.SITE0060B2_EcoMeter#015.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#021.Active Energy","Trend Point.Metered Data.SITE0060B2_EMDX3#021.Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#021.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#021.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#021.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#022 #22.Active Energy","Trend Point.Metered Data.SITE0060B2_EMDX3#022 #22.Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#022 #22.Line 1 - Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#022 #22.Line 2 - Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#022 #22.Line 3 - Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#022.Active Energy",
                "Trend Point.Metered Data.SITE0060B2_EMDX3#022.Active Power","Trend Point.Metered Data.SITE0060B2_EMDX3#022.Line 1 - Active Power",
                "Trend Point.Metered Data.SITE0060B2_EMDX3#022.Line 2 - Active Power",
                "Trend Point.Metered Data.SITE0060B2_EMDX3#022.Line 3 - Active Power"
            };

            Item[] itemCollection = new Item[98];
            for (int index = 0; index < tags.Length; index++)
                itemCollection[index] = new Item { ItemName = tags[index], MaxAge = -1 };

            ItemValueResult[] results = _server.Read(itemCollection);

            //for (int index = 0; index < results.Length; index++)
            //    Console.WriteLine("ItemName: " + results[index].ItemName + " Value: " + results[index].Value + " Quality: " + results[index].Quality + " Timestamp: " + results[index].Timestamp);
            return results;
        }
    }
}