using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InTheHand.Net;
using System.Windows.Forms;

namespace Projekt_InzOpr
{
    public partial class Okno
    {

        private BluetoothAddress MyBTMacAdress { get; set; }

        public BluetoothAddress GetLocalMacAdress()
        {
            InTheHand.Net.Bluetooth.BluetoothRadio myAdress = InTheHand.Net.Bluetooth.BluetoothRadio.PrimaryRadio;

            if (myAdress == null)
            {
                MessageBox.Show("Nie znaleziono adresu");

                return null;
            }

            return myAdress.LocalAddress;
        }

        private List<InTheHand.Net.Sockets.BluetoothDeviceInfo> deviceList = new List<InTheHand.Net.Sockets.BluetoothDeviceInfo>();

        private void component_DiscoverDevicesProgress(object sender, InTheHand.Net.Bluetooth.DiscoverDevicesEventArgs e)
        {
            for (int i = 0; i < e.Devices.Length; i++)
            {
                if (e.Devices[i].Remembered)
                {
                    MessageBox.Show(e.Devices[i].DeviceName + " (" + e.Devices[i].DeviceAddress + "): Device is known");
                }
                else
                {
                    MessageBox.Show(e.Devices[i].DeviceName + " (" + e.Devices[i].DeviceAddress + "): Device is unknown");
                }
                this.deviceList.Add(e.Devices[i]);
            }
        }

        private void component_DiscoverDevicesComplete(object sender, InTheHand.Net.Bluetooth.DiscoverDevicesEventArgs e)
        {
            MessageBox.Show("zakonczono");
        }

        private static InTheHand.Net.Sockets.BluetoothClient mainLocalClient { get; set; } //first set in searchForDevices method

        private void searchForDevices()
        {
            MyBTMacAdress = GetLocalMacAdress();
            if (MyBTMacAdress == null)
            {
                MessageBox.Show("Nie ma adresu, czy masz wlaczony BT?");
                return;
            }

            BluetoothEndPoint localEndPoint = new BluetoothEndPoint(MyBTMacAdress, InTheHand.Net.Bluetooth.BluetoothService.SerialPort);

            InTheHand.Net.Sockets.BluetoothClient localClient = new InTheHand.Net.Sockets.BluetoothClient(localEndPoint);
            mainLocalClient = localClient;

            InTheHand.Net.Bluetooth.BluetoothComponent localComponent = new InTheHand.Net.Bluetooth.BluetoothComponent(localClient);

            localComponent.DiscoverDevicesAsync(10, true, true, true, true, null);
            localComponent.DiscoverDevicesProgress += new EventHandler<InTheHand.Net.Bluetooth.DiscoverDevicesEventArgs>(component_DiscoverDevicesProgress);
            localComponent.DiscoverDevicesComplete += new EventHandler<InTheHand.Net.Bluetooth.DiscoverDevicesEventArgs>(component_DiscoverDevicesComplete);
        }

        private void pairing()
        {
            InTheHand.Net.Sockets.BluetoothDeviceInfo[] paired = mainLocalClient.DiscoverDevices(10, false, true, false, false);

            foreach(InTheHand.Net.Sockets.BluetoothDeviceInfo device in this.deviceList)
            {
                bool isPaired = false;
                for(int i = 0; i < paired.Length; i++)
                {
                    if (device.Equals(paired[i])){
                        isPaired = true;
                        break;
                    }
                }

                if (!isPaired)
                {
                    isPaired = InTheHand.Net.Bluetooth.BluetoothSecurity.PairRequest(device.DeviceAddress, null);
                    if (isPaired)
                    {
                        MessageBox.Show("Now it is paired.");
                    }
                    else
                    {
                        MessageBox.Show("Pairing failed.");
                    }
                }
            }
        }

        private void showPairedDevices()
        {
            string pairedDevices = string.Empty;

            searchForDevices();
            foreach(InTheHand.Net.Sockets.BluetoothDeviceInfo device in this.deviceList)
            {
                pairedDevices += device.DeviceName + '\n';
            }

            
            MessageBox.Show("Paired devices:\n" + pairedDevices);
        }

    }
}
