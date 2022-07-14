namespace RST_CRR {
    public partial class Form1 : Form {

        string trackCode;
        string trackDetail;

        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {

            trackCode = textBox1.Text;

            try {
                var result = new Correios.NET.CorreiosService().GetPackageTracking(trackCode);

                foreach (var track in result.TrackingHistory)
                    trackDetail += ($"{track.Date:dd/MM/yyyy} - ({track.Source} -> {track.Destination}) - {track.Status}  {(char)13}");

                textBox2.Text = trackDetail;

            } catch (Exception) {
                MessageBox.Show("O código informado não existe ou está incorreto.\nFavor tente novamente.", "Código Incorreto");

            }

        }
    }
}