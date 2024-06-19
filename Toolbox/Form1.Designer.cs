namespace Toolbox
{
    partial class Window
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            volumeUp = new Button();
            volumeDown = new Button();
            volumeMute = new Button();
            printScreen = new Button();
            deafenButton = new Button();
            taskManager = new Button();
            muteButton = new Button();
            settingsButton = new Button();
            calculatorButton = new Button();
            openFileDialog1 = new OpenFileDialog();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // volumeUp
            // 
            volumeUp.Image = (Image)resources.GetObject("volumeUp.Image");
            volumeUp.Location = new Point(12, 12);
            volumeUp.Name = "volumeUp";
            volumeUp.Size = new Size(64, 64);
            volumeUp.TabIndex = 0;
            volumeUp.UseVisualStyleBackColor = true;
            volumeUp.Click += volumeUp_Click;
            // 
            // volumeDown
            // 
            volumeDown.Image = (Image)resources.GetObject("volumeDown.Image");
            volumeDown.Location = new Point(82, 12);
            volumeDown.Name = "volumeDown";
            volumeDown.Size = new Size(64, 64);
            volumeDown.TabIndex = 1;
            volumeDown.UseVisualStyleBackColor = true;
            volumeDown.Click += volumeDown_Click;
            // 
            // volumeMute
            // 
            volumeMute.Image = (Image)resources.GetObject("volumeMute.Image");
            volumeMute.Location = new Point(152, 12);
            volumeMute.Name = "volumeMute";
            volumeMute.Size = new Size(64, 64);
            volumeMute.TabIndex = 2;
            volumeMute.UseVisualStyleBackColor = true;
            volumeMute.Click += volumeMute_Click;
            // 
            // printScreen
            // 
            printScreen.Image = (Image)resources.GetObject("printScreen.Image");
            printScreen.Location = new Point(13, 82);
            printScreen.Name = "printScreen";
            printScreen.Size = new Size(64, 64);
            printScreen.TabIndex = 3;
            printScreen.UseVisualStyleBackColor = true;
            printScreen.Click += printScreen_Click;
            // 
            // deafenButton
            // 
            deafenButton.Image = (Image)resources.GetObject("deafenButton.Image");
            deafenButton.Location = new Point(292, 12);
            deafenButton.Name = "deafenButton";
            deafenButton.Size = new Size(64, 64);
            deafenButton.TabIndex = 4;
            deafenButton.UseVisualStyleBackColor = true;
            deafenButton.Click += deafenButton_Click;
            // 
            // taskManager
            // 
            taskManager.Image = (Image)resources.GetObject("taskManager.Image");
            taskManager.Location = new Point(82, 82);
            taskManager.Name = "taskManager";
            taskManager.Size = new Size(64, 64);
            taskManager.TabIndex = 5;
            taskManager.UseVisualStyleBackColor = true;
            taskManager.Click += taskManager_Click;
            // 
            // muteButton
            // 
            muteButton.Image = (Image)resources.GetObject("muteButton.Image");
            muteButton.Location = new Point(222, 12);
            muteButton.Name = "muteButton";
            muteButton.Size = new Size(64, 64);
            muteButton.TabIndex = 6;
            muteButton.UseVisualStyleBackColor = true;
            muteButton.Click += muteButton_Click;
            // 
            // settingsButton
            // 
            settingsButton.Image = (Image)resources.GetObject("settingsButton.Image");
            settingsButton.Location = new Point(223, 82);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(63, 64);
            settingsButton.TabIndex = 7;
            settingsButton.UseVisualStyleBackColor = true;
            settingsButton.Click += settingsButton_Click;
            // 
            // calculatorButton
            // 
            calculatorButton.Image = (Image)resources.GetObject("calculatorButton.Image");
            calculatorButton.Location = new Point(152, 82);
            calculatorButton.Name = "calculatorButton";
            calculatorButton.Size = new Size(64, 64);
            calculatorButton.TabIndex = 8;
            calculatorButton.UseVisualStyleBackColor = true;
            calculatorButton.Click += button9_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "png files (*.png)|*.png";
            openFileDialog1.SupportMultiDottedExtensions = true;
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.SlateGray;
            pictureBox1.Location = new Point(1, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(389, 228);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.DoubleClick += pictureBox;
            // 
            // Window
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            BackColor = Color.SlateGray;
            ClientSize = new Size(367, 225);
            Controls.Add(calculatorButton);
            Controls.Add(settingsButton);
            Controls.Add(muteButton);
            Controls.Add(taskManager);
            Controls.Add(deafenButton);
            Controls.Add(printScreen);
            Controls.Add(volumeMute);
            Controls.Add(volumeDown);
            Controls.Add(volumeUp);
            Controls.Add(pictureBox1);
            ForeColor = SystemColors.ControlText;
            Name = "Window";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.Manual;
            Text = "ToolBox";
            TopMost = true;
            Load += Window_Load;
            DoubleClick += Window_DoubleClick;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button volumeUp;
        private Button volumeDown;
        private Button volumeMute;
        private Button printScreen;
        private Button deafenButton;
        private Button taskManager;
        private Button button7;
        private Button button8;
        private Button calculatorButton;
        private Button settingsButton;
        private OpenFileDialog openFileDialog1;
        private Button button1;
        private PictureBox pictureBox1;
        private Button muteButton;
    }
}