using System.Diagnostics;
using System.Runtime.InteropServices;
using WindowsInput.Native;
using WindowsInput;

#pragma warning disable IDE1006
namespace Toolbox
{

    public partial class Window : Form
    {
        public enum DWMWINDOWATTRIBUTE
        {
            DWMWA_WINDOW_CORNER_PREFERENCE = 33
        }

        public enum DWM_WINDOW_CORNER_PREFERENCE
        {
            DWMWCP_DEFAULT = 0,
            DWMWCP_DONOTROUND = 1,
            DWMWCP_ROUND = 2,
            DWMWCP_ROUNDSMALL = 3
        }

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void DwmSetWindowAttribute(IntPtr hwnd,
                                                         DWMWINDOWATTRIBUTE attribute,
                                                         ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute,
                                                         uint cbAttribute);

        InputSimulator sim = new InputSimulator();


        private const int VOLUME_MUTE = 0x80000;
        private const int VOLUME_UP = 0xA0000;
        private const int VOLUME_DOWN = 0x90000;
        private const int WM = 0x319;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Window_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                int v = SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

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
            foreach (Control control in this.Controls)
            {
                control.MouseEnter += new EventHandler(Window_MouseEnter);
                control.MouseLeave += new EventHandler(Window_MouseLeave);
                control.MouseEnter += new EventHandler(pictureBox1_MouseEnter);
                control.MouseLeave += new EventHandler(pictureBox1_MouseLeave);
            }
            var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
            var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
            DwmSetWindowAttribute(this.Handle, attribute, ref preference, sizeof(uint));

            this.volumeUp.MouseDown += new MouseEventHandler(volumeUp_MouseDown);
            this.volumeUp.MouseUp += new MouseEventHandler(volumeUp_MouseUp);
            this.timer1.Tick += new EventHandler(timer1_Tick);
            this.volumeDown.MouseDown += new MouseEventHandler(volumeDown_MouseDown);
            this.volumeDown.MouseUp += new MouseEventHandler(volumeDown_MouseUp);
            this.timer1.Tick += new EventHandler(timer2_Tick);
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

            clickedVolumeMute++;
            switch (clickedVolumeMute)
            {
                case 1:
                    this.volumeMute.BackColor = Color.Crimson; break;
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
            sim.Keyboard.ModifiedKeyStroke(
              new[] { VirtualKeyCode.LWIN, VirtualKeyCode.SHIFT },
              new[] { VirtualKeyCode.VK_S });
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
                    this.muteButton.BackColor = Color.Crimson; //this.deafenButton.BackColor = Window.DefaultBackColor;
                    break;
                case 2:
                    this.muteButton.BackColor = Window.DefaultBackColor; //this.deafenButton.BackColor = Window.DefaultBackColor;
                    clickedMuteButton = 0; break;
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
                    this.deafenButton.BackColor = Color.Crimson;
                    //this.muteButton.BackColor = Color.Crimson;
                    break;
                case 2:
                    this.deafenButton.BackColor = Window.DefaultBackColor;
                    //this.muteButton.BackColor = Window.DefaultBackColor;
                    clickedDeafenButton = 0;
                    break;
            }
        }

        int pictureBoxColor = 0;
        private void pictureBox_Click(object sender, EventArgs e)
        {
            //      pictureBoxColor++;
            //     switch (pictureBoxColor)
            //    {
            //        case 1:
            //           this.pictureBox1.BackColor = Color.Crimson;
            //            break;
            //        case 2:
            //            this.pictureBox1.BackColor = Color.DarkOrange;
            //            break;
            //        case 3:
            //            this.pictureBox1.BackColor = Color.Yellow;
            //            break;
            //        case 4:
            //            this.pictureBox1.BackColor = Color.DarkOliveGreen;
            //            break;
            //        case 5:
            //            this.pictureBox1.BackColor = Color.AliceBlue;
            //            break;
            //        case 6:
            //            this.pictureBox1.BackColor = Color.DarkViolet;
            //            break;
            //        case 7:
            //            this.pictureBox1.BackColor = Color.HotPink;
            //            break;
            //        case 8:
            //            this.pictureBox1.BackColor = Color.AntiqueWhite;
            //            break;
            //        case 9:
            //            this.pictureBox1.BackColor = Color.SlateGray;
            //            pictureBoxColor = 0;
            //            break;
            //    }
        }

        private void pictureBox(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                Window window = new Window();

                dlg.Title = "Open Image";
                dlg.Filter = "Images|*.png;*.jpeg;*.jpg;*.jfif;*.bmp;*.gif";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var imagePath = dlg.FileName;
                    Image img = Image.FromFile(imagePath);
                    Bitmap imgbitmap = new Bitmap(img);
                    Image resizedImage = resizeImage(imgbitmap, new Size(389, 228));
                    pictureBox1.Image = new Bitmap(resizedImage);
                    this.BackgroundImage = resizedImage;
                }
            }
        }

        private void Window_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                Window window = new Window();

                dlg.Title = "Open Image";
                dlg.Filter = "Images|*.png;*.jpeg;*.jpg;*.jfif;*.bmp;*.gif";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var imagePath = dlg.FileName;
                    Image img = Image.FromFile(imagePath);
                    Bitmap imgbitmap = new Bitmap(img);
                    Image resizedImage = resizeImage(imgbitmap, new Size(389, 228));
                    pictureBox1.Image = new Bitmap(resizedImage);
                    this.BackgroundImage = resizedImage;
                }
            }
        }

        private void notepadButton_Click(object sender, EventArgs e)
        {
            Process.Start(sys32 + "notepad.exe");
        }

        private void Window_MouseLeave(object sender, EventArgs e)
        {
            if (!this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition)))
            {
                this.Opacity = 0.40;
            }
        }

        private void Window_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1;

            this.Cursor = Cursors.SizeAll;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (!this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition)))
            {
                pictureBox1.Visible = false;
            }
        }

        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // if (e.Button == MouseButtons.Left)
            // {
            //     ReleaseCapture();
            //     SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            // }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;

            pictureBox1.Cursor = Cursors.Default;
        }

        private void volumeUp_MouseDown(object sender, MouseEventArgs e)
        {
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendMessageW(this.Handle, WM, this.Handle, (IntPtr)VOLUME_UP);
        }

        private void volumeUp_MouseUp(object sender, MouseEventArgs e)
        {
            this.timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            SendMessageW(this.Handle, WM, this.Handle, (IntPtr)VOLUME_DOWN);
        }

        private void volumeDown_MouseDown(object sender, MouseEventArgs e)
        {
            this.timer2.Start();
        }

        private void volumeDown_MouseUp(object sender, MouseEventArgs e)
        {
            this.timer2.Stop();
        }
    }
}
#pragma warning restore IDE1006