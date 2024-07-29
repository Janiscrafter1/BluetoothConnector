using System;
using System.Management;
using System.Security.Cryptography;

namespace DeviceEnumerator
{
    class Program
    {
        private static ManagementObject device;
        static void Main(string[] args)
        {
            
            FindDevice();
            
        }

        static void FindDevice()
        {
            try
            {
                string query = $"SELECT * FROM Win32_PnPEntity WHERE Description LIKE '%Bluetooth%' AND Name LIKE '%SRS-XB20 Stereo%'";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);                
                foreach (ManagementObject device in searcher.Get())
                {
                    Console.WriteLine($"Device Name: {device["Name"]}, Device ID: {device["DeviceID"]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        
    }
}
