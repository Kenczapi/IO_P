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
        
        Guid myGuid;
        bool serverStarted = false;

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

        public OknoBT()
        {
            InitializeComponent();
            getGuid();
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
            Stream aStream = client.GetStream();

            while (client.Connected)
            {
                try
                {
                    byte[] received = new byte[1024];
                    aStream.Read(received, 0, received.Length);
                    updateUI("Received: " + Encoding.ASCII.GetString(received));
                    byte[] sent = Encoding.ASCII.GetBytes("Thank you! " + DateTime.Now.ToString("hh:mm.ss"));
                    aStream.Write(sent, 0, sent.Length);
                }
                catch (IOException exc)
                {
                    updateUI("Client disconnected.\n" + exc.ToString());
                }
            }
        }

        private void buttonWlacz_Click(object sender, EventArgs e)
        {
            connectAsServer();
            updateUI(myGuid.ToString() + "No tak to wyglada");
        }
    }
}
