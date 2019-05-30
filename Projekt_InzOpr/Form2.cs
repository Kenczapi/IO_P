using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InTheHand.Net;

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


    }
}
