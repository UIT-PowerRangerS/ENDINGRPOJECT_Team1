using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpeechLib;
namespace DoAnCuoiKy
{
	public partial class fAdd : Form
	{
		public fAdd()
		{
			InitializeComponent();
		}
		private Dictionary<string, string> newDict =new Dictionary<string, string>();
		private List<string> keyList = new List<string>();
		private List<string> ValueList = new List<string>();

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				if(textBox1.Text!="" && textBox2.Text != "")
				{
					newDict.Add(textBox1.Text,textBox2.Text);
				}
				List<string> keyList = new List<string>(newDict.Keys);
				listBox1.Items.Clear();
				foreach (var kvp in newDict)
					listBox1.Items.Add(kvp.Key);

			}
			catch
			{
				MessageBox.Show("Errors");
			}
		}

		private void richTextBox1_DoubleClick(object sender, EventArgs e)
		{
			
		}

		private void listBox1_DoubleClick(object sender, EventArgs e)
		{
			richTextBox1.Clear();
			string temp = listBox1.SelectedItem.ToString();
			foreach(var kvp in newDict)
			{
				if (kvp.Key == temp)
				{
					richTextBox1.AppendText(kvp.Key);
					richTextBox1.AppendText("\n");
					richTextBox1.AppendText(kvp.Value);
				}
			}
		}
		public SpVoice Voice = new SpVoice();
		private void button2_Click(object sender, EventArgs e)
		{
			string temp = listBox1.SelectedItem.ToString();
			try
			{
				SpVoice Voice = new SpVoice();
				Voice.Voice = Voice.GetVoices().Item(Properties.Settings.Default.VoiceType);
				Voice.Volume = Properties.Settings.Default.Volume;
				Voice.Speak(temp, SpeechLib.SpeechVoiceSpeakFlags.SVSFDefault);
			}
			catch
			{
				MessageBox.Show("Speak error", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
