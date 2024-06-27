namespace MemoryWin
{
    public partial class Form1 : Form
    {
        int mov, clicks, found, tagIndex;
        Image[] farm = new Image[15];
        public Form1()
        {
            InitializeComponent();
            Start();
        }
        private void Start()
        {
            foreach (PictureBox img in Controls.OfType<PictureBox>())
            {
                tagIndex = int.Parse(string.Format("{0}", img.Tag));
                farm[tagIndex] = img.Image;
                img.Image = Properties.Resources.corn1;
                //img.Refresh();
                img.Enabled = true;
            }
        }


    }
}