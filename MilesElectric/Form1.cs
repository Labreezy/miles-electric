using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reloaded.Memory.Sources;
using Reloaded.Assembler;
using Reloaded.Memory.Exceptions;
using Reloaded.Memory.Sigscan;
using Reloaded.Memory.Sigscan.Structs;

namespace MilesElectric
{
    public partial class Form1 : Form
    {
        private Process colorsProc;
        private IntPtr baseaddr;
        private ulong igtaddr;
        private int basepos = 0x5C4D858;
        private int baserestart = 0x52B16B0;

        private int[] offsetpos = new[] {8, 0x44};

        //private int boostwispstart = 0x5222030;
        //private int[] boostwispoffsets = new[] {0x68,0x88,0x48,8,0x10,0x18,0xC8,0x40}; //thanks jujstme for this doozy
        private Vec3 currentpos = new Vec3();
        private Vec3 currentrestart = new Vec3();
        private float currentboost = -1f;
        private int currentwisp = -1;
        private float savedboost;
        private int savedwisp;
        private string currentstage = "";
        private ulong currentbwaddr, bwptraddr, codeaddr;
        private IntPtr posAddr, restartAddr, igtAddr, boostWispAddr;
        private IMemory memory;

        public Form1()
        {
            InitializeComponent();

        }

        public struct Vec3
        {
            public float x;
            public float y;
            public float z;
        }


        private void attachBtn_Click(object sender, EventArgs e)
        {


            colorsProc = Process.GetProcessesByName("Sonic Colors - Ultimate").FirstOrDefault();
            if (colorsProc == null)
            {
                MessageBox.Show("Could not attach");
                return;
            }

            memory = new ExternalMemory(colorsProc);
            attachBtn.Enabled = false;
            MessageBox.Show("Attached to colors successfully!");
            baseaddr = colorsProc.MainModule.BaseAddress;
            posAddr = IntPtr.Zero;
            try
            {

                memory.Read<IntPtr>(IntPtr.Add(baseaddr, basepos), out posAddr);
                posAddr = IntPtr.Add(posAddr, offsetpos[0]);
                memory.Read<IntPtr>(posAddr, out posAddr);
                posAddr = IntPtr.Add(posAddr, offsetpos[1]);
                restartAddr = IntPtr.Zero;
                memory.Read<IntPtr>(IntPtr.Add(baseaddr, baserestart), out restartAddr);
                memory.Read(restartAddr, out restartAddr);
                igtAddr = IntPtr.Add(restartAddr, 0x270);

                memory.Read(IntPtr.Add(restartAddr, 0x170), out restartAddr);
                restartAddr = IntPtr.Add(restartAddr, 0x40);
                /*boostWispAddr = IntPtr.Add(baseaddr, boostwispstart);
                foreach(int off in boostwispoffsets)
                {
                   memory.Read(IntPtr.Add(boostWispAddr, off), out boostWispAddr);
                }*/
            }
            catch (MemoryException)
            {
                Debug.Print("memexception");
            }





            memWatchTimer.Enabled = true;
            savePosBtn.Enabled = true;
            refreshButton.Enabled = true;
        }

        private void memWatchTimer_Tick(object sender, EventArgs e)
        {

            memory.Read(posAddr, out currentpos);
            memory.Read(restartAddr, out currentrestart);
          

            posLabel.Text = $"Current Position:\n({currentpos.x},{currentpos.y},{currentpos.z})";
            respawnPosLabel.Text =
                $"Current Respawn Position:\n({currentrestart.x},{currentrestart.y},{currentrestart.z})";

        }

        private void savePosBtn_Click(object sender, EventArgs e)
        {
            if (memWatchTimer.Enabled)
            {
                memory.Write(igtAddr, 600.0f);
                for (ulong i = 0; i < 3; i++)
                {
                    memory.Write(restartAddr, currentpos);
                }

                if (dimnesionCheck.Checked)
                {
                    memory.Write(IntPtr.Add(restartAddr, 0x10), 1);
                    memory.Write(IntPtr.Add(restartAddr, 0x14), 9);

                }
                else
                {
                    memory.Write(IntPtr.Add(restartAddr, 0x10), 0);
                    memory.Write(IntPtr.Add(restartAddr, 0x14), 0);
                }

                //no initial speed
                memory.Write(IntPtr.Add(restartAddr, 0x18), 0);
                savedboost = currentboost;
                savedwisp = currentwisp;



            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            baseaddr = colorsProc.MainModule.BaseAddress;
            posAddr = IntPtr.Zero;
            memory.Read<IntPtr>(IntPtr.Add(baseaddr, basepos), out posAddr);
            posAddr = IntPtr.Add(posAddr, offsetpos[0]);
            memory.Read<IntPtr>(posAddr, out posAddr);
            posAddr = IntPtr.Add(posAddr, offsetpos[1]);
            restartAddr = IntPtr.Zero;
            memory.Read<IntPtr>(IntPtr.Add(baseaddr, baserestart), out restartAddr);
            memory.Read(restartAddr, out restartAddr);
            igtAddr = IntPtr.Add(restartAddr, 0x270);
            memory.Read(IntPtr.Add(restartAddr, 0x170), out restartAddr);
            restartAddr = IntPtr.Add(restartAddr, 0x40);

            memory.Read(IntPtr.Add(boostWispAddr, 0x10), out currentboost);
            memory.Read(IntPtr.Add(boostWispAddr, 0x20), out currentwisp);


            return;
        }
    }

}