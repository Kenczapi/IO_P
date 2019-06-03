using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InTheHand.Net.Sockets;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;

namespace Projekt_InzOpr
{
    public partial class OknoBT : Form
    {

        private BluetoothAddress MyBtAdress;

        List<BluetoothDeviceInfo> zapamietane;
        List<BluetoothDeviceInfo> nieznane;
        List<BluetoothDeviceInfo> wszystkie;
        List<BluetoothDeviceInfo> sparowane;
        BluetoothDeviceInfo[] paired;

        BluetoothEndPoint endPoint;
        BluetoothClient client;
        BluetoothComponent component;

        

        public OknoBT()
        {
            InitializeComponent();

            zapamietane = new List<BluetoothDeviceInfo>();
            nieznane = new List<BluetoothDeviceInfo>();
            wszystkie = new List<BluetoothDeviceInfo>();

            endPoint = new BluetoothEndPoint(MyBtAdress, BluetoothService.SerialPort);
            client = new BluetoothClient(endPoint);
            component = new BluetoothComponent(client);
        }

        private BluetoothAddress getMyMacAdress()
        {
            if(BluetoothRadio.PrimaryRadio == null)
            {
                return null;
            }

            return BluetoothRadio.PrimaryRadio.LocalAddress;
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DiscoverDevicesProgress(object sender, DiscoverDevicesEventArgs e)
        {
            for(int i = 0; i < e.Devices.Length; i++)
            {
                if (e.Devices[i].Remembered)
                {
                    zapamietane.Add(e.Devices[i]);
                }
                else
                {
                    nieznane.Add(e.Devices[i]);
                }
                this.wszystkie.Add(e.Devices[i]);
                MessageBox.Show(e.Devices[i].DeviceName.ToString());
            }
        }

        private void DiscoverDevicesCoplete(object sender, DiscoverDevicesEventArgs e)
        {
            this.dataGridView1.DataSource = this.wszystkie;
        }

        private void detectBluetoothDevices(object sender, DiscoverDevicesEventArgs e)
        {
            if((MyBtAdress = getMyMacAdress()) == null)
            {
                MessageBox.Show("Czy masz wlaczony Bluetooth?");
                return;
            }

            MessageBox.Show("Rozpoczynam skanowanie, zajmie to okolo 10 sekund, nie próbuj nic naciskac");
            component.DiscoverDevicesAsync(255, true, true, true, true, null);
            component.DiscoverDevicesProgress += new EventHandler<DiscoverDevicesEventArgs>(DiscoverDevicesProgress);
            component.DiscoverDevicesComplete += new EventHandler<DiscoverDevicesEventArgs>(DiscoverDevicesCoplete);
        }

        private void buttonSzukaj_Click(object sender, EventArgs e)
        {
            detectBluetoothDevices(null, null);
            System.Threading.Thread.Sleep(10000);
            MessageBox.Show("Zakonczono");
            this.dataGridView1.Update();
        }

        private void Connect(IAsyncResult result)
        {
            if (result.IsCompleted)
            {
                MessageBox.Show("Polaczono");
            }
        }

        private void buttonPolacz_Click(object sender, EventArgs e)
        {
            ///PROBLEM JEST GDY NA TELEFONIE USUNIEMY SPAROWANIE A NA KOMPUTERZE ZOSTAJE, NIE WIME JAK ROZWIAZAC


            if(dataGridView1.SelectedRows.Count != 1 || dataGridView1.SelectedRows.Count == null)
            {
                MessageBox.Show("Nic nie wybrano");
                return;
            }

            searchForPairedDevices();

            foreach(BluetoothDeviceInfo device in wszystkie)
            {//porownaj czy urzadzenie jest GENERALNIE znalezione

                bool czyZnalezione = false;

                if (device.DeviceName.Equals(dataGridView1[1, dataGridView1.CurrentRow.Index].Value) && device.DeviceAddress.Equals(dataGridView1[0, dataGridView1.CurrentRow.Index].Value)) //znajduje wybrane z listy urzadzenie w zeskanowanych urzazdeniach
                {
                    foreach (BluetoothDeviceInfo pairedDevice in paired)
                    {
                        if (device.DeviceName.Equals(pairedDevice.DeviceName) && device.DeviceAddress.Equals(pairedDevice.DeviceAddress))
                        {//urzadzenie z ktorym chcemy sie polaczcy jest juz sparowane
                            czyZnalezione = true;

                            //polacz sie z urzadzeniem


                        }
                    }

                    //znaleziono urzadzenie trzeba jes sparowac i polaczyc sie z nim
                    czyZnalezione = BluetoothSecurity.PairRequest(device.DeviceAddress, null);
                    if (device.Authenticated)
                    {
                        client.SetPin(null);

                        client.BeginConnect(device.DeviceAddress, BluetoothService.SerialPort, new System.AsyncCallback(Connect), device);
                    }
                }

                if (czyZnalezione == true)
                    break;

            }
        }

        private void searchForPairedDevices()
        {
            this.paired = client.DiscoverDevices(255, false, true, false, false);
        }

        private void OknoBT_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }
    }
}
