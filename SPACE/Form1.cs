using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Speech.Recognition; // adicionar namespace


namespace SPACE
{
    public partial class Form1 : Form
    {
        private SpeechRecognitionEngine engine; // engine de Reconhecimento
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadSpeech()
        {
            try
            {

                engine = new SpeechRecognitionEngine(); // instância
                engine.SetInputToDefaultAudioDevice(); // microfone

                string[] words = { "Oi", "Boa noite", "Tudo bem?" };

                // carregar a gramática
                engine.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(words))));

                engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(rec);

                engine.RecognizeAsync(RecognizeMode.Multiple); // inciar o reconhecimento
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu no LoadSpeech(): " + ex.Message);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSpeech();
        }

       // método que é chamado quando algo é reconhecido
       private void rec(object s, SpeechRecognizedEventArgs e)
        {
            MessageBox.Show(e.Result.Text);
        }
    }
}
