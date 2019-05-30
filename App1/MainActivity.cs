using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using InTheHand.Net;
using System.Collections.Generic;


namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        TextView txtNumber;

        int number;

        ListView listOfDevices;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            txtNumber = FindViewById<TextView>(Resource.Id.txtNumber);

            FindViewById<Button>(Resource.Id.button1).Click += (o, e) => txtNumber.Text = (++number).ToString();

        }

        ///BT part
        ///

            //mac adress bluetooth tego urzadzenia
        private InTheHand.Net.BluetoothAddress MacAdress { get; set; }

        //przetrzymuje liste urzadzen ktore znaleziono przy skanowaniu
        private List<InTheHand.Net.Sockets.BluetoothDeviceInfo> foundDevices = new List<InTheHand.Net.Sockets.BluetoothDeviceInfo>();


        private BluetoothAddress GetLocalMacAdress()
        {
            InTheHand.Net.Bluetooth.BluetoothRadio myAdress = InTheHand.Net.Bluetooth.BluetoothRadio.PrimaryRadio;

            if (myAdress == null)
            {
                return null;
            }

            return myAdress.LocalAddress;
        }

        private void DiscoverDevices(object sender, InTheHand.Net.Bluetooth.DiscoverDevicesEventArgs e)
        {
            for(int i = 0; i < e.Devices.Length; i++)//zapisuje znalezione urzadzenia do listy
            {
                this.foundDevices.Add(e.Devices[i]);
            }
        }

        private void DiscoverDevicesComplete(object sender,InTheHand.Net.Bluetooth.DiscoverDevicesEventArgs e)
        {//zakonczone wyszukiwanie urzadzen
            this.listOfDevices = FindViewById<ListView>(Resource.Id.listView1); //referencja na ListView ktore bedzie trzymac znalezione urzadzenia

            return;
        }

        private void searchForDevice()
        {
            if((MacAdress = GetLocalMacAdress()) == null)
            {
                //byc moze bluetooth jest wylaczony czy cos nie wiem
                return;
            }

            BluetoothEndPoint localEndPoint = new BluetoothEndPoint(MacAdress, InTheHand.Net.Bluetooth.BluetoothService.SerialPort);

            InTheHand.Net.Sockets.BluetoothClient localClient = new InTheHand.Net.Sockets.BluetoothClient(localEndPoint);

            InTheHand.Net.Bluetooth.BluetoothComponent localComponent = new InTheHand.Net.Bluetooth.BluetoothComponent(localClient);

            localComponent.DiscoverDevicesAsync(10, true, true, true, true, null);
            localComponent.DiscoverDevicesProgress += new System.EventHandler<InTheHand.Net.Bluetooth.DiscoverDevicesEventArgs>(DiscoverDevices);
            localComponent.DiscoverDevicesComplete += new System.EventHandler<InTheHand.Net.Bluetooth.DiscoverDevicesEventArgs>(DiscoverDevicesComplete);
        }
    }
}