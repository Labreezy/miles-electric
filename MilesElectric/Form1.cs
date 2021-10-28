using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Squalr.Engine.Memory;
using Squalr.Engine.OS;

namespace MilesElectric
{
    public partial class Form1 : Form
    {
        private ulong baseaddr;
        private ulong basepos = 0x5BBE768;
        private ulong baserestart = 0x52225C0;
        private int[] offsetpos = new[] {8, 0x44};
        private float[] currentpos = new float[3];
        private float[] currentrestart = new float[3];
        private string currentstage = "";
        private ulong currentposaddr, currentrestartaddr;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void attachBtn_Click(object sender, EventArgs e)
        {
            
            Process colorsProc = Process.GetProcessesByName("Sonic Colors - Ultimate").FirstOrDefault();
            if (colorsProc == null)
            {
                MessageBox.Show("Could not attach");
                return;
            }

            Processes.Default.OpenedProcess = colorsProc;
            attachBtn.Enabled = false;
            MessageBox.Show("Attached to colors successfully!");
            baseaddr = (ulong)colorsProc.MainModule.BaseAddress.ToInt64();

            currentposaddr = Reader.Default.Read<ulong>(baseaddr + basepos, out _);
            currentposaddr = Reader.Default.Read<ulong>(currentposaddr + (ulong) offsetpos[0], out _);
            currentposaddr = currentposaddr + (ulong) offsetpos[1];
            currentrestartaddr = Reader.Default.Read<ulong>(baseaddr + baserestart, out _);
            currentrestartaddr = Reader.Default.Read<ulong>(currentrestartaddr, out _);
            currentrestartaddr = Reader.Default.Read<ulong>(currentrestartaddr + 0x170, out _);
            currentrestartaddr += 0x40;
            memWatchTimer.Enabled = true;
            savePosBtn.Enabled = true;
            refreshButton.Enabled = true;
        }

        private void memWatchTimer_Tick(object sender, EventArgs e)
        {

             
            currentpos[0] = Reader.Default.Read<float>(currentposaddr, out _);
            currentpos[1] = Reader.Default.Read<float>(currentposaddr + 4, out _);
            currentpos[2] = Reader.Default.Read<float>(currentposaddr + 8, out _);

            for (ulong i = 0; i < 3; i++)
            {
                currentrestart[i] = Reader.Default.Read<float>(currentrestartaddr + i * 4, out _);
            }
            
            posLabel.Text = $"Current Position:\n({currentpos[0]},{currentpos[1]},{currentpos[2]})";
            respawnPosLabel.Text = $"Current Respawn Position:\n({currentrestart[0]},{currentrestart[1]},{currentrestart[2]})";
        }

        private void savePosBtn_Click(object sender, EventArgs e)
        {
            if (memWatchTimer.Enabled)
            {
                for (ulong i = 0; i < 3; i++)
                {
                    Writer.Default.Write(currentrestartaddr + i * 4, currentpos[i]);
                }

                if (dimnesionCheck.Checked)
                {
                    Writer.Default.Write<byte>(currentrestartaddr + 0x10, 1);
                    Writer.Default.Write<byte>(currentrestartaddr + 0x14, 9);
                    
                }
                else
                {
                  Writer.Default.Write<byte>(currentrestartaddr + 0x10, 0);
                  Writer.Default.Write<byte>(currentrestartaddr + 0x14, 0);
                }
                Writer.Default.Write(currentrestartaddr + 0x18, 0.0f);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            currentposaddr = Reader.Default.Read<ulong>(baseaddr + basepos, out _);
            currentposaddr = Reader.Default.Read<ulong>(currentposaddr + (ulong) offsetpos[0], out _);
            currentposaddr = currentposaddr + (ulong) offsetpos[1];
            currentrestartaddr = Reader.Default.Read<ulong>(baseaddr + baserestart, out _);
            currentrestartaddr = Reader.Default.Read<ulong>(currentrestartaddr, out _);
            currentrestartaddr = Reader.Default.Read<ulong>(currentrestartaddr + 0x170, out _);
            currentrestartaddr += 0x40;
        }
    }
}