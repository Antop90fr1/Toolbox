using System.CodeDom;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WindowsInput.Native;
using WindowsInput;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

#pragma warning disable IDE1006
namespace Toolbox
{
    public partial class Window : Form
    {
        InputSimulator sim = new InputSimulator();

        private const int VOLUME_MUTE = 0x80000;
        private const int VOLUME_UP = 0xA0000;
        private const int VOLUME_DOWN = 0x90000;
        private const int WM = 0x319;

        string sys32 = @"C:\Windows\System32\";

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
        IntPtr wParam, IntPtr lParam);

        public Window()
        {
            InitializeComponent();
        }

        private void taskManager_Click(object sender, EventArgs e)
        {
            Process.Start(sys32 + "taskmgr.exe");
        }

        int clickedVolumeMute = 0;

        private void volumeMute_Click(object sender, EventArgs e)
        {
            SendMessageW(this.Handle, WM, this.Handle,
                (IntPtr)VOLUME_MUTE);
            SendKeys.Send("^+(M)");
            clickedVolumeMute++;
            switch (clickedVolumeMute)
            {
                case 1:
                    this.volumeMute.BackColor = Color.IndianRed; break;
                case 2:
                    this.volumeMute.BackColor = Window.DefaultBackColor; clickedVolumeMute = 0; break;
            }
        }

        private void volumeDown_Click(object sender, EventArgs e)
        {
            SendMessageW(this.Handle, WM, this.Handle,
                (IntPtr)VOLUME_DOWN);
        }

        private void volumeUp_Click(object sender, EventArgs e)
        {
            SendMessageW(this.Handle, WM, this.Handle,
                (IntPtr)VOLUME_UP);
        }

        private void printScreen_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{PRTSC}");
        }

        private void Window_Load(object sender, EventArgs e)
        {
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.VK_I);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        int clickedMuteButton = 0;

        private void muteButton_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^+(M)");
            clickedMuteButton++;
            switch (clickedMuteButton)
            {
                case 1:
                    this.muteButton.BackColor = Color.IndianRed; break;
                case 2:
                    this.muteButton.BackColor = Window.DefaultBackColor; clickedMuteButton = 0; break;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Process.Start(sys32 + "calc.exe");
        }

        int clickedDeafenButton = 0;
        private void deafenButton_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^+(D)");
            clickedDeafenButton++;
            switch (clickedDeafenButton)
            {
                case 1:
                    this.deafenButton.BackColor = Color.IndianRed; break;
                case 2:
                    this.deafenButton.BackColor = Window.DefaultBackColor; clickedDeafenButton = 0; break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Images|*.png;*.jpeg;*.bmp;*.gif";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var imagePath = dlg.FileName;
                    Image img = Image.FromFile(imagePath);
                    Bitmap imgbitmap = new Bitmap(img);
                    Image resizedImage = resizeImage(imgbitmap, new Size(389, 228));
                    pictureBox1.Image = new Bitmap(resizedImage);
                }
            }
        }

        private void Window_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Background";
                dlg.Filter = "Images|*.png;*.jpeg;*.bmp;*.gif";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var imagePath = dlg.FileName;
                    Image img = Image.FromFile(imagePath);
                    Bitmap imgbitmap = new Bitmap(img);
                    Image resizedImage = resizeImage(imgbitmap, new Size(389, 228));
                    pictureBox1.Image = new Bitmap(resizedImage);
                }
            }
        }
    }
}
#pragma warning restore IDE1006