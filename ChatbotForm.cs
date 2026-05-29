//Initialize CyberGuard AI Windows Forms application//  
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CybersecurityChatbot
{
    public partial class ChatbotForm : Form
    {
        private readonly CybersecurityBot bot = new CybersecurityBot();

        private RichTextBox rtbChat;
        private TextBox txtInput;
        private Button btnSend;
        private Label lblTitle;

        public ChatbotForm()
        {
            InitializeGUI();

            StartBot();
        }

        private void InitializeGUI()
        {
            // FORM
            this.Text = "CyberGuard AI";
            this.Size = new Size(900, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(15, 15, 30);

            // TITLE
            lblTitle = new Label();
            lblTitle.Text = "CYBERGUARD AI";
            lblTitle.ForeColor = Color.Cyan;
            lblTitle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(280, 20);

            // CHAT BOX
            rtbChat = new RichTextBox();
            rtbChat.Location = new Point(30, 80);
            rtbChat.Size = new Size(820, 430);
            rtbChat.BackColor = Color.Black;
            rtbChat.ForeColor = Color.White;
            rtbChat.Font = new Font("Consolas", 11);
            rtbChat.ReadOnly = true;

            // INPUT
            txtInput = new TextBox();
            txtInput.Location = new Point(30, 540);
            txtInput.Size = new Size(650, 30);
            txtInput.Font = new Font("Segoe UI", 12);

            txtInput.KeyDown += TxtInput_KeyDown;

            // BUTTON
            btnSend = new Button();
            btnSend.Text = "SEND";
            btnSend.Location = new Point(700, 535);
            btnSend.Size = new Size(150, 40);
            btnSend.BackColor = Color.Cyan;
            btnSend.ForeColor = Color.Black;
            btnSend.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            btnSend.Click += BtnSend_Click;

            // ADD CONTROLS
            this.Controls.Add(lblTitle);
            this.Controls.Add(rtbChat);
            this.Controls.Add(txtInput);
            this.Controls.Add(btnSend);
        }

        private void StartBot()
        {
           rtbChat.SelectionColor = Color.Cyan;

            rtbChat.AppendText(@"

 ██████╗██╗   ██╗██████╗ ███████╗██████╗  ██████╗ ██╗   ██╗ █████╗ ██████╗ ██████╗
██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗██╔════╝ ██║   ██║██╔══██╗██╔══██╗██╔══██╗
██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝██║  ███╗██║   ██║███████║██████╔╝██║  ██║
██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗██║   ██║██║   ██║██╔══██║██╔══██╗██║  ██║
╚██████╗   ██║   ██████╔╝███████╗██║  ██║╚██████╔╝╚██████╔╝██║  ██║██║  ██║██████╔╝
 ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝

");

            rtbChat.SelectionColor = Color.LightGreen;

            rtbChat.AppendText("                CYBERSECURITY AWARENESS CHATBOT\n\n");

            rtbChat.SelectionColor = Color.White;

            rtbChat.AppendText("🤖 BOT: Welcome to CyberGuard AI!\n");

            rtbChat.AppendText("🤖 BOT: Tell me your name to begin.\n\n");

            BotUI.Speak("Welcome to Cyber Guard AI");
        }
        

        private void BtnSend_Click(object sender, EventArgs e)
        {
            ProcessMessage();
        }

        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProcessMessage();
            }
        }

        private void ProcessMessage()
        {
            string input = txtInput.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            AppendUserMessage(input);

            string response = bot.GetResponse(input);

            AppendBotMessage(response);

            BotUI.Speak(response);

            txtInput.Clear();
        }

        private void AppendUserMessage(string text)
        {
            rtbChat.SelectionColor = Color.LightBlue;

            rtbChat.AppendText("\n👤 YOU: " + text + "\n");
        }

        private void AppendBotMessage(string text)
        {
            rtbChat.SelectionColor = Color.Cyan;

            rtbChat.AppendText("\n🤖 BOT: " + text + "\n");
        }
    }
}
