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
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Projekt_InzOpr
{

    // DO TESTOWANIA DZIALANIA SERVERA UZYWALEM ALPIKACJI BLUE SERIAL, pieknie wysyla i odbiera dane
    // pozostalo tylko zrobic mobilna aplikacje, niestety xamarin odpada, bo chlopak ma problem z obsluga dll'a bluetoothowego

    public partial class OknoBT : Form
    {
        private void getGuid()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "myGuid.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("00001101-0000-1000-8000-00805F9B34FB");
                }
            }

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                int i = 0;
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    i++;
                    myGuid = new Guid(s);
                }

                if (i != 1)
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        myGuid = new Guid("00001101-0000-1000-8000-00805F9B34FB");
                        sw.WriteLine("00001101-0000-1000-8000-00805F9B34FB");
                    }
                }
            }
        }


        Guid myGuid;
        bool serverStarted = false;

        public bool isWorking { get; set; }

        BluetoothAddress myMacAdress;

        BluetoothEndPoint endPoint;
        BluetoothClient client;
        BluetoothComponent component;

        private int STATE = 0;

        List<BluetoothDeviceInfo> bt;

        BluetoothDeviceInfo[] paired;

        Stream aStream;

        Okno okno;

        public string elo;

        public OknoBT(Okno o)
        {

            okno = o;
            InitializeComponent();
            getGuid();

            myMacAdress = GetMyMac();
            if (myMacAdress == null)
            {
                MessageBox.Show("Prosze sprawdzic czy bluetooth jest wlaczony.");
                this.Close();
            }

            endPoint = new BluetoothEndPoint(myMacAdress,BluetoothService.SerialPort);
            client = new BluetoothClient(endPoint);
            component = new BluetoothComponent(client);

            isWorking = false;

            this.buttonWlacz.Visible = false;
            this.richTextBox1.Visible = false;
        }


        private void DiscoverDevicesFinish(object sender, DiscoverDevicesEventArgs e)
        {
            bt = new List<BluetoothDeviceInfo>();
            foreach(BluetoothDeviceInfo dev in e.Devices)
            {
                bt.Add(dev);
            }

            dataGridView1.DataSource = null;
            dataGridView1.Update();
            dataGridView1.DataSource = e.Devices;
            dataGridView1.Update();
        }

        private void searchForPaired()
        {
            paired = client.DiscoverDevices(255, false, true, false, false);

            if (paired.Length > 0)
                dataGridView1.DataSource = paired;
        }

        private void searchForNewDevices()
        {
            component.DiscoverDevicesComplete += new EventHandler<DiscoverDevicesEventArgs>(DiscoverDevicesFinish);
            component.DiscoverDevicesAsync(255, true, true, true, true, null);
        }

        private BluetoothAddress GetMyMac()
        {
            if (BluetoothRadio.PrimaryRadio == null)
            {
                return null;
            }

            return BluetoothRadio.PrimaryRadio.LocalAddress;
        }

        private void connectAsServer()
        {
            Thread bluetoothServerThread = new Thread(new ThreadStart(ServerConnectThread));
            bluetoothServerThread.Start();
        }

        private void updateUI(string message)
        {
            Func<int> del = delegate ()
            {
                richTextBox1.AppendText(message + System.Environment.NewLine);
                return 0;
            };

            Invoke(del);
        }

        private void ServerConnectThread()
        {
            serverStarted = true;
            updateUI("server started");
            BluetoothListener btListener = new BluetoothListener(myGuid);
            btListener.Start();
            BluetoothClient client = btListener.AcceptBluetoothClient();
            updateUI("Client has connected");
            aStream = client.GetStream();

            while (client.Connected)
            {

                isWorking = true;
                try
                {
                    string tmp = GetData();
                    okno.waitForData(tmp);
                }
                catch (IOException exc)
                {
                    updateUI("Client disconnected.\n" + exc.ToString());
                }
            }

            isWorking = false;
        }

        private void buttonWlacz_Click(object sender, EventArgs e)
        {
            connectAsServer();
            updateUI(myGuid.ToString() + "No tak to wyglada");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach(BluetoothDeviceInfo dev in bt)
            {
                if(dev.DeviceAddress.Equals(dataGridView1[0,dataGridView1.CurrentRow.Index].Value) && dev.DeviceName.Equals(dataGridView1[1, dataGridView1.CurrentRow.Index].Value))
                {//znalezione urzadzenie
                    if (dev.Authenticated)
                    {
                        MessageBox.Show("Urzadzenie juz znane! Musisz tylko sie polaczyc z telefonu");
                        return;
                    }
                    else
                    {
                        BluetoothSecurity.PairRequest(dev.DeviceAddress, null);                    
                    }
                }
            }
            MessageBox.Show("Nie znaleziono urzadzenia!");

        }

        public void SendData(string message)
        {
            byte[] sent = Encoding.ASCII.GetBytes(message);
            aStream.Write(sent, 0, sent.Length);
        }

        public string GetData()
        {
            byte[] received = new byte[1024];
            aStream.Read(received, 0, received.Length);

            return Encoding.ASCII.GetString(received);
        }

        private void buttonSzukaj_Click(object sender, EventArgs e)
        {
            if(STATE == 0)
            {

                buttonWlacz_Click(null, null);

                searchForPaired();
                STATE++;
                return;
            }
            else if(STATE == 1)
            {
                searchForNewDevices();
                STATE++;
                return;
            }
            else
            {
                MessageBox.Show("Jezeli nadal nie znajduje Twojego urzadzenia, sprawdzy czy na pewno masz wlaczonego bluetooth'a");
            }
        }

        private void OknoBT_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
